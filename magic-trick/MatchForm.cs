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
    public partial class MatchForm : Form
    {
        public MatchForm(int idPartida)
        {
            InitializeComponent();
            string resultado = Jogo.ConsultarMao(idPartida);
            string[] maos = SepararStringDeResultado(resultado);
            string primeiraCarta = maos[0];
            string primeiroId = primeiraCarta.Split(',')[0];
            for(int i=0; i< maos.Length; i++)
            {
                string carta = maos[i];
                if (carta.Contains(primeiroId))
                {
                    lstCartas1.Items.Add(carta);
                }
                else
                {
                    lstCartas2.Items.Add(carta);
                }
            }
        }
        private string[] SepararStringDeResultado(string str)
        {
            str.Replace("\r", "");
            str = str.Substring(0, str.Length - 1);
            return str.Split('\n');
        }

        private void btnJogarCarta_Click(object sender, EventArgs e)
        {
            string cartaSelecionada = lstCartas1.SelectedItem.ToString();
            int posicaoCarta = Int32.Parse(cartaSelecionada.Split(',')[1]);

        }
    }
}
