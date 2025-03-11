using System;
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

namespace piotrek
{
    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Media.Imaging;

    namespace PocztaApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                UstawDomyslnyObraz();
            }
            private void UstawDomyslnyObraz()
            {
                imgPrzesylka.Source = new BitmapImage(new Uri("pack://application:,,,/Images/pocztowka.png"));
            }

            private void btnSprawdzCene_Click(object sender, RoutedEventArgs e)
            {
                if (rbPocztowka.IsChecked == true)
                {
                    imgPrzesylka.Source = new BitmapImage(new Uri("pack://application:,,,/Images/pocztowka.png"));
                    lblCena.Content = "Cena: 1 zł";
                }
                else if (rbList.IsChecked == true)
                {
                    imgPrzesylka.Source = new BitmapImage(new Uri("pack://application:,,,/Images/list.png"));
                    lblCena.Content = "Cena: 1,5 zł";
                }
                else if (rbPaczka.IsChecked == true)
                {
                    imgPrzesylka.Source = new BitmapImage(new Uri("pack://application:,,,/Images/paczka.png"));
                    lblCena.Content = "Cena: 10 zł";
                }
            }
            private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
            {
                string kodPocztowy = txtKodPocztowy.Text;

                if (!Regex.IsMatch(kodPocztowy, @"^\d{5}$"))
                {
                    if (!Regex.IsMatch(kodPocztowy, @"^\d+$"))
                        MessageBox.Show("Kod pocztowy powinien składać się z samych cyfr", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Dane przesyłki zostały wprowadzone", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
