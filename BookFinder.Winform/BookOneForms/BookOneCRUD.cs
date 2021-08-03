using Repository.Models;
using Repository.Repos;
using System;
using System.Windows.Forms;

namespace BookFinder.Winform.BookOneForms
{
    public partial class BookOneCRUD : Form
    {
        private int Id;
        private readonly IUnitOfWork unitOfWork;
        private BookOne book;

        public BookOneCRUD(IUnitOfWork _unitOfWork)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
        }
        public BookOneCRUD(IUnitOfWork _unitOfWork, int id)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
            Id = id;
            book = unitOfWork.BookOneRepository.GetOneBy(x => x.Id == id);
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AssignValues(BookOne book)
        {
            Country.Text = book.Country;
            Auther.Text = book.Auther;
            Type.Text = book.Type;
            Address.Text = book.Address;
            AddressType.Text = book.AddressType;
            City.Text = book.City;
            Publisher.Text = book.Publisher;
            NormalDate.Text = book.NormalDate;
            Month.Text = book.Month;
            HijryDate.Text = book.HijryDate;
            Pages.Text = book.Pages;
            SegelType.Text = book.SegelType;
            CrypticCol.Text = book.CrypticCol;
            ItemDescription.Text = book.ItemDescription;
            MessageType.Text = book.MessageType;
            University.Text = book.University;
            Colleage.Text = book.Colleage;
            Country2.Text = book.Country2;
            Mostakhlas.Text = book.Mostakhlas;
            Subjects.Text = book.Subjects;
            OtherAuthers.Text = book.OtherAuthers;
            MainArabicSubjects.Text = book.MainArabicSubjects;
            Mogalad.Text = book.Mogalad;
            Source.Text = book.Source;
            ISSN.Text = book.ISSN;
        }
        private void AddNew()
        {
            var book = new BookOne();
            MapModel(ref book);

            unitOfWork.BookOneRepository.Insert(book);
            unitOfWork.Complete();

            MessageBox.Show("added");
        }
        private void EditExisting(BookOne book)
        {
            MapModel(ref book);
            unitOfWork.BookOneRepository.Update(book);
            unitOfWork.Complete();
        }
        private void MapModel(ref BookOne book)
        {
            book.Country = Country.Text;
            book.Auther = Auther.Text;
            book.Type = Type.Text;
            book.Address = Address.Text;
            book.AddressType = AddressType.Text;
            book.City = City.Text;
            book.Publisher = Publisher.Text;
            book.NormalDate = NormalDate.Text;
            book.Month = Month.Text;
            book.HijryDate = HijryDate.Text;
            book.Pages = Pages.Text;
            book.SegelType = SegelType.Text;
            book.CrypticCol = CrypticCol.Text;
            book.ItemDescription = ItemDescription.Text;
            book.MessageType = MessageType.Text;
            book.University = University.Text;
            book.Colleage = Colleage.Text;
            book.Country2 = Country2.Text;
            book.Mostakhlas = Mostakhlas.Text;
            book.Subjects = Subjects.Text;
            book.OtherAuthers = OtherAuthers.Text;
            book.MainArabicSubjects = MainArabicSubjects.Text;
            book.Mogalad = Mogalad.Text;
            book.Source = Source.Text;
            book.ISSN = ISSN.Text;
        }

    }
}
