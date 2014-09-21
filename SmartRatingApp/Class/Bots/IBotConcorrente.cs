using System.Collections.Generic;
using SmartRatingApp.Class.ViewObject;

namespace SmartRatingApp.Class.Bots
{
    public interface IBotConcorrente
    {
        ProdutoLeituraVO RealizarPesquisa(RequisicaoLeituraVO requisicaoLeitura);
    }
}