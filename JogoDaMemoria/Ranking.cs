using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace JogoDaMemoria
{
    public partial class Ranking : Form
    {

        private String strConn = @"Data Source=" + Directory.GetCurrentDirectory() + "/Ranking.s3db";

        public Ranking()
        {
            InitializeComponent();
            Atualizar();
        }

        //Atualizar valores da lista:
        private void Atualizar()
        {
            DataTable dt = new DataTable();

            String insSQL = "select * from Rank";
            

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
            dataGridView1.DataSource = dt.DefaultView;
            dataGridView1.Columns[0].Width = 21;
            //Irá deixar a lista em ordem crescente baseado nos pontos
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
        }

        // Caso Clicar no botão apagar irá perguntar se deseja apagar ou não.
        private void BTN_APAGAR_Click(object sender, EventArgs e)
        {
            //Irá exibir a mensagem e rodar o condicional perguntando se clicou em sim ou não
            if (MessageBox.Show("Deseja apagar?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Irá acessar o banco
                String fraseDelete = "DELETE FROM Rank";
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
