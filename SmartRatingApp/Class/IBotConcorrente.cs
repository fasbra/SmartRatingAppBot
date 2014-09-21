using SmartRatingApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRatingApp
{
    public interface IBotConcorrente
    {
        IEnumerable<LeituraProduto> RealizarPesquisa(IEnumerable<LeituraProduto> requisicoes);
    }
}
