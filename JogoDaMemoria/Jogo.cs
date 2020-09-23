using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data.SQLite;

namespace JogoDaMemoria
{
    public partial class Jogo : Form
    {
        /*SQLite info:--------------------------------------------------------------------------------*/
        private String insSQL = "insert or ignore into Rank (Nome, Vitorias,Derrotas)";
        private String strConn = @"Data Source=" + Directory.GetCurrentDirectory() + "/Ranking.s3db";
        /*--------------------------------------------------------------------------------------------*/

        /*GameInfo:-----------------------------------------------------------------------------------*/
        private bool DoisJogadores,Acabou = false;
        private String Nome_Jogador_1, Nome_Jogador_2;
        private int Pontos_Jogador_1, Pontos_Jogador_2;
        private int vez = 0, mov = 0, tempo = 0,cont = 0;
        private bool primeiro_mov = false;
        private PictureBox[] Baralho;
        private Carta primeiro,ultimo;
        private int qt = 0;
        private int dificuldade = 20;
        private Carta Compare_A;
        /*--------------------------------------------------------------------------------------------*/

        /*Inteligencia Artificial---------------------------------------------------------------------*/
        private int contadormem = 0, lembranca = -1, lembranca2 = -1;
        private int inteligencia;
        private int[,] memoria;
        private bool permitido = true;
        private int contadorIA = 0;
        /*--------------------------------------------------------------------------------------------*/

        //Seta a primeira carta do baralho
        // Resumo:
        //      Seta a primeira carta do baralho.
        public void SetPrimeiro(Carta o)
        {
            primeiro = o;
        }

        //Pega a primeira carta do baralho
        public Carta GetPrimeiro()
        {
            return primeiro;
        }

        //É setada a ultima carta
        public void SetUltimo(Carta o)
        {
            ultimo = o;
        }

        //Escolhe a ultima carta adicionada
        public Carta GetUltimo()
        {
            return ultimo;
        }

        //Adiciona uma carta no final do baralho
        public void addfinal(int valor, PictureBox picturebox)
        {
            Carta temp = new Carta(valor, picturebox, this);
            if(qt == 0)
            {
                SetPrimeiro(temp);
                SetUltimo(temp);
            }
            else if(qt > 0)
            {
                Carta temp2 = GetUltimo();
                temp2.setProximo(temp);
                SetUltimo(temp);
            }
            qt++;
        }

        //Gerar numeros para as cartas
        public void gerarnumeros()
        {
            Carta temp = GetPrimeiro();
            //Todos os numeros disponiveis para adicionar as cartas:
            int[] numerosPossiveis = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9 , 10, 11, 12, 13, 14, 15 };
            for (int i = 0; i < dificuldade; i++)
            {
                //Gerar um numero aleatório baseado no tempo
                System.Threading.Thread.Sleep(50);
                Random rnd1 = new Random(DateTime.Now.Millisecond);
                
                int sorteio = rnd1.Next(1,(dificuldade/2)+1);
                bool ok1 = false;
                //Enquanto a carta não tiver um numero e não encontrar um numero disponivel:
                while(ok1 == false && temp.getNumero() == 0)
                {
                    for (int J = 0; J < (dificuldade/2); J++)
                    {
                        if (sorteio == numerosPossiveis[J])
                        {
                            ok1 = true;
                            numerosPossiveis[J] = 0;
                            break;
                        }
                    }
                    if(ok1 == false)
                    {
                        System.Threading.Thread.Sleep(50);
                        sorteio = rnd1.Next(1, (dificuldade / 2) + 1);
                    }
                }
                //Caso encontrar uma combinação:
                if(ok1 == true)
                {
                    System.Threading.Thread.Sleep(50);
                    Carta match = GetPrimeiro();
                    temp.setNumero(sorteio);
                    Random rnd2 = new Random(DateTime.Now.Millisecond);
                    bool ok = false;
                    while(ok == false)
                    {
                        int id = rnd2.Next(0, dificuldade);
                        match = GetPrimeiro();
                        while (id != match.getID())
                        {
                            if(match.getProximo() != null)
                            {
                                match = match.getProximo();
                            }
                        }
                        if (match.getNumero() == 0)
                        {
                            match.setNumero(temp.getNumero());
                            ok = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    } 
                }
                if (temp.getProximo() != null)
                {
                    temp = temp.getProximo();
                }
            }
        }

