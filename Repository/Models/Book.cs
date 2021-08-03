namespace Repository.Models
{
    public class Book
    {
        public int Id { get; set; } //database

        public string BookId { get; set; } //excel
        public string BookName { get; set; }
        public string BookAuther { get; set; }
        public string BookVerifier { get; set; }
        public string BookPublisher { get; set; }
        public string BookPublishDate { get; set; }
        public string BookCountry { get; set; }
        public string BookCity { get; set; }
        public string BookPrintNumber { get; set; }
        public string BookNumberOfParts { get; set; }
        public string BookNumberOfPapers { get; set; }
        public string BookBucketType { get; set; }
        public string BookFileType { get; set; }
        public string BookMainCategory { get; set; }
        public string BookSecondaryCategory { get; set; }
        public string BookContents { get; set; }
        public string BookNotes { get; set; }
        public string BookCover { get; set; }
        public string BookReadUrl { get; set; }
        public string BookDownloadUrl { get; set; }

    }
}
