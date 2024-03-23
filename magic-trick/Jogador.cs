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
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Senha { get; set; }

        public Jogador(string Nome, int Id, string Senha = null) {
            this.Nome = Nome;
            this.Id = Id;
            this.Senha = Senha;
        }

        public string JogarCarta(string carta)
        {
            int posicao = Convert.ToInt32(carta.Split(',')[1]);
            return Jogo.Jogar(Id, Senha, posicao);
        }

        public string Apostar(int aposta)
        {
            return Jogo.Apostar(Id, Senha, aposta);
        }
    }
}
