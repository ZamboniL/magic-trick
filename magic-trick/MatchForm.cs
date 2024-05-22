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
        public int IdJogador { get; set; }
        public List<Jogador> Jogadores { get; set; }
        private Automato Robo;

        public MatchForm(int id, string senha)
        {
            InitializeComponent();

            Id = id;
            Senha = senha;

            CarregarJogadores();
            CarregarTurno();
        }

        private void CarregarJogadores()
        {
            List<Jogador> jogadores = Jogador.ListarJogadores(Id);
            Jogadores = jogadores;
            dgvJogadores.DataSource = jogadores;
        }

        private void CarregarTurno()
        {
            Turno = new Turno(Id);
            Turno.Atualizar();

            if(Turno.StatusPartida != 'A')
            {
                btnIniciarPartida.Enabled = false;
                btnAdicionarJogador.Enabled = false;
                btnReload.Enabled = false;
                btnReloadTurno.Enabled = false;
                btnIniciarTimer.Enabled = true;
                InicializarRodada();
                AtualizarTurno();
            } else
            {
                btnIniciarTimer.Enabled = false;
                btnIniciarPartida.Enabled = true;
                btnAdicionarJogador.Enabled = true;
                btnReload.Enabled = true;
                btnReloadTurno.Enabled = true;
            }
        }

        private void InicializarRodada()
        {
            Robo = null;
            List<Carta> cartas = Carta.ListarCartas(Id);

            foreach (Jogador jogador in Jogadores)
            {
                jogador.AdicionarMao(cartas);
            }

            MostrarMaos();
        }

        private void AtualizarTurno()
        {
            Turno.Atualizar();

            lblRodada.Text = $"{Turno.Rodada}";
            lblAcao.Text = Turno.Acao == 'C' ? "Jogar" : "Apostar";
            lblTurno.Text = Jogadores.Find(j => j.Id == Turno.Jogador).Nome;

            if(!Turno.Mudou) { return; };

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
            int inicioEsquerda = ((this.Width - 200) / 2) - ((Carta.Width * metade) + (espacamento * (metade - 1))) / 2;

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
            int tamanhoMao = 14;
            int metade = tamanhoMao / 2;
            int espacamento = 8;

            int inicioEsquerda = indiceJogador == 2 ? 20 : this.Width - ((Carta.Width * 3) + 20 + 200);
            int inicioTopo = (this.Height / 2) - ((Carta.Height * metade) + (espacamento * (metade - 1))) / 2;

            jogador.Label.Top = inicioTopo;
            jogador.Label.Left = indiceJogador == 2 ? inicioEsquerda + (Carta.Width * 2) + espacamento + 12 : inicioEsquerda - 60 - espacamento;
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
            if(tmrJogador.Enabled)
            {
                tmrJogador.Enabled = false;
                btnIniciarTimer.Text = "Iniciar Robo";
            }
            else
            {
                tmrJogador.Enabled = true;
                btnIniciarTimer.Text = "Pausar Robo";

            }
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            if (Turno.StatusPartida != 'A')
            {
                return;
            }

            string id = txtId.Text;
            string senha = txtSenha.Text;

            if (id == "" || id == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha o ID do jogador primeiro");
                return;

            }

            if (senha == "" || senha == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha a senha do jogador primeiro");
                return;
            }

            string resultadoIniciarPartida = Jogo.IniciarPartida(Convert.ToInt32(id), senha);

            if (GerenciadorDeRespostas.PossuiErro(resultadoIniciarPartida))
            {
                GerenciadorDeRespostas.MostrarErro(resultadoIniciarPartida);
                return;
            }

            CarregarTurno();
        }

        private void dgvJogadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var jogador = dgvJogadores.SelectedRows[0];

            if (jogador != null)
            {
                Jogador carregar = (Jogador)jogador.DataBoundItem;
                txtId.Text = Convert.ToString(carregar.Id);
                txtNome.Text = carregar.Nome;
            }
        }

        private void btnAdicionarJogador_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            if (nome == "" || nome == null)
            {
                GerenciadorDeRespostas.MostrarErro("ERRO: Preencha o nome do jogador primeiro");
                return;

            }

            string resultado = Jogo.EntrarPartida(Id, nome, Senha);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return;
            }


            string[] dadosJogador = resultado.Split(',');
            txtId.Text = dadosJogador[0];
            txtSenha.Text = dadosJogador[1];

            CarregarJogadores();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            CarregarJogadores();
        }
    }
}
