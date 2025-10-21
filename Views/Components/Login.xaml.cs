
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
using BCrypt.Net;
using System.Diagnostics;
using MongoDB.Bson;

namespace WPFLoginJoin.Views.Components
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public static bool loggedStatus { get; set; } = false;
        public static string currentUser { get; set; } = String.Empty;




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
            string localUserPassword = UserPassword.Text.Trim();

            bool isMatchGood = false;

            Login.currentUser = "";
            Login.loggedStatus = false;

            int theCount = theCollectionAsList.Count;

            for (int i = 0; i < theCount; i++)
            {
                AdminsDTO currentDoc = theCollectionAsList[i];

                try
                {

                    isMatchGood = BCrypt.Net.BCrypt.Verify(localUserPassword, currentDoc.Password);

                    if (isMatchGood)
                    {

                        Login.currentUser = currentDoc.Username;
                        Login.loggedStatus = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    // Catch exceptions if the hash format is unexpected.
                    Trace.WriteLine("Password Hashing error");
                }

            }



            MessageBox.Show("MATCH = " + Login.loggedStatus + " Username = " + Login.currentUser);

        }
    }
}
