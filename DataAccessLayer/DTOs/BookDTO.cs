namespace DataAccessLayer.DTOs
{
    public class BookDTO
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime BorrowedTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
