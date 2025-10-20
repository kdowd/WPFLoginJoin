using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
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
using WPFLoginJoin.Database;
using WPFLoginJoin.ViewModels;

namespace WPFLoginJoin.Views.Components
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public bool loggedStatus { get; set; } = false;


        public Login()
        {
            InitializeComponent();

        }

        private void OnCheckLogin(object sender, RoutedEventArgs e)
        {

            IMongoDatabase? theDatabase = Connection.database;

            if (theDatabase == null)
            {
                return;
            }

            //username "admin1"
            //password "password123"
            IQueryable<AdminsDTO> theCollection = theDatabase.GetCollection<AdminsDTO>("admins").AsQueryable<AdminsDTO>();
            List<AdminsDTO> theCollectionAsList = theCollection.ToList<AdminsDTO>();
            string userPass = UserPassword.Text.Trim();
            string userName = UserName.Text.Trim();

            if (!String.IsNullOrEmpty(userPass) && !String.IsNullOrEmpty(userName))
            {
                bool test = theCollectionAsList.Any(item => item.Password.Equals(userPass) && item.Username.Equals(userName));

                MessageBox.Show(test.ToString());
            }


            //theCollectionAsList.ForEach(a =>
            //{

            //    if (a.Password == "password123")
            //    {
            //        loggedStatus = true;
            //        MessageBox.Show("PASS");

            //    }
            //});



            //var index = theCollection.Select((value, index) => new { value, index });

            // int indexOfKiwi = theCollection.Select((value, index) => new { value, index })
            //                    .Where(item => item.user == "Kiwi")
            //                    .Select(item => item.index)
            //                    .DefaultIfEmpty(-1) // If no match, return -1
            //                    .FirstOrDefault();



        }
    }
}
