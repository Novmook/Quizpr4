using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Windows.Controls;

namespace Quizpr4
{

    /// <summary>
    /// Логика взаимодействия для ReportBD.xaml
    /// </summary>
    public partial class ReportBD : Window
    {
        string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Desktop\КНИТУ\4 курс\Моделирование систем\Quizpr4\BD\QuizDB.mdf;Integrated Security=True;Connect Timeout=30");
        public ReportBD()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Используйте NonCommercial, если проект не коммерческий
            InitializeComponent();
            binddatagrid();
        }
        private void binddatagrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM LoginUser";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                QuizDataGrid.ItemsSource = dtbl.DefaultView;
            }
        }

        private void Excel1Tab_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                ExportToExcel(QuizDataGrid, filePath);
                MessageBox.Show("Данные успешно экспортированы в Excel.", "Успех");
            }

            /*Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            workbook.Sheets.Add(Type.Missing);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];
            Excel.Range range;
            Excel.Range myRange;
            bool bl = true;

            for (int i = 0; i < QuizDataGrid.Items.Count; i++)
            {
                DataRowView row = QuizDataGrid.Items[i] as DataRowView;

                for (int j = 0; j < QuizDataGrid.Columns.Count; j++)
                {
                    if (bl)
                    {
                        range = (Excel.Range)sheet1.Cells[1, j + 1];
                        range.Font.Bold = true;
                        range.Value = QuizDataGrid.Columns[j].Header;
                    }
                    if (row != null && row[j] != null)
                    {
                        myRange = sheet1.Range[i + 2, j + 1];
                        myRange.Value = row[j].ToString();
                    }
                }
                bl = false;
            }
            excel.Visible = true;*/
        }

        public void ExportToExcel(DataGrid dataGrid, string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int col = 0; col < QuizDataGrid.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1].Value = QuizDataGrid.Columns[col].Header;
                    worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                }

                int row = 2;
                foreach (var item in QuizDataGrid.Items)
                {
                    for (int col = 0; col < QuizDataGrid.Columns.Count; col++)
                    {
                        var cellValue = QuizDataGrid.Columns[col].GetCellContent(item);
                        worksheet.Cells[row, col + 1].Value = cellValue is TextBlock ? ((TextBlock)cellValue).Text : cellValue.ToString();
                    }
                    row++;
                }

                package.Save();
            }
        }
    }
}
