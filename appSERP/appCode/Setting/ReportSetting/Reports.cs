using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using System.Drawing.Printing;
using System.Management;
using appSERP.Reports;
using appSERP.Reports.POS;

namespace appSERP.appCode.Setting.ReportSetting
{
    public static class Reports
    {
        public static PrintOptions  printOptions;
        //public void PrinteBill()
        // {
        //     try
        //     {

        //     GENERAL.CustomerReport.SetDataSource(GENERAL.ObjTableCustomerBill);
        //     GENERAL.CustomerReport.SetParameterValue(0, Discount);
        //     GENERAL.CustomerReport.SetParameterValue(1, Cash);
        //     GENERAL.CustomerReport.SetParameterValue(2, Span);
        //     GENERAL.CustomerReport.SetParameterValue(3, Inv_Id);
        //     GENERAL.CustomerReport.SetParameterValue(4, GENERAL.USERNAME);
        //     GENERAL.CustomerReport.SetParameterValue("FOOTER", GENERAL.FooterBill);
        //     GENERAL.CustomerReport.SetParameterValue(6, Title);
        //     GENERAL.CustomerReport.SetParameterValue("Timebill", time);
        //     GENERAL.CustomerReport.SetParameterValue("CUSTOMER", GENERAL.Customer_Name_A);
        //     GENERAL.CustomerReport.SetParameterValue("CUSTOMER_NO", GENERAL.Customer_Id);
        //     GENERAL.CustomerReport.SetParameterValue("CUSTOMER_PHONE", GENERAL.Customer_phone);
        //     GENERAL.CustomerReport.SetParameterValue("CUSTOMER_ADDRESS", GENERAL.Customer_address);
        //     GENERAL.CustomerReport.SetParameterValue("VatCode", GENERAL.VatCode);
           
        //     printOptions = GENERAL.CustomerReport.PrintOptions;
        //     printOptions.PrinterName = @GENERAL.DefaultPrinter;
        //     GENERAL.CustomerReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)PaperKind.ESheet;
        //     GENERAL.CustomerReport.PrintToPrinter(1, true, 1, 1);

        //     //Form1 f = new Form1();
        //     //f.crystalReportViewer1.ReportSource = GENERAL.CustomerReport;
        //     //f.crystalReportViewer1.Refresh();
        //     //f.ShowDialog();

        //     }
        //     catch (Exception ex)
        //     {
                 
        //        CLASSP.WriteToFile.WriteErrors("الطابعة", ex.Message.ToString(), "1");
        //     }

            
        // }


        ///// <summary>
        ///// دالة طباعة الباركو
        ///// </summary>
        ///// <param name="printe"></param>
        ///// <param name="item_name"></param>
        ///// <param name="barcode"></param>
        ///// <param name="number"></param>
        // public void PrinteBarcode(string printe, string item_name, string barcode,string company,string price, int number)
        // {
        //     try
        //     {
        //         GENERAL.Barcode.SetParameterValue(0, barcode);
        //         GENERAL.Barcode.SetParameterValue(1, barcode);
        //         GENERAL.Barcode.SetParameterValue(2, company);
        //         GENERAL.Barcode.SetParameterValue(3,item_name);
        //         GENERAL.Barcode.SetParameterValue(4,price);
        //         printOptions=GENERAL.Barcode.PrintOptions;
        //         printOptions.PrinterName=@printe;
        //         GENERAL.Barcode.PrintToPrinter(number, true, 1, 1);
        //     }
        //     catch (Exception)
        //     {
                 
                 
        //     }
        // }




         public static void PrinteInss()
         {
             try
             {
               
                 DataTable temp = new DataTable();
                 //temp = DAL.GET_TABLE(sql);
                 Customer rpt = new Customer();
                 rpt.SetDataSource(temp);

                PrinterSettings settings = new PrinterSettings();

                printOptions = rpt.PrintOptions;
                 printOptions.PrinterName = settings.PrinterName;
                 rpt.PrintToPrinter(2, true, 1, 1);

                 //Form1 f = new Form1();
                 //f.crystalReportViewer1.ReportSource = rpt;
                 //f.crystalReportViewer1.Refresh();
                 //f.ShowDialog();

             }
             catch (Exception)
             {
                     
             }
         }


    }
}
