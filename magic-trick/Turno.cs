using MagicTrickServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicTrick
{
    internal class Turno
    {
        private int IdPartida;
        private string Cache = "";
        public bool Mudou = false;
        public int Rodada { get; set; } = 1;
        public char Acao { get; set;  } = 'C';
        public char StatusPartida { get; set; } = 'J';
        public int Jogador { get; set; }
        public List<Carta> Jogadas { get; set; }
        public List<Carta> Apostas { get; set; }
        public Dictionary<int, int> Vitorias { get; set; }

        public Turno(int idPartida)
        {
            IdPartida = idPartida;
        }

        public void Atualizar()
        {
            string resultado = Jogo.VerificarVez2(IdPartida);
            
            if(Cache == resultado)
            {
                Mudou = false;
                return;
            }

            Mudou = true;
            Cache = resultado;
            string[] dados = GerenciadorDeRespostas.SepararStringDeResposta(resultado);
            string[] turno = dados[0].Split(',');
            StatusPartida = Convert.ToChar(turno[0]);
            Jogador = Convert.ToInt32(turno[1]);
            Acao = Convert.ToChar(turno[3]);
            Vitorias = new Dictionary<int, int>();
            Jogadas = new List<Carta>();
            Apostas = new List<Carta>();
            
            int novaRodada = Convert.ToInt32(turno[2]);
            bool atualizouRodada = novaRodada != Rodada;
            if(atualizouRodada)
            {
                CalcularVitorias(novaRodada - Rodada);
            }
            Rodada = novaRodada;
            for(int i = 1; i < dados.Length; i++)
            {
                string dadosCarta = dados[i].Split(':')[1];
                if (dados[i].StartsWith("C:"))
                {
                    Carta carta = Carta.DeVerificarVez(dadosCarta.Split(','));
                    Jogadas.Add(carta);
                } else
                {
                    Carta carta = Carta.DeVerificarVezAposta(dadosCarta.Split(','));
                    Apostas.Add(carta);
                }
            }
        }

        private void CalcularVitorias(int diferenca)
        {
            string resultado = Jogo.ExibirJogadas2(IdPartida);
            string[] dados = GerenciadorDeRespostas.SepararStringDeResposta(resultado);
            for(int i = diferenca - 1; i >= 0; i--)
            {
                int rodada = Rodada + i;
                string[] dadosRodada = dados.Where(d => d.StartsWith($"{rodada},")).ToArray();
                List<Carta> jogadasRodada = new List<Carta>();

                for(int j = 0; j < dadosRodada.Length; j++)
                {
                    Carta carta = Carta.DeRodada(dadosRodada[j]);
                    if(i == 0 && j == dadosRodada.Length - 1)
                    {
                        Jogadas.Add(carta);
                    }
                    jogadasRodada.Add(carta);
                }

                Carta vencedorRodada = null;

                foreach (Carta carta in jogadasRodada)
                {
                    if (
                        vencedorRodada == null ||
                        (carta.Naipe == vencedorRodada.Naipe && carta.Valor > vencedorRodada.Valor) ||
                        (carta.Naipe == 'C' && vencedorRodada.Naipe != 'C')
                    )
                    {
                        vencedorRodada = carta;
                    }
                }

                if(Vitorias.ContainsKey(vencedorRodada.IdJogador))
                {
                    Vitorias[vencedorRodada.IdJogador]++;
                } else
                {
                    Vitorias[vencedorRodada.IdJogador] = 1;
                }
            }
        }
    }
}
