using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick
{
    public class Partida
    {
        private int _id;
        public string Nome { get; set; }
        public DateTime data { get; set; }
        public char status { get; set; }

        public Partida(int id, string Nome, DateTime data, char status) { 
            this._id = id;
            this.Nome = Nome;
            this.data = data;
            this.status = status;
        }

        public static List<Partida> ListarPartidas() {
            string retorno = Jogo.ListarPartidas("T");
            string[] partidas = GerenciadorDeRespostas.SepararStringDeResposta(retorno);

            List<Partida> listaPartidas = new List<Partida>();

            for (int i = 0; i < partidas.Length; i++)
            {
                string[] dadosPartida = partidas[i].Split(',');
                listaPartidas.Add(new Partida(
                    Convert.ToInt32(dadosPartida[0]),
                    dadosPartida[1],
                    Convert.ToDateTime(dadosPartida[2]),
                    Convert.ToChar(dadosPartida[3])
                ));
            }

            return listaPartidas;
        }
    }
}
