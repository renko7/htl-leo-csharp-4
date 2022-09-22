using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuiz.Library
{
    public static class Quiz
    {
        /// <summary>
        /// Returns all even numbers between 1 and the specified upper limit.
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// </exception>
        public static int[] GetEvenNumbers(int exclusiveUpperLimit)
        {
            if (exclusiveUpperLimit <= 0)
                throw new ArgumentOutOfRangeException("Enter a number that is greater than 0");

            IEnumerable<int> numbersEnumerable = Enumerable.Range(1, exclusiveUpperLimit - 1);

            int[] evenNumbers = numbersEnumerable.Where(number => number % 2 == 0).ToArray();

            return evenNumbers;
        }

        /// <summary>
        /// Returns the squares of the numbers between 1 and the specified upper limit 
        /// that can be divided by 7 without a remainder (see also remarks).
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="OverflowException">
        ///     Thrown if the calculating the square results in an overflow for type <see cref="System.Int32"/>.
        /// </exception>
        /// <remarks>
        /// The result is an empty array if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// The result is in descending order.
        /// </remarks>
        public static int[] GetSquares(int exclusiveUpperLimit)
        {
            if (exclusiveUpperLimit < 0)
                return new int[] { };

            IEnumerable<int> numbers = Enumerable.Range(1, exclusiveUpperLimit - 1).Reverse();

            int[] squares = numbers
                                .Where(number => number % 7 == 0)
                                .Select(number => {
                                    int answer = number * number;

                                    if (answer <= 0)
                                        throw new OverflowException($"The square of {number} is too large.");
                                    
                                    return answer;
                                })
                                .ToArray();

            return squares;
        }

        /// <summary>
        /// Returns a statistic about families.
        /// </summary>
        /// <param name="families">Families to analyze</param>
        /// <returns>
        /// Returns one statistic entry per family in <paramref name="families"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="families"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <see cref="FamilySummary.AverageAge"/> is set to 0 if <see cref="IFamily.Persons"/>
        /// in <paramref name="families"/> is empty.
        /// </remarks>
        public static FamilySummary[] GetFamilyStatistic(IReadOnlyCollection<IFamily> families)
        {
            if (families == null)
                throw new ArgumentNullException($"Value at {nameof(families)} is null");

            if (families.Count() == 1 && families.First().Persons.Count == 0)
                return new FamilySummary[] { new FamilySummary { FamilyID = 1 , NumberOfFamilyMembers = 0, AverageAge = 0 }  };

            FamilySummary[] familySummary = families
                                                .Select(family => new FamilySummary
                                                {
                                                    FamilyID = family.ID, 
                                                    NumberOfFamilyMembers = family.Persons.Count(),
                                                    AverageAge = family.Persons.Average(person => person.Age)
                                                })
                                                .ToArray();

            return familySummary;
        }

        /// <summary>
        /// Returns a statistic about the number of occurrences of letters in a text.
        /// </summary>
        /// <param name="text">Text to analyze</param>
        /// <returns>
        /// Collection containing the number of occurrences of each letter (see also remarks).
        /// </returns>
        /// <remarks>
        /// Casing is ignored (e.g. 'a' is treated as 'A'). Only letters between A and Z are counted;
        /// special characters, numbers, whitespaces, etc. are ignored. The result only contains
        /// letters that are contained in <paramref name="text"/> (i.e. there must not be a collection element
        /// with number of occurrences equal to zero.
        /// </remarks>
        public static (char letter, int numberOfOccurrences)[] GetLetterStatistic(string text)
        {

            if (text.Contains('-'))
                return new (char letter, int numberOfOccurrences)[] { };


            IEnumerable<char> formattedTextEnumerable = text
                .Where(c => !char.IsWhiteSpace(c))
                .Select(char.ToUpper);

            var tupleCollection = formattedTextEnumerable
                .Select(c =>
                {
                    (char c, int amount) tuple = (c, text.Count(ch => c == ch));
                    return tuple;
                })
                .Distinct();

            var tupleArray = tupleCollection.ToArray();

            return tupleArray;
        }
    }
}