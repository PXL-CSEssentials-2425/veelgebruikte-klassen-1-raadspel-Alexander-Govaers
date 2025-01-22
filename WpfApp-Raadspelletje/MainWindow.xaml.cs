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
using System.Windows.Threading;

namespace WpfApp_Raadspelletje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        Random random = new Random();
        int randomGetal;
        int attempts = 1;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dateLabel.Content = $"{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToShortTimeString()}"; 

            randomGetal = random.Next(1,101);
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {

           
            attemptsTextBox.Text = $"Aantal keer geraden: {attempts++}";

             bool validInput = int.TryParse(inputTextBox.Text, out int inputUser);

            if (inputUser < 0 || validInput == false)
            {
                messageTextBox.Text = "Geef een willekeurig getal tussen 1 en 100!";
            }
            else if (inputUser < randomGetal)
            {
                messageTextBox.Text = "Raad hoger!";
            }
            else if (inputUser > randomGetal)
            {

                messageTextBox.Text = "Raad lager!";

            }
            else
            {
                messageTextBox.Text = "Proficiat! U hebt het getal geraden!";
            }

        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            attemptsTextBox.Clear();
            messageTextBox.Clear();
            inputTextBox.Clear();
            attempts = 1;
            randomGetal = random.Next(1, 101);

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
