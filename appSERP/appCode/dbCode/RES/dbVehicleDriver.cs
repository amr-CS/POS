using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbVehicleDriver: IdbVehicleDriver
    {
        private IclsADO _clsADO;
        public dbVehicleDriver(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funVehicleDriverGET(
int? pVehicleDriverId = null,
string pVehicleDriverCode = null,
int? pVehicleId = null,
int? pDriverId = null,
DateTime? pTransactionDate = null,
int? pTransactionStatusId = null,
decimal? pCounter = null,
string pNotes = null,
bool? pVehicleDriverIsActive = null,
bool? pIsDeleted = false,
int? pQueryTypeId = null,
string pVecDescL1 = null,
string pResEmployeeNameL1 = null,
string pLstVehicleDriver = null,
string pVehicleCode = null,
string pResEmployeeCode  = null,
string pSearchedDate  = null   ,
string pLstVehicles = null,
string pLstDrivers = null
)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("VehicleDriverId", pVehicleDriverId));
            vlstParam.Add(new SqlParameter("VehicleDriverCode", pVehicleDriverCode));
            vlstParam.Add(new SqlParameter("VehicleId", pVehicleId));
            vlstParam.Add(new SqlParameter("DriverId", pDriverId));
            vlstParam.Add(new SqlParameter("TransactionDate", pTransactionDate));
            vlstParam.Add(new SqlParameter("TransactionStatusId", pTransactionStatusId));
            vlstParam.Add(new SqlParameter("Counter", pCounter));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("VehicleDriverIsActive", pVehicleDriverIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("VecDescL1", pVecDescL1));
            vlstParam.Add(new SqlParameter("ResEmployeeNameL1", pResEmployeeNameL1));
            vlstParam.Add(new SqlParameter("LstVehicleDriver", pLstVehicleDriver));
            vlstParam.Add(new SqlParameter("VehicleCode", pVehicleCode));
            vlstParam.Add(new SqlParameter("ResEmployeeCode", pResEmployeeCode));
            vlstParam.Add(new SqlParameter("SearchedDate", pSearchedDate));
            vlstParam.Add(new SqlParameter("LstVehicles", pLstVehicles));
            vlstParam.Add(new SqlParameter("LstDrivers", pLstDrivers));

            vData = _clsADO.funExecuteScalar("RES.spVehicleDriverCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetVehicleDriverReport(bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("RES.spGetVehiclesDriversReport", vlstParam, "Data GET");


            return vData;
        }
    }
}