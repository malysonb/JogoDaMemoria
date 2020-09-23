using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace JogoDaMemoria
{
    public partial class Historico : Form
    {

        private String strConn = @"Data Source=" + Directory.GetCurrentDirectory() + "/Ranking.s3db";

        public Historico()
        {
            InitializeComponent();
            Atualizar();
        }

        //Atualizar valores da lista:
        public void Atualizar()
        {
            //Irá selecionar o banco de dados
            DataTable dt = new DataTable();
            String insSQL = "select * from Historico";
            SQLiteConnection con = new SQLiteConnection(strConn);
            SQLiteDataAdapter data = new SQLiteDataAdapter(insSQL, con);
            //Adicionar uma coluna para os numeros de indices
            dt.Columns.Add(" ", typeof(String));
            data.Fill(dt);
            //Irá adicionar os numeros nos indices
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = i + 1;
                }

            }
            Grid_Historico.DataSource = dt.DefaultView;
            Grid_Historico.Columns[0].Width = 21;
            Grid_Historico.Sort(Grid_Historico.Columns[0], ListSortDirection.Descending);
        }

        // Caso Clicar no botão apagar irá perguntar se deseja apagar ou não.
        private void BTN_APAGARHISTORICO_Click(object sender, EventArgs e)
        {
            //Irá exibir a mensagem e rodar o condicional perguntando se clicou em sim ou não
            if (MessageBox.Show("Deseja apagar?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Irá acessar o site
                String fraseDelete = "DELETE FROM Historico";
                SQLiteConnection conn = new SQLiteConnection(strConn);
                SQLiteCommand comando = new SQLiteCommand(fraseDelete, conn);
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
                Atualizar();
            }
        }
    }
}
