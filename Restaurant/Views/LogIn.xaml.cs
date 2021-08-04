using Restaurant.Models;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        LogInVM logInVM = new LogInVM();

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Utilizator> ListaUtilizatori = logInVM.ListaUtilizatori;
            bool exista = false;
            int indice = 0;
            Utilizator u;
            for(int i=0; i<ListaUtilizatori.Count;i++)
            {
                if(ListaUtilizatori[i].Email==mail.Text && ListaUtilizatori[i].Parola==parola.Password.ToString())
                {
                    exista = true;
                    indice = i;
                }
            }
            if(!exista)
            {
                MessageBox.Show("E-mail sau parola invalida!");
            }
            else
            {
                if(ListaUtilizatori[indice].Statut=="client")
                {
                    Meniu meniu = new Meniu(ListaUtilizatori[indice]);
                    meniu.Show();
                    this.Close();
                }
                else
                {
                    Meniu meniu = new Meniu(ListaUtilizatori[indice],true);
                    meniu.Show();
                    this.Close();
                }
            }
        }

        private void Inapoi_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
