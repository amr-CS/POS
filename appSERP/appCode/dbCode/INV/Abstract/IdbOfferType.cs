using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbOfferType
    {
        string funOfferTypeGET(

        int? pOfferTypeId = null,
        string pOfferTypeCode = null,
        string pOfferTypeNameL1 = null,
        string pOfferTypeNameL2 = null,
        string pAbbr = null,
        bool? pIsDefault = null,
        int? pBranchId = null,
        bool? pOfferTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetOfferTypeReport(bool? pIsActive = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }


    }
}
