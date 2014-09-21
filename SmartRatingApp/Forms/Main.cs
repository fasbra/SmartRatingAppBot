<<<<<<< HEAD
﻿using SmartRatingApp.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
=======
﻿using System.Windows.Forms;
using SmartRatingApp.Class.Bots.Base;
using SmartRatingApp.Class.Bots.Base.Const;
using SmartRatingApp.Class.Bots.Base.Impl;
using SmartRatingApp.Class.Service.Impl;
>>>>>>> 78e54b9... Estrutura básica

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
                var botConcorrente = botFactory.CreateBotConcorrente((Concorrente) requisicao.IdConcorrente);
                var produtosLeitura = botConcorrente.RealizarPesquisa(requisicao);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Aplicacao.ExecutaAtualizacaoPrecos();
        }
    }
}
