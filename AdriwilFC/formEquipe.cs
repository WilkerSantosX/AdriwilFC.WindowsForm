using AdriwilFC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdriwilFC
{
    public partial class formEquipe : Form
    {
        string nomeTecnico = String.Empty;
        string nomeTime = String.Empty;

        public formEquipe(string tecnico, string time)
        {
            InitializeComponent();
            nomeTecnico = tecnico != "" ? tecnico : "Padrão";
            nomeTime = time != "" ? time : "Time A";
        }

        //Instanciando controle resultado
        Resultado score = new Resultado();

        List<Jogador> listaJogadores = new List<Jogador>();
        List<Jogador> listaCombo = new List<Jogador>();

        private void formEquipe_Load(object sender, EventArgs e)
        {
            labelTime.Text = nomeTime;
            labelTecnico.Text = "Técnico: " + nomeTecnico; 
            labelJogadorPlacar.Text = nomeTime.ToUpper(); 
            
            #region Inserir os jogadores

            Jogador goleiro = new Jogador("GL - Barack", "GL", 73, 34, 30, 70, 74, 71, 56, 60, 46);
            Jogador _goleiro = new Jogador("GL - Pedrinho", "GL", 79, 20, 29, 43, 64, 80, 77, 60, 65);
            

            Jogador fixo = new Jogador("FX - Douglas Moraes", "FX", 54, 23, 10, 76, 40, 50, 35, 60, 54);
            Jogador _fixo = new Jogador("FX - Matheus Pozzer", "FX", 50, 25, 13, 73, 50, 44, 45, 55, 58);

            Jogador alaD = new Jogador("ALD - Matheus", "ALD", 78, 72, 68, 56, 78, 60, 61, 65, 74);
            Jogador _alaD = new Jogador("ALD - Falcão", "ALD", 80, 79, 74, 60, 85, 70, 69, 72, 88);

            Jogador alaE = new Jogador("ALE - Alexandre Rodrigues", "ALE", 69, 70, 65, 63, 70, 60, 63, 64, 73);
            Jogador _alaE = new Jogador("ALE - Marcel de Mendonça", "ALE", 67, 69, 64, 62, 73, 71, 67, 65, 70);

            Jogador pivo = new Jogador("PV - Douglas Nunes", "PV", 72, 69, 71, 78, 83, 65, 70, 69, 74);
            Jogador _pivo = new Jogador("PV - Vinícius Nunes", "PV", 70, 73, 70, 76, 80, 70, 67, 70, 74);

            listaJogadores.Add(goleiro);
            listaJogadores.Add(_goleiro);

            listaJogadores.Add(fixo);
            listaJogadores.Add(_fixo);

            listaJogadores.Add(alaD);
            listaJogadores.Add(_alaD);

            listaJogadores.Add(alaE);            
            listaJogadores.Add(_alaE);

            listaJogadores.Add(pivo);          
            listaJogadores.Add(_pivo);

            #endregion

            #region Disponibilzar nos combos

            #region Goleiros

            listaCombo = listaJogadores.Where(x => x.Posicao == "GL").ToList();
            
            foreach (var item in listaCombo)
            {
                comboGoleiro.Items.Add(item.NomeDoJogador);
            }

            comboGoleiro.SelectedText = "SELECIONE...";

            listaCombo = null;

            #endregion

            #region Fixos

            listaCombo = listaJogadores.Where(x => x.Posicao == "FX").ToList();

            foreach (var item in listaCombo)
            {
                comboFixo.Items.Add(item.NomeDoJogador);
            }

            comboFixo.SelectedText = "SELECIONE...";

            listaCombo = null;

            #endregion

            #region Ala Direita

            listaCombo = listaJogadores.Where(x => x.Posicao == "ALD").ToList();

            foreach (var item in listaCombo)
            {
                comboAlaDireita.Items.Add(item.NomeDoJogador);
            }

            comboAlaDireita.SelectedText = "SELECIONE...";

            listaCombo = null;

            #endregion

            #region Ala Esquerda

            listaCombo = listaJogadores.Where(x => x.Posicao == "ALE").ToList();

            foreach (var item in listaCombo)
            {
                comboAlaEsquerda.Items.Add(item.NomeDoJogador);
            }

            comboAlaEsquerda.SelectedText = "SELECIONE...";

            listaCombo = null;

            #endregion

            #region Pivô

            listaCombo = listaJogadores.Where(x => x.Posicao == "PV").ToList();

            foreach (var item in listaCombo)
            {
                comboPivo.Items.Add(item.NomeDoJogador);
            }

            comboPivo.SelectedText = "SELECIONE...";

            listaCombo = null;

            #endregion

            #endregion
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            bool validaTime = verificaEscalacao();

            if (validaTime)
            {
                labelProgress.Visible = true;
                label7.Visible = true;
                Refresh();

                //Instanciando os TIMES usuário e máquina
                Equipe timeJogador = new Equipe();
                Equipe timeCOM = new Equipe();

                //Instanciando lista para armazenar jogadores selecionados
                List<Jogador> jogadorSelecionado = new List<Jogador>();

                //Verificando quais jogadores foram selecionados
                Jogador goleiro = listaJogadores.Where(x => x.NomeDoJogador == Convert.ToString(comboGoleiro.SelectedItem)).First();
                Jogador alaEsquerda = listaJogadores.Where(x => x.NomeDoJogador == Convert.ToString(comboAlaEsquerda.SelectedItem)).First();
                Jogador fixo = listaJogadores.Where(x => x.NomeDoJogador == Convert.ToString(comboFixo.SelectedItem)).First();
                Jogador alaDireita = listaJogadores.Where(x => x.NomeDoJogador == Convert.ToString(comboAlaDireita.SelectedItem)).First();
                Jogador pivo = listaJogadores.Where(x => x.NomeDoJogador == Convert.ToString(comboPivo.SelectedItem)).First();

                //Add time do jogador
                jogadorSelecionado.Add(goleiro);
                jogadorSelecionado.Add(alaEsquerda);
                jogadorSelecionado.Add(fixo);
                jogadorSelecionado.Add(alaDireita);
                jogadorSelecionado.Add(pivo);

                //Pontuação total do Time
                foreach (var item in jogadorSelecionado)
                {
                    timeJogador.PotenciaPasse += item.Passe;
                    timeJogador.PotenciaDrible += item.Drible;
                    timeJogador.PotenciaFinta += item.Finta;
                    timeJogador.PotenciaCabeceio += item.Cabeceio;
                    timeJogador.PotenciaChute += item.Chute;
                    timeJogador.PotenciaRecepcao += item.Recepcao;
                    timeJogador.PotenciaConducao += item.Conducao;
                    timeJogador.PotenciaDominioDeBola += item.DominioDeBola;
                    timeJogador.PotenciaChuteNoGol += item.ChuteNoGol;
                }

                //Limpando a lista de jogadores selecionados para armazenar COM
                jogadorSelecionado.Clear();

                //Verificando quais jogadores foram selecionados
                Jogador goleiroCOM = listaJogadores.Where(x => x.NomeDoJogador != Convert.ToString(comboGoleiro.SelectedItem) && x.Posicao == "GL").First();
                Jogador alaEsquerdaCOM = listaJogadores.Where(x => x.NomeDoJogador != Convert.ToString(comboAlaEsquerda.SelectedItem) && x.Posicao == "ALE").First();
                Jogador fixoCOM = listaJogadores.Where(x => x.NomeDoJogador != Convert.ToString(comboFixo.SelectedItem) && x.Posicao == "FX").First();
                Jogador alaDireitaCOM = listaJogadores.Where(x => x.NomeDoJogador != Convert.ToString(comboAlaDireita.SelectedItem) && x.Posicao == "ALD").First();
                Jogador pivoCOM = listaJogadores.Where(x => x.NomeDoJogador != Convert.ToString(comboPivo.SelectedItem) && x.Posicao == "PV").First();

                //Add time da máquina
                jogadorSelecionado.Add(goleiroCOM);
                jogadorSelecionado.Add(alaEsquerdaCOM);
                jogadorSelecionado.Add(fixoCOM);
                jogadorSelecionado.Add(alaDireitaCOM);
                jogadorSelecionado.Add(pivoCOM);

                //Pontuação total do Time
                foreach (var item in jogadorSelecionado)
                {
                    timeCOM.PotenciaPasse += item.Passe;
                    timeCOM.PotenciaDrible += item.Drible;
                    timeCOM.PotenciaFinta += item.Finta;
                    timeCOM.PotenciaCabeceio += item.Cabeceio;
                    timeCOM.PotenciaChute += item.Chute;
                    timeCOM.PotenciaRecepcao += item.Recepcao;
                    timeCOM.PotenciaConducao += item.Conducao;
                    timeCOM.PotenciaDominioDeBola += item.DominioDeBola;
                    timeCOM.PotenciaChuteNoGol += item.ChuteNoGol;
                }

                //Limpando a lista de jogadores selecionados para armazenar COM
                jogadorSelecionado.Clear();

                if (timeJogador.PotenciaCabeceio > timeCOM.PotenciaCabeceio)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaChute > timeCOM.PotenciaChute)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaChuteNoGol > timeCOM.PotenciaChuteNoGol)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaConducao > timeCOM.PotenciaConducao)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaDominioDeBola > timeCOM.PotenciaDominioDeBola)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaDrible > timeCOM.PotenciaDrible)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaFinta > timeCOM.PotenciaFinta)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaPasse > timeCOM.PotenciaPasse)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                Refresh();

                if (timeJogador.PotenciaRecepcao > timeCOM.PotenciaRecepcao)
                    score.PlacarJogador += 1;
                else
                    score.PlacarCOM += 1;

                tempoProcessar(score.PlacarJogador, score.PlacarCOM);
                labelProgress.Text = "FIM DE JOGO!";
                labelProgress.BackColor = Color.Red;
                labelProgress.ForeColor = Color.White;
                Refresh();
            }           
        }

        public void tempoProcessar(int placarJogador, int placarCOM)
        {
            DateTime tempo = DateTime.Now;
            DateTime tempoAux = tempo.AddSeconds(5);

            //Paralisa o indicador em 5 segundos
            while (tempo <= tempoAux)
            {
                tempo = DateTime.Now;
            }

            mostraPlacar(placarJogador, placarCOM);
        }

        public void mostraPlacar(int placarJogador, int placarCOM)
        {
            labelJogador.Text = Convert.ToString(placarJogador);
            labelCOM.Text = Convert.ToString(placarCOM);
        }

        public bool verificaEscalacao()
        {
            bool validado = true;

            if (comboGoleiro.SelectedIndex == -1 || comboAlaDireita.SelectedIndex == -1 || comboAlaEsquerda.SelectedIndex == -1
                || comboFixo.SelectedIndex == -1 || comboPivo.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário escalar todo o time!", "Atenção");
                validado = false;
            }

            return validado;
        }

    }
}
