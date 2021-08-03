using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace A.Supermarket.BaseForms
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();

            sfDataGrid1.SearchController.AllowFiltering = true;
            this.sfDataGrid1.SearchController.SearchColor = Color.LightGreen;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        public virtual void GetData()
        {
            MessageBox.Show("base new");
        }

        public virtual void New()
        {
            MessageBox.Show("تمت الاضافة بنجاح");
        }

        public virtual void Edit()
        {
            MessageBox.Show("تم التعديل بنجاح");
        }

        public virtual void Delete()
        {
            MessageBox.Show("تم الحذف بنجاح");
            btnDelete.Enabled = false;
            GetData();
        }

        public virtual void ClientSideSearch()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            { sfDataGrid1.SearchController.ClearSearch(); }
            else
            { sfDataGrid1.SearchController.Search(txtSearch.Text.Trim()); }
        }

        public virtual void ServerSideSearch()
        {

        }

        public virtual void CreateIdColumn()
        {
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", Visible = false });
        }

        public virtual int GetId()
        {
            if (sfDataGrid1.View.Records.Count > 0 && sfDataGrid1.SelectedItems.Count > 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                int index = sfDataGrid1.SelectedIndex + 1;
                var rowData = sfDataGrid1.GetRecordAtRowIndex(index);
                var propertyCollection = sfDataGrid1.View.GetPropertyAccessProvider();
                var id = propertyCollection.GetValue(rowData, "Id");

                return int.Parse(id.ToString());
            }
            return 0;
        }



        private void frmMainBase_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            switch (key)
            {
                case Keys.F1:
                    New();
                    break;
                case Keys.F2:
                    Edit();
                    break;
                case Keys.Delete:
                    Delete();
                    break;
                case Keys.Enter:
                    txtSearch.Focus();
                    break;
                default:
                    //some code here
                    break;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ServerSideSearch();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClientSideSearch();
        }

        private void sfDataGrid1_DrawCell(object sender, Syncfusion.WinForms.DataGrid.Events.DrawCellEventArgs e)
        {
            if (sfDataGrid1.ShowRowHeader && e.RowIndex != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    e.DisplayText = e.RowIndex.ToString();
                }

            }
        }

        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            GetId();           
        }
    }
}
