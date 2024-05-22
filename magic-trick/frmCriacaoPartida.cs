using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick
{
    public partial class frmCriacaoPartida : Form
    {
        public string Senha { get; set; }
        public int Id { get; set; }

        public frmCriacaoPartida()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string senha = txtSenha.Text;
            string resultado = Jogo.CriarPartida(nome, senha, "Amsterdã");

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }

            Senha = senha;
            Id = Convert.ToInt32(resultado);

            DialogResult = DialogResult.OK;
        }
    }
}
