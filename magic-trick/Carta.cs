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
        public Bitmap Verso { get; set; }
        public Panel Panel { get; set; } = new Panel();
        public static int Height = 60;
        public static int Width = 45;

        public Carta(int idJogador, int posicao, char naipe)
        {
            IdJogador = idJogador;
            Posicao = posicao;
            Naipe = naipe;

            IdentifiqueImagem(naipe);
            
            Panel.BackgroundImage = Verso;
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
            lblValorCarta.Text = valor.ToString();
            lblValorCarta.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            Panel.BackgroundImage = Frente;
            Panel.Controls.Add(lblValorCarta);
            Panel.BringToFront();
        }

        public override string ToString()
        {
            return $"Posição: {Posicao}, Naipe: {Naipe}";
        }

        private void IdentifiqueImagem(char naipe)
        {
            switch (naipe)
            {
                case 'C':
                    Verso = Properties.Resources.Copas1;
                    Frente = Properties.Resources.Copas2;
                    return;
                case 'E':
                    Verso = Properties.Resources.Espadas1;
                    Frente = Properties.Resources.Espadas2;
                    return;
                case 'O':
                    Verso = Properties.Resources.Ouros1;
                    Frente = Properties.Resources.Ouros2;
                    return;
                case 'P':
                    Verso = Properties.Resources.Paus1;
                    Frente = Properties.Resources.Paus2;
                    return;
                case 'T':
                    Verso = Properties.Resources.Triângulo1;
                    Frente = Properties.Resources.Triângulo2;
                    return;
                case 'L':
                    Verso = Properties.Resources.Lua1;
                    Frente = Properties.Resources.Lua2;
                    return;
                default:
                    Verso = Properties.Resources.Estrela1;
                    Frente = Properties.Resources.Estrela2;
                    return;
            }
        }
    }
}
