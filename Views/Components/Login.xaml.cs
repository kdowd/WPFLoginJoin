
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



            if (!String.IsNullOrEmpty(userPass))
            {
                bool UnEncryptedHash = false;

                bool test = theCollectionAsList.Any((item) =>
                 {


                     try
                     {

                         UnEncryptedHash = BCrypt.Net.BCrypt.Verify(userPass, item.Password);

                     }
                     catch (Exception)
                     {
                         // Catch exceptions if the hash format is unexpected.
                         return false;
                     }


                     return UnEncryptedHash;

                 });

                //set static var
                if (UnEncryptedHash == true)
                {
                    loggedStatus = true;
                }
                else
                {
                    loggedStatus = false;
                }

                // yadda
                MessageBox.Show("Logged Status = " + loggedStatus.ToString());
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
