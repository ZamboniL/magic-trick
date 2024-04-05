using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MagicTrickServer;

namespace MagicTrick
{
    public partial class MatchForm : Form
    {
        private int IdPartida {  get; set; }
        public List<Jogador> Jogadores { get; set; }

        public MatchForm(int idPartida, List<Jogador> jogadores)
        {
            InitializeComponent();

            IdPartida = idPartida;
            Jogadores = jogadores;

            List<Carta> cartas = Carta.ListarCartas(idPartida);
            
            foreach(Jogador jogador in jogadores)
            {
                jogador.AdicionarMao(cartas);
            }

            MostrarMaos();
            AtualizarTurno();
        }

        private void AtualizarTurno()
        {
            string resultado = Jogo.VerificarVez(IdPartida);
            string[] vezDados = resultado.Split(',');
            Jogador jogadorAtual = Jogadores.Find(j => j.Id == Convert.ToInt32(vezDados[1]));
            Console.WriteLine(resultado);

            lblTurno.Text = $"Turno: {jogadorAtual.Nome}";
        }

        private void MostrarMaos()
        {
            for (int i = 0; i < Jogadores.Count; i++)
            {
                Jogador jogador = Jogadores[i];
                if (i < 2)
                {
                    MostrarMaoHorizontal(jogador.Mao, i, jogador.Nome);
                } else
                {
                    MostrarMaoVertical(jogador.Mao, i, jogador.Nome);
                }
            }
        }

        private void MostrarMaoHorizontal(List<Carta> mao, int indexJogador, string nomeJogador)
        {
            int metade = mao.Count / 2;
            int espacamento = 8;

            int inicioTopo = indexJogador == 0 ? 20 : this.Height - ((Carta.Height * 3) + 8);
            int inicioEsquerda = (this.Width / 2) - ((Carta.Width * metade) + (espacamento * (metade - 1))) / 2;

            Label lblNome = new Label();
            lblNome.Text = nomeJogador;
            lblNome.Top = indexJogador == 0 ? inicioTopo + (Carta.Height * 2) + espacamento + 20 : inicioTopo - 20 - espacamento;
            lblNome.Left = inicioEsquerda;
            lblNome.AutoSize = true;
            this.Controls.Add(lblNome);
            
            for (int i = 0; i < mao.Count; i++)
            {
                Carta carta = mao[i];

                int posicao = carta.Posicao % metade;
                int topo = i < metade ? inicioTopo : (inicioTopo + Carta.Height + espacamento);
                int esquerda = inicioEsquerda + (posicao * Carta.Width) + (posicao * espacamento);
                AdicionarCartaMesa(topo, esquerda, carta);
            }
        }

        private void MostrarMaoVertical(List<Carta> mao, int indexJogador, string nomeJogador)
        {
            int metade = mao.Count / 2;
            int espacamento = 8;

            int inicioEsquerda = indexJogador == 0 ? 20 : this.Width - ((Carta.Width * 3) + 8);
            int inicioTopo = (this.Height / 2) - ((Carta.Height * metade) + (espacamento * (metade - 1))) / 2;

            Label lblNome = new Label();
            lblNome.Text = nomeJogador;
            lblNome.Top = inicioTopo;
            lblNome.Left = indexJogador == 0 ? inicioEsquerda + (Carta.Width * 2) + espacamento + 20 : inicioEsquerda - 40 - espacamento;
            lblNome.AutoSize = true;
            this.Controls.Add(lblNome);

            for (int i = 0; i < mao.Count; i++)
            {
                Carta carta = mao[i];
                int posicao = carta.Posicao % metade;
                int topo = inicioTopo + (posicao * Carta.Height) + (posicao * espacamento);
                int esquerda = i < metade ? inicioEsquerda : (inicioEsquerda + Carta.Width + espacamento);

                AdicionarCartaMesa(topo, esquerda, carta);
            }
        }

        private void AdicionarCartaMesa(int topo, int esquerda, Carta carta)
        {
            Panel pnlCarta = new Panel();

            pnlCarta.BackgroundImage = carta.Imagem;
            pnlCarta.Left = esquerda;
            pnlCarta.Top = topo;
            pnlCarta.Height = Carta.Height;
            pnlCarta.Width = Carta.Width;

            pnlCarta.BackColor = Color.Transparent;
            pnlCarta.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pnlCarta);
            carta.Panel = pnlCarta;
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {

        }

        private void btnApostar_Click(object sender, EventArgs e)
        {

        }
    }
}
