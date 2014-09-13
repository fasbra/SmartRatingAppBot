using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRatingApp.Class.Bots
{
    public class PontoFrio : IBotConcorrente
    {
        public IEnumerable<LeituraProduto> RealizarPesquisa(IEnumerable<LeituraProduto> requisicoes)
        {
            //Codigo que raspa o site do PontoFrio usando o HAP
            return null;
        }
    }
}
