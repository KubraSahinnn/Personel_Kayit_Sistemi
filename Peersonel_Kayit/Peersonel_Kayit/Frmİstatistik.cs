using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peersonel_Kayit
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-GPOGES2\\MSSQLSERVER02;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Encrypt=False");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) From Tbl_Personel ", baglanti);
            SqlDataReader dr1=komut1.ExecuteReader();
            while(dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();
            
            //Evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read()) 
            {
                lblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=0",baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read()) 
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Toplam şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while(dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam maaş 
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) From Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
