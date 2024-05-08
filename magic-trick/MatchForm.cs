using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MagicTrickServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MagicTrick
{
    public partial class MatchForm : Form
    {
        private Turno Turno {  get; set; }
        private int IdPartida {  get; set; }
        public int IdJogador { get; set; }
        public List<Jogador> Jogadores { get; set; }
        private Automato Robo;

        public MatchForm(int idPartida, int idJogador, List<Jogador> jogadores)
        {
            InitializeComponent();
            lblVersao.Text = "Versão: " + Jogo.Versao;

            IdJogador = idJogador;
            IdPartida = idPartida;
            Jogadores = jogadores;
            Turno = new Turno(idPartida);

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
            Turno.Atualizar();
            if(!Turno.Mudou) { return; };

            AdicionarJogadas();
            AdicionarApostas();
            AdicionarVitorias();
            AtualizarPlacar();

            lblTurno.Text = $"Turno: {Jogadores.Find(j => j.Id == Turno.Jogador).Nome}\nRodada: {Turno.Rodada}\n{(Turno.Acao == 'C' ? "Jogar carta" : "Apostar")}";
        }

        private void AdicionarJogadas()
        {
            gpbJogada.Controls.Clear();
            foreach (Carta jogada in Turno.Jogadas)
            {
                Jogador jogador = Jogadores.Find(j => j.Id == jogada.IdJogador);
                int cartaOriginal = jogador.Mao.FindIndex(c => c.Naipe == jogada.Naipe && c.Posicao == jogada.Posicao);

                if(cartaOriginal != -1)
                {
                    Controls.Remove(jogador.Mao[cartaOriginal].Panel);
                    jogador.Mao.RemoveAt(cartaOriginal);
                }

                jogada.Virar(jogada.Valor);
                gpbJogada.Controls.Add(jogada.Panel);
                jogada.Panel.Location = new Point(8, 20);
                jogada.Panel.BringToFront();
            }
        }

        private void AdicionarApostas()
        {
            gpbAposta.Controls.Clear();
            foreach (Carta aposta in Turno.Apostas)
            {
                Jogador jogador = Jogadores.Find(j => j.Id == aposta.IdJogador);
                jogador.Aposta = aposta.Valor;
                int cartaOriginal = jogador.Mao.FindIndex(c => c.Naipe == aposta.Naipe && c.Posicao == aposta.Posicao);
                
                if (cartaOriginal != -1)
                {
                    Controls.Remove(jogador.Mao[cartaOriginal].Panel);
                    jogador.Mao.RemoveAt(cartaOriginal);
                }

                aposta.Virar(aposta.Valor);
                gpbAposta.Controls.Add(aposta.Panel);
                aposta.Panel.Location = new Point(8, 20);
                aposta.Panel.BringToFront();
            }
        }

        private void AdicionarVitorias()
        {
            foreach(KeyValuePair<int,int> entry in Turno.Vitorias) {
                Jogador jogador = Jogadores.Find(j => j.Id == entry.Key);
                jogador.Vitorias += entry.Value;
            }
        }

        private void AtualizarPlacar()
        {
            foreach(Jogador jogador in Jogadores)
            {
                jogador.AtualizarLabel();
            }
        }

        private void MostrarMaos()
        {
            for (int i = 0; i < Jogadores.Count; i++)
            {
                Jogador jogador = Jogadores[i];
                if (i < 2)
                {
                    MostrarMaoHorizontal(jogador);
                } else
                {
                    MostrarMaoVertical(jogador);
                }
            }
        }

        private void MostrarMaoHorizontal(Jogador jogador)
        {
            List<Carta> mao = jogador.Mao;
            int indiceJogador = Jogadores.IndexOf(jogador);
            int tamanhoMao = Jogadores.Count > 2 ? 14 : 12;
            int metade = tamanhoMao / 2;
            int espacamento = 8;

            int inicioTopo = indiceJogador == 0 ? 20 : this.Height - ((Carta.Height * 3) + 8);
            int inicioEsquerda = (this.Width / 2) - ((Carta.Width * metade) + (espacamento * (metade - 1))) / 2;

            jogador.Label.Top = indiceJogador == 0 ? inicioTopo + (Carta.Height * 2) + espacamento + 20 : inicioTopo - 20 - espacamento;
            jogador.Label.Left = inicioEsquerda;
            this.Controls.Add(jogador.Label);
            
            for (int i = 0; i < mao.Count; i++)
            {
                Carta carta = mao[i];
                int posicao = (carta.Posicao - 1) % metade;
                int topo = (carta.Posicao - 1) < metade ? inicioTopo : (inicioTopo + Carta.Height + espacamento);
                int esquerda = inicioEsquerda + (posicao * Carta.Width) + (posicao * espacamento);

                AdicionarCartaMesa(topo, esquerda, carta);
            }
        }

        private void MostrarMaoVertical(Jogador jogador)
        {
            List<Carta> mao = jogador.Mao;
            int indiceJogador = Jogadores.IndexOf(jogador);
            int tamanhoMao = Jogadores.Count > 2 ? 14 : 12;
            int metade = tamanhoMao / 2;
            int espacamento = 8;

            int inicioEsquerda = indiceJogador == 0 ? 20 : this.Width - ((Carta.Width * 3) + 8);
            int inicioTopo = (this.Height / 2) - ((Carta.Height * metade) + (espacamento * (metade - 1))) / 2;

            jogador.Label.Top = inicioTopo;
            jogador.Label.Left = indiceJogador == 0 ? inicioEsquerda + (Carta.Width * 2) + espacamento + 20 : inicioEsquerda - 40 - espacamento;
            this.Controls.Add(jogador.Label);

            for (int i = 0; i < mao.Count; i++)
            {
                Carta carta = mao[i];
                int posicao = (carta.Posicao - 1) % metade;
                int topo = inicioTopo + (posicao * Carta.Height) + (posicao * espacamento);
                int esquerda = (carta.Posicao - 1) < metade ? inicioEsquerda : (inicioEsquerda + Carta.Width + espacamento);

                AdicionarCartaMesa(topo, esquerda, carta);
            }
        }

        private void AdicionarCartaMesa(int topo, int esquerda, Carta carta)
        {
            carta.Panel.Left = esquerda;
            carta.Panel.Top = topo;

            this.Controls.Add(carta.Panel);
        }

        private void TmrJogador_Tick(object sender, EventArgs e)
        {
            AtualizarTurno();

            if(Robo == null)
            {
                Robo = new Automato(IdPartida, Turno.Rodada);
                foreach (Jogador jogador in Jogadores)
                {
                    Robo.InicializarPossibilidades(jogador.Mao);
                }
            } else
            {
                Robo.AtualizarRodada(Turno.Rodada, Jogadores);
            }

            foreach(Jogador jogador in Jogadores)
            {
                Console.WriteLine($"{jogador.Id} - {jogador.Nome}:");
                foreach(Carta carta in jogador.Mao)
                {
                    Console.WriteLine($"{carta.Posicao} - {carta.Naipe}: {String.Join(", ", carta.Possibilidades)}");
                }
                Console.WriteLine("");
            }

            if(IdJogador != Turno.Jogador)
            {
                return;
            }

            Jogador jogadorAtual = Jogadores.Find(j => j.Id == IdJogador);
            if(Turno.Acao == 'C')
            {
                Carta jogada = Robo.EscolherCarta(jogadorAtual.Mao, jogadorAtual.Aposta, jogadorAtual.Vitorias);
                jogadorAtual.Jogar(jogada.Posicao);
            } else
            {
                int aposta = Robo.EscolherAposta(jogadorAtual.Mao);
                jogadorAtual.Apostar(aposta);
            }

            AtualizarTurno();
        }

        private void BtnIniciarTimer_Click(object sender, EventArgs e)
        {
            tmrJogador.Enabled = true;
            btnIniciarTimer.Visible = false;
        }


        //private void BtnJogar_Click(object sender, EventArgs e)
        //{
        //    if(txtCarta.Text == "")
        //    {
        //        return;
        //    }

        //    int posicao = Convert.ToInt32(txtCarta.Text);

        //    int indiceJogador = Jogadores.FindIndex(j => j.Id == IdJogadorAtual);
        //    Jogador jogadorAtual = Jogadores[indiceJogador]; Carta cartaJogada = jogadorAtual.Mao.Find(c => c.Posicao == posicao);
        //    int valor = jogadorAtual.Jogar(indiceJogador == 0 ? txtSenhaJogador1.Text : txtSenhaJogador2.Text, posicao);

        //    if(valor == -1) { return; }

        //    cartaJogada.Virar(valor);
        //    gpbJogada.Controls.Add(cartaJogada.Panel);
        //    cartaJogada.Panel.Location = new Point(8, 20);
        //    cartaJogada.Panel.BringToFront();

        //    gpbAposta.Controls.Clear();

        //    AtualizarTurno();
        //}

        //private void BtnApostar_Click(object sender, EventArgs e)
        //{
        //    if (txtAposta.Text == "")
        //    {
        //        return;
        //    }

        //    int posicao = Convert.ToInt32(txtAposta.Text);

        //    int indiceJogador = Jogadores.FindIndex(j => j.Id == IdJogadorAtual);
        //    Jogador jogadorAtual = Jogadores[indiceJogador];
        //    int valor = jogadorAtual.Apostar(indiceJogador == 0 ? txtSenhaJogador1.Text : txtSenhaJogador2.Text, posicao);

        //    if (posicao != 0)
        //    {
        //        Carta cartaApostada = jogadorAtual.Mao.Find(c => c.Posicao == posicao);
        //        cartaApostada.Virar(valor);
        //        gpbAposta.Controls.Add(cartaApostada.Panel);
        //        cartaApostada.Panel.Location = new Point(8, 20);
        //        cartaApostada.Panel.BringToFront();
        //    }

        //    if(valor == -1)
        //    {
        //        return;
        //    }

        //    AtualizarTurno();
        //}
    }
}
