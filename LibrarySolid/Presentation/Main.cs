namespace LibrarySolid.Presentation
{
    public class Main
    {
        public int MainMenu()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Select an option below:");
            Console.WriteLine("1 - Register a book");
            Console.WriteLine("2 - Consult a book");
            Console.WriteLine("3 - Consult all books");
            Console.WriteLine("4 - Removing a book");
            Console.WriteLine("5 - Register a user");
            Console.WriteLine("6 - Register a loan");
            Console.WriteLine("7 - Return a book");
            Console.WriteLine("8 - Leave");
            var option = Console.ReadLine();
            Int32.TryParse(option, out int value);
            return value;
        }
    }
}
