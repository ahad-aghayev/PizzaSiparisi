using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PizzaSiparis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbBoyut.Items.Add("Küçük 150 Tl");
            cmbBoyut.Items.Add("Orta 200 Tl");
            cmbBoyut.Items.Add("Büyük 250 Tl");

            cmbKenarTipi.Items.Add("İnce ");
            cmbKenarTipi.Items.Add("Normal +20 Tl");
            cmbKenarTipi.Items.Add("Kalın +30 TL");

            cmbTatli.Items.Add("Pastel de Nata +200 Tl");
            cmbTatli.Items.Add("Suffle +200 Tl");
            cmbTatli.Items.Add("Lazza +200 Tl");
            cmbTatli.Items.Add("Tatlı İstemiyorum");

            cmbIcecek.Items.Add("Pepsi +75 Tl");
            cmbIcecek.Items.Add("Pepsi Zero +75 Tl");
            cmbIcecek.Items.Add("Yedigün +75 Tl");
            cmbIcecek.Items.Add("İçecek İstemiyorum");


            btnSiparişVer.Enabled = false;// başlanğıcta button pasif 

            cmbBoyut.SelectedIndexChanged += ComboBoxSecimi;
            cmbKenarTipi.SelectedIndexChanged += ComboBoxSecimi;
            cmbTatli.SelectedIndexChanged += ComboBoxSecimi;
            cmbIcecek.SelectedIndexChanged += ComboBoxSecimi;
        }

        private void ComboBoxSecimi(object sender, EventArgs e)
        {
            // ComboBox seçimi ile butonu aktif hale getirir
            btnSiparişVer.Enabled = !string.IsNullOrEmpty(cmbBoyut.Text) &&
                                    !string.IsNullOrEmpty(cmbKenarTipi.Text) &&
                                    !string.IsNullOrEmpty(cmbTatli.Text) &&
                                    !string.IsNullOrEmpty(cmbIcecek.Text);
        }


        private void btnSiparişVer_Click(object sender, EventArgs e)
        {
            try
            {
                Siparis siparis = new Siparis();

                siparis.Boyut = cmbBoyut.Text;
                siparis.KenarTipi = cmbKenarTipi.Text;
                siparis.Tatli = cmbTatli.Text;
                siparis.Içecek = cmbIcecek.Text;

                // Malzeme seçimlerini kontrol et ve ekle
                if (cCitirTavuk.Checked) siparis.MalzemeEkle("Çıtır Tavuk");
                if (cRuffles.Checked) siparis.MalzemeEkle("Ruffles");
                if (cSoganHalkasi.Checked) siparis.MalzemeEkle("Soğan Halkası");
                if (cTiritkliPatates.Checked) siparis.MalzemeEkle("Tırtıklı Patates");

                decimal SonFiyat = siparis.Hesapla();

                string siparisOzeti = "Boyut: " + siparis.Boyut +
                                       "\nKenar Tipi: " + siparis.KenarTipi +
                                       "\nİçecek: " + siparis.Içecek +
                                       "\nTatlı: " + siparis.Tatli +
                                       "\nMalzemeler: " + siparis.Malzemeler +
                                       "\nToplam Tutar :" + SonFiyat+" Tl";

                MessageBox.Show(siparisOzeti, "Sipariş Özeti");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata oluştu");
            }
        }
    }
}
