using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace appSERP.ZatcaEInvoicing.LinkPro
{
    public class ApiHelper
    {
        static string urlServer = "https://linkpro.cloud/api/";
        //static string TokenDb = "46dffc49c8882fbf04481aeffd6cf44bc94cfab3";
        private static HttpClient instance = null;
        public static HttpClient ApiClient
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpClient();
                    InitializeClient();
                }
                return instance;
            }
        }
        public static void InitializeClient()
        {
            // تهيئة الكلاس في دالة البناء واسناد رابط الخدمة البعيدة
            ApiClient.BaseAddress = new Uri(urlServer);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
        }


    }
}