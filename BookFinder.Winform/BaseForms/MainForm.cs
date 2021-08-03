using System;
using System.Windows.Forms;
using BookFinder.Winform.BookForms;
using BookFinder.Winform.BookOneForms;
using BookFinder.Winform.BookTwoForms;
using Repository.Repos;
using Unity;

namespace BookFinder.Winform.BaseForms
{
    public partial class MainForm : Form
    {
        private readonly IUnitOfWork unitOfWork;
        public MainForm(IUnitOfWork _unitOfWork)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            panelBtn.Height = btnNew.Height;
            panelBtn.Top = btnNew.Top;
            var bookFormBase = new BookFormBase(unitOfWork);
            groupBox1.Controls.Clear();
            bookFormBase.TopLevel = false;
            groupBox1.Controls.Add(bookFormBase);
            bookFormBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bookFormBase.Dock = DockStyle.Fill;
            bookFormBase.Show();
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            panelBtn.Height = sfButton1.Height;
            panelBtn.Top = sfButton1.Top;
            var bookFormBase = new BookOneFormBase(unitOfWork);
            groupBox1.Controls.Clear();
            bookFormBase.TopLevel = false;
            groupBox1.Controls.Add(bookFormBase);
            bookFormBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bookFormBase.Dock = DockStyle.Fill;
            bookFormBase.Show();
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            panelBtn.Height = sfButton2.Height;
            panelBtn.Top = sfButton2.Top;
            var bookFormBase = new BookTwoFormBase(unitOfWork);
            groupBox1.Controls.Clear();
            bookFormBase.TopLevel = false;
            groupBox1.Controls.Add(bookFormBase);
            bookFormBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bookFormBase.Dock = DockStyle.Fill;
            bookFormBase.Show();
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            panelBtn.Height = sfButton2.Height;
            panelBtn.Top = sfButton2.Top;
            var bookFormBase = new ManuscriptForms.ManuscriptFormBase(unitOfWork);
            groupBox1.Controls.Clear();
            bookFormBase.TopLevel = false;
            groupBox1.Controls.Add(bookFormBase);
            bookFormBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bookFormBase.Dock = DockStyle.Fill;
            bookFormBase.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }
    }
}
