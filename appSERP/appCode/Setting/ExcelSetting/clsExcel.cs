using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.ExcelSetting
{
    public static class clsExcel
    {
        // Convert Excel To DataTable
        public static DataTable funExcelToDataTable(string pFilePath)
        {
            // Excel File
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook WorkBook = application.Workbooks.Open(pFilePath);
            Microsoft.Office.Interop.Excel.Worksheet WorkSheet = WorkBook.ActiveSheet;
            WorkSheet = WorkBook.ActiveSheet;
            //WorkSheet = WorkBook.ActiveSheet;
            Microsoft.Office.Interop.Excel.Range range = WorkSheet.UsedRange;

            // Get Data
            DataTable vbDtData = new DataTable();
            // Creata Dt Columns
            for (int vColumn = 1; vColumn <= range.Columns.Count; vColumn++)
            {
                // Add Column
                vbDtData.Columns.Add(vColumn.ToString());
            }

            // Get Data [Rows]
            for (int vRow = 2; vRow <= range.Rows.Count; vRow++)
            {
                // Add Row
                vbDtData.Rows.Add();

                // Check ALl Columns
                for (int vColumn = 1; vColumn <= range.Columns.Count; vColumn++)
                {
                    // Current Cell
                    string vCurrentCell = ((Microsoft.Office.Interop.Excel.Range)range.Cells[vRow, vColumn]).Text;

                    // Check If Not Header
                    if (vRow > 1)
                    {
                        // Fill Row
                        vbDtData.Rows[vRow - 2][vColumn - 1] = vCurrentCell;
                    }
                }

            } // End Check Rows

            // Return Result
            return vbDtData;
        }
    }
}