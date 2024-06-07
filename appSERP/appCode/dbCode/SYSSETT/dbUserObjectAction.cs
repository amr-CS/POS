using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbUserObjectAction: IdbUserObjectAction
    {

        // System Message
        public string vSystemMessage { get; set; } = "";
        public int vSystemMessageTypeId { get; set; } = 0;
        private IclsADO _clsADO;
        private IclsAPI _clsAPI;
        public dbUserObjectAction(clsADO clsADO, IclsAPI clsAPI)
        {
            _clsADO = clsADO;
            _clsAPI = clsAPI;
        }
        // UserObjectAction Load
        public string funUserObjectActionGET(

            int? pUserObjectActionId = null, int? pUserObjectActionSeq = null, int? pUserId = null, int? pObjectId = null, string pObjectProName = null,
            int? pObjectAction = null, int? pObjectActionId = null, bool? pObjectIsAdmin = null, bool? pIsDeleted = null, int? pQueryTypeId = null)
        {
            // Declaration
            string vUserObjectAction;
            // Parameters
            List<SqlParameter> vlsParam = new List<SqlParameter>();
            vlsParam.Add(new SqlParameter("UserObjectActionId", pUserObjectActionId));
            vlsParam.Add(new SqlParameter("UserObjectActionSeq ", pUserObjectActionSeq));
            vlsParam.Add(new SqlParameter("UserId", pUserId));
            vlsParam.Add(new SqlParameter("ObjectId", pObjectId));
            vlsParam.Add(new SqlParameter("ObjectProName", pObjectProName));
            vlsParam.Add(new SqlParameter("ObjectAction", pObjectAction));
            vlsParam.Add(new SqlParameter("ObjectActionId", pObjectActionId));
            vlsParam.Add(new SqlParameter("ObjectIsAdmin", pObjectIsAdmin));
            vlsParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlsParam.Add(new SqlParameter("IsDeleted", false));
            vlsParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            // Fill Data Table

            vUserObjectAction = _clsADO.funExecuteScalar("SYSSETT.spUserObjectActionCRUD", vlsParam, "UserObjectAction Select").ToString();
            // Return Result
            return vUserObjectAction;
        }

        // User Object Load
        public DataTable funUserObjectGET(int UserId)
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserObjectAction + "?pUserId=" + UserId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // User Object Load
            return vDtData;
        }

        // User Object Page Type Load [Distinct]
        public DataTable funUserObjectTypeGET(DataTable pDtObject)
        {
            try
            {
                // User Object Action
                DataTable vDtUserObject = pDtObject;
                // Data View
                DataView vDv = new DataView(vDtUserObject);

                string[] arrDistinctColumns = new string[4];
                arrDistinctColumns[0] = "ObjectTypeId";
                arrDistinctColumns[1] = "ObjectTypeName";
                arrDistinctColumns[2] = "SystemId";
                arrDistinctColumns[3] = "SystemName";
                // Distinct Values [Type]
                DataTable vDtDistinctValues = vDv.ToTable(true, arrDistinctColumns);

                // Return Result
                return vDtDistinctValues;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        // User Object Page Type Load [Distinct]
        public DataTable funUserSystemGET(DataTable pDtObjectType)
        {
            try
            {
                // User Object Action
                DataTable vDtUserObject = pDtObjectType;
                // Data View
                DataView vDv = new DataView(vDtUserObject);

                string[] arrDistinctColumns = new string[2];
                arrDistinctColumns[0] = "SystemId";
                arrDistinctColumns[1] = "SystemName";

                // Distinct Values [Type]
                DataTable vDtDistinctValues = vDv.ToTable(true, arrDistinctColumns);

                // Return Result
                return vDtDistinctValues;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}