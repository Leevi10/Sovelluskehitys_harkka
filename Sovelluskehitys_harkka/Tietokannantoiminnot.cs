using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sovelluskehitys_harkka
{
    internal class Tietokannantoiminnot
    {
        string polku = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\k2101792\\Documents\\Tietokanta.mdf;Integrated Security=True;Connect Timeout=30";

        public void paivitaCombo(ComboBox kombo1)
        {
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

            SqlCommand komento = new SqlCommand("SELECT * FROM harjoitukset", kanta);
            SqlDataReader lukija  = komento.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("LIIKE", typeof(string));

            kombo1.ItemsSource = dt.DefaultView;
            kombo1.DisplayMemberPath = "LIIKE";
            kombo1.SelectedValuePath = "ID";

            while (lukija.Read()) 
            {
                int id = lukija.GetInt32(0);
                string liike = lukija.GetString(1);
                dt.Rows.Add(id, liike);
            }
            lukija.Close();
            kanta.Close();

        }
        public void paivitaDataGrid(string kysely, string taulu, DataGrid grid)
        {
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

        
            SqlCommand komento = kanta.CreateCommand();
            komento.CommandText = kysely; 

            
            SqlDataAdapter adapteri = new SqlDataAdapter(komento);
            DataTable dt = new DataTable(taulu);
            adapteri.Fill(dt);

            
            grid.ItemsSource = dt.DefaultView;

            kanta.Close();
        }
    }
}
