using Repository.Models;
using Repository.Repos;
using System;
using System.Windows.Forms;

namespace BookFinder.Winform.BookForms
{
    public partial class BookCRUD : Form
    {
        private int Id;
        private readonly IUnitOfWork unitOfWork;
        private Book book;

        public BookCRUD(IUnitOfWork _unitOfWork)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
        }
        public BookCRUD(IUnitOfWork _unitOfWork, int id)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
            Id = id;
            book = unitOfWork.BookRepository.GetOneBy(x => x.Id == id);
            AssignValues(book);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            switch (Id)
            {
                case 0:
                    AddNew();
                    break;
                default:                  
                    EditExisting(book);
                    break;

            }

        }
        

        private void AddNew()
        {
            var book = new Book();
            MapModel(ref book);

            unitOfWork.BookRepository.Insert(book);
            unitOfWork.Complete();

            MessageBox.Show("added");
        }

        private void EditExisting(Book book)
        {
            MapModel(ref book);
            unitOfWork.BookRepository.Update(book);
            unitOfWork.Complete();
        }

        private void MapModel(ref Book book)
        {

            book.BookAuther = txtBookAuther.Text;
            book.BookBucketType = txtBookBucketType.Text;
            book.BookCity = txtBookCity.Text;
            book.BookContents = txtBookContents.Text;
            book.BookCountry = txtBookCountry.Text;
            book.BookCover = "";
            book.BookDownloadUrl = txtBookDownloadUrl.Text;
            book.BookFileType = txtBookFileType.Text;
            book.BookId = txtBookId.Text;
            book.BookMainCategory = txtBookMainCategory.Text;
            book.BookName = txtBookName.Text;
            book.BookNotes = txtBookNotes.Text;
            book.BookNumberOfPapers = txtBookNumberOfPapers.Text;
            book.BookNumberOfParts = txtBookNumberOfParts.Text;
            book.BookPrintNumber = txtBookPrintNumber.Text;
            book.BookPublishDate = txtBookPublishDate.Text;
            book.BookPublisher = txtBookPublisher.Text;
            book.BookReadUrl = txtBookReadUrl.Text;
            book.BookSecondaryCategory = txtBookSecondaryCategory.Text;
            book.BookVerifier = txtBookVerifier.Text;
        }

        private void AssignValues(Book book)
        {
            txtBookAuther.Text = book.BookAuther;
            txtBookBucketType.Text = book.BookBucketType;
            txtBookCity.Text = book.BookCity;
            txtBookContents.Text = book.BookContents;
            txtBookCountry.Text = book.BookCountry;
            txtBookDownloadUrl.Text = book.BookDownloadUrl;
            txtBookFileType.Text = book.BookFileType;
            txtBookId.Text = book.BookId;
            txtBookMainCategory.Text = book.BookMainCategory;
            txtBookName.Text = book.BookName;
            txtBookNotes.Text = book.BookNotes;
            txtBookNumberOfPapers.Text = book.BookNumberOfPapers;
            txtBookNumberOfParts.Text = book.BookNumberOfParts;
            txtBookPrintNumber.Text = book.BookPrintNumber;
            txtBookPublishDate.Text = book.BookPublishDate;
            txtBookPublisher.Text = book.BookPublisher;
            txtBookReadUrl.Text = book.BookReadUrl;
            txtBookSecondaryCategory.Text = book.BookSecondaryCategory;
            txtBookVerifier.Text = book.BookVerifier;
        }
    }
}
