using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        string polku = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\leevi\\OneDrive\\Tiedostot\\Tietokanta.mdf;Integrated Security=True;Connect Timeout=30";
        Tietokannantoiminnot tkt;
        public MainWindow()
        {
            InitializeComponent();

            tkt = new Tietokannantoiminnot();

            tkt.paivitaLKCombo(valitseliike_combo);
            tkt.paivitaKTcombo(valitsekäyttäjä_combo, aloitareeni_combo);

            tkt.paivitaDataGrid("SELECT re.id AS id, k.käyttäjätunnus AS käyttäjä, ha.liike AS liike, re.paino AS paino, re.toistomäärä AS toistot, kr.pvm AS pvm FROM reeni re, käyttäjät k, harjoitukset ha, käyttäjänreenit kr WHERE kr.id = re.reeni_id AND k.id = kr.käyttäjä_id AND ha.id = re.harjoitus_id","treeni", treeni_tiedot_lista);


        }

        private void liikelisää_button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

            string sql = "INSERT INTO harjoitukset (liike) VALUES ('" + uusiliike_box.Text + "')";

            SqlCommand komento = new SqlCommand(sql, kanta);
            komento.ExecuteNonQuery();

            kanta.Close();

            tkt.paivitaLKCombo(valitseliike_combo);
        }

        private void käyttäjä_lisää_button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

            string sql = "INSERT INTO käyttäjät (käyttäjätunnus) VALUES ('" + uusikäyttäjä_box.Text + "')";

            SqlCommand komento = new SqlCommand(sql, kanta);
            komento.ExecuteNonQuery();

            kanta.Close();

            tkt.paivitaKTcombo(valitsekäyttäjä_combo, aloitareeni_combo);
        }

        private void Lisäätreeni_button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection kanta = new SqlConnection (polku);
            kanta.Open();

            string kayttajaID = valitsekäyttäjä_combo.SelectedValue.ToString();
            string liikeID = valitseliike_combo.SelectedValue.ToString();

            string sql = "INSERT INTO reeni(harjoitus_id, reeni_id, toistomäärä, paino) SELECT harjoitukset.id, käyttäjät.id, '" + toisto_box.Text + "', '" + paino_box.Text + "' FROM harjoitukset CROSS JOIN käyttäjät WHERE harjoitukset.id = '"+liikeID+"' AND käyttäjät.id = '"+kayttajaID+"'";

            SqlCommand komento = new SqlCommand(sql, kanta);
            komento.ExecuteNonQuery();
            kanta.Close();

            tkt.paivitaDataGrid("SELECT re.id AS id, k.käyttäjätunnus AS käyttäjä, ha.liike AS liike, re.paino AS paino, re.toistomäärä AS toistot, kr.pvm AS pvm FROM reeni re, käyttäjät k, harjoitukset ha, käyttäjänreenit kr WHERE kr.id = re.reeni_id AND k.id = kr.käyttäjä_id AND ha.id = re.harjoitus_id" , "treeni", treeni_tiedot_lista);
        }

        private void aloitareeni_button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

            string kayttaja = aloitareeni_combo.SelectedValue.ToString();

            string paiva = nykyinen_paiva.SelectedDate.Value.Day.ToString();
            string kuukausi = nykyinen_paiva.SelectedDate.Value.Month.ToString();
            string vuosi = nykyinen_paiva.SelectedDate.Value.Year.ToString();

            string paivamaara = paiva + "/" + kuukausi + "/" + vuosi;

            string sql = "INSERT INTO käyttäjänreenit(käyttäjä_id, pvm) VALUES ('" + kayttaja + "', '" + paivamaara + "');";

            SqlCommand komento = new SqlCommand(sql, kanta);
            komento.ExecuteNonQuery();

            kanta.Close();

            
        }
    }
}
