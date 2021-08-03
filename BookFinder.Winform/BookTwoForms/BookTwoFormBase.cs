using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Common;
using Repository.Models;
using Repository.Repos;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookFinder.Winform.BookTwoForms
{
    public partial class BookTwoFormBase : Form
    {
        private const int NumberOfBookColumns = 20;
        private readonly IUnitOfWork unitOfWork;
        public BookTwoFormBase(IUnitOfWork _unitOfWork)
        {
            InitializeComponent();
            unitOfWork = _unitOfWork;
            pictureBox1.Visible = false;
            PrepareDGV();
            CreateColumns();
            GetData();
        }




        private void btnNew_Click(object sender, EventArgs e)
        {
            new BookTwoCRUD(unitOfWork).ShowDialog();
            MessageBox.Show("تمت الاضافة بنجاح");
            GetData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetId();
            new BookTwoCRUD(unitOfWork, id).ShowDialog();
            MessageBox.Show("تم التعديل بنجاح");
            GetData();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportToExcel(sfDataGrid1);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ClientSideSearch();
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            DataTable excelResultDatatable = ExcelImporter.ImportFromExcel();
            if (excelResultDatatable == null)
            {
                return;
            }
            else if (excelResultDatatable.Rows.Count == 0)
            {
                MessageBox.Show("ملف الاكسيل خالي من البيانات");
            }
            else if (excelResultDatatable.Columns.Count != NumberOfBookColumns)
            {
                MessageBox.Show("عدد اعمدة الاكسيل غير متطابقه ، تأكد من ان هذا ملف الاكسيل الصحيح");
            }
            else
            {
                ToggleControls(false);
                await Task.Run(() => InsertImportedExcel(excelResultDatatable));
                ToggleControls(true);
                GetData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {

        }


        //#########################################################################

        private async Task InsertImportedExcel(DataTable excelResultDatatable)
        {
            var dbBooks = unitOfWork.BookTwoRepository.GetAll().Distinct();
            var books = new List<BookTwo>();
            for (int i = 0; i < excelResultDatatable.Rows.Count; i++)
            {
                var book = new BookTwo()
                {
                    RegisterationNumber = excelResultDatatable.Rows[i][0].ToString(),
                    Address = excelResultDatatable.Rows[i][1].ToString(),
                    Auther = excelResultDatatable.Rows[i][2].ToString(),

                    AuthersTag = excelResultDatatable.Rows[i][3].ToString(),
                    Subjects = excelResultDatatable.Rows[i][4].ToString(),
                    Print = excelResultDatatable.Rows[i][5].ToString(),

                    PublishDate = excelResultDatatable.Rows[i][6].ToString(),
                    Description = excelResultDatatable.Rows[i][7].ToString(),
                    Chain = excelResultDatatable.Rows[i][8].ToString(),

                    Insight = excelResultDatatable.Rows[i][9].ToString(),
                    AssosiatedAuthers = excelResultDatatable.Rows[i][10].ToString(),
                    AdditionalAddress = excelResultDatatable.Rows[i][11].ToString(),

                    CallNumber = excelResultDatatable.Rows[i][12].ToString(),
                    InsertNumber = excelResultDatatable.Rows[i][13].ToString(),
                    RDMCNumber = excelResultDatatable.Rows[i][14].ToString(),

                    RDMDNumber = excelResultDatatable.Rows[i][15].ToString(),
                    BucketType = excelResultDatatable.Rows[i][16].ToString(),
                    DawryaNumber = excelResultDatatable.Rows[i][17].ToString(),

                    RepeatedPublish = excelResultDatatable.Rows[i][18].ToString(),
                    Language = excelResultDatatable.Rows[i][19].ToString()
                    
                };

                var dublicatebookinList = books
                    .Where(x => x.InsertNumber.Trim() == book.InsertNumber.Trim()).FirstOrDefault();

                var dublicatebookInDatabase = dbBooks
                    .Where(x => x.InsertNumber.Trim() == book.InsertNumber.Trim()).FirstOrDefault();  

                if (dublicatebookinList == null && dublicatebookInDatabase == null)
                {
                    books.Add(book);
                }
            }

            unitOfWork.BookTwoRepository.InsertRange(books);
            await unitOfWork.CompleteAsync();
        }




        private void PrepareDGV()
        {
            sfDataGrid1.SearchController.AllowFiltering = true;
            this.sfDataGrid1.SearchController.SearchColor = Color.LightGreen;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void GetData()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            sfDataGrid1.DataSource = unitOfWork.BookTwoRepository.GetAll().ToList();
            if (sfDataGrid1.RowCount == 1)
            {
                txtSearch.Enabled = false;
            }
            else
            {
                txtSearch.Enabled = true;
            }
            btnSearch.Text = sfDataGrid1.View.Records.Count.ToString();
        }

        private void CreateColumns()
        {
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", Visible = false });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "RegisterationNumber", HeaderText = "رقم التسجيلة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Address", HeaderText = " العنوان" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Auther", HeaderText = "المؤلف" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "AuthersTag", HeaderText = "وسم المؤلفين" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Subjects", HeaderText = "الموضوعات" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Print", HeaderText = "الطبعة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "PublishDate", HeaderText = "تاريخ النشر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Description", HeaderText = "الوصف المادي" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Chain", HeaderText = "السلسلة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Insight", HeaderText = "التبصرة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "AssosiatedAuthers", HeaderText = "المؤلفين المشاركين" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "AdditionalAddress", HeaderText = "العناوين الإضافية" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CallNumber", HeaderText = "رقم الاستدعاء" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "InsertNumber", HeaderText = "رقم الإيداع" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "RDMCNumber", HeaderText = "رقم ردمك" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "RDMDNumber", HeaderText = "رقم ردمد" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BucketType", HeaderText = "نوع الوعاء" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "DawryaNumber", HeaderText = "عنوان الدورية" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "RepeatedPublish", HeaderText = "تكرار الصدور" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Language", HeaderText = "اللغة" });

        }

        private void ClientSideSearch()
        {
            sfDataGrid1.SearchController.AllowCaseSensitiveSearch = true;
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                sfDataGrid1.SearchController.ClearSearch();
            }
            else
            {
                sfDataGrid1.SearchController.Search(txtSearch.Text);

            }
            btnSearch.Text = sfDataGrid1.View.Records.Count.ToString();

        }

        private int GetId()
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

        private void Delete()
        {
            int id = GetId();
            if (id != 0 && Misc.ConfirmationDialog())
            {
                unitOfWork.BookTwoRepository.Delete(id);
                unitOfWork.Complete();
                GetData();
            }
        }

        private void ToggleControls(bool toggle)
        {
            pictureBox1.Visible = !toggle;
            btnImport.Enabled = toggle;
            btnNew.Enabled = toggle;
            btnExportToExcel.Enabled = toggle;
        }
    }
}
