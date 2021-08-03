using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookFinder.Winform.BaseForms
{
    public partial class BaseCRUD : Form
    {
        public BaseCRUD()
        {
            InitializeComponent();
            NewRecord();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        public virtual void CloseForm()
        {
            Close();
        }
        public virtual void InsertRecord()
        {

        }
        public virtual void NewRecord()
        {

        }

    }
}
