

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows;

namespace WPFLoginJoin.Database
{
    public class Connection
    {

        public static IMongoClient? client;
        public static IMongoDatabase? database;

        public Connection()
        {
            OnConnect();
        }

        private void OnConnect()
        {

            const string connectionUri = "mongodb+srv://kdowd:yourHero@ubercluster.dc2sqiw.mongodb.net/?retryWrites=true&w=majority&appName=UberCluster";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            client = new MongoClient(settings);


            try
            {
                database = client.GetDatabase("user_app");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}