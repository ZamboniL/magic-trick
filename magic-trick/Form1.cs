using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagicTrickServer;

namespace MagicTrick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblVersion.Text = "Versão: " + Jogo.Versao;
            this.UpdateMatchList();
        }

        private void UpdateMatchList()
        {
            var matchesString = Jogo.ListarPartidas("T");
            this.AddStringToList(lstMatchList, matchesString);
        }

        private void LstMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMatch = lstMatchList.SelectedItem.ToString();
            var matchData = selectedMatch.Split(',');
            int matchId = Convert.ToInt32(matchData[0]);

            var playersString = Jogo.ListarJogadores(matchId);
            this.AddStringToList(lstPlayerList, playersString);
        }

        private void AddStringToList(ListBox lst,  string str)
        {
            if(str.Length == 0)
            {
                return;
            }

            str.Replace("\r", "");
            str = str.Substring(0, str.Length - 1);
            var list = str.Split('\n');

            lst.Items.Clear();

            for (int i = 0; i < list.Length; i++)
            {
                lst.Items.Add(list[i]);
            }
        }

        private void BtnCreateMatch_Click(object sender, EventArgs e)
        {
            var name = txtMatchName.Text;
            var password = txtMatchPassword.Text;

            if(name == "" || password == "")
            {
                MessageBox.Show("Para criar uma partida você deve preencher os campos de nome e senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = Jogo.CriarPartida(name, password, "Amsterdã");

            if(result.StartsWith("ERRO:"))
            {
                this.ShowError(result);
            }

            this.UpdateMatchList();
        }

        private void ShowError(string message)
        {
             var errorMessage = message.Split(':')[1];

            MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
