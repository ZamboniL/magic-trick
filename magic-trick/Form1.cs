using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MagicTrick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblVersion.Text = "Versão: " + Jogo.Versao;
            AtualizarListaDePartidas();

            int idPartida = Convert.ToInt32(2021);

            List<Jogador> jogadores = Jogador.ListarJogadores(idPartida);

            MatchForm formulario = new MatchForm(idPartida, jogadores);
            formulario.Show();
        }

        private void LstMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarListaDeJogadores();
        }

        private void BtnCreateMatch_Click(object sender, EventArgs e)
        {
            string nomePartida = txtMatchName.Text;
            string senhaPartida = txtMatchPassword.Text;
            string resultado = Jogo.CriarPartida(nomePartida, senhaPartida, "Amsterdã");

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
            }

            AtualizarListaDePartidas();
        }

        private void btnEnterMatch_Click(object sender, EventArgs e)
        {
            string partidaSelecionada = lstMatchList.SelectedItem?.ToString();

            if (partidaSelecionada == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Uma partida tem que estar selecionada.");
                return;
            }

            string[] dadosPartida = partidaSelecionada.Split(',');
            int idPartida = Convert.ToInt32(dadosPartida[0]);

            string nomeJogador = txtPlayerName.Text;
            string senhaPartida = txtMatchPassword.Text;
            string resultado = Jogo.EntrarPartida(idPartida, nomeJogador, senhaPartida);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }

            string[] dadosJogador = resultado.Split(',');
            txtPlayerId.Text = dadosJogador[0];
            txtPlayerPassword.Text = dadosJogador[1];

            AtualizarListaDeJogadores();
        }

        private void btnStartMatch_Click(object sender, EventArgs e)
        {
            int idJogador = Convert.ToInt32(txtPlayerId.Text);
            string senhaJogador = txtPlayerPassword.Text;
            string resultadoIniciarPartida = Jogo.IniciarPartida(idJogador, senhaJogador);

            if (GerenciadorDeRespostas.PossuiErro(resultadoIniciarPartida))
            {
                GerenciadorDeRespostas.MostrarErro(resultadoIniciarPartida);
                return;
            }

            string partidaSelecionada = lstMatchList.SelectedItem?.ToString();

            if (partidaSelecionada == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Partida a ser iniciada não foi selecionada");
                return;
            }

            string[] dadosPartida = partidaSelecionada.Split(',');
            int idPartida = Convert.ToInt32(dadosPartida[0]);

            List<Jogador> jogadores = Jogador.ListarJogadores(idPartida);

            MatchForm formulario = new MatchForm(idPartida, jogadores);
            formulario.Show();
        }

        // Atualiza o componente de lista de partidas com as partidas atuais
        private void AtualizarListaDePartidas()
        {
            string partidas = Jogo.ListarPartidas("T");
            GerenciadorDeRespostas.AdicionarStringALista(lstMatchList, partidas);
        }

        // Atualiza o componente de lista de jogadores com os jogadores da partida selecionada
        private void AtualizarListaDeJogadores()
        {
            string partidaSelecionada = lstMatchList.SelectedItem?.ToString();

            if (partidaSelecionada == "" || partidaSelecionada == null)
            {
                return;
            }

            string[] dadosPartida = partidaSelecionada.Split(',');
            int idPartida = Convert.ToInt32(dadosPartida[0]);

            string jogadores = Jogo.ListarJogadores(idPartida);
            GerenciadorDeRespostas.AdicionarStringALista(lstPlayerList, jogadores);
        }

        private void btnEscolherPartida_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPartidas frm = new frmPartidas();
            frm.ShowDialog();
            this.Show();
        }
    }
}
