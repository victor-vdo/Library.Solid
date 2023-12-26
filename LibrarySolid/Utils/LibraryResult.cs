using LibrarySolid.Interfaces;

namespace LibrarySolid.Utils
{
    public class LibraryResult : ILibraryResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public LibraryResult(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
