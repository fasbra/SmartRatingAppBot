using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SmartRatingApp.Class.ViewObject;

namespace SmartRatingApp.Class.Bots.Impl
{
    public class SubmarinoBot : IBotConcorrente
    {
        public const string URL_BASE = "http://busca.submarino.com.br/";
        public const string URL_BUSCA = URL_BASE + "/busca.php?q=";
        public ProdutoLeituraVO RealizarPesquisa(RequisicaoLeituraVO requisicaoLeitura)
        {
            var produtoLeitura = new ProdutoLeituraVO
            {
                IdConcorrente = requisicaoLeitura.IdConcorrente,
                IdProduto = requisicaoLeitura.IdProduto,
                Preco = 0
            };

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDocument = htmlWeb.Load(URL_BUSCA + requisicaoLeitura.NomeProduto);

            List<HtmlNode> resultados = htmlDocument.DocumentNode
                                            .Descendants("div")
                                            .Where(div => div.GetAttributeValue("class", "").Contains("productInfo"))
                                            .ToList();

            foreach (var resultado in resultados)
            {
                HtmlNode link = resultado.SelectSingleNode("//a[@title='" + requisicaoLeitura.NomeProduto + "']");

                if(link == null)
                    continue;

                var url = link.GetAttributeValue("href", "");
                htmlDocument = htmlWeb.Load(url);

                var valoresHtml = htmlDocument.DocumentNode
                            .Descendants("div")
                            .Where(div => div.GetAttributeValue("class", "").Contains("mp-price"))
                            .ToList();

                foreach (var valorHtml in valoresHtml)
                {
                    if (valorHtml.InnerText.Contains("De"))
                        continue;
                    produtoLeitura.Preco = Convert.ToDecimal(valorHtml.InnerText.Replace("\n\t\t\t\t\t R$ ", "").Replace("\n\t\t\t\t", ""));
                }
            }

            produtoLeitura.Disponivel = produtoLeitura.Preco > 0;

            return produtoLeitura;
        }
    }
}
