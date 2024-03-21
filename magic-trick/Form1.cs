using MagicTrickServer;
using System;
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

            if (PossuiErro(resultado))
            {
                MostrarErro(resultado);
            }

            AtualizarListaDePartidas();
        }

        private void btnEnterMatch_Click(object sender, EventArgs e)
        {
            string partidaSelecionada = lstMatchList.SelectedItem.ToString();
            string[] dadosPartida = partidaSelecionada.Split(',');
            int idPartida = Convert.ToInt32(dadosPartida[0]);

            string nomeJogador = txtPlayerName.Text;
            string senhaPartida = txtMatchPassword.Text;
            string resultado = Jogo.EntrarPartida(idPartida, nomeJogador, senhaPartida);

            if (PossuiErro(resultado))
            {
                MostrarErro(resultado);
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

            if (PossuiErro(resultadoIniciarPartida))
            {
                MostrarErro(resultadoIniciarPartida);
                return;
            }

            string partidaSelecionada = lstMatchList.SelectedItem.ToString();
            string[] dadosPartida = partidaSelecionada.Split(',');
            int idPartida = Convert.ToInt32(dadosPartida[0]);

            string resultadorListarJogadores = Jogo.ListarJogadores(idPartida);
            string[] jogadores = SepararStringDeResultado(resultadorListarJogadores);
            string primeiroJogador = "";
            for(int i = 0; i < jogadores.Length; i++)
            {
                if (jogadores[i].Contains(resultadoIniciarPartida))
                {
                    primeiroJogador = jogadores[i];
                }
            }

            txtFirstPlayer.Text = primeiroJogador;
            MatchForm formulario = new MatchForm(idPartida);
            formulario.Show();
        }

        // Atualiza o componente de lista de partidas com as partidas atuais
        private void AtualizarListaDePartidas()
        {
            string partidas = Jogo.ListarPartidas("T");
            AdicionarStringALista(lstMatchList, partidas);
        }

        // Atualiza o componente de lista de jogadores com os jogadores da partida selecionada
        private void AtualizarListaDeJogadores()
        {
            string partidaSelecionada = lstMatchList.SelectedItem.ToString();

            if (partidaSelecionada == "")
            {
                return;
            }

            string[] dadosPartida = partidaSelecionada.Split(',');
            int idPartida = Convert.ToInt32(dadosPartida[0]);

            string jogadores = Jogo.ListarJogadores(idPartida);
            AdicionarStringALista(lstPlayerList, jogadores);
        }

        // Passado uma string e um componente de lista, ele adiciona o conteúdo da string na lista
        private void AdicionarStringALista(ListBox lst, string str)
        {
            lst.Items.Clear();

            if (str.Length == 0)
            {
                return;
            }

            string[] list = SepararStringDeResultado(str);

            for (int i = 0; i < list.Length; i++)
            {
                lst.Items.Add(list[i]);
            }
        }

        private string[] SepararStringDeResultado(string str)
        {
            str.Replace("\r", "");
            str = str.Substring(0, str.Length - 1);
            return str.Split('\n');
        }

        // Retorna se o resultado de uma chamada é um erro
        private bool PossuiErro(string str)
        {
            return str.StartsWith("ERRO:");
        }

        // Abre uma caixa com a mensagem de erro
        private void MostrarErro(string message)
        {
            string errorMessage = message.Split(':')[1];

            MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
