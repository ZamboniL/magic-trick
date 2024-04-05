using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick
{
    public class Carta
    {
        public int IdJogador {  get; set; }
        public int Posicao {  get; set; }
        public int Valor {  get; set; }
        public char Naipe {  get; set; }
        public System.Drawing.Bitmap Imagem { get; set; }
        public Panel Panel { get; set; }
        public static int Height = 60;
        public static int Width = 45;

        public Carta(string cartaString)
        {
            string[] dadosCarta = cartaString.Split(',');

            IdJogador = Convert.ToInt32(dadosCarta[0]);
            Posicao = Convert.ToInt32(dadosCarta[1]);
            Naipe = Convert.ToChar(dadosCarta[2]);
            Imagem = IdentifiqueNaipe(dadosCarta[2]);
        }

        public static List<Carta> ListarCartas(int idPartida)
        {
            string resultado = Jogo.ConsultarMao(idPartida);
            string[] maos = GerenciadorDeRespostas.SepararStringDeResposta(resultado);
            List<Carta> listaCartas = new List<Carta>();

            for (int i = 0; i < maos.Length; i++)
            {
                listaCartas.Add(new Carta(maos[i]));
            }

            return listaCartas;
        }

        public override string ToString()
        {
            return $"Posição: {Posicao}, Naipe: {Naipe}";
        }

        private System.Drawing.Bitmap IdentifiqueNaipe(string naipe)
        {
            switch (naipe)
            {
                case "C":
                    return Properties.Resources.Copas1;
                case "E":
                    return Properties.Resources.Espadas1;
                case "O":
                    return Properties.Resources.Ouros1;
                case "P":
                    return Properties.Resources.Paus1;
                case "T":
                    return Properties.Resources.Triângulo1;
                case "L":
                    return Properties.Resources.Lua1;
                default:
                    return Properties.Resources.Estrela1;
            }
        }
    }
}
