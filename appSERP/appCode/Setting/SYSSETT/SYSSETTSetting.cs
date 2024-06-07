using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.SYSSETT.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.SYSSETT
{
    public class SYSSETTSetting: ISYSSETTSetting
    {
        public int i { get; set; } = 0;

        private IclsAPI _clsAPI;
        public SYSSETTSetting(IclsAPI clsAPI) {
            _clsAPI = clsAPI;
        }
        // First
        public string funFirstGl()
        {
             i = 0;
            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
       
           vDtPage = vDtData.Rows[i]["GLVoucherId"].ToString();
                
            return vDtPage;
        }
        // Last 
        public string funLastGL()
        {

            
            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
             i = vDtData.Rows.Count - 1;
            vDtPage = vDtData.Rows[i]["GLVoucherId"].ToString();
            return vDtPage;
        }
       
        // Next 
        public string funNextGL()
        {


            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            if (i < vDtData.Rows.Count - 1)
            {
                i++;
                vDtPage = vDtData.Rows[i]["GLVoucherId"].ToString();
                return vDtPage;
            }
            else
            {
                return null;
            }
           
        }
        // Prev
        public string funPrevGL()
        {
            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            if (i == vDtData.Rows.Count - 1 || i!=0)
            {
                i--;
                vDtPage = vDtData.Rows[i]["GLVoucherId"].ToString();
                return vDtPage;
            }
            else
            {
                return null;
            }

        }


        // First
        public string funFirstCashDeskTrans()
        {
            i = 0;
            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);

            vDtPage = vDtData.Rows[i]["CashDeskTransId"].ToString();

            return vDtPage;
        }
        // Last 
        public string funLastCashDeskTrans()
        {


            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            i = vDtData.Rows.Count - 1;
            vDtPage = vDtData.Rows[i]["CashDeskTransId"].ToString();
            return vDtPage;
        }

        // Next 
        public string funNextCashDeskTrans()
        {


            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            if (i < vDtData.Rows.Count - 1)
            {
                i++;
                vDtPage = vDtData.Rows[i]["CashDeskTransId"].ToString();
                return vDtPage;
            }
            else
            {
                return null;
            }

        }
        // Prev
        public string funPrevCashDeskTrans()
        {
            string vDtPage;
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            if (i == vDtData.Rows.Count - 1 || i != 0)
            {
                i--;
                vDtPage = vDtData.Rows[i]["CashDeskTransId"].ToString();
                return vDtPage;
            }
            else
            {
                return null;
            }

        }

    }
}