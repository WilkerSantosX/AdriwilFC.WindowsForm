using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriwilFC.Classes
{
    class Jogador
    {
        public string NomeDoJogador { get; set; }

        public string Posicao { get; set; }

        public int Passe { get; set; }
        //É quando o jogador passa a bola para um companheiro da sua equipe.

        public int Drible { get; set; }
        //É o ato em que o jogador utiliza-se da bola para enganar o adversário.

        public int Finta { get; set; }
        //É o ato de enganar o adversário sem tocar na bola.

        public int Cabeceio { get; set; }
        //É a ação de cabecear a bola que tem como objetivo defender ou marcar um gol.

        public int Chute { get; set; }
        //É a ação de chutar a bola, quando a bola estiver parada ou em movimento.

        public int Recepcao { get; set; }
        //É a ação de interromper a trajetória da bola vinda de passes ou arremessos.

        public int Conducao { get; set; }
        //É a ação de progredir com a bola por todos os espaços possíveis de jogo.

        public int DominioDeBola { get; set; }
        //Como no futebol, usa-se os pés para dominar a bola.

        public int ChuteNoGol { get; set; }
        //Com um dos pés, chute a bola no gol.

        #region Construtor

        //Usando construtor afim de que tudo seja instanciado com valor
        public Jogador(string nomeJogador, string posicao, int passe, int drible, int finta, int cabeceio,
                                int chute, int recepcao, int conducao, int dominioDeBola, int chuteNoGol)
        {
            this.NomeDoJogador = nomeJogador.ToUpper();
            this.Posicao = posicao.ToUpper();
            this.Passe = passe;
            this.Drible = drible;
            this.Finta = finta;
            this.Cabeceio = cabeceio;
            this.Chute = chute;
            this.Recepcao = recepcao;
            this.Conducao = conducao;
            this.DominioDeBola = dominioDeBola;
            this.ChuteNoGol = chuteNoGol;
        }

        #endregion
    }
}
