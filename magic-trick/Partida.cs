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
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public char Status { get; set; }

        public Partida(int id, string nome, DateTime data, char status) {
            this.Id = id;
            this.Nome = nome;
            this.Data = data;
            this.Status = status;
        }

        public static Partida InterpretarRetornoApi(string partida)
        {
            string[] dados = partida.Split(',');

            return new Partida(Convert.ToInt32(dados[0]), dados[1], Convert.ToDateTime(dados[2]), Convert.ToChar(dados[3]));
        }

        public static List<Partida> ListarPartidas() {
            string retorno = Jogo.ListarPartidas("T");
            string[] partidas = GerenciadorDeRespostas.SepararStringDeResposta(retorno);

            List<Partida> listaPartidas = new List<Partida>();

            for (int i = 0; i < partidas.Length; i++)
            {
                listaPartidas.Add(InterpretarRetornoApi(partidas[i]));
            }

            return listaPartidas;
        }
    }
}
