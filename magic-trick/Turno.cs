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
        public bool Resetou = true;
        public bool Acabou = false;
        public int Rodada { get; set; } = 1;
        public char Acao { get; set;  } = 'C';
        public char StatusPartida { get; set; } = 'A';
        public int Jogador { get; set; }
        public List<Carta> Jogadas { get; set; }
        public List<Carta> Apostas { get; set; }

        public Turno(int idPartida)
        {
            IdPartida = idPartida;
        }

        public void Atualizar()
        {
            string resultado = Jogo.VerificarVez2(IdPartida);

            if (GerenciadorDeRespostas.PossuiErro(resultado))
            {
                return;
            }

            if (Cache == resultado)
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
            Jogadas = new List<Carta>();
            Apostas = new List<Carta>();
            
            int novaRodada = Convert.ToInt32(turno[2]);
            bool atualizouRodada = novaRodada != Rodada;

            if(atualizouRodada && novaRodada == 1)
            {
                Resetou = true;
                Rodada = novaRodada;
                return;
            } else
            {
                Resetou = false;
            }

            if(StatusPartida == 'E' || StatusPartida == 'F')
            {
                Acabou = true;
                return;
            }
            
            if(atualizouRodada)
            {
                PegarUltimaCartaJogada();
                Rodada = novaRodada;
            }

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

        private void PegarUltimaCartaJogada()
        {
            string resultado = Jogo.ExibirJogadas2(IdPartida);
            string[] dados = GerenciadorDeRespostas.SepararStringDeResposta(resultado);
            string[] dadosRodada = dados.Where(d => d.StartsWith($"{Rodada},")).ToArray();

            Carta carta = Carta.DeRodada(dadosRodada[dadosRodada.Length - 1]);
            Jogadas.Add(carta);
        }
    }
}
