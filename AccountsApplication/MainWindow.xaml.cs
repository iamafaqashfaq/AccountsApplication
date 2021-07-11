using AccountsApplication.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace AccountsApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AppContext()) 
            {
                var user = await context.AppUsers.FirstOrDefaultAsync(u => u.Username == userText.Text && u.Password == passwordText.Password);
                if(user != null)
                {
                    MainMenu mm = new MainMenu();
                    mm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mm.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Cannot find the user", "Invalid Credentials", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
        }
    }
}
