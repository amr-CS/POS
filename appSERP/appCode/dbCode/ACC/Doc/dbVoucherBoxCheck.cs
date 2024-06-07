using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC.Doc
{
    public class dbVoucherBoxCheck : IdbVoucherBoxCheck
    {

        private IclsADO _clsADO;
        public dbVoucherBoxCheck(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funVoucherBoxCheckGET(
        int? pVoucherBoxCheckId = null,
        int? pGLVoucherId=null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        string pAccountId = null,
        decimal? pPayDebit = null,
        decimal? pPayCurrencyValue = null,
        decimal? pDebit = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pBaseDebit = null,
        decimal? pCredit = null,
        decimal? pBaseCredit = null,
        string pNote = null,
        int? pCostCenterId = null,
        bool? pVoucherIsCheck = null,
        int? pCheckBankId = null,
        int? pCheckNo = null,
        DateTime? pCheckDate = null,
        decimal? pCheckDebit = null,
        decimal? pCheckCurrencyValue = null,
        decimal? pCheckBaseDebit = null,
        string pCheckNote = null,
        int? pCheckCostCenterId = null,
        int? pCheckBankBranchId = null,
        int? pPayTypeId = null,
        int? pEPayTypeId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("VoucherBoxCheckId", pVoucherBoxCheckId));
            vlstParam.Add(new SqlParameter("GLVoucherId", pGLVoucherId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("PayDebit", pPayDebit));
            vlstParam.Add(new SqlParameter("PayCurrencyValue", pPayCurrencyValue));
            vlstParam.Add(new SqlParameter("Debit", pDebit));
            vlstParam.Add(new SqlParameter("BaseCurrencyValue", pBaseCurrencyValue));
            vlstParam.Add(new SqlParameter("BaseDebit", pBaseDebit));
            vlstParam.Add(new SqlParameter("Credit", pCredit));
            vlstParam.Add(new SqlParameter("BaseCredit", pBaseCredit));
            vlstParam.Add(new SqlParameter("Note", pNote));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("VoucherIsCheck", pVoucherIsCheck));
            vlstParam.Add(new SqlParameter("CheckBankId", pCheckBankId));
            vlstParam.Add(new SqlParameter("CheckNo", pCheckNo));
            vlstParam.Add(new SqlParameter("CheckDate", pCheckDate));
            vlstParam.Add(new SqlParameter("CheckDebit", pCheckDebit));
            vlstParam.Add(new SqlParameter("CheckCurrencyValue", pCheckCurrencyValue));
            vlstParam.Add(new SqlParameter("CheckBaseDebit", pCheckBaseDebit));
            vlstParam.Add(new SqlParameter("CheckNote", pCheckNote));
            vlstParam.Add(new SqlParameter("CheckCostCenterId", pCheckCostCenterId));
            vlstParam.Add(new SqlParameter("CheckBankBranchId", pCheckBankBranchId));
            vlstParam.Add(new SqlParameter("PayTypeId", pPayTypeId));
            vlstParam.Add(new SqlParameter("EPayTypeId", pEPayTypeId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spVoucherBoxCheckCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

    }
}