using ChuckNorrisClassLibrary;
using ChuckNorrisDB;
using ChuckNorrisDB.DbContexts;
using ChuckNorrisDB.Factories;


var _fetchDataClient = new FetchDataClient();

int jokeAmount = 0;
while (jokeAmount > 10 || jokeAmount < -1 || jokeAmount == 0)
{
    Console.WriteLine("Enter the amount of jokes you want to add: ");
    string userInput = Console.ReadLine();

    bool convertToNumberAttempt = int.TryParse(userInput, out jokeAmount);

    if (convertToNumberAttempt == false)
    {
        if (userInput == "clear")
        {
            jokeAmount = -1;
        }
        else if (userInput == "")
        {
            jokeAmount = 5;
        }
    }

    if (jokeAmount > 10)
        Console.WriteLine("Don't enter a number that is above 10.");

}

ChuckNorrisDbContextFactory factory = new ChuckNorrisDbContextFactory();

ChuckNorrisDbContext context = factory.CreateDbContext();




ChuckNorrisFact[] facts = new ChuckNorrisFact[10];

for(int i = 0; i < jokeAmount; i++)
{
    ChuckNorrisFact fact = await _fetchDataClient.GetDataFromEndPoint<ChuckNorrisFact>("https://api.chucknorris.io/jokes/random");
    //bool factExists = context.ChuckNorrisFacts
    //    .Any(f => f.ChuckNorrisId == fact.ChuckNorrisId);



   
}

