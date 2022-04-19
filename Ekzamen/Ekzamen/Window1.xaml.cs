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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection con;

        public Window1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source = DESKTOP-BBU13M2\SQL; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT [Employee].[LastName]+' '+[Employee].[MiddleName]+' '+[Employee].[FirstName],[Name] ,count(Client.LastName + ' ' + Client.MiddleName + ' ' + Client.FirstName) as [Кол-во заказов] FROM[dbo].[Employee] left join Position on PositionId = Position.ID left join [Order] on [Order].EmployeeID = Employee.ID left join Client on Client.ID = [Order].ClientID group by [Employee].[LastName]+' '+[Employee].[MiddleName]+' '+[Employee].[FirstName],[Name]", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            baza.ItemsSource = table.DefaultView;
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientOrders newFonm = new ClientOrders();
            newFonm.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Zayvki newFonm = new Zayvki();
            newFonm.Show();
            this.Hide();
        }
    }
}
