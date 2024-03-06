using MagicTrickServer;
using System;
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

        private void UpdateMatchList()
        {
            string matchesString = Jogo.ListarPartidas("T");
            AddStringToList(lstMatchList, matchesString);
        }

        private void LstMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMatch = lstMatchList.SelectedItem.ToString();
            string[] matchData = selectedMatch.Split(',');
            int matchId = Convert.ToInt32(matchData[0]);

            string playersString = Jogo.ListarJogadores(matchId);
            AddStringToList(lstPlayerList, playersString);
        }

        private void AddStringToList(ListBox lst, string str)
        {
            lst.Items.Clear();

            if (str.Length == 0)
            {
                return;
            }

            str.Replace("\r", "");
            str = str.Substring(0, str.Length - 1);
            string[] list = str.Split('\n');


            for (int i = 0; i < list.Length; i++)
            {
                lst.Items.Add(list[i]);
            }
        }

        private void BtnCreateMatch_Click(object sender, EventArgs e)
        {
            string name = txtMatchName.Text;
            string password = txtMatchPassword.Text;

            if (name == "" || password == "")
            {
                MessageBox.Show("Para criar uma partida você deve preencher os campos de nome e senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = Jogo.CriarPartida(name, password, "Amsterdã");
            txtMatchName.Text = "";
            txtMatchPassword.Text = "";

            if (result.StartsWith("ERRO:"))
            {
                ShowError(result);
            }

            UpdateMatchList();
        }

        private void ShowError(string message)
        {
            string errorMessage = message.Split(':')[1];

            MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
