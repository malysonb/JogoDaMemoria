namespace JogoDaMemoria
{
    partial class Historico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Grid_Historico = new System.Windows.Forms.DataGridView();
            this.BTN_APAGARHISTORICO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Historico)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid_Historico
            // 
            this.Grid_Historico.AllowUserToAddRows = false;
            this.Grid_Historico.AllowUserToDeleteRows = false;
            this.Grid_Historico.AllowUserToResizeColumns = false;
            this.Grid_Historico.AllowUserToResizeRows = false;
            this.Grid_Historico.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid_Historico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Historico.Dock = System.Windows.Forms.DockStyle.Top;
            this.Grid_Historico.Location = new System.Drawing.Point(0, 0);
            this.Grid_Historico.Name = "Grid_Historico";
            this.Grid_Historico.RowHeadersVisible = false;
            this.Grid_Historico.ShowCellToolTips = false;
            this.Grid_Historico.ShowEditingIcon = false;
            this.Grid_Historico.Size = new System.Drawing.Size(424, 216);
            this.Grid_Historico.TabIndex = 0;
            // 
            // BTN_APAGARHISTORICO
            // 
            this.BTN_APAGARHISTORICO.Location = new System.Drawing.Point(167, 222);
            this.BTN_APAGARHISTORICO.Name = "BTN_APAGARHISTORICO";
            this.BTN_APAGARHISTORICO.Size = new System.Drawing.Size(75, 23);
            this.BTN_APAGARHISTORICO.TabIndex = 1;
            this.BTN_APAGARHISTORICO.Text = "Apagar";
            this.BTN_APAGARHISTORICO.UseVisualStyleBackColor = true;
            this.BTN_APAGARHISTORICO.Click += new System.EventHandler(this.BTN_APAGARHISTORICO_Click);
            // 
            // Historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 251);
            this.Controls.Add(this.BTN_APAGARHISTORICO);
            this.Controls.Add(this.Grid_Historico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Historico";
            this.Text = "Historico";
            //this.Load += new System.EventHandler(this.Historico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Historico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid_Historico;
        private System.Windows.Forms.Button BTN_APAGARHISTORICO;
    }
}