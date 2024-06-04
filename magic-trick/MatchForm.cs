using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MagicTrickServer;

namespace MagicTrick
{
    public partial class MatchForm : Form
    {
        private Turno Turno {  get; set; }
        private int Id {  get; set; }
        private string Senha {  get; set; }
        private int IdJogadorControlado;
        private string SenhaJogadorControlado;
        public int IdJogador { get; set; }
        public List<Jogador> Jogadores { get; set; }
        private Automato Robo;

        public MatchForm(int id, string senha)
        {
            InitializeComponent();

            Id = id;
            Senha = senha;
            Turno = new Turno(Id);

            CarregarJogadores();
            CarregarPartida();
        }

        private void CarregarJogadores()
        {
            List<Jogador> jogadores = Jogador.ListarJogadores(Id);
            Jogadores = jogadores;
        }

        private void CarregarPartida()
        {
            AtualizarTurno();
            InicializarRodada();

            if (Turno.StatusPartida != 'A')
            {
                btnIniciarPartida.Enabled = false;
                btnIniciarPartida.Image = Properties.Resources.iniciar_partida_disabled;
                
                btnJogador.Enabled = false;
                btnJogador.Image = Properties.Resources.person_off;

                btnReloadTurno.Enabled = false;
                btnReloadTurno.Image = Properties.Resources.reload_off;

                btnIniciarTimer.Enabled = true;
                btnIniciarTimer.Image = Properties.Resources.iniciar_robo;
            } else
            {
                btnIniciarTimer.Enabled = false;
                btnIniciarTimer.Image = Properties.Resources.iniciar_robo_disabled;

                btnJogador.Enabled = true;
                btnJogador.Image = Properties.Resources.person_;

                btnIniciarPartida.Enabled = true;
                btnIniciarPartida.Image = Properties.Resources.iniciar_partida;

                btnReloadTurno.Enabled = true;
                btnReloadTurno.Image = Properties.Resources.reload_;
            }
        }

        private void InicializarRodada()
        {
            Robo = null;
            List<Carta> cartas = Carta.ListarCartas(Id);

            for (int i = 0; i < Jogadores.Count; i++)
            {
                foreach (Carta carta in Jogadores[i].Mao) {
                    Controls.Remove(carta.Panel);
                }

                Jogadores[i].AdicionarMao(cartas, i);
            }

            MostrarMaos();
        }

        private void AtualizarTurno()
        {
            Turno.Atualizar();

            if(!Turno.Mudou) { return; };

            if(!Turno.Acabou)
            {
                lblRodada.Text = $"{Turno.Rodada}";
                lblAcao.Text = Turno.Acao == 'C' ? "Jogar" : "Apostar";
                lblTurno.Text = Jogadores.Find(j => j.Id == Turno.Jogador).Nome;
            }

            if(Turno.Resetou)
            {
                InicializarRodada();
            }

            AdicionarJogadas();
            AdicionarVitorias();
            AdicionarApostas();

            if(Turno.Acabou)
            {
                tmrJogador.Stop();
                AnunciarVencedor();
                lblTurno.Text = "";
            }
        }

        private void AnunciarVencedor()
        {
            Jogador vencedor = null;
            bool empate = false;

            foreach(Jogador jogador in Jogadores)
            {
                if (vencedor != null && vencedor.Pontuacao == jogador.Pontuacao)
                {
                    empate = true;
                }

                if(vencedor == null || vencedor.Pontuacao < jogador.Pontuacao)
                {
                    vencedor = jogador;
                }

                foreach(Carta carta in jogador.Mao)
                {
                    this.Controls.Remove(carta.Panel);
                }

                jogador.Mao.Clear();
            }
            
            if(!empate)
            {
                lblVencedor.Text = $"{vencedor.Nome} venceu!";
            } else
            {
                lblVencedor.Text = "Empate!";
            }

            lblVencedor.Visible = true;
        }

