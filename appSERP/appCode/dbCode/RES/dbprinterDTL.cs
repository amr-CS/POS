using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbPrinterDTL: IdbPrinterDTL
    {

        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbPrinterDTL(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funPrinterDTLGET(
        int? pPrinterDTLId = null,
        string pPrinterDTLCode = null, 
        int? pPrinterDTLSeq = null,
        int? pInvTypeId = null, 
        string pPrinterName = null, 
        string pPrinterIP = null, 
        int? pPortTypeId = null,
        int? pPortNo = null, 
        int? pDirectPrintId = null,
        int?pPrintNum = null,
         int? pPrinterId = null,

        bool?pPrinterDTLIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("PrinterDTLId", pPrinterDTLId));
            vlstParam.Add(new SqlParameter("PrinterDTLCode", pPrinterDTLCode));
            vlstParam.Add(new SqlParameter("PrinterDTLSeq", pPrinterDTLSeq));
            vlstParam.Add(new SqlParameter("InvTypeId", pInvTypeId));
            vlstParam.Add(new SqlParameter("PrinterName", pPrinterName));
            vlstParam.Add(new SqlParameter("PrinterIP", pPrinterIP));
            vlstParam.Add(new SqlParameter("PortTypeId", pPortTypeId));
            vlstParam.Add(new SqlParameter("PortNo", pPortNo));
            vlstParam.Add(new SqlParameter("DirectPrintId", pDirectPrintId));
            vlstParam.Add(new SqlParameter("PrintNum", pPrintNum));
            vlstParam.Add(new SqlParameter("PrinterId", pPrinterId));
            vlstParam.Add(new SqlParameter("PrinterDTLIsActive", pPrinterDTLIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spAllPrintersDTLCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}