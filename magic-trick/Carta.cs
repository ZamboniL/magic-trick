using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MagicTrick
{
    public class Carta
    {
        public int IdJogador { get; set; }
        public int Posicao { get; set; }
        public int Valor { get; set; }
        public List<int> Possibilidades { get; set; } = new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 };
        public char Naipe {  get; set; }
        public Bitmap Frente { get; set; }
        public Bitmap VersoTopo { get; set; }
        public Bitmap VersoEsquerda { get; set; }
        public Bitmap VersoDireita { get; set; }
        public Bitmap VersoBaixo { get; set; }
        public Panel Panel { get; set; } = new Panel();
        public static int Height = 60;
        public static int Width = 40;

        public Carta(int idJogador, int posicao, char naipe)
        {
            IdJogador = idJogador;
            Posicao = posicao;
            Naipe = naipe;

            IdentifiqueImagem(naipe);
            
            Panel.BackgroundImage = VersoBaixo;
            Panel.Height = Height;
            Panel.Width = Width;

            Panel.BackColor = Color.Transparent;
            Panel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public static Carta DeMao(string cartaString)
        {
            string[] dadosCarta = cartaString.Split(',');

            Carta carta = new Carta(
                Convert.ToInt32(dadosCarta[0]),
                 Convert.ToInt32(dadosCarta[1]),
                 Convert.ToChar(dadosCarta[2])
                );

            return carta;
        }

        public static Carta DeVerificarVezAposta(string[] dados)
        {
            Carta carta = new Carta(
               Convert.ToInt32(dados[0]),
               Convert.ToInt32(dados[4]),
               Convert.ToChar(dados[1])
               );

            carta.Valor = Convert.ToInt32(dados[2]);

            return carta;
        }

        public static Carta DeVerificarVez(string[] dados)
        {
            Carta carta = new Carta(
                Convert.ToInt32(dados[0]),
                Convert.ToInt32(dados[3]),
                Convert.ToChar(dados[1])
                );

            carta.Valor = Convert.ToInt32(dados[2]);

            return carta;
        }

        public static Carta DeRodada(string cartaString)
        {
            string[] dadosCarta = cartaString.Split(',');

            Carta carta = new Carta(
                Convert.ToInt32(dadosCarta[1]),
                Convert.ToInt32(dadosCarta[4]),
                Convert.ToChar(dadosCarta[2])
                );

            carta.Valor = Convert.ToInt32(dadosCarta[3]);

            return carta;
        }

        public static List<Carta> ListarCartas(int idPartida)
        {
            string resultado = Jogo.ConsultarMao(idPartida);

            if(GerenciadorDeRespostas.PossuiErro(resultado))
            {
                return new List<Carta>();
            }

            string[] maos = GerenciadorDeRespostas.SepararStringDeResposta(resultado);
            List<Carta> listaCartas = new List<Carta>();

            for (int i = 0; i < maos.Length; i++)
            {
                listaCartas.Add(DeMao(maos[i]));
            }

            return listaCartas;
        }

        public void Virar(int valor)
        {
            Valor = valor;
            Label lblValorCarta = new Label();
            lblValorCarta.AutoSize = false;
            lblValorCarta.TextAlign = ContentAlignment.MiddleCenter;
            lblValorCarta.Dock = DockStyle.Fill;
            lblValorCarta.Text = valor.ToString();
            lblValorCarta.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            lblValorCarta.ForeColor = Color.White;
            Panel.Height = Height;
            Panel.Width = Width;
            Panel.BackgroundImage = Frente;
            Panel.Controls.Add(lblValorCarta);
            Panel.BringToFront();
        }

        public void AdicionarOrientacao(int posicaoJogador)
        {
            if(posicaoJogador == 0 || posicaoJogador == 1)
            {
                Panel.BackgroundImage = posicaoJogador == 0 ? VersoTopo : VersoBaixo;
            } else
            {
                Panel.Height = Width;
                Panel.Width = Height;
                Panel.BackgroundImage = posicaoJogador == 2 ? VersoEsquerda : VersoDireita;
            }
        }

        private void IdentifiqueImagem(char naipe)
        {
            switch (naipe)
            {
                case 'C':
                    VersoTopo = Properties.Resources.Copas_t_f;
                    VersoBaixo = Properties.Resources.Copas_b_f;
                    VersoDireita = Properties.Resources.Copas_r_f;
                    VersoEsquerda = Properties.Resources.Copas_l_f;
                    Frente = Properties.Resources.Copas2;
                    return;
                case 'E':
                    VersoTopo = Properties.Resources.Espadas_t_f;
                    VersoBaixo = Properties.Resources.Espadas_b_f;
                    VersoDireita = Properties.Resources.Espadas_r_f;
                    VersoEsquerda = Properties.Resources.Espadas_l_f;
                    Frente = Properties.Resources.Espadas2;
                    return;
                case 'O':
                    VersoTopo = Properties.Resources.Ouros_t_f;
                    VersoBaixo = Properties.Resources.Ouros_b_f;
                    VersoDireita = Properties.Resources.Ouros_r_f;
                    VersoEsquerda = Properties.Resources.Ouros_l_f;
                    Frente = Properties.Resources.Ouros2;
                    return;
                case 'P':
                    VersoTopo = Properties.Resources.Paus_t_f;
                    VersoBaixo = Properties.Resources.Paus_b_f;
                    VersoDireita = Properties.Resources.Paus_r_f;
                    VersoEsquerda = Properties.Resources.Paus_l_f;
                    Frente = Properties.Resources.Paus2;
                    return;
                case 'T':
                    VersoTopo = Properties.Resources.Triângulo_t_f;
                    VersoBaixo = Properties.Resources.Triângulo_b_f;
                    VersoDireita = Properties.Resources.Triângulo_r_f;
                    VersoEsquerda = Properties.Resources.Triângulo_l_f;
                    Frente = Properties.Resources.Triângulo2;
                    return;
                case 'L':
                    VersoTopo = Properties.Resources.Lua_t_f;
                    VersoBaixo = Properties.Resources.Lua_b_f;
                    VersoDireita = Properties.Resources.Lua_r_f;
                    VersoEsquerda = Properties.Resources.Lua_l_f;
                    Frente = Properties.Resources.Lua2;
                    return;
                default:
                    VersoTopo = Properties.Resources.Estrela_t_f;
                    VersoBaixo = Properties.Resources.Estrela_b_f;
                    VersoDireita = Properties.Resources.Estrela_r_f;
                    VersoEsquerda = Properties.Resources.Estrela_l_f;
                    Frente = Properties.Resources.Estrela2;
                    return;
            }
        }
    }
}
