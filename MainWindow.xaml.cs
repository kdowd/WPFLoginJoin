using System.Text;
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
using WPFLoginJoin.Views.Components;
using WPFLoginJoin.Windows;

namespace WPFLoginJoin
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAppLoaded(object sender, RoutedEventArgs e)
        {
            new Connection();



            Window win2 = new LoginWindow();

            win2.Owner = Application.Current.MainWindow;

            win2.ShowDialog();

        }

        public void IsLogged(bool b)
        {
            MessageBox.Show($"Logged status is {b}");
        }
    }
}