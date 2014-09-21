using HtmlAgilityPack;
using SmartRatingApp.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace SmartRatingApp
{
    public class Aplicacao
    {
        public static void ExecutaAtualizacaoPrecos()
        {
            var nameSpace = "SmartRatingApp.Class.Bots";
            var bots = Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => t.Namespace == nameSpace).ToList();
            for (int i = 0; i < bots.Count; i++)
            {

                Type type = Type.GetType(nameSpace + "." + bots[i].Name);
                var instance = Activator.CreateInstance(type);
                PropertyInfo property = type.GetProperty("Id");

                var id = (int)property.GetValue(instance, null);
                var bot = BotFactory.CreateBot(id);

                var produtos = "http://smartrating.apphb.com/api/ProdutoLeitura/?guid=f9101313-c8cb-4646-a4f7-c2bf57d4ecad";
                
                foreach (var x in bot.RealizarPesquisa(null))
                {

                }
            }
        }

    }
}