        //A cada 1 Segundo diminui o tempo
        private void Controle_Tempo_Tick(object sender, EventArgs e)
        {
            tempo--;
        }

        //Estes eventos ocorrem a cada 50 milisegundos durante o jogo
        private void TICKS_Tick(object sender, EventArgs e)
        {
            //Caso o computador ja estiver jogado duas vezes ele não estará mais disponivel para jogar:
            if(contadorIA > 1)
            {
                permitido = false;
            }
            //Caso o computador não tiver terminado suas jogadas, continuar permitido:
            else
            {
                permitido = true;
            }
            //A cada 50 milisegundos é atualizado o texto com o nome e os pontos do jogador
            TXT_Nome_Jogador1.Text = Nome_Jogador_1 + "\nPontos: " + Pontos_Jogador_1;
            TXT_Nome_Jogador2.Text = Nome_Jogador_2 + "\nPontos: " + Pontos_Jogador_2;
            TXT_TEMPO.Text = tempo.ToString();
            //A seta mostra é a vez dos jogadores
            //0 = Jogador 1
            //1 = Jogador 2
            if(vez == 0)
            {
                IMG_SETA1.Visible = true;
                IMG_SETA2.Visible = false;
                contadorIA = 0;
            }
            //Caso for a vez do jogador2:
            else if (vez == 1)
            {
                //Irá ativar a seta do lado do jogador 2.
                IMG_SETA1.Visible = false;
                IMG_SETA2.Visible = true;
                //Caso for a vez do computador:
                if(DoisJogadores == false && permitido)
                {
                    Random teste = new Random(DateTime.Now.Millisecond);
                    Carta temporario = GetPrimeiro();
                    //Caso Encontrar uma jogada na memoria que o computador possa jogar:
                    if (Pensar())
                    {
                        Console.WriteLine("Tentando jogar posições da memoria.");
                        //Caso for a primeira jogada:
                        if (cont == 0)
                        {
                            //Caso a carta que está planejada está disponivel:
                            if (ProcurarPorID(lembranca).EstaAtiva())
                            {
                                Console.WriteLine(cont + "—Tentando jogar na posicao: " + lembranca);
                                Comput_Click(lembranca, ProcurarPorID(lembranca));
                            }
                            //Caso a carta que estava planejada não está mais disponivel:
                            else
                            {
                                Console.WriteLine("Cartas da memoria ja foram jogadas.");
                                int aleatorio = teste.Next(0, dificuldade);
                                if (ProcurarPorID(aleatorio).EstaAtiva())
                                {
                                    Console.WriteLine(cont + "—Tentando jogar aleatoriamente na posicao: " + aleatorio);
                                    Comput_Click(aleatorio, ProcurarPorID(aleatorio));
                                }
                            }
                        }
                        if(cont == 1)
                        {
                            //Caso a carta que está planejada está disponivel:
                            if (ProcurarPorID(lembranca2).EstaAtiva())
                            {
                                Console.WriteLine(cont + "—Tentando jogar na posicao: " + lembranca2);
                                Comput_Click(lembranca2, ProcurarPorID(lembranca2));
                            }
                            //Caso a carta que estava planejada não está mais disponivel:
                            else
                            {
                                Console.WriteLine("Cartas da memoria ja foram jogadas.");
                                int aleatorio = teste.Next(0, dificuldade);
                                if (ProcurarPorID(aleatorio).EstaAtiva())
                                {
                                    Console.WriteLine(cont + "—Tentando jogar aleatoriamente na posicao: " + aleatorio);
                                    Comput_Click(aleatorio, ProcurarPorID(aleatorio));
                                }
                            }
                        }
                    }
                    //Caso não tiver nenhuma combinação disponivel, jogar aleatóriamente.
                    else
                    {
                        if (cont < 2)
                        {
                            int aleatorio = teste.Next(0, dificuldade);
                            if (ProcurarPorID(aleatorio).EstaAtiva())
                            {
                                Console.WriteLine(cont + "—Tentando jogar aleatoriamente na posicao: " + aleatorio);
                                Comput_Click(aleatorio, ProcurarPorID(aleatorio));
                            }
                        }
                    }
                }
            }
            //Esta parte é onde ocorre a atualização das imagens das cartas ao serem viradas.
            Carta temp = GetPrimeiro();
            bool finalizou = false;
            while(finalizou == false)
            {
                if(temp.EstaVirada() == false)
                {
                    temp.GetObjeto().Image = Properties.Resources.cardBack_blue5;
                }
                else if(temp.EstaVirada() == true || temp.EstaAtiva() == false)
                {
                    switch (temp.getNumero())
                    { 
                        case 1:
                            temp.GetObjeto().Image = Properties.Resources.cardClubsA;
                            break;
                        case 2:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs2;
                            break;
                        case 3:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs3;
                            break;
                        case 4:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs4;
                            break;
                        case 5:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs5;
                            break;
                        case 6:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs6;
                            break;
                        case 7:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs7;
                            break;
                        case 8:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs8;
                            break;
                        case 9:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs9;
                            break;
                        case 10:
                            temp.GetObjeto().Image = Properties.Resources.cardClubs10;
                            break;
                        case 11:
                            temp.GetObjeto().Image = Properties.Resources.cardDiamondsA;
                            break;
                        case 12:
                            temp.GetObjeto().Image = Properties.Resources.cardDiamonds2;
                            break;
                        case 13:
                            temp.GetObjeto().Image = Properties.Resources.cardDiamonds3;
                            break;
                        case 14:
                            temp.GetObjeto().Image = Properties.Resources.cardDiamonds4;
                            break;
                        case 15:
                            temp.GetObjeto().Image = Properties.Resources.cardDiamonds5;
                            break;
                    }
                }
                if(temp.getProximo() != null)
                {
                    temp = temp.getProximo();
                }
                else
                {
                    finalizou = true;
                }
                
            }
            //Irá atualizar o contador de tempo
            if(tempo > 0)
            {
                TXT_TEMPO.Text = tempo.ToString();
            }
            //Se caso o jogo acabar (seja por tempo ou acabou às cartas)
            if((Pontos_Jogador_1 + Pontos_Jogador_2 == (dificuldade / 2) || tempo <= 0) && (Acabou == false))
            {
                Acabou = true;
                //Caso o jogo der empate:
                if (Pontos_Jogador_1 == Pontos_Jogador_2)
                {
                    TICKS.Stop();
                    MessageBox.Show("Empate!\nSerá iniciado o desempate.", "Empate!");
                    Jogo jogo = new Jogo(Nome_Jogador_1, Nome_Jogador_2,DoisJogadores, dificuldade, Pontos_Jogador_1, Pontos_Jogador_2,inteligencia);
                    jogo.Show();
                    this.Close();
                }
                //Caso o jogador 1 ganhar, irá adicionar no ranking sua pontuação
                else if (Pontos_Jogador_1 > Pontos_Jogador_2)
                {
                    TICKS.Stop();
                    MessageBox.Show(Nome_Jogador_1 + ", O jogador 1, Ganhou o jogo! ", "Fim do jogo!");
                    SQLiteConnection conn = new SQLiteConnection(strConn);
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(insSQL + " values ('" + Nome_Jogador_1 + "', 0,0);\n" +
                        "UPDATE Rank SET Vitorias = Vitorias + 1 WHERE nome = '" + Nome_Jogador_1+"';", conn);
                    command.ExecuteNonQuery();
                    command = new SQLiteCommand(insSQL + " values ('" + Nome_Jogador_2 + "', 0,0);\n" +
                        "UPDATE Rank SET Derrotas = Derrotas + 1 WHERE nome = '" + Nome_Jogador_2 + "';", conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    //Adicionar o histórico da partida no banco de dados
                    AdicionarHistorico();
                    this.Close();
                }
                //Caso o jogador 2 ganhar, irá adicionar no ranking sua pontuação
                else if (Pontos_Jogador_2 > Pontos_Jogador_1)
                {
                    TICKS.Stop();
                    MessageBox.Show(Nome_Jogador_2 + ", O jogador 2, Ganhou o jogo! ", "Fim do jogo!");
                    SQLiteConnection conn = new SQLiteConnection(strConn);
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(insSQL + "values ('" + Nome_Jogador_2 + "', 0,0);\n" +
                        "UPDATE Rank SET Vitorias = Vitorias + 1 WHERE nome = '"+Nome_Jogador_2+"';", conn);
                    command.ExecuteNonQuery();
                    command = new SQLiteCommand(insSQL + "values ('" + Nome_Jogador_1 + "', 0,0);\n" +
                        "UPDATE Rank SET Derrotas = Derrotas + 1 WHERE nome = '" + Nome_Jogador_1 + "';", conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    //Adicionar o histórico da partida no banco de dados
                    AdicionarHistorico();
                    this.Close();
                }
            }
        }

        //Irá adicionar a pontuação dos jogadores no banco de dados
        public void AdicionarHistorico()
        {
            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteCommand comando = new SQLiteCommand("insert into Historico(Jogador_1,Pontos_1,Pontos_2,Jogador_2)\n" +
                "values('"+Nome_Jogador_1+"',"+Pontos_Jogador_1+","+Pontos_Jogador_2+",'"+Nome_Jogador_2+"')",conn);
            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();
        }

        //Adiciona na memoria do computador oq fazer.
        public void AdicionarNaMemoria(int id,int valor)
        {
            //Irá adicionar a carta na ultima posição da memoria
            for(int i = 0; i < memoria.GetLength(0); i++)
            {
                if(id == memoria[i,0])
                {
                    return;
                }
            }
            memoria[contadormem,0] = id;
            memoria[contadormem, 1] = valor;
            //Quando a memoria lotar irá sobrepor as cartas mais antigas
            contadormem = (contadormem < memoria.GetLength(0)-1) ? contadormem + 1 : 0;
        }

        //Procura a carta pelo ID
        public Carta ProcurarPorID(int ID)
        {
            //Irá procurar na lista de cartas qual delas tem o ID que está parametros e irá retornar a carta com o ID
            Carta temporario = GetPrimeiro();
            for(int i = 0; i < dificuldade; i++)
            {
                if(ID == temporario.getID())
                {
                    return temporario;
                }
                else
                {
                    temporario = temporario.getProximo();
                }
            }
            Console.WriteLine("Foi não");
            return null;
        }

        //Computador irá procurar se tem duas cartas com valores iguais na memoria
        public bool Pensar()
        {
            for(int x = 0; x < memoria.GetLength(0); x++)
            {
                for(int i = 0; i < memoria.GetLength(0); i++)
                {
                    if((memoria[x,0] != -1 && memoria[i,0] != -1) &&(ProcurarPorID(memoria[x,0]).getNumero() == ProcurarPorID(memoria[i,0]).getNumero() && x != i))
                    {
                        if(ProcurarPorID(memoria[x, 0]).EstaAtiva() == true && ProcurarPorID(memoria[i, 0]).EstaAtiva())
                        {
                            lembranca = memoria[x, 0];
                            lembranca2 = memoria[i, 0];
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return false;
        }

        //Ao clicar numa carta
        public void Baralho_Click( int id, Carta objeto, object sender = null, EventArgs e = null)
        {
            //Caso For a vez do computador, não ocorrerá nada
            if (DoisJogadores == false && vez == 1)
            {
                return;
            }
            else
            {
                //Se a carta está ativa:
                if (objeto.EstaAtiva() == true)
                {
                    //Caso for seu primeiro movimento:
                    if (primeiro_mov == false && cont == 0)
                    {
                        // Ao clicar na carta ela será virada
                        objeto.toogleVirada();
                        mov = id;
                        Compare_A = objeto;
                        primeiro_mov = true;
                        cont++;
                        //Irá adicionar na memoria do computador
                        AdicionarNaMemoria(id,objeto.getNumero());
                    }
                    //Caso for seu segundo movimento:
                    else if (cont == 1)
                    {
                        //Caso clicar na mesma carta anterior:
                        if (id == mov)
                        {
                            MessageBox.Show("Selecione outra carta!");
                        }
                        //Caso clicar numa carta nova:
                        else
                        {
                            //Irá adicionar na memoria, irá virar a carta e comparar as duas.
                            AdicionarNaMemoria(id,objeto.getNumero());
                            objeto.toogleVirada();
                            CompararCartas(Compare_A, objeto);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Esta Carta ja foi jogada!");
                }
            }
        }

        //Simula o clique do computador
        public void Comput_Click(int id, Carta objeto)
        {
            contadorIA++;
            if (objeto.EstaAtiva() == true && permitido)
            {
                if (primeiro_mov == false && cont == 0)
                {
                    // Ao clicar na carta ela será virada
                    objeto.toogleVirada();
                    mov = id;
                    Compare_A = objeto;
                    primeiro_mov = true;
                    cont++;
                }
                else if (cont == 1)
                {
                    //Caso clicar na mesma carta:
                    if (id == mov)
                    {
                        Console.WriteLine("Selecione outra carta!");
                        contadorIA = 1;
                    }
                    //Caso clicar numa carta diferente
                    else
                    {
                        //Irá adicionar na memoria a carta que foi jogada:
                        AdicionarNaMemoria(id,objeto.getNumero());
                        objeto.toogleVirada();
                        CompararCartas(Compare_A, objeto);
                    }
                }
            }
            else
            {
                Console.WriteLine("Esta Carta ja foi jogada!");
                contadorIA = 1;
            }
        }

        //Compara duas Cartas
        public void CompararCartas(Carta A, Carta B)
        {
            //Se os numeros das cartas forem iguais irá:
            if(A.getNumero() == B.getNumero())
            {
                //Se for a vez do jogador 1:
                if(vez == 0)
                {
                    //Adicionar os pontos e Desativar as cartas para que não possam ser jogadas mais
                    Pontos_Jogador_1 = Pontos_Jogador_1 + 1;
                    A.Desativar();
                    B.Desativar();
                    Compare_A = null;
                    primeiro_mov = false;
                    cont = 0;
                }
                //Se for a vez do jogador 2:
                if (vez == 1)
                {
                    //Adicionar os pontos e Desativar as cartas para que não possam ser jogadas mais
                    Compare_A = null;
                    A.Desativar();
                    B.Desativar();
                    primeiro_mov = false;
                    Pontos_Jogador_2 = Pontos_Jogador_2 + 1;
                    cont = 0;
                    //Caso estiver jogando com o computador:
                    if(DoisJogadores == false)
                    EsperarNSegundos(1);
                    contadorIA = 0;
                }
            }
            //Caso contrário:
            else
            {
                cont = 0;
                Compare_A = null;
                EsperarNSegundos(1);
                A.toogleVirada();
                B.toogleVirada();
                primeiro_mov = false;
                mov = 0;
                vez = (vez == 0) ? 1 : 0;
            }
        }

        //Espera N Segundos para continuar a thread
        private void EsperarNSegundos(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desejado = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desejado)
            {
                Thread.Sleep(1);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        //Metodo construtor do modo do jogo, todos os parametros irá setar todas as variáveis necessarias
        //Para o funcionamento do jogo.
        public Jogo(String Nome1, String Nome2, bool doisjogadores, int dificul = 10, int pontos_1 = 0, int pontos_2 = 0, int memo = 4)
        {
            InitializeComponent();
            inteligencia = memo;
            memoria = new int[memo, 2];
            Nome_Jogador_1 = Nome1;
            dificuldade = dificul;
            Pontos_Jogador_1 = pontos_1;
            Pontos_Jogador_2 = pontos_2;
            DoisJogadores = doisjogadores;
            switch (dificul) 
            {
                case 10:
                    tempo = 120;
                    break;
                case 20:
                    tempo = 240;
                    break;
                case 30:
                    tempo = 360;
                    break;
            }
            if (doisjogadores)
            {
                Nome_Jogador_2 = Nome2;
            }
            else
            {
                Nome_Jogador_2 = "Computador";
            }
            panel1.Enabled = true;
            panel1.Visible = true;
            panel1.Location = new System.Drawing.Point(0, 75);
        }

        // Este metodo é chamado ao iniciar o jogo.
        private void Jogo_Load(object sender, EventArgs e)
        {
            //Irá virar a seta do jogador2
            IMG_SETA2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            IMG_SETA2.Invalidate();
            //---------------------------------------------------------//
            Baralho = new PictureBox[dificuldade];
            int y = 0;
            int z = 0;
            //Irá organizar as cartas dependendo da dificuldade escolhida
            for (int i = 0; i < dificuldade; i++)
            {
                Baralho[i] = (PictureBox)this.Controls.Find("IMG_CARTA_" + (i + 1), true)[0];
                Baralho[i].Visible = true;
                if(dificuldade == 10)
                {
                    const int distancia = 106;
                    Baralho[i].Size = new System.Drawing.Size(100, 139);
                    if(i < 5)
                    {
                        Baralho[i].Location = new System.Drawing.Point(120 + (distancia * i + 1), 91);
                    }
                    else
                    {
                        Baralho[i].Location = new System.Drawing.Point(120 + (distancia * y + 1), 236);
                        y++;
                    }
                }
                if (dificuldade == 20)
                {
                    const int distancia = 106;
                    Baralho[i].Size = new System.Drawing.Size(100, 139);
                    if (i < 7)
                    {
                        Baralho[i].Location = new System.Drawing.Point(14 + (distancia * i + 1), 15);
                    }
                    else if(i >= 7 && i < 14)
                    {
                        Baralho[i].Location = new System.Drawing.Point(14 + (distancia * y + 1), 160);
                        y++;
                    }
                    else if(i >= 14 && i < 21)
                    {
                        Baralho[i].Location = new System.Drawing.Point(66 + (distancia * z + 1), 305);
                        z++;
                    }
                }
                Baralho[i].Enabled = true;
                addfinal(i, Baralho[i]);
            }
            //Seta todos os valores da memoria para -1 (Nenhuma carta)
            for(int j = 0; j < memoria.GetLength(0); j++)
            {
                memoria[j,0] = -1;
                memoria[j, 1] = -1;
            }
            gerarnumeros();
        }
    }
    // Objeto das cartas, contem todas as informações necessarias para funcionar
    public class Carta
    {
        private int ID;
        private int numero = 0;
        private PictureBox objeto;
        private Carta proximo;
        private Jogo jogo;
        private bool virada = false;
        private bool ativa = true;

        //Metodo construtor da carta, onde os parametros setam todos as variaveis
        public Carta(int ID_N, PictureBox imagem, Jogo este)
        {
            jogo = este;
            ID = ID_N;
            objeto = imagem;
            objeto.Click += new EventHandler((sender, e) => jogo.Baralho_Click(ID,this, sender, e));
        }

        //Desativa a carta para não poder ser jogada mais
        public void Desativar()
        {
            ativa = false;
        }

        //Retorna se a carta ainda pode ser jogada
        public bool EstaAtiva()
        {
            return ativa;
        }

        //Retorna o objeto da interface (clicavel)
        public PictureBox GetObjeto()
        {
            return objeto;
        }

        //Retorna o ID unico da carta
        public int getID()
        {
            return ID;
        }

        //Retorna se está virada ou não
        public bool EstaVirada()
        {
            return virada;
        }

        //Vira a carta
        public void toogleVirada()
        {
            virada = !virada;
        }

        //Muda o sentido da carta
        public void SetVirada(bool a)
        {
            virada = a;
        }

        //Aponta a proxima carta para a carta do parametro
        public void setProximo(Carta o)
        {
            proximo = o;
        }

        //Retorna a proxima carta (se tiver)
        public Carta getProximo()
        {
            return proximo;
        }

        //Retorna o valor da carta
        public int getNumero()
        {
            return numero;
        }

        //Seta o valor da carta
        public void setNumero(int num)
        {
            numero = num;
        }
    }
}
