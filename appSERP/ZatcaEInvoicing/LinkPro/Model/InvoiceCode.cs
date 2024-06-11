using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.ZatcaEInvoicing.LinkPro.Model
{
    public class InvoiceCode
    {
        //invoice, credit, debit
        // bh
        static string InvoiceCode_invoice = "invoice";
        static string InvoiceCode_credit = "credit";
        static string InvoiceCode_debit = "debit";
        public static string InvoiceCodeType(string IsReturn)
        {
            if (IsReturn == "true")
                return InvoiceCode_credit;
            else
                return InvoiceCode_invoice;
        }
    }
}