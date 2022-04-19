using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Ekzamen
{
    /// <summary>
    /// Логика взаимодействия для Zayvki.xaml
    /// </summary>
    public partial class Zayvki : Window
    {
        string data1;
        string data2;

        SqlConnection con;

        public Zayvki()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source = DESKTOP-BBU13M2\SQL; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date],[Accepted]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dtZayava.ItemsSource = table.DefaultView;
            con.Close();
        }

        private void btnPrinyat_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection(@"Data source = DESKTOP-BBU13M2\SQL; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Order].ID, LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID Where LastName+' '+ MiddleName+' '+FirstName = " +
                "'" + data1 + "' and [Name] = '" + data2 + "'", con);
            SqlDataReader r = com.ExecuteReader();
            r.Read();
            int id = Convert.ToInt32(r["[Order].ID"]);

            SqlCommand com1 = new SqlCommand("Update [Order] set [Accepted] = 'True' Where ID= " + id + "", con);
            com1.ExecuteNonQuery();
            con.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnOtkl_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection(@"Data source = DESKTOP-BBU13M2\SQL; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Order].ID, LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID Where LastName+' '+ MiddleName+' '+FirstName = " +
                "'" + data1 + "' and [Name] = '" + data2 + "'", con);
            SqlDataReader r = com.ExecuteReader();
            r.Read();
            int id = Convert.ToInt32(r["[Order].ID"]);

            SqlCommand com1 = new SqlCommand("Update [Order] set [Accepted] = 'False' Where ID= " + id + "", con);
            com1.ExecuteNonQuery();
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 newFonm = new Window1();
            newFonm.Show();
            this.Hide();
        }
    }
}
