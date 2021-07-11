using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace AccountsApplication.Views.Dealers
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Dealers : Window
    {
        public Dealers()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchDataToGridView();
        }

        private async void fetchDataToGridView()
        {
            using(var context = new AppContext())
            {
                var data = await context.Dealers.ToListAsync();
                dealersGridView.ItemsSource = data;
                dealersGridView.CanUserAddRows = false;
                dealersGridView.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new AppContext())
            {
                Model.Dealer dealer = new Model.Dealer();
                dealer.ShortName = shortName.Text;
                dealer.CompanyFullName = companyName.Text;
                dealer.CompanyAddress = companyAddress.Text;
                dealer.CompanyPhoneNo = companyPhone.Text;
                dealer.CompanyTelNo = companyTel.Text;
                dealer.RepresentativeName = repName.Text;
                dealer.RepresentativePhoneNo = repPhone.Text;
                dealer.Distribution = distYes.IsChecked != null && distYes.IsChecked == true;
                dealer.Reseller = resellerYes.IsChecked != null && resellerYes.IsChecked == true;

                context.Dealers.Add(dealer);
                await context.SaveChangesAsync();
                fetchDataToGridView();
            }
        }

        private async void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new AppContext())
            {
                var dealer = dealersGridView.SelectedItem as Model.Dealer;
                if(dealer != null)
                {
                    var newDealerObject = await context.Dealers.FirstOrDefaultAsync(u => u.Id == dealer.Id);
                    if (newDealerObject != null)
                    {
                        context.Dealers.Attach(newDealerObject);
                        context.Dealers.Remove(newDealerObject);
                        await context.SaveChangesAsync();
                        fetchDataToGridView();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete the " + dealer.ShortName, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nothing was selected to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            shortName.Clear();
            companyName.Clear();
            companyAddress.Clear();
            companyPhone.Clear();
            companyTel.Clear();
            repName.Clear();
            repPhone.Clear();
            distYes.IsChecked = false;
            resellerYes.IsChecked =false;
        }
    }
}
