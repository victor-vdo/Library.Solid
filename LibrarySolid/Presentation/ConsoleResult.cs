using LibrarySolid.Interfaces;
using Newtonsoft.Json;

namespace LibrarySolid.Presentation
{
    public static class ConsoleResult
    {
        public static void Result(ILibraryResult result)
        {
            Console.WriteLine("Status: " + result.Status);
            Console.WriteLine("Message: " + result.Message);
            Console.WriteLine("Data: ");
            Console.WriteLine(JsonConvert.SerializeObject(result.Data));
        }
    }
}
