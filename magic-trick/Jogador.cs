using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick
{
    public class Jogador
    {
        private int _IdPartida;
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Senha { get; set; }
        public List<Carta> Mao { get; set; }
        public Carta Aposta { get; set; }

        public Jogador(string Nome, int Id, int idPartida, string Senha = null) {
            this.Nome = Nome;
            this.Id = Id;
            this.Senha = Senha;
            this._IdPartida = idPartida;
            this.Mao = new List<Carta>();
        }

        public static List<Jogador> ListarJogadores(int idPartida)
        {
            string retorno = Jogo.ListarJogadores(idPartida);
            string[] jogadores = GerenciadorDeRespostas.SepararStringDeResposta(retorno);

            List<Jogador> listaJogadores = new List<Jogador>();

            for (int i = 0; i < jogadores.Length; i++)
            {
                string[] dadosJogador = jogadores[i].Split(',');

                listaJogadores.Add(new Jogador(
                   dadosJogador[1],
                   Convert.ToInt32(dadosJogador[0]),
                   idPartida
                ));
            }

            return listaJogadores;
        }

        public void AdicionarMao(List<Carta> cartas)
        {
            Mao.Clear();
            foreach (Carta carta in cartas)
            {
                if(Id == carta.IdJogador)
                {
                    Mao.Add(carta);
                }
            }
        }

        public string JogarCarta(string carta)
        {
            int comecoPosicao = 9;
            int finalPosicao = carta.IndexOf(",");
            int posicao = Convert.ToInt32(carta.Substring(comecoPosicao, finalPosicao - comecoPosicao));
            return Jogo.Jogar(Id, Senha, posicao);
        }

        public string Apostar(int aposta)
        {
            return Jogo.Apostar(Id, Senha, aposta);
        }
    }
}
