using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Utils
{
    public class ExportToFiles //: Controller
    {
        /*
        public ActionResult ToExcel(DataTable dataTable, string fileNamePrefix, List<string> excludedColumns, string Worksheets = "Sheet1")
        {        
            // Get the column names dynamically from the DataTable
            //var columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            //var excludedColumns = new List<string> { "IsPassed", "InvStatus", "TotalInvoiceBeforeTax", "invRef" }; // قائمة الأعمدة المراد استثناؤها

            var columnNames = dataTable.Columns
                .Cast<DataColumn>()
                .Where(column => !excludedColumns.Contains(column.ColumnName)) // استثناء الأعمدة الموجودة في قائمة excludedColumns
                .Select(column => column.ColumnName)
                .ToList();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Create a new worksheet
                //var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                var worksheet = package.Workbook.Worksheets.Add(Worksheets);//Invoices

                // Set the column headers dynamically
                for (var i = 0; i < columnNames.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Fill the rows with data
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (var j = 0; j < columnNames.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][columnNames[j]];
                    }
                }

                // Auto-fit the columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Convert the Excel package to a byte array
                var excelBytes = package.GetAsByteArray();

                // Set the response headers
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("Content-Disposition", "attachment; filename=ExportedData.xlsx");
                Response.AddHeader("Content-Disposition", "attachment; filename="+ fileNamePrefix + "Data_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".xlsx");
                Response.AddHeader("Content-Length", excelBytes.Length.ToString());

                // Write the Excel file to the response
                Response.BinaryWrite(excelBytes);
            }

            return new EmptyResult(); // ActionResult
        }
        */

        public static byte[] ToExcel(DataTable dataTable, List<string> excludedColumns, string Worksheets = "Sheet1")
        {
            // Get the column names dynamically from the DataTable
            //var columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();

            //var excludedColumns = new List<string> { "IsPassed", "InvStatus", "TotalInvoiceBeforeTax", "invRef" }; // قائمة الأعمدة المراد استثناؤها

            var columnNames = dataTable.Columns
                .Cast<DataColumn>()
                .Where(column => !excludedColumns.Contains(column.ColumnName)) // استثناء الأعمدة الموجودة في قائمة excludedColumns
                .Select(column => column.ColumnName)
                .ToList();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Create a new worksheet
                //var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                var worksheet = package.Workbook.Worksheets.Add(Worksheets);//Invoices

                // Set the column headers dynamically
                for (var i = 0; i < columnNames.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Fill the rows with data
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (var j = 0; j < columnNames.Count; j++)
                    {
                        //var value = dataTable.Rows[i][columnNames[j]];
                        //if (value != null && value.GetType() == typeof(DateTime))
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][columnNames[j]].ToString();
                        }
                        //else
                        //    worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][columnNames[j]];
                    }
                }

                // Auto-fit the columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Convert the Excel package to a byte array
                var excelBytes = package.GetAsByteArray();



                return excelBytes;


            }

        }
    }
}