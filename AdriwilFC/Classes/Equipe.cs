using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriwilFC.Classes
{
    public class Equipe
    {
        public string NomeDoTime { get; set; }

        public int PotenciaPasse { get; set; }
        //É quando o jogador passa a bola para um companheiro da sua equipe.

        public int PotenciaDrible { get; set; }
        //É o ato em que o jogador utiliza-se da bola para enganar o adversário.

        public int PotenciaFinta { get; set; }
        //É o ato de enganar o adversário sem tocar na bola.

        public int PotenciaCabeceio { get; set; }
        //É a ação de cabecear a bola que tem como objetivo defender ou marcar um gol.

        public int PotenciaChute { get; set; }
        //É a ação de chutar a bola, quando a bola estiver parada ou em movimento.

        public int PotenciaRecepcao { get; set; }
        //É a ação de interromper a trajetória da bola vinda de passes ou arremessos.

        public int PotenciaConducao { get; set; }
        //É a ação de progredir com a bola por todos os espaços possíveis de jogo.

        public int PotenciaDominioDeBola { get; set; } 
        //Como no futebol, usa-se os pés para dominar a bola.

        public int PotenciaChuteNoGol { get; set; }
        //Com um dos pés, chute a bola no gol.
    }
}
