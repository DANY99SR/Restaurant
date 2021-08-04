using Restaurant.Models;
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
using System.Windows.Shapes;

namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for Meniu.xaml
    /// </summary>
    public partial class Meniu : Window
    {
        public Meniu()
        {
            InitializeComponent();
            plusProdus.Visibility = Visibility.Hidden;
            plusMeniu.Visibility = Visibility.Hidden;
            btnCos.Visibility = Visibility.Hidden;
            btnFinalizareComanda.Visibility = Visibility.Hidden;
            btnGolireCos.Visibility = Visibility.Hidden;
            comenzi.Visibility = Visibility.Hidden;
            btnDepozit.Visibility = Visibility.Hidden;
            btnComenzi.Visibility = Visibility.Hidden;
        }
        public static Utilizator utilizatorCurent;
        public Meniu(Utilizator utilizator)
        {
            utilizatorCurent = utilizator;
            InitializeComponent();
            btnDepozit.Visibility = Visibility.Hidden;
            btnComenzi.Visibility = Visibility.Hidden;
        }

        public Meniu(Utilizator utilizator, bool angajat)
        {
            utilizatorCurent = utilizator;
            InitializeComponent();
            plusProdus.Visibility = Visibility.Hidden;
            plusMeniu.Visibility = Visibility.Hidden;
            btnCos.Visibility = Visibility.Hidden;
            btnFinalizareComanda.Visibility = Visibility.Hidden;
            btnGolireCos.Visibility = Visibility.Hidden;
            comenzi.Visibility = Visibility.Hidden;
        }
        private void Inapoi_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void comenzi_Click(object sender, RoutedEventArgs e)
        {
            Comenzi comenzi = new Comenzi();
            comenzi.Show();
        }

        private void btnComenzi_Click(object sender, RoutedEventArgs e)
        {
            Comenzi comenzi = new Comenzi();
            comenzi.Show();
        }
    }
}
