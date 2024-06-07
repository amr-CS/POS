using appSERP.Models.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace appSERP.ZatcaEInvoicing.LinkPro
{
    public class ZatcaEInvoiceAPI : IZatcaEInvoice
    {
        HttpClient client = ApiHelper.ApiClient;
        private async Task<HttpResponseMessage> post(string TokenDb, InvoiceCreateRequest entity)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
            HttpResponseMessage response = await client.PostAsJsonAsync("invoices/", entity);
           string s= response.StatusCode.ToString();
            // التحقق من نجاح الاستجابة
            //response.EnsureSuccessStatusCode(); // التحقق من نجاح الاستجابة يشير إلى نجاح الطلب أم لا إذا كان لا ستقوم بإلقاء استثناء 
            /*
                وظيفة الدالة EnsureSuccessStatusCode() في فئة HttpResponseMessage هي التحقق مما إذا كان 
                رمز حالة الاستجابة (status code) يشير إلى نجاح الطلب أم لا. إذا كان رمز حالة الاستجابة يشير إلى نجاح (2xx)، فإن الدالة لا تفعل شيئًا وتعود بدون أي استثناء.
                ومع ذلك، إذا كان رمز حالة الاستجابة يشير إلى خطأ (3xx, 4xx, 5xx)، فإن الدالة ستقوم بإلقاء استثناء من 
                نوع HttpRequestException وستتضمن تفاصيل حول الخطأ.
             */
            return response;
        }
        //public async Task<InvoiceResponseDto> SendInvoice(InvoiceCreateRequest entity)
        public async Task<InvoiceResponseDto> SendInvoice(string TokenDb, InvoiceCreateRequest entity)
        {
            InvoiceResponseDto result = new InvoiceResponseDto();
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
                //HttpResponseMessage response = await client.PostAsJsonAsync("invoices/", entity);
                HttpResponseMessage response = await post(TokenDb, entity);
                //response.EnsureSuccessStatusCode(); // التحقق من نجاح الاستجابة يشير إلى نجاح الطلب أم لا إذا كان لا ستقوم بإلقاء استثناء            
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<InvoiceResponseDto>();                    
                }
                result.statusCode = ((int)response.StatusCode).ToString();
                return result;
            }
            catch (Exception)
            {
                result.statusCode = "900";
                return result;
                //throw new ArgumentException("");
            }
        }

        public async Task<string> SendInvoiceStr(string TokenDb, InvoiceCreateRequest entity)
        {
            string result = null;
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
                //HttpResponseMessage response = await client.PostAsJsonAsync("invoices/", entity);
                HttpResponseMessage response = await post(TokenDb, entity);
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                result += ";=;"+((int)response.StatusCode).ToString();
                return result;
            }
            catch (Exception)
            {
                result = "900";
                return result;
                //throw new ArgumentException("");
            }
        }
        
       
    }
}