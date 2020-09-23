namespace JogoDaMemoria
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TXT_TITULO = new System.Windows.Forms.Label();
            this.TXT_ESCOLHA = new System.Windows.Forms.Label();
            this.GrP_JxJ = new System.Windows.Forms.GroupBox();
            this.TXT_NOME2 = new System.Windows.Forms.Label();
            this.TXT_NOME1 = new System.Windows.Forms.Label();
            this.TXB_JOGADOR1 = new System.Windows.Forms.TextBox();
            this.TXB_JOGADOR2 = new System.Windows.Forms.TextBox();
            this.BTN_JOGAR = new System.Windows.Forms.Button();
            this.Controles = new System.Windows.Forms.Timer(this.components);
            this.Combo_Dificuldade = new System.Windows.Forms.ComboBox();
            this.TXT_DIFICULDADE = new System.Windows.Forms.Label();
            this.BTN_VERRANKING = new System.Windows.Forms.Button();
            this.Grupo_PC = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Combo_Inteligência = new System.Windows.Forms.ComboBox();
            this.BTN_JOGARvsPC = new System.Windows.Forms.Button();
            this.TXT_NOMEJ1 = new System.Windows.Forms.Label();
            this.TXB_NOMEvsPC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Historico = new System.Windows.Forms.Button();
            this.GrP_JxJ.SuspendLayout();
            this.Grupo_PC.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXT_TITULO
            // 
            this.TXT_TITULO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TXT_TITULO.AutoSize = true;
            this.TXT_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_TITULO.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TXT_TITULO.Location = new System.Drawing.Point(89, 9);
            this.TXT_TITULO.Name = "TXT_TITULO";
            this.TXT_TITULO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TXT_TITULO.Size = new System.Drawing.Size(178, 25);
            this.TXT_TITULO.TabIndex = 0;
            this.TXT_TITULO.Text = "Jogo da Memória";
            this.TXT_TITULO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TXT_TITULO.UseMnemonic = false;
            // 
            // TXT_ESCOLHA
            // 
            this.TXT_ESCOLHA.AutoSize = true;
            this.TXT_ESCOLHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_ESCOLHA.Location = new System.Drawing.Point(9, 91);
            this.TXT_ESCOLHA.Name = "TXT_ESCOLHA";
            this.TXT_ESCOLHA.Size = new System.Drawing.Size(197, 16);
            this.TXT_ESCOLHA.TabIndex = 1;
            this.TXT_ESCOLHA.Text = "Escolha seu modo de jogo:";
            // 
            // GrP_JxJ
            // 
            this.GrP_JxJ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrP_JxJ.Controls.Add(this.TXT_NOME2);
            this.GrP_JxJ.Controls.Add(this.TXT_NOME1);
            this.GrP_JxJ.Controls.Add(this.TXB_JOGADOR1);
            this.GrP_JxJ.Controls.Add(this.TXB_JOGADOR2);
            this.GrP_JxJ.Controls.Add(this.BTN_JOGAR);
            this.GrP_JxJ.Location = new System.Drawing.Point(12, 110);
            this.GrP_JxJ.Name = "GrP_JxJ";
            this.GrP_JxJ.Size = new System.Drawing.Size(332, 131);
            this.GrP_JxJ.TabIndex = 3;
            this.GrP_JxJ.TabStop = false;
            this.GrP_JxJ.Text = "Jogador Vs. Jogador";
            // 
            // TXT_NOME2
            // 
            this.TXT_NOME2.AutoSize = true;
            this.TXT_NOME2.Location = new System.Drawing.Point(6, 69);
            this.TXT_NOME2.Name = "TXT_NOME2";
            this.TXT_NOME2.Size = new System.Drawing.Size(138, 13);
            this.TXT_NOME2.TabIndex = 7;
            this.TXT_NOME2.Text = "Insira o nome do Jogador 2:";
            // 
            // TXT_NOME1
            // 
            this.TXT_NOME1.AutoSize = true;
            this.TXT_NOME1.Location = new System.Drawing.Point(6, 18);
            this.TXT_NOME1.Name = "TXT_NOME1";
            this.TXT_NOME1.Size = new System.Drawing.Size(138, 13);
            this.TXT_NOME1.TabIndex = 6;
            this.TXT_NOME1.Text = "Insira o nome do Jogador 1:";
            // 
            // TXB_JOGADOR1
            // 
            this.TXB_JOGADOR1.Location = new System.Drawing.Point(6, 34);
            this.TXB_JOGADOR1.MaxLength = 25;
            this.TXB_JOGADOR1.Name = "TXB_JOGADOR1";
            this.TXB_JOGADOR1.Size = new System.Drawing.Size(239, 20);
            this.TXB_JOGADOR1.TabIndex = 4;
            //this.TXB_JOGADOR1.TextChanged += new System.EventHandler(this.TXB_JOGADOR1_TextChanged);
            // 
            // TXB_JOGADOR2
            // 
            this.TXB_JOGADOR2.Location = new System.Drawing.Point(6, 85);
            this.TXB_JOGADOR2.MaxLength = 25;
            this.TXB_JOGADOR2.Name = "TXB_JOGADOR2";
            this.TXB_JOGADOR2.Size = new System.Drawing.Size(239, 20);
            this.TXB_JOGADOR2.TabIndex = 5;
            //this.TXB_JOGADOR2.TextChanged += new System.EventHandler(this.TXB_JOGADOR2_TextChanged);
            // 
            // BTN_JOGAR
            // 
            this.BTN_JOGAR.AccessibleDescription = "Necessario o nome dos jogadores";
            this.BTN_JOGAR.Location = new System.Drawing.Point(248, 58);
            this.BTN_JOGAR.Name = "BTN_JOGAR";
            this.BTN_JOGAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_JOGAR.TabIndex = 4;
            this.BTN_JOGAR.Text = "Jogar";
            this.BTN_JOGAR.UseVisualStyleBackColor = true;
            this.BTN_JOGAR.Click += new System.EventHandler(this.BTN_JOGAR_Click);
            // 
            // Controles
            // 
            this.Controles.Enabled = true;
            this.Controles.Interval = 50;
            this.Controles.Tick += new System.EventHandler(this.Controles_Tick);
            // 
            // Combo_Dificuldade
            // 
            this.Combo_Dificuldade.DisplayMember = "1";
            this.Combo_Dificuldade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Dificuldade.FormattingEnabled = true;
            this.Combo_Dificuldade.Items.AddRange(new object[] {
            "10 Cartas — 2 minutos",
            "20 Cartas — 4 minutos",
            "30 Cartas — 6 minutos"});
            this.Combo_Dificuldade.Location = new System.Drawing.Point(12, 60);
            this.Combo_Dificuldade.MaxDropDownItems = 3;
            this.Combo_Dificuldade.Name = "Combo_Dificuldade";
            this.Combo_Dificuldade.Size = new System.Drawing.Size(144, 21);
            this.Combo_Dificuldade.TabIndex = 1;
            this.Combo_Dificuldade.ValueMember = "1";
            this.Combo_Dificuldade.SelectedIndexChanged += new System.EventHandler(this.Combo_Dificuldade_SelectedIndexChanged);
            // 
            // TXT_DIFICULDADE
            // 
            this.TXT_DIFICULDADE.AutoSize = true;
            this.TXT_DIFICULDADE.Location = new System.Drawing.Point(9, 44);
            this.TXT_DIFICULDADE.Name = "TXT_DIFICULDADE";
            this.TXT_DIFICULDADE.Size = new System.Drawing.Size(110, 13);
            this.TXT_DIFICULDADE.TabIndex = 7;
            this.TXT_DIFICULDADE.Text = "Quantidade de Cartas";
            // 
            // BTN_VERRANKING
            // 
            this.BTN_VERRANKING.Location = new System.Drawing.Point(260, 58);
            this.BTN_VERRANKING.Name = "BTN_VERRANKING";
            this.BTN_VERRANKING.Size = new System.Drawing.Size(75, 23);
            this.BTN_VERRANKING.TabIndex = 8;
            this.BTN_VERRANKING.Text = "Ver Ranking";
            this.BTN_VERRANKING.UseVisualStyleBackColor = true;
            this.BTN_VERRANKING.Click += new System.EventHandler(this.BTN_VERRANKING_Click);
            // 
            // Grupo_PC
            // 
            this.Grupo_PC.Controls.Add(this.label1);
            this.Grupo_PC.Controls.Add(this.Combo_Inteligência);
            this.Grupo_PC.Controls.Add(this.BTN_JOGARvsPC);
            this.Grupo_PC.Controls.Add(this.TXT_NOMEJ1);
            this.Grupo_PC.Controls.Add(this.TXB_NOMEvsPC);
            this.Grupo_PC.Location = new System.Drawing.Point(12, 243);
            this.Grupo_PC.Name = "Grupo_PC";
            this.Grupo_PC.Size = new System.Drawing.Size(332, 105);
            this.Grupo_PC.TabIndex = 9;
            this.Grupo_PC.TabStop = false;
            this.Grupo_PC.Text = "Jogador Vs. Computador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecione a inteligência da maquina:";
            // 
            // Combo_Inteligência
            // 
            this.Combo_Inteligência.DisplayMember = "1";
            this.Combo_Inteligência.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Inteligência.FormattingEnabled = true;
            this.Combo_Inteligência.Items.AddRange(new object[] {
            "Fácil — Relembra 4 Cartas.",
            "Normal — Relembra 6 Cartas.",
            "Médio — Relembra 8 Cartas.",
            "Difícil — Relembra 12 Cartas.",
            "Impossível — Relembra 16 Cartas.  "});
            this.Combo_Inteligência.Location = new System.Drawing.Point(6, 39);
            this.Combo_Inteligência.Name = "Combo_Inteligência";
            this.Combo_Inteligência.Size = new System.Drawing.Size(239, 21);
            this.Combo_Inteligência.TabIndex = 1;
            this.Combo_Inteligência.ValueMember = "1";
            this.Combo_Inteligência.SelectedIndexChanged += new System.EventHandler(this.Combo_Inteligência_SelectedIndexChanged);
            // 
            // BTN_JOGARvsPC
            // 
            this.BTN_JOGARvsPC.Location = new System.Drawing.Point(248, 77);
            this.BTN_JOGARvsPC.Name = "BTN_JOGARvsPC";
            this.BTN_JOGARvsPC.Size = new System.Drawing.Size(75, 23);
            this.BTN_JOGARvsPC.TabIndex = 2;
            this.BTN_JOGARvsPC.Text = "Jogar";
            this.BTN_JOGARvsPC.UseVisualStyleBackColor = true;
            this.BTN_JOGARvsPC.Click += new System.EventHandler(this.BTN_JOGARvsPC_Click);
            // 
            // TXT_NOMEJ1
            // 
            this.TXT_NOMEJ1.AutoSize = true;
            this.TXT_NOMEJ1.Location = new System.Drawing.Point(6, 63);
            this.TXT_NOMEJ1.Name = "TXT_NOMEJ1";
            this.TXT_NOMEJ1.Size = new System.Drawing.Size(129, 13);
            this.TXT_NOMEJ1.TabIndex = 1;
            this.TXT_NOMEJ1.Text = "Insira o nome do Jogador:";
            // 
            // TXB_NOMEvsPC
            // 
            this.TXB_NOMEvsPC.Location = new System.Drawing.Point(6, 79);
            this.TXB_NOMEvsPC.Name = "TXB_NOMEvsPC";
            this.TXB_NOMEvsPC.Size = new System.Drawing.Size(239, 20);
            this.TXB_NOMEvsPC.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fênix TECH — Todos os direitos reservados.";
            // 
            // BTN_Historico
            // 
            this.BTN_Historico.Location = new System.Drawing.Point(179, 58);
            this.BTN_Historico.Name = "BTN_Historico";
            this.BTN_Historico.Size = new System.Drawing.Size(75, 23);
            this.BTN_Historico.TabIndex = 11;
            this.BTN_Historico.Text = "Histórico";
            this.BTN_Historico.UseVisualStyleBackColor = true;
            this.BTN_Historico.Click += new System.EventHandler(this.BTN_Historico_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 370);
            this.Controls.Add(this.BTN_Historico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Grupo_PC);
            this.Controls.Add(this.BTN_VERRANKING);
            this.Controls.Add(this.TXT_DIFICULDADE);
            this.Controls.Add(this.Combo_Dificuldade);
            this.Controls.Add(this.GrP_JxJ);
            this.Controls.Add(this.TXT_ESCOLHA);
            this.Controls.Add(this.TXT_TITULO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Jogo Da Memoria";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GrP_JxJ.ResumeLayout(false);
            this.GrP_JxJ.PerformLayout();
            this.Grupo_PC.ResumeLayout(false);
            this.Grupo_PC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TXT_TITULO;
        private System.Windows.Forms.Label TXT_ESCOLHA;
        private System.Windows.Forms.GroupBox GrP_JxJ;
        private System.Windows.Forms.Button BTN_JOGAR;
        private System.Windows.Forms.TextBox TXB_JOGADOR1;
        private System.Windows.Forms.TextBox TXB_JOGADOR2;
        private System.Windows.Forms.Label TXT_NOME2;
        private System.Windows.Forms.Label TXT_NOME1;
        private System.Windows.Forms.Timer Controles;
        private System.Windows.Forms.ComboBox Combo_Dificuldade;
        private System.Windows.Forms.Label TXT_DIFICULDADE;
        private System.Windows.Forms.Button BTN_VERRANKING;
        private System.Windows.Forms.GroupBox Grupo_PC;
        private System.Windows.Forms.Button BTN_JOGARvsPC;
        private System.Windows.Forms.Label TXT_NOMEJ1;
        private System.Windows.Forms.TextBox TXB_NOMEvsPC;
        private System.Windows.Forms.ComboBox Combo_Inteligência;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_Historico;
    }
}

