using Repository.Models;
using Repository.Repos;
using System;
using System.Windows.Forms;

namespace BookFinder.Winform.ManuscriptForms
{
    public partial class ManuscriptCRUD : Form
    {
        private int Id;
        private readonly IUnitOfWork unitOfWork;
        private Manuscript manuscript;

        public ManuscriptCRUD(IUnitOfWork _unitOfWork)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
        }
        public ManuscriptCRUD(IUnitOfWork _unitOfWork, int id)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
            Id = id;
            manuscript = unitOfWork.ManuscriptRepository.GetOneBy(x => x.Id == id);
            AssignValues(manuscript);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            switch (Id)
            {
                case 0:
                    AddNew();
                    break;
                default:
                    EditExisting(manuscript);
                    break;

            }

        }

        private void AssignValues(Manuscript manuscript)
        {
            txtManuName.Text = manuscript.ManuName;
            txtManuAuther.Text = manuscript.ManuAuther;
            txtManuArt.Text = manuscript.ManuArt;
            txtManuLiberaryName.Text = manuscript.ManuLiberaryName;
            txtManuNumber1.Text = manuscript.ManuNumber1;
            txtManuNumber2.Text = manuscript.ManuNumber2;
            txtManuCountry.Text = manuscript.ManuCountry;
            txtManuCopier.Text = manuscript.ManuCopier;
            txtManuCopyDate.Text = manuscript.ManuCopyDate;
            txtManuNumberOfPapers.Text = manuscript.ManuNumberOfPapers;
            txtManuNotes.Text = manuscript.ManuNotes;
            txtManuLanguage.Text = manuscript.ManuLanguage;
            txtManuFirst.Text = manuscript.ManuFirst;
            txtManuLast.Text = manuscript.ManuLast;
            txtManuDescription.Text = manuscript.ManuDescription;
            txtManuDataSource.Text = manuscript.ManuDataSource;
            txtManuFont.Text = manuscript.ManuFont;
            txtManuInk.Text = manuscript.ManuInk;
            txtManuPaperArea.Text = manuscript.ManuPaperArea;
            txtManuContentArea.Text = manuscript.ManuContentArea;
            txtManuNumberOfLines.Text = manuscript.ManuNumberOfLines;
            txtManuContentCondition.Text = manuscript.ManuContentCondition;
        }
        private void AddNew()
        {
            var manuscript = new Manuscript();
            MapModel(ref manuscript);

            unitOfWork.ManuscriptRepository.Insert(manuscript);
            unitOfWork.Complete();

            MessageBox.Show("added");
        }
        private void EditExisting(Manuscript manuscript)
        {
            MapModel(ref manuscript);
            unitOfWork.ManuscriptRepository.Update(manuscript);
            unitOfWork.Complete();
        }
        private void MapModel(ref Manuscript manuscript)
        {
            manuscript.ManuName = txtManuName.Text;
            manuscript.ManuAuther = txtManuAuther.Text;
            manuscript.ManuArt = txtManuArt.Text;
            manuscript.ManuLiberaryName = txtManuLiberaryName.Text;
            manuscript.ManuNumber1 = txtManuNumber1.Text;
            manuscript.ManuNumber2 = txtManuNumber2.Text;
            manuscript.ManuCountry = txtManuCountry.Text;
            manuscript.ManuCopier = txtManuCopier.Text;
            manuscript.ManuCopyDate = txtManuCopyDate.Text;
            manuscript.ManuNumberOfPapers = txtManuNumberOfPapers.Text;
            manuscript.ManuNotes = txtManuNotes.Text;
            manuscript.ManuLanguage = txtManuLanguage.Text;
            manuscript.ManuFirst = txtManuFirst.Text;
            manuscript.ManuLast = txtManuLast.Text;
            manuscript.ManuDescription = txtManuDescription.Text;
            manuscript.ManuDataSource = txtManuDataSource.Text;
            manuscript.ManuFont = txtManuFont.Text;
            manuscript.ManuInk = txtManuInk.Text;
            manuscript.ManuPaperArea = txtManuPaperArea.Text;
            manuscript.ManuContentArea = txtManuContentArea.Text;
            manuscript.ManuNumberOfLines = txtManuNumberOfLines.Text;
            manuscript.ManuContentCondition = txtManuContentCondition.Text;
        }

    }
}
