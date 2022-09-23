using ChuckNorrisDB.DbContexts;
using ChuckNorrisDB.Factories;

Console.WriteLine("Enter the amount of jokes you want to add: ");
int userJokeAmount = Convert.ToInt32(Console.ReadLine());

while (userJokeAmount > 10)
{
    Console.WriteLine("Don't enter a number that is above 10");
    userJokeAmount = Convert.ToInt32(Console.ReadLine());
}

ChuckNorrisDbContextFactory factory = new ChuckNorrisDbContextFactory();

ChuckNorrisDbContext context = factory.CreateDbContext();

