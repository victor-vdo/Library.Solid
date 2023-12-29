namespace LibrarySolid.Interfaces
{
    public interface ILibraryResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