        private void AdicionarJogadas()
        {
            gpbJogada.Controls.Clear();
            foreach (Carta jogada in Turno.Jogadas)
            {
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
                int cartaOriginal = jogador.Mao.FindIndex(c => c.Posicao == aposta.Posicao);
                
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
            string resultado = Jogo.ListarJogadores2(Id);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }

            string[] listaVitorias = GerenciadorDeRespostas.SepararStringDeResposta(resultado);

            foreach (string str in listaVitorias)
            {
                string[] vitorias = str.Split(',');

                Jogador jogador = Jogadores.Find(j => j.Id == Convert.ToInt32(vitorias[0]));
                jogador?.AtualizarScore(vitorias: Turno.Acabou ? -1 :Convert.ToInt32(vitorias[3]), pontuacao: Convert.ToInt32(vitorias[2]));
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

            int inicioTopo = indiceJogador == 0 ? 84 : this.Height - ((Carta.Height * 3) + 8);
            int inicioEsquerda = ((this.Width) / 2) - ((Carta.Width * metade) + (espacamento * (metade - 1))) / 2;

            int topoLabel = indiceJogador == 0 ? 221 : 549;
            jogador.LabelNome.Top = topoLabel;
            jogador.LabelAposta.Top = topoLabel;
            jogador.LabelPontuacao.Top = topoLabel;

            jogador.LabelNome.Left = 334;
            jogador.LabelAposta.Left = 436;
            jogador.LabelPontuacao.Left = 584;

            this.Controls.Add(jogador.LabelNome);
            this.Controls.Add(jogador.LabelAposta);
            this.Controls.Add(jogador.LabelPontuacao);
            
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
            int tamanhoMao = 14;
            int metade = tamanhoMao / 2;
            int espacamento = 8;

            int inicioEsquerda = indiceJogador == 2 ? 20 : this.Width - ((Carta.Width * 3) + 40);
            int inicioTopo = (this.Height / 2) - ((Carta.Width * metade) + (espacamento * (metade - 1))) / 2;

            int esquerdaLabel = indiceJogador == 2 ? 17 : 840;
            jogador.LabelNome.Left = esquerdaLabel;
            jogador.LabelAposta.Left = esquerdaLabel;
            jogador.LabelPontuacao.Left = esquerdaLabel;

            jogador.LabelNome.Top = 562;
            jogador.LabelAposta.Top = 586;
            jogador.LabelPontuacao.Top = 610;

            this.Controls.Add(jogador.LabelNome);
            this.Controls.Add(jogador.LabelAposta);
            this.Controls.Add(jogador.LabelPontuacao);

            for (int i = 0; i < mao.Count; i++)
            {
                Carta carta = mao[i];
                int posicao = (carta.Posicao - 1) % metade;
                int topo = inicioTopo + (posicao * Carta.Width) + (posicao * espacamento);
                int esquerda = (carta.Posicao - 1) < metade ? inicioEsquerda : (inicioEsquerda + Carta.Height + espacamento);

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

            if(Turno.StatusPartida == 'E' || Turno.StatusPartida == 'F')
            {
                return;
            }

            if(Robo == null)
            {
                Robo = new Automato(Id, Turno.Rodada);
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

            if(IdJogadorControlado != Turno.Jogador)
            {
                return;
            }

            Jogador jogadorAtual = Jogadores.Find(j => j.Id == IdJogadorControlado);

            if(jogadorAtual.Senha == null || jogadorAtual.Senha.Length == 0)
            {
                jogadorAtual.Senha = SenhaJogadorControlado;
            }

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
            if(IdJogadorControlado == null || SenhaJogadorControlado == null || SenhaJogadorControlado.Length == 0)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Primeiro preencha o ID e senha do jogador que será controlado pelo robo.");
                return;
            }

            if(tmrJogador.Enabled)
            {
                tmrJogador.Enabled = false;
                btnIniciarTimer.Image = Properties.Resources.iniciar_robo;
            }
            else
            {
                tmrJogador.Enabled = true;
                btnIniciarTimer.Image = Properties.Resources.pausar_robo;
            }
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            if (Turno.StatusPartida != 'A')
            {
                return;
            }

            if (IdJogadorControlado == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha o ID do jogador primeiro");
                return;

            }

            if (SenhaJogadorControlado == "" || SenhaJogadorControlado == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha a senha do jogador primeiro");
                return;
            }

            CarregarJogadores();
            string resultadoIniciarPartida = Jogo.IniciarPartida(IdJogadorControlado, SenhaJogadorControlado);

            if (GerenciadorDeRespostas.PossuiErro(resultadoIniciarPartida))
            {
                GerenciadorDeRespostas.MostrarErro(resultadoIniciarPartida);
                return;
            }

            CarregarPartida();
        }

        private void btnReloadTurno_Click(object sender, EventArgs e)
        {
            CarregarPartida();
        }

        private void btnJogador_Click(object sender, EventArgs e)
        {
            frmSelecaoJogador frm = new frmSelecaoJogador(Id, Senha);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Jogadores = frm.ListaJogadores;
                IdJogadorControlado = frm.Id;
                SenhaJogadorControlado = frm.Senha;
            }
        }
    }
}
