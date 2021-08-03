using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookFinder.Winform
{
    public static class ExcelImporter
    {
        private static DataTable excelResultDatatable;
        public static DataTable ImportFromExcel()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook .xlsx|*xlsx|Excel 97-2003 Workbook .xls|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            excelResultDatatable = result.Tables[0];
                        }
                    }
                }
            }
            return excelResultDatatable;
        }
    }
}
