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
            UpdateMatchList();
        }

        private void LstMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerList();
        }

        private void BtnCreateMatch_Click(object sender, EventArgs e)
        {
            string name = txtMatchName.Text;
            string password = txtMatchPassword.Text;
            string result = Jogo.CriarPartida(name, password, "Amsterdã");

            if (IsError(result))
            {
                ShowError(result);
            }

            UpdateMatchList();
        }

        private void btnEnterMatch_Click(object sender, EventArgs e)
        {
            string selectedMatch = lstMatchList.SelectedItem.ToString();
            string[] matchData = selectedMatch.Split(',');
            int matchId = Convert.ToInt32(matchData[0]);

            string playerName = txtPlayerName.Text;
            string matchPassword = txtMatchPassword.Text;
            string result = Jogo.EntrarPartida(matchId, playerName, matchPassword);

            if (IsError(result))
            {
                ShowError(result);
                return;
            }

            string[] data = result.Split(',');
            txtPlayerId.Text = data[0];
            txtPlayerPassword.Text = data[1];

            UpdatePlayerList();
        }

        private void btnStartMatch_Click(object sender, EventArgs e)
        {
            int playerId = Convert.ToInt32(txtPlayerId.Text);
            string playerPassword = txtPlayerPassword.Text;
            string result = Jogo.IniciarPartida(playerId, playerPassword);

            if (IsError(result))
            {
                ShowError(result);
                return;
            }

            string selectedMatch = lstMatchList.SelectedItem.ToString();
            string[] matchData = selectedMatch.Split(',');
            int matchId = Convert.ToInt32(matchData[0]);

            string res = Jogo.ListarJogadores(matchId);
            string[] players = SplitResultString(res);
            string firstPlayer = "";
            for(int i = 0; i < players.Length; i++)
            {
                if (players[i].Contains(result))
                {
                    firstPlayer = players[i];
                }
            }

            txtFirstPlayer.Text = firstPlayer;
        }

        // Atualiza o componente de lista de partidas com as partidas atuais
        private void UpdateMatchList()
        {
            string matchesString = Jogo.ListarPartidas("T");
            AddStringToList(lstMatchList, matchesString);
        }

        // Atualiza o componente de lista de jogadores com os jogadores da partida selecionada
        private void UpdatePlayerList()
        {
            string selectedMatch = lstMatchList.SelectedItem.ToString();

            if (selectedMatch == "")
            {
                return;
            }

            string[] matchData = selectedMatch.Split(',');
            int matchId = Convert.ToInt32(matchData[0]);

            string playersString = Jogo.ListarJogadores(matchId);
            AddStringToList(lstPlayerList, playersString);
        }

        // Passado uma string e um componente de lista, ele adiciona o conteúdo da string na lista
        private void AddStringToList(ListBox lst, string str)
        {
            lst.Items.Clear();

            if (str.Length == 0)
            {
                return;
            }

            string[] list = SplitResultString(str);

            for (int i = 0; i < list.Length; i++)
            {
                lst.Items.Add(list[i]);
            }
        }

        private string[] SplitResultString(string str)
        {
            str.Replace("\r", "");
            str = str.Substring(0, str.Length - 1);
            return str.Split('\n');
        }

        // Retorna se o resultado de uma chamada é um erro
        private bool IsError(string str)
        {
            return str.StartsWith("ERRO:");
        }

        // Abre uma caixa com a mensagem de erro
        private void ShowError(string message)
        {
            string errorMessage = message.Split(':')[1];

            MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
