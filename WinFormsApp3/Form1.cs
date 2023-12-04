using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=.\\SQLEXPRESS01;Initial Catalog=ProjelerVT;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnVTdenOku_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sqlCumlesi = "SELECT PersonelNo, Ad, Soy, Sehir,Semt From Personel ";
                SqlCommand sqlKomut = new SqlCommand(sqlCumlesi, baglanti);
                SqlDataReader sdr = sqlKomut.ExecuteReader();

                while (sdr.Read())
                {
                    string pno = sdr[0].ToString();
                    string ad = sdr[1].ToString();
                    string soy = sdr[2].ToString();
                    string sehir = sdr[3].ToString();
                    string semt = sdr[4].ToString();
                    richTextBox1.Text = richTextBox1.Text + pno + " " +ad + " " + soy  + " " + sehir  + " " +  semt + " \n";  
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" SQL Query sýrasýnda hata verdi, Hata Kodu: SQLREAD101 \n " + ex.ToString());    
            }
            finally
            {
                if (baglanti != null) 
                baglanti.Close();
            }
        }
    }
}