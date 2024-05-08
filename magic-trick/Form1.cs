using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MagicTrick
{
    public partial class Form1 : Form
    {
        Partida PartidaSelecionada;
        Jogador JogadorSelecionado;
        public Form1()
        {
            InitializeComponent();

            lblVersion.Text = "Versão: " + Jogo.Versao;

            AtualizarListaDePartidas();
        }

        private void LstMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string partidaSelecionada = lstMatchList.SelectedItem?.ToString();
            PartidaSelecionada = Partida.InterpretarRetornoApi(partidaSelecionada);

            if(PartidaSelecionada.Status == 'A')
            {
                btnStartMatch.Text = "Iniciar partida";
            } else
            {
                btnStartMatch.Text = "Abrir partida";
            }

            AtualizarListaDeJogadores();
        }
        private void LstPlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jogadorSelecionado = lstPlayerList.SelectedItem?.ToString();
            if(jogadorSelecionado == null)
            {
                return;
            }
            JogadorSelecionado = Jogador.InterpretarRetornoApi(jogadorSelecionado, PartidaSelecionada.Id);
            txtPlayerId.Text = JogadorSelecionado.Id.ToString();
            txtPlayerName.Text = JogadorSelecionado.Nome;
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

        private void BtnEnterMatch_Click(object sender, EventArgs e)
        {
            if (PartidaSelecionada == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Uma partida tem que estar selecionada.");
                return;
            }

            string nomeJogador = txtPlayerName.Text;
            string senhaPartida = txtMatchPassword.Text;
            string resultado = Jogo.EntrarPartida(PartidaSelecionada.Id, nomeJogador, senhaPartida);

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

        private void BtnStartMatch_Click(object sender, EventArgs e)
        {

            if(txtPlayerId.Text == "" || txtPlayerId.Text == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Selecione um jogador Primeiro");
                return;
            
            }

            if (txtPlayerPassword.Text == "" || txtPlayerPassword.Text == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha a senha do seu jogador primeiro");
                return;
            }

            int idJogador = Convert.ToInt32(txtPlayerId.Text);
            string senhaJogador = txtPlayerPassword.Text;

            if (PartidaSelecionada == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Partida a ser iniciada não foi selecionada");
                return;
            }

            if(PartidaSelecionada.Status != 'A')
            {
                AbraPartida(idJogador, senhaJogador);
                return;
            }

            string resultadoIniciarPartida = Jogo.IniciarPartida(idJogador, senhaJogador);

            if (GerenciadorDeRespostas.PossuiErro(resultadoIniciarPartida))
            {
                GerenciadorDeRespostas.MostrarErro(resultadoIniciarPartida);
                return;
            }



            AbraPartida(idJogador, senhaJogador);
        }

        private void AbraPartida(int idJogador, string senhaJogador)
        {
            List<Jogador> jogadores = Jogador.ListarJogadores(PartidaSelecionada.Id);
            int indexJogador = jogadores.FindIndex(j => j.Id == idJogador);
            jogadores[indexJogador].Senha = senhaJogador;
            MatchForm formulario = new MatchForm(PartidaSelecionada.Id, idJogador, jogadores);
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
            if (PartidaSelecionada == null)
            {
                return;
            }

            string jogadores = Jogo.ListarJogadores(PartidaSelecionada.Id);
            GerenciadorDeRespostas.AdicionarStringALista(lstPlayerList, jogadores);
        }

        private void btnEscolherPartida_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPartidas frm = new frmPartidas();
            frm.ShowDialog();
            this.Show();
        }

        private void BtnAbrirPartida_Click(object sender, EventArgs e)
        {

            if (txtPlayerId.Text == "" || txtPlayerId.Text == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Selecione um jogador Primeiro");
                return;

            }

            if (txtPlayerPassword.Text == "" || txtPlayerPassword.Text == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha a senha do seu jogador primeiro");
                return;
            }

            int idJogador = Convert.ToInt32(txtPlayerId.Text);
            string senhaJogador = txtPlayerPassword.Text;

            if (PartidaSelecionada == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Partida a ser iniciada não foi selecionada");
                return;
            }
            
            AbraPartida(idJogador, senhaJogador);
        }
    }
}
