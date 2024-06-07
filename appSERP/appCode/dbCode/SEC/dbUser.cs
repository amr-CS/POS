using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
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
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace appSERP.appCode.dbCode.SEC
{
    public class dbUser : IdbUser
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        private IclsAPI _clsAPI;
        public dbUser(clsADO clsADO, IclsAPI clsAPI)
        {
            _clsADO = clsADO;
            _clsAPI = clsAPI;
        }

        public string funUserGET(
        int? pUserId = null,
        string Printer = null,
        string pUserCode = null,
        string pUserFullName = null,
        string pUserAddress = null,
        string pUserPhone = null,
        string pUserEmail = null,
        string pUserName = null,
        string pUserPassword = null,
        bool? pIsUserLock = null,
        string pUserImage = null,
        int? pSecurityGradeId = null,
        int? pCountryId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pFontSizeTypeId = null,
        int? pUserTypeId = null, 
        int? pEmployeeId= null,
        int? pUserTimeZoneId = null,
        bool? pUserTimeZoneDST = null,
        bool? pUserIsActive = null,
        string phNumbers=null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("UserCode", pUserCode));
            vlstParam.Add(new SqlParameter("Printer", Printer));
            vlstParam.Add(new SqlParameter("UserFullName", pUserFullName));
            vlstParam.Add(new SqlParameter("UserAddress", pUserAddress));
            vlstParam.Add(new SqlParameter("UserPhone", pUserPhone));
            vlstParam.Add(new SqlParameter("UserEmail", pUserEmail));
            vlstParam.Add(new SqlParameter("UserName", pUserName));
            vlstParam.Add(new SqlParameter("UserPassword", pUserPassword));
            vlstParam.Add(new SqlParameter("IsUserLock", pIsUserLock));
            vlstParam.Add(new SqlParameter("UserImage", pUserImage));
            vlstParam.Add(new SqlParameter("SecurityGradeId", pSecurityGradeId));
            vlstParam.Add(new SqlParameter("CountryId", pCountryId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("FontSizeTypeId", pFontSizeTypeId));
            vlstParam.Add(new SqlParameter("UserTypeId", pUserTypeId));
            vlstParam.Add(new SqlParameter("EmployeeId", pEmployeeId));
            vlstParam.Add(new SqlParameter("UserTimeZoneId", pUserTimeZoneId));
            vlstParam.Add(new SqlParameter("UserTimeZoneIsDST", pUserTimeZoneDST));
            vlstParam.Add(new SqlParameter("UserIsActive", pUserIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", pLanguageId));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spUserCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        //test

        // User Lgoin
        public string funUserLogin(string pUserName = null, string pUserPassword = null, string pDevice = null, bool? pUserIsActive = null, bool? pIsDeleted = null, int? pQueryTypeId = null)
        {
            // Declaration
            string vDtUser;
            // Parameters
            List<SqlParameter> vlsParam = new List<SqlParameter>();
            vlsParam.Add(new SqlParameter("UserName", pUserName));
            vlsParam.Add(new SqlParameter("UserPassword", pUserPassword));
            vlsParam.Add(new SqlParameter("Device", pDevice));
            vlsParam.Add(new SqlParameter("UserIsActive", pUserIsActive));
            vlsParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlsParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            // Fill Data Table
            vDtUser = _clsADO.funExecuteScalar("SEC.spUserCRUD", vlsParam, "User Select").ToString();
            // Return Result
            return vDtUser;
        }

        // IP Address
        public string funGetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        // User Data
        public DataTable funUserData(string pUserName)
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUser;
            string vParameters = "?pUserName=" + pUserName;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            // Return Result
            return vDtData;
        }


        // User Data Load
        public void funUserDataSet(string pUserName)
        {
            // User Data
            //DataTable vDtUserData = dbUser.funUserData(pUserName);
            DataTable vDtUserData = funUserData(pUserName);
            // Check Data - NULL
            if (vDtUserData != null)
            {
                // Check Data - Rows
                if (vDtUserData.Rows.Count > 0)
                {
                    // Set Data
                    clsUser.vUserId = Convert.ToInt32(vDtUserData.Rows[0]["UserId"]);
                    clsUser.vUserName = vDtUserData.Rows[0]["UserName"].ToString();
                    clsUser.vUserFullName = vDtUserData.Rows[0]["UserFullName"].ToString();
                    clsUser.vUserImage = vDtUserData.Rows[0]["UserImage"].ToString();
                    clsUser.vUserLanguageId = Convert.ToInt32(vDtUserData.Rows[0]["LanguageId"]);
                    clsUser.vUserTypeId = Convert.ToInt32(vDtUserData.Rows[0]["UserTypeId"]);
                    clsUser.vUserEmail = vDtUserData.Rows[0]["UserEmail"].ToString();
                    clsUser.vUserPhone = vDtUserData.Rows[0]["UserPhone"].ToString();
                }
            }
        }
        public DataTable funGetUserReport(bool? pIsActive = null)
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
            vData = _clsADO.funFillDataTable("SEC.spUserReport", vlstParam, "Data GET");


            return vData;
        }

    }
}