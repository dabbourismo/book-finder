using Common;
using Repository.Models;
using Repository.Repos;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookFinder.Winform.BookOneForms
{
    public partial class BookOneFormBase : Form
    {
        private const int NumberOfBookColumns = 25;
        private readonly IUnitOfWork unitOfWork;
        public BookOneFormBase(IUnitOfWork _unitOfWork)
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
            new BookOneCRUD(unitOfWork).ShowDialog();
            MessageBox.Show("تمت الاضافة بنجاح");
            GetData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetId();
            new BookOneCRUD(unitOfWork, id).ShowDialog();
            MessageBox.Show("تم التعديل بنجاح");
            GetData();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportToExcel(sfDataGrid1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            int id = GetId();
        }
        //#########################################################################

        private async Task InsertImportedExcel(DataTable excelResultDatatable)
        {
            var dbBooks = unitOfWork.BookOneRepository.GetAll().Distinct();
            var books = new List<BookOne>();
            for (int i = 0; i < excelResultDatatable.Rows.Count; i++)
            {
                var book = new BookOne()
                {
                    Country = excelResultDatatable.Rows[i][0].ToString(),
                    Auther = excelResultDatatable.Rows[i][1].ToString(),
                    Type = excelResultDatatable.Rows[i][2].ToString(),

                    Address = excelResultDatatable.Rows[i][3].ToString(),
                    AddressType = excelResultDatatable.Rows[i][4].ToString(),
                    City = excelResultDatatable.Rows[i][5].ToString(),

                    Publisher = excelResultDatatable.Rows[i][6].ToString(),
                    NormalDate = excelResultDatatable.Rows[i][7].ToString(),
                    Month = excelResultDatatable.Rows[i][8].ToString(),

                    HijryDate = excelResultDatatable.Rows[i][9].ToString(),
                    Pages = excelResultDatatable.Rows[i][10].ToString(),
                    SegelType = excelResultDatatable.Rows[i][11].ToString(),

                    CrypticCol = excelResultDatatable.Rows[i][12].ToString(),
                    ItemDescription = excelResultDatatable.Rows[i][13].ToString(),
                    MessageType = excelResultDatatable.Rows[i][14].ToString(),

                    University = excelResultDatatable.Rows[i][15].ToString(),
                    Colleage = excelResultDatatable.Rows[i][16].ToString(),
                    Country2 = excelResultDatatable.Rows[i][17].ToString(),

                    Mostakhlas = excelResultDatatable.Rows[i][18].ToString(),
                    Subjects = excelResultDatatable.Rows[i][19].ToString(),
                    OtherAuthers = excelResultDatatable.Rows[i][20].ToString(),

                    MainArabicSubjects = excelResultDatatable.Rows[i][21].ToString(),
                    Mogalad = excelResultDatatable.Rows[i][22].ToString(),
                    Source = excelResultDatatable.Rows[i][23].ToString(),

                    ISSN = excelResultDatatable.Rows[i][24].ToString()
                };

                var dublicatebookinList = books
                    .Where(x => x.Country.Trim() == book.Country.Trim()
                        && x.Auther.Trim() == book.Auther.Trim()
                        && x.Type.Trim() == book.Type.Trim()).FirstOrDefault();

                var dublicatebookInDatabase = dbBooks
                      .Where(x => x.Country.Trim() == book.Country.Trim()
                        && x.Auther.Trim() == book.Auther.Trim()
                        && x.Type.Trim() == book.Type.Trim()).FirstOrDefault();

                if (dublicatebookinList == null && dublicatebookInDatabase == null)
                {
                    books.Add(book);
                }
            }

            unitOfWork.BookOneRepository.InsertRange(books);
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
            sfDataGrid1.DataSource = unitOfWork.BookOneRepository.GetAll().ToList();
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

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country", HeaderText = "الدولة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Auther", HeaderText = " المؤلف" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Type", HeaderText = "النوع" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Address", HeaderText = "العنوان" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "AddressType", HeaderText = "نوع العنوان" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "City", HeaderText = "المدينة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Publisher", HeaderText = "الناشر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "NormalDate", HeaderText = "التاريخ الميلادي" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Month", HeaderText = "الشهر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "HijryDate", HeaderText = "التاريخ الهجري" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Pages", HeaderText = "الصفحات" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "SegelType", HeaderText = "نوع السجل" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CrypticCol", HeaderText = "336$b" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ItemDescription", HeaderText = "وصف العنصر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "MessageType", HeaderText = "نوع الرسالة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "University", HeaderText = "الجامعة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Colleage", HeaderText = "الكلية" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country2", HeaderText = "الدولة" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Mostakhlas", HeaderText = "المستخلص" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Subjects", HeaderText = "مواضيع" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OtherAuthers", HeaderText = "مؤلفين آخرين" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "MainArabicSubjects", HeaderText = "الموضوع العام عربي" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Mogalad", HeaderText = "المجلد / العدد" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Source", HeaderText = "المصدر " });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ISSN", HeaderText = "ISSN" });
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
                unitOfWork.BookOneRepository.Delete(id);
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
