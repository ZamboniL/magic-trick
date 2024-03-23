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
        public Jogador Jogador { get; set; }
        public Jogador Oponente {  get; set; }

        public MatchForm(int idPartida, Jogador jogador, Jogador oponente)
        {
            InitializeComponent();
            this.Jogador = jogador;
            this.Oponente = oponente;

            lblJogador.Text = jogador.Nome;
            lblOponente.Text = oponente.Nome;

            string resultado = Jogo.ConsultarMao(idPartida);
            string[] maos = GerenciadorDeRespostas.SepararStringDeResposta(resultado);
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

        private void btnJogarCarta_Click(object sender, EventArgs e)
        {
            string cartaSelecionada = lstCartas1.SelectedItem?.ToString();

            if(cartaSelecionada == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Nenhuma carta foi selecionada.");
                return;
            }

            string resultado = Jogador.JogarCarta(cartaSelecionada);

            if(GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }

            txtCartaJogada.Text = resultado;
        }

        private void btnApostar_Click(object sender, EventArgs e)
        {
            int aposta;

            try
            {
                aposta = Convert.ToInt32(txtAposta.Text);

            } catch {
                GerenciadorDeRespostas.MostrarErro("ERRO: Valor de aposta tem que ser um número");
                return;
            }

            string resultado = Jogador.Apostar(aposta);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }

            txtCartaApostada.Text = resultado;
        }
    }
}
