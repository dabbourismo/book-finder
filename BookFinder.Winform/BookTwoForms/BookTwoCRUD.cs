using Repository.Models;
using Repository.Repos;
using System;
using System.Windows.Forms;

namespace BookFinder.Winform.BookTwoForms
{
    public partial class BookTwoCRUD : Form
    {
        private int Id;
        private readonly IUnitOfWork unitOfWork;
        private BookTwo book;

        public BookTwoCRUD(IUnitOfWork _unitOfWork)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
        }
        public BookTwoCRUD(IUnitOfWork _unitOfWork, int id)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
            Id = id;
            book = unitOfWork.BookTwoRepository.GetOneBy(x => x.Id == id);
            AssignValues(book);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNew()
        {
            var book = new BookTwo();
            MapModel(ref book);

            unitOfWork.BookTwoRepository.Insert(book);
            unitOfWork.Complete();

            MessageBox.Show("added");
        }
        private void EditExisting(BookTwo book)
        {
            MapModel(ref book);
            unitOfWork.BookTwoRepository.Update(book);
            unitOfWork.Complete();
        }
        private void AssignValues(BookTwo book)
        {
            RegisterationNumber.Text = book.RegisterationNumber;
            Address.Text = book.Address;
            Auther.Text = book.Auther;
            AuthersTag.Text = book.AuthersTag;
            Subjects.Text = book.Subjects;
            Print.Text = book.Print;
            PublishDate.Text = book.PublishDate;
            Description.Text = book.Description;
            Chain.Text = book.Chain;
            Insight.Text = book.Insight;
            AssosiatedAuthers.Text = book.AssosiatedAuthers;
            AdditionalAddress.Text = book.AdditionalAddress;
            CallNumber.Text = book.CallNumber;
            InsertNumber.Text = book.InsertNumber;
            RDMCNumber.Text = book.RDMCNumber;
            RDMDNumber.Text = book.RDMDNumber;
            BucketType.Text = book.BucketType;
            DawryaNumber.Text = book.DawryaNumber;
            RepeatedPublish.Text = book.RepeatedPublish;
            Language.Text = book.Language;
        }

        private void MapModel(ref BookTwo book)
        {

            book.RegisterationNumber = RegisterationNumber.Text;
            book.Address = Address.Text;
            book.Auther = Auther.Text;
            book.AuthersTag = AuthersTag.Text;
            book.Subjects = Subjects.Text;
            book.Print = Print.Text;
            book.PublishDate = PublishDate.Text;
            book.Description = Description.Text;
            book.Chain = Chain.Text;
            book.Insight = Insight.Text;
            book.AssosiatedAuthers = AssosiatedAuthers.Text;
            book.AdditionalAddress = AdditionalAddress.Text;
            book.CallNumber = CallNumber.Text;
            book.InsertNumber = InsertNumber.Text;
            book.RDMCNumber = RDMCNumber.Text;
            book.RDMDNumber = RDMDNumber.Text;
            book.BucketType = BucketType.Text;
            book.DawryaNumber = DawryaNumber.Text;
            book.RepeatedPublish = RepeatedPublish.Text;
            book.Language = Language.Text;
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
    }
}
