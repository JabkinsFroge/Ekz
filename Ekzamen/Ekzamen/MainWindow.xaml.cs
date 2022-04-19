using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ekzamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data source = DESKTOP-BBU13M2\SQL; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("Select * from [Employee] Where Login = '" + Login.Text + "' and Password = '" + Pass.Text + "'", con);
            SqlDataReader r = com.ExecuteReader();
            string userlogin = "";
            string userpass = "";
            try
            {
                r.Read();
                userlogin = r["Login"].ToString();
                userpass = r["Password"].ToString();
            }
            catch { };
            if (Login.Text == userlogin)
            {
                if (Pass.Text == userpass)
                {
                    Window1 order = new Window1();
                    order.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Не удается найти пользователя!");
            }
        }
    }
}
