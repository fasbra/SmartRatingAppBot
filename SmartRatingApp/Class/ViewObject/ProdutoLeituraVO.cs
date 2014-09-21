namespace SmartRatingApp.Class.ViewObject
{
    public class ProdutoLeituraVO
    {
        public long IdProduto { get; set; }
        public long IdConcorrente { get; set; }
        public bool Disponivel { get; set; }
        public decimal Preco { get; set; }
    }
}
