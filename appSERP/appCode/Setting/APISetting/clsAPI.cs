using appSERP.appCode.Setting.APISetting.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace appSERP.appCode.Setting.APISetting
{
    public class clsAPI : IclsAPI
    {
        // API [Current Base URL]
        public string funAPIBaseURL()
        {
            // Get Current Base URL
            string vAPIBaseURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            // Return Result
            return vAPIBaseURL + "/api";
        }

        // Run
        public async Task<string> RunAsync(string pPath)
        {
            // FULL URL
            string vFullURL = funAPIBaseURL() + pPath;
            // Http Client
            using (var vHttpClient = new HttpClient())
            using (var vHttpResponse = await vHttpClient.GetAsync(vFullURL).ConfigureAwait(false))
            {
                // Return Result
                return await vHttpResponse.Content.ReadAsAsync<string>();
            }
        }

        // Data Result
        public DataTable funResultGet(string pPath)
        {
            // Get Result
            var vDataResult = RunAsync(pPath).Result;

            // Data [Data Table]
            DataTable vDtResult = new DataTable();

            if (!string.IsNullOrEmpty(vDataResult) && vDataResult!="" && vDataResult != null)
            {

                vDtResult = JsonConvert.DeserializeObject<DataTable>(vDataResult);

            }
            else
            {

            }
            // Return Result
            return vDtResult;
        }

        public string funResultGetJSON(string pPath)
        {
            // Get Result
            var vDataResult = RunAsync(pPath).Result;
            // Return Result
            return vDataResult;
        }
    }
}