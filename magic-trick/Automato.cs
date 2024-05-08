using MagicTrickServer;
using System.Collections.Generic;
using System.Linq;

namespace MagicTrick
{
    internal class Automato
    {
        private int IdPartida;
        private int Rodada;
        private List<Carta> Cemiterio = new List<Carta>();
        private Carta VencedorRodada = null;

        public Automato(int idPartida, int rodada)
        {
            IdPartida = idPartida;
            Rodada = rodada;

            for (int i = 1; i <= rodada; i++)
            {
                VencedorRodada = null;
                AtualizarCemiterio(i);
            }
        }

        public void InicializarPossibilidades(List<Carta> Mao)
        {
            foreach (Carta c in Mao)
            {
                foreach (Carta c2 in Mao)
                {
                    if (c2 == c) continue;

                    if (c.Posicao > c2.Posicao && c.Naipe == c2.Naipe)
                    {
                        c.Possibilidades.RemoveAt(0);
                    }
                    else if (c.Posicao < c2.Posicao && c.Naipe == c2.Naipe)
                    {
                        c.Possibilidades.RemoveAt(c.Possibilidades.Count - 1);
                    }
                }
            }

            foreach (Carta c in Mao)
            {
                foreach (Carta c2 in Mao)
                {
                    if (c2 == c) continue;

                    if (c.Posicao > c2.Posicao)
                    {
                        c.Possibilidades = c.Possibilidades.Where(v => v >= c2.Possibilidades.First()).ToList();
                    }
                    else
                    {
                        c.Possibilidades = c.Possibilidades.Where(v => v <= c2.Possibilidades.Last()).ToList();
                    }
                }
            }
        }

        public void AtualizarRodada(int rodada, List<Jogador> jogadores)
        {
            int diferenca = rodada - Rodada;
            Rodada = rodada;

            for (int i = 0; i <= diferenca; i++)
            {
                VencedorRodada = null;
                AtualizarCemiterio(rodada - i);
            }
            
            foreach(Jogador jogador in jogadores)
            {
                DescontarPossibilidadeComCemiterio(jogador.Mao);
            }
            for (int i = 0; i < jogadores.Count; i++)
            {
                for (int j = jogadores.Count - 1; j > i; j-- )
                {
                    DescontarPossibilidadeComparandoMaos(jogadores[i].Mao, jogadores[j].Mao);
                }
            }
        }

        public Carta EscolherCarta(List<Carta> mao, int aposta, int pontos)
        {
            List<Carta> maoValida;
            Carta escolha;

            if(VencedorRodada != null)
            {
                if (mao.Any(c => c.Naipe == VencedorRodada.Naipe))
                {
                    maoValida = mao.Where(c => c.Naipe == VencedorRodada.Naipe).ToList();
                } else if (mao.Any(c => c.Naipe == 'C'))
                {
                    maoValida = mao.Where(c => c.Naipe == 'C').ToList();
                } else
                {
                    maoValida = mao;
                }

                if(aposta == 0)
                {
                    escolha = maoValida[maoValida.Count / 2];
                } else if (aposta > pontos)
                {
                    escolha = TentarGanhar(maoValida, VencedorRodada);
                } else
                {
                    escolha = TentarPerder(maoValida, VencedorRodada);
                }
            } else
            {
                if(aposta == 0)
                {
                    escolha = mao[mao.Count / 2];
                } else if (aposta > pontos)
                {
                    escolha = mao.Last();
                } else
                {
                    escolha = mao.First();
                }
            }


            return escolha;
        }

        public int EscolherAposta(List<Carta> mao)
        {
            if(Rodada != 3)
            {
                return 0;
            }

            int escolha;

            int media = 0;
            foreach(Carta carta in mao)
            {
                int total = carta.Possibilidades.Sum();
                int mediaLocal = total / carta.Possibilidades.Count;

                media += mediaLocal;
            }

            media /= mao.Count;

            if(media > 3)
            {
                Carta carta = mao.Find(c => c.Possibilidades.Min() > 4);
                escolha = carta.Posicao;
            } else
            {
                Carta carta = mao.Find(c => c.Possibilidades.Max() < 4);
                escolha = carta.Posicao;
            }

            return escolha;
        }

        private Carta TentarGanhar(List<Carta> mao, Carta alvo)
        {
            Carta escolha;

            escolha = mao.Find(c => c.Possibilidades.Min() > alvo.Valor);

            if (escolha == null)
            {
                escolha = mao.FindLast(c => c.Possibilidades.Any(p => p > alvo.Valor));
            }

            if (escolha == null)
            {
                escolha = mao.First();
            }

            return escolha;
        }

        private Carta TentarPerder(List<Carta> mao, Carta alvo)
        {
            Carta escolha;

            escolha = mao.FindLast(c => c.Possibilidades.Max() < alvo.Valor);

            if (escolha == null)
            {
                escolha = mao.Find(c => c.Possibilidades.Any(p => p < alvo.Valor));
            }

            if (escolha == null)
            {
                escolha = mao.Last();
            }

            return escolha;
        }

        private void AtualizarCemiterio(int rodada)
        {
            string resposta = Jogo.ExibirJogadas2(IdPartida);

            if(GerenciadorDeRespostas.PossuiErro(resposta))
            {
                return;
            }
            
            if(resposta.Length == 0)
            {
                return;
            }

            string[] cartas = GerenciadorDeRespostas.SepararStringDeResposta(resposta);
            cartas = cartas.Where(c => c.StartsWith($"{rodada},")).ToArray();

            for (int i = 0; i < cartas.Length; i++)
            {
                Carta carta = Carta.DeRodada(cartas[i]);

                if (
                    (VencedorRodada == null) || 
                    (VencedorRodada.Valor < carta.Valor && VencedorRodada.Naipe == carta.Naipe) || 
                    (VencedorRodada.Naipe != 'C' && carta.Naipe == 'C'))
                {
                    VencedorRodada = carta;
                }

                if (Cemiterio.Find(c => c.Naipe == carta.Naipe && c.Valor == carta.Valor) != null)
                {
                    continue;
                }

                Cemiterio.Add(carta);
            }
        }

        private void DescontarPossibilidadeComCemiterio(List<Carta> mao)
        {
            foreach(Carta c in mao)
            {
                if(c.Possibilidades.Count == 1) continue;

                foreach(Carta c2 in Cemiterio)
                {
                    if(c.Naipe == c2.Naipe)
                    {
                        c.Possibilidades.Remove(c2.Valor);
                    }

                    if(c.IdJogador == c2.IdJogador)
                    {
                        List<int> possibilidades = new List<int>();
                        if(c.Posicao > c2.Posicao)
                        {
                            possibilidades = c.Possibilidades.Where(v => v >= c2.Valor).ToList();
                        } else
                        {
                            possibilidades = c.Possibilidades.Where(v => v <= c2.Valor).ToList();
                        }

                        c.Possibilidades = possibilidades;
                    }
                }
            }
        }

        public void DescontarPossibilidadeComparandoMaos(List<Carta> mao1, List<Carta> mao2)
        {
            foreach (Carta c in mao1)
            {
                foreach (Carta c2 in mao2)
                {
                    if(c.Naipe == c2.Naipe)
                    {
                        if (c2.Possibilidades.Count == 1)
                        {
                            c.Possibilidades.Remove(c2.Possibilidades.First());
                        }
                    }
                }
            }
        }
    }
}
