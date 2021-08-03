using Common;
using Repository.Models;
using Repository.Repos;
using Syncfusion.Pdf.Graphics;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.DataGridConverter.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookFinder.Winform.BookForms
{
    public partial class BookFormBase : Form
    {
        private const int NumberOfBookColumns = 20;
        private readonly IUnitOfWork unitOfWork;
        public BookFormBase(IUnitOfWork _unitOfWork)
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
            new BookCRUD(unitOfWork).ShowDialog();
            MessageBox.Show("تمت الاضافة بنجاح");
            GetData();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ClientSideSearch();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetId();
            new BookCRUD(unitOfWork, id).ShowDialog();
            MessageBox.Show("تم التعديل بنجاح");
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            int id = GetId();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportToExcel(sfDataGrid1);
            //ExportToPdf();
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



        //#########################################################################
        private async Task InsertImportedExcel(DataTable excelResultDatatable)
        {
            var dbBooks = unitOfWork.BookRepository.GetAll().Distinct();
            var books = new List<Book>();
            for (int i = 0; i < excelResultDatatable.Rows.Count; i++)
            {
                var book = new Book()
                {
                    BookId = excelResultDatatable.Rows[i][0].ToString(),
                    BookName = excelResultDatatable.Rows[i][1].ToString(),
                    BookAuther = excelResultDatatable.Rows[i][2].ToString(),
                    BookVerifier = excelResultDatatable.Rows[i][3].ToString(),
                    BookPublisher = excelResultDatatable.Rows[i][4].ToString(),
                    BookPublishDate = excelResultDatatable.Rows[i][5].ToString(),
                    BookCountry = excelResultDatatable.Rows[i][6].ToString(),
                    BookCity = excelResultDatatable.Rows[i][7].ToString(),
                    BookPrintNumber = excelResultDatatable.Rows[i][8].ToString(),
                    BookNumberOfParts = excelResultDatatable.Rows[i][9].ToString(),
                    BookNumberOfPapers = excelResultDatatable.Rows[i][10].ToString(),
                    BookBucketType = excelResultDatatable.Rows[i][11].ToString(),
                    BookFileType = excelResultDatatable.Rows[i][12].ToString(),
                    BookMainCategory = excelResultDatatable.Rows[i][13].ToString(),
                    BookSecondaryCategory = excelResultDatatable.Rows[i][14].ToString(),
                    BookContents = excelResultDatatable.Rows[i][15].ToString(),
                    BookNotes = excelResultDatatable.Rows[i][16].ToString(),
                    BookCover = excelResultDatatable.Rows[i][17].ToString(),
                    BookReadUrl = excelResultDatatable.Rows[i][18].ToString(),
                    BookDownloadUrl = excelResultDatatable.Rows[i][19].ToString()
                };

                var dublicatebookinList = books
                    .Where(x => x.BookReadUrl.Trim() == book.BookReadUrl.Trim()
                        && x.BookDownloadUrl.Trim() == book.BookDownloadUrl.Trim()
                        && x.BookName.Trim() == book.BookName.Trim()).FirstOrDefault();

                var dublicatebookInDatabase = dbBooks
                      .Where(x => x.BookReadUrl.Trim() == book.BookReadUrl.Trim()
                          && x.BookDownloadUrl.Trim() == book.BookDownloadUrl.Trim()
                          && x.BookName.Trim() == book.BookName.Trim()).FirstOrDefault();

                if (dublicatebookinList == null && dublicatebookInDatabase == null)
                {
                    books.Add(book);
                }
            }

            unitOfWork.BookRepository.InsertRange(books);
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
            sfDataGrid1.DataSource = unitOfWork.BookRepository.GetAll().ToList();
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
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookId", HeaderText = "كود" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookName", HeaderText = " عنوان الكتاب" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookAuther", HeaderText = "اسم المؤلف" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookVerifier", HeaderText = "اسم المحقق" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookPublisher", HeaderText = "اسم الناشر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookPublishDate", HeaderText = "تاريخ النشر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookCountry", HeaderText = "بلد النشر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookCity", HeaderText = "المدينة" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookPrintNumber", HeaderText = "رقم الطبعة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookNumberOfParts", HeaderText = "عدد الأجزاء" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookNumberOfPapers", HeaderText = "عدد الأوراق" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookBucketType", HeaderText = "نوع الوعاء" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookFileType", HeaderText = "نوع الملف" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookMainCategory", HeaderText = "التصنيف الرئيسي" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookSecondaryCategory", HeaderText = "التصنيف الفرعي" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookContents", HeaderText = "موضوعات الكتاب" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookNotes", HeaderText = "ملاحظات" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "BookCover", HeaderText = "الغلاف" });
            sfDataGrid1.Columns.Add(new GridHyperlinkColumn() { MappingName = "BookReadUrl", HeaderText = "رابط القراءة" });
            sfDataGrid1.Columns.Add(new GridHyperlinkColumn() { MappingName = "BookDownloadUrl", HeaderText = "رابط التحميل" });
        }

        private void ExportToPdf()
        {
            PdfExportingOptions options = new PdfExportingOptions();
            options.CellExporting += options_CellExporting;
            var document = sfDataGrid1.ExportToPdf(options);
            document.Save("Sample.pdf");

            
        }
        void options_CellExporting(object sender, DataGridCellPdfExportingEventArgs e)
        {
            if (e.CellType != ExportCellType.RecordCell)
                return;
            PdfStringFormat format = new PdfStringFormat();

            //format the string from right to left.
            format.TextDirection = PdfTextDirection.RightToLeft;
            format.Alignment = PdfTextAlignment.Right;
            e.PdfGridCell.StringFormat = format;
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
                unitOfWork.BookRepository.Delete(id);
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
