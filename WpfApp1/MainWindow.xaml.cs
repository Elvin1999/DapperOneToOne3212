using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using WpfApp1.Entities;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var conn = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            using (var connection=new SqlConnection(conn))
            {
                var sql = @"SELECT Capitals.CapitalId,Capitals.Name,Capitals.CountryId,
                        Countries.CountryId,Countries.Name
                        FROM Capitals
                        INNER JOIN Countries
                        ON Capitals.CountryId=Countries.CountryId";

                var capitals = connection.Query<Capital, Country, Capital>(sql,
                    (capital, country) =>
                    {
                        capital.Country = country;
                        return capital;
                    }, splitOn: "CountryId").ToList();

                myDataGrid.ItemsSource = capitals;




                //var countries = connection.Query<Country,Capital,Country>(sql,
                //    (country, capital) =>
                //    {
                //        country.Capital=capital;
                //        return country;
                //    }, splitOn: "CountryId").ToList();

                //myDataGrid.ItemsSource = countries;
            }

        }
    }
}
