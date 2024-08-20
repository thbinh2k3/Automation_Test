using ExcelDataReader;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Exam
{
    internal class Read_Write_Catalog
    {
            public static IEnumerable<TestCaseData> GetTestCaseDataFromExcel(string path, string sheetName)
            {
                var testData = new List<TestCaseData>();
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var table = result.Tables[sheetName]; // Truy cập vào sheet theo tên

                        int columnCount = table.Columns.Count;

                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            var rowData = new List<string>();
                            for (int j = 0; j < columnCount; j++)
                            {
                                rowData.Add(Convert.ToString(table.Rows[i][j]));
                            }
                            var expected = Convert.ToString(table.Rows[i][columnCount - 1]); // Giả sử cột cuối cùng chứa kết quả mong đợi
                            testData.Add(new TestCaseData(rowData.ToArray()) { TestName = $"{path}_{sheetName}_Row_{i}" });
                        }
                    }
                }
                return testData;
            }


           

            public void WriteResultToExcel(string path, string sheetName, string actuals, int index)
            {
                int rowStart = index;
                int colEnd = 4;

                try
                {
                    using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName] ?? package.Workbook.Worksheets[0];

                        int column = colEnd - 1;
                        worksheet.Cells[rowStart, column].Value = actuals;
                        if (worksheet.Cells[rowStart, colEnd - 2].Value.ToString().Trim().Equals(actuals.Trim()))
                        {
                            worksheet.Cells[rowStart, colEnd].Value = "Pass";
                        }
                        else
                        {
                            worksheet.Cells[rowStart, colEnd].Value = "Fail";
                        }

                        package.Save();
                        rowStart++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi : {ex.Message}");
                }
            }
        }
}
