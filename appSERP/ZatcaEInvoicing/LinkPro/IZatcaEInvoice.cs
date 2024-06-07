using appSERP.Models.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.ZatcaEInvoicing.LinkPro
{
    public interface IZatcaEInvoice
    {
        Task<InvoiceResponseDto> SendInvoice(string TokenDb, InvoiceCreateRequest entity);
        Task<string> SendInvoiceStr(string TokenDb, InvoiceCreateRequest entity);
        //Task<InvoiceResponseDto> SendInvoice(string TokenDb, DataPro entity);
    }
}
