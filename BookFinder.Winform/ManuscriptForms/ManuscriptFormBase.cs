using Common;
using ExcelDataReader;
using Repository.Models;
using Repository.Repos;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookFinder.Winform.ManuscriptForms
{
    public partial class ManuscriptFormBase : Form
    {
        private const int NumberOfManuscriptColumns = 22;
        private readonly IUnitOfWork unitOfWork;
        public ManuscriptFormBase(IUnitOfWork _unitOfWork)
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
            new ManuscriptCRUD(unitOfWork).ShowDialog();
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
            new ManuscriptCRUD(unitOfWork, id).ShowDialog();
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
            else if (excelResultDatatable.Columns.Count != NumberOfManuscriptColumns)
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

            List<Manuscript> dbManuscripts = unitOfWork.ManuscriptRepository.GetAll().Distinct().ToList();
            int dbRowsCount = dbManuscripts.Count;
            int datatableRowCount = excelResultDatatable.Rows.Count;
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();

            var manuscripts = new List<Manuscript>();

            for (int i = 0; i < datatableRowCount / 2; i++)
            {
                //Manuscript dublicateManuscriptinList = manuscripts
                //    .Where(x => x.ManuName.Trim() == excelResultDatatable.Rows[i][0].ToString()).FirstOrDefault();


                //Manuscript dublicateManuscriptInDatabase = dbManuscripts
                //        .Where(x => x.ManuName.Trim() == excelResultDatatable.Rows[i][0].ToString()).FirstOrDefault();

                //if (dublicateManuscriptinList == null && dublicateManuscriptInDatabase == null)
                //{
                //}
                var manuscript = new Manuscript()
                {
                    ManuName = excelResultDatatable.Rows[i][0].ToString(),
                    ManuAuther = excelResultDatatable.Rows[i][1].ToString(),
                    ManuArt = excelResultDatatable.Rows[i][2].ToString(),
                    ManuLiberaryName = excelResultDatatable.Rows[i][3].ToString(),
                    ManuNumber1 = excelResultDatatable.Rows[i][4].ToString(),
                    ManuNumber2 = excelResultDatatable.Rows[i][5].ToString(),
                    ManuCountry = excelResultDatatable.Rows[i][6].ToString(),
                    ManuCopier = excelResultDatatable.Rows[i][7].ToString(),
                    ManuCopyDate = excelResultDatatable.Rows[i][8].ToString(),
                    ManuNumberOfPapers = excelResultDatatable.Rows[i][9].ToString(),
                    ManuNotes = excelResultDatatable.Rows[i][10].ToString(),
                    ManuLanguage = excelResultDatatable.Rows[i][11].ToString(),
                    ManuFirst = excelResultDatatable.Rows[i][12].ToString(),
                    ManuLast = excelResultDatatable.Rows[i][13].ToString(),
                    ManuDescription = excelResultDatatable.Rows[i][14].ToString(),
                    ManuDataSource = excelResultDatatable.Rows[i][15].ToString(),
                    ManuFont = excelResultDatatable.Rows[i][16].ToString(),
                    ManuInk = excelResultDatatable.Rows[i][17].ToString(),
                    ManuPaperArea = excelResultDatatable.Rows[i][18].ToString(),
                    ManuContentArea = excelResultDatatable.Rows[i][19].ToString(),
                    ManuNumberOfLines = excelResultDatatable.Rows[i][19].ToString(),
                    ManuContentCondition = excelResultDatatable.Rows[i][19].ToString()
                };

                // manuscripts.Add(manuscript);
                unitOfWork.ManuscriptRepository.Insert(manuscript);
                if (i % 50 == 0)
                {
                    unitOfWork.Complete();
                    //unitOfWork.Dispose();
                }
            }
            await unitOfWork.CompleteAsync();
            manuscripts.Clear();
            manuscripts.TrimExcess();
            
          
            //stopWatch.Stop();
            //MessageBox.Show(stopWatch.Elapsed.ToString());



            //unitOfWork.ManuscriptRepository.InsertRange(manuscripts);
            // await unitOfWork.CompleteAsync();

        }




        private void PrepareDGV()
        {
            sfDataGrid1.SearchController.AllowFiltering = true;
            this.sfDataGrid1.SearchController.SearchColor = Color.LightGreen;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void CreateColumns()
        {
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuName", HeaderText = "عنوان المخطوط" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuAuther", HeaderText = " اسم المؤلف" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuArt", HeaderText = "التصنيف (الفن)" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuLiberaryName", HeaderText = "اسم المكتبة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuNumber1", HeaderText = "الرقم 1" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuNumber2", HeaderText = "الرقم 2" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuCountry", HeaderText = "الدولة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuCopier", HeaderText = "اسم الناسخ" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuCopyDate", HeaderText = "تاربخ النسخ" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuNumberOfPapers", HeaderText = "عدد الاوراق" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuNotes", HeaderText = "ملاحظات" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuLanguage", HeaderText = "اللغة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuFirst", HeaderText = "أوله" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuLast", HeaderText = "آخره" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuDescription", HeaderText = "الوصف" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuDataSource", HeaderText = "مصدر البيانات" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuFont", HeaderText = "الخط" });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuInk", HeaderText = "الحبر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuPaperArea", HeaderText = "قياس الصفحة" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuContentArea", HeaderText = "مساحة النص" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuNumberOfLines", HeaderText = "عدد الأسطر" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ManuContentCondition", HeaderText = "حالة النص" });
        }

        private void GetData()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            //sfDataPager1.DataSource = unitOfWork.ManuscriptRepository.GetAll().ToList();
            //sfDataPager1.PageSize = 100;
            //sfDataGrid1.DataSource = sfDataPager1.PagedSource;

            sfDataGrid1.DataSource = unitOfWork.ManuscriptRepository.GetAll().ToList();
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

        private void ClientSideSearch()
        {
            sfDataGrid1.SearchController.AllowCaseSensitiveSearch = true;
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                sfDataGrid1.SearchController.ClearSearch();
            }
            else
            {
                if (txtSearch.Text.StartsWith("أ") || txtSearch.Text.StartsWith("ا") || txtSearch.Text.EndsWith("ه"))
                {
                    txtSearch.Text.Replace("أ", "").Replace("ه", "").Replace("ا", "");

                }
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
                unitOfWork.ManuscriptRepository.Delete(id);
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


        public DataTable RemoveDuplicateRows(DataTable table, string DistinctColumn1, string DistinctColumn3)
        {
            try
            {
                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Check if records is already added to UniqueRecords otherwise,
                // Add the records to DuplicateRecords
                foreach (System.Data.DataRow dRow in table.Rows)
                {
                    if (UniqueRecords.Contains(dRow[DistinctColumn1] + "" + dRow[DistinctColumn3]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[DistinctColumn1] + "" + dRow[DistinctColumn3]);
                }

                // Remove duplicate rows from DataTable added to DuplicateRecords
                foreach (System.Data.DataRow dRow in DuplicateRecords)
                {
                    table.Rows.Remove(dRow);
                }

                // Return the clean DataTable which contains unique records.
                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}
