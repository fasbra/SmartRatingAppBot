using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRatingApp.Class.Bots
{
    public class PontoFrio : IBotConcorrente
    {

        public int Id { get { return 1; } }
        public string Url { get { return "http://search.pontofrio.com.br/search?w={0}&utm_source=Google&utm_medium=BuscaOrganica&utm_campaign=DescontoEspecial"; } }

        public IEnumerable<LeituraProduto> RealizarPesquisa(List<LeituraProduto> requisicoes)
        {
            var produtos = new List<LeituraProduto>();

            for (int rs = 0; rs < requisicoes.ToArray().Count(); rs++)
            {
                HtmlWeb web = new HtmlWeb();
                var htmlDocument = web.Load(string.Format(this.Url, requisicoes[rs].NomeProduto.Replace(" ", "%20")));

                var elements = htmlDocument.DocumentNode.SelectNodes("//ul[contains(@class,'vitrineProdutos')]");
                for (int e = 0; e < elements.Count(); e++)
                {
                    var linkProdutos = elements[e].SelectNodes("//a[contains(@class,'link url')]");
                    for (int lps = 0; lps < linkProdutos.Count(); lps++)
                    {
                        string produtoUrl = linkProdutos[lps].Attributes.Where(a => a.Name == "title").Select(a => a.Value).ToArray().First();
                    }
                }
            }

            return produtos;
        }
    }
}
