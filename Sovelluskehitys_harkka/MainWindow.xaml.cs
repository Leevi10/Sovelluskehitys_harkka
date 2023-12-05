using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Data.SqlClient;

namespace Sovelluskehitys_harkka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string solun_arvo;
        string polku = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\k2101792\\Documents\\Tietokanta.mdf;Integrated Security=True;Connect Timeout=30";
        Tietokannantoiminnot tkt;
        public MainWindow()
        {
            InitializeComponent();

            tkt = new Tietokannantoiminnot();

            tkt.paivitaCombo(valitseliike_combo);
            
        }

        private void liikelisää_button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

            string sql = "INSERT INTO harjoitukset (liike) VALUES ('" + uusiliike_box.Text + "')";

            SqlCommand komento = new SqlCommand(sql, kanta);
            komento.ExecuteNonQuery();

            kanta.Close();

            tkt.paivitaCombo(valitseliike_combo);
        }
    }
}
