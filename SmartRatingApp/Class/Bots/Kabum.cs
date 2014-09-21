using HtmlAgilityPack;
using SmartRatingApp.Class.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRatingApp.Class.Bots
{
    public class Kabum : IBotConcorrente
    {
        public int Id { get { return 2; } }
        public string Url { get { return "http://www.kabum.com.br/cgi-local/site/listagem/listagem.cgi?string={0}&btnG="; } }

        
        public IEnumerable<LeituraProduto> RealizarPesquisa(IEnumerable<LeituraProduto> requisicoes)
        {
            var produtos = new List<LeituraProduto>();

            HtmlWeb web = new HtmlWeb();
            var htmlDocument = web.Load(string.Format(this.Url,"celular"));

            return produtos;
        }
    }
}
