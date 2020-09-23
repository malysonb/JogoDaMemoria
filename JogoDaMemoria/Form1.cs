using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace JogoDaMemoria
{
    public partial class Form1 : Form
    {
        Jogo jogo;
        int dificuldade = 10;
        int inteligencia = 4;
        public Form1()
        {
            InitializeComponent();
        }

        // ao carregar a janela irá selecionar os indices dos combobox
        private void Form1_Load(object sender, EventArgs e)
        {
            Combo_Dificuldade.SelectedIndex = 0;
            Combo_Inteligência.SelectedIndex = 0;
        }

        //Ao clicar no botão de jogar irá abrir a janela do jogo com dois jogadores humanos
        private void BTN_JOGAR_Click(object sender, EventArgs e)
        {
            jogo = new Jogo(TXB_JOGADOR1.Text,TXB_JOGADOR2.Text,true,dificuldade);
            this.Hide();
            jogo.ShowDialog();
            jogo.Close();
            this.Show();
        }

        //A cada momento irá comparar se você poderá jogar
        private void Controles_Tick(object sender, EventArgs e)
        {
            if(TXB_JOGADOR1.TextLength > 0 && TXB_JOGADOR2.TextLength > 0 && TXB_JOGADOR1.Text != TXB_JOGADOR2.Text)
            {
                BTN_JOGAR.Enabled = true;
            }
            else
            {
                BTN_JOGAR.Enabled = false;
            }
            if(TXB_NOMEvsPC.TextLength > 0)
            {
                BTN_JOGARvsPC.Enabled = true;
            }
            else
            {
                BTN_JOGARvsPC.Enabled = false;
            }
        }

        //Irá selecionar a quantidade de cartas (No principio eu estava planejando deixar a dificuldade sincronizada com o numero de cartas)
        private void Combo_Dificuldade_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Combo_Dificuldade.SelectedIndex)
            {
                case 0:
                    dificuldade = 10;
                    break;
                case 1:
                    dificuldade = 20;
                    break;
                case 2:
                    dificuldade = 30;
                    break;
            }
        }

        //Irá abrir a janela para ver o ranking
        private void BTN_VERRANKING_Click(object sender, EventArgs e)
        {
            Ranking rank = new Ranking();
            rank.ShowDialog();
        }

        //Irá abrir a janela para jogar contra o jogador
        private void BTN_JOGARvsPC_Click(object sender, EventArgs e)
        {
            jogo = new Jogo(TXB_NOMEvsPC.Text, "Computador", false, dificuldade,0,0,inteligencia);
            this.Hide();
            jogo.ShowDialog();
            jogo.Close();
            this.Show();
        }

        //Selecioanr o valor da inteligência da maquina
        private void Combo_Inteligência_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Combo_Inteligência.SelectedIndex)
            {
                case 0:
                    inteligencia = 4;
                    break;
                case 1:
                    inteligencia = 6;
                    break;
                case 2:
                    inteligencia = 8;
                    break;
                case 3:
                    inteligencia = 12;
                    break;
                case 4:
                    inteligencia = 16;
                    break;
            }
        }

        //Ao clicar no botão do histórico:
        private void BTN_Historico_Click(object sender, EventArgs e)
        {
            //Irá abrir a janela do histórico de partidas
            Historico historico = new Historico();
            historico.ShowDialog();
        }
    }
}
