using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTrick
{
    public class Jogador
    {
        private int _IdPartida;
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Senha { get; set; }
        public List<Carta> Mao { get; set; } = new List<Carta>();
        public int Aposta { get; set; } = 0;
        public int Vitorias { get; set; } = 0;
        public int Pontuacao { get; set; } = 0;
        public Label Label {  get; set; } = new Label();

        public Jogador(string Nome, int Id, int idPartida, string Senha = null) {
            this.Nome = Nome;
            this.Id = Id;
            this.Senha = Senha;
            this._IdPartida = idPartida;
            Label.Text = $"{Nome} - {Aposta}/{Vitorias}";
            Label.AutoSize = true;
        }

        public static Jogador InterpretarRetornoApi(string jogador, int idPartida)
        {
            string[] dados = jogador.Split(',');

            return new Jogador(
                dados[1],
                Convert.ToInt32(dados[0]),
                idPartida
            );
        }

        public static List<Jogador> ListarJogadores(int idPartida)
        {
            string retorno = Jogo.ListarJogadores(idPartida);

            if (retorno.Length == 0)
            {
                return new List<Jogador>();
            }

            string[] jogadores = GerenciadorDeRespostas.SepararStringDeResposta(retorno);

            List<Jogador> listaJogadores = new List<Jogador>();

            for (int i = 0; i < jogadores.Length; i++)
            {
                listaJogadores.Add(InterpretarRetornoApi(jogadores[i], idPartida));
            }

            return listaJogadores;
        }

        public void Resetar()
        {
            Mao.Clear();
            AtualizarScore(vitorias: 0, aposta: 0);
        }

        public void AdicionarMao(List<Carta> cartas)
        {
            Resetar();
            foreach (Carta carta in cartas)
            {
                if(Id == carta.IdJogador)
                {
                    Mao.Add(carta);
                }
            }
        }

        public void RemoverJogadas(List<Carta> cemiterio)
        {
            foreach(Carta c in cemiterio)
            {
                Console.WriteLine($"{c.Posicao} {c.Naipe} {c.IdJogador}");
                Carta carta = Mao.Find(m => m.Posicao == c.Posicao && m.Naipe == c.Naipe && Id == c.IdJogador);
                if(carta != null)
                {
                    Mao.Remove(carta);
                    carta.Panel.Dispose();
                }
            }
        }

        public void AtualizarScore(int vitorias = -1, int pontuacao = -99, int aposta = -1)
        {
            if(vitorias != -1)
            {
                Vitorias = vitorias;
            }

            if(pontuacao != -99)
            {
                Pontuacao = pontuacao;
            }

            if(aposta != -1)
            {
                Aposta = aposta;
            }

            Label.Text = $"{Nome} - {Aposta}/{Vitorias}";
        }

        public int Jogar(int posicao)
        {
            string resultado = Jogo.Jogar(Id, Senha, posicao);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {

                GerenciadorDeRespostas.MostrarErro(resultado);
                
                return -1;
            }

            int valor = Convert.ToInt32(resultado);

            return valor;
        }

        public int Apostar(int posicao)
        {
            string resultado = Jogo.Apostar(Id, Senha, posicao);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                GerenciadorDeRespostas.MostrarErro(resultado);
                return -1;
            }

            AtualizarScore(aposta: Convert.ToInt32(resultado));

            return Aposta;
        }
    }
}
