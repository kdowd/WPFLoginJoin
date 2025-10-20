using MongoDB.Driver;
using System;
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
    /// Interaction logic for CreateAdmin.xaml
    /// </summary>
    public partial class CreateAdmin : UserControl
    {
        //public string MyProperty { get; set; } = "Yadda";

        //public event PropertyChangedEventHandler? PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}




        public CreateAdmin()
        {
            InitializeComponent();
        }

        private void OnCreateAdmin(object sender, RoutedEventArgs e)
        {
            IMongoDatabase? theDatabase = Connection.database;

            //MyProperty = "Whoa!";
            //NotifyPropertyChanged("MyProperty");

            if (theDatabase == null)
            {
                return;
            }


            IMongoCollection<AdminsDTO> theCollection = theDatabase.GetCollection<AdminsDTO>("admins");
            string userPass = UserPassword.Text.Trim();
            string userName = UserName.Text.Trim();

            var newDoc = new AdminsDTO();
            newDoc.Password = userPass;
            newDoc.Username = userName;

            theCollection.InsertOne(newDoc);
            // OR use async methods, must add async to method qualifiers
            //var tt = await theCollection.InsertOneAsync(newDoc);



        }
    }
}
