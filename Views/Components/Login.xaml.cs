using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
                loggedStatus = true;
                // yadda
                MessageBox.Show(test.ToString());
            }

            // I could loop it instead
            //theCollectionAsList.ForEach(a =>
            //{

            //    if (a.Password == "password123")
            //    {
            //        loggedStatus = true;
            //        MessageBox.Show("PASS");

            //    }
            //});


        }
    }
}
