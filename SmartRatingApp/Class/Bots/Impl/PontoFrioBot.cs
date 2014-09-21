using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using SmartRatingApp.Class.ViewObject;

namespace SmartRatingApp.Class.Bots.Impl
{
    public class PontoFrioBot : IBotConcorrente
    {
        public const string URL_BASE = "http://search.pontofrio.com.br";
        public const string URL_BUSCA = URL_BASE + "/search?w=";

        public ProdutoLeituraVO RealizarPesquisa(RequisicaoLeituraVO requisicaoLeitura)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDocument = htmlWeb.Load(URL_BUSCA + requisicaoLeitura.NomeProduto);

            IEnumerable<HtmlNode> resultados = htmlDocument.DocumentNode
                                            .Descendants("ul")
                                            .Where(ul => ul.GetAttributeValue("class", "").Contains("vitrineProdutos"))
                                            .SelectMany(ul => ul.Descendants("li"))
                                            .ToArray();


            foreach (var resultado in resultados)
            {
                //Console.WriteLine(string.Format("Link href={0}, link text={1}", link.Attributes["href"].Value, link.InnerText));
            }

            return null;
        }
    }
}
