using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SmartRatingApp.Class.ViewObject;

namespace SmartRatingApp.Class.Service.Impl
{
    public class ProdutoLeituraAPIService : IService
    {
        private string URI_BASE = "http://smartrating.apphb.com";
        private string URI_GET = "/api/ProdutoLeitura/?guid=f9101313-c8cb-4646-a4f7-c2bf57d4ecad";

        public List<RequisicaoLeituraVO> RequisicaoLeituraList { get; set; }
        public List<ProdutoLeituraVO> ProdutoLeituraList { get; set; }

        public ProdutoLeituraAPIService()
        {
            RequisicaoLeituraList = new List<RequisicaoLeituraVO>();
            ProdutoLeituraList = new List<ProdutoLeituraVO>();
        }

        public List<RequisicaoLeituraVO> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI_BASE);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage  response = client.GetAsync(URI_GET).Result;
                var requisicoesString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<RequisicaoLeituraVO[]>(requisicoesString).ToList();
            }
        }
    }
}
