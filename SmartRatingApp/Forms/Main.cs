using System.Windows.Forms;
using SmartRatingApp.Class.Bots.Base;
using SmartRatingApp.Class.Bots.Base.Const;
using SmartRatingApp.Class.Bots.Base.Impl;
using SmartRatingApp.Class.Service.Impl;

namespace SmartRatingApp.Forms
{
    public partial class Main : Form
    {
        private ProdutoLeituraAPIService produtoLeituraApi;
        private IBotFactory botFactory;

        public Main()
        {
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            produtoLeituraApi = new ProdutoLeituraAPIService();
            botFactory = new BotFactory();
        }

        private void btn1_Click(object sender, System.EventArgs e)
        {
            var requisicoes = produtoLeituraApi.GetAll();

            foreach (var requisicao in requisicoes)
            {
                if (requisicao.IdConcorrente == 4)
                {
                    var botConcorrente = botFactory.CreateBotConcorrente((Concorrente) requisicao.IdConcorrente);
                    var produtosLeitura = botConcorrente.RealizarPesquisa(requisicao);
                }
            }
        }
    }
}