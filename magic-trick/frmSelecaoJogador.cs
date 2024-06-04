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
    public partial class frmSelecaoJogador : Form
    {
        public int Id;
        public string Senha;
        public List<Jogador> ListaJogadores;
        private int PartidaId;
        private string PartidaSenha;

        public frmSelecaoJogador(int partidaId, string partidaSenha)
        {
            InitializeComponent();
            PartidaId = partidaId;
            PartidaSenha = partidaSenha;
            CarregarJogadores();
        }

        private void CarregarJogadores()
        {
            List<Jogador> jogadores = Jogador.ListarJogadores(PartidaId);
            ListaJogadores = jogadores;
            dgvJogador.DataSource = jogadores;
        }

        private void btnSelecionar_click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(txtId.Text);
            Senha = txtSenha.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregarJogadores();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            if (nome == "" || nome == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha o nome do jogador primeiro");
                return;

            }

            string resultado = Jogo.EntrarPartida(PartidaId, nome, PartidaSenha);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }

            string[] dadosJogador = resultado.Split(',');
            txtId.Text = dadosJogador[0];
            txtSenha.Text = dadosJogador[1];

            CarregarJogadores();
        }

        private void dgvJogador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var jogador = dgvJogador.SelectedRows[0];

            if (jogador != null)
            {
                Jogador carregar = (Jogador)jogador.DataBoundItem;
                txtId.Text = Convert.ToString(carregar.Id);
                txtNome.Text = carregar.Nome;
            }
        }
    }
}
