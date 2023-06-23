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

namespace Hangman_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Word word = new Word();
        Attempts attempts = new Attempts();
        public char guess { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Board.Text = word.getBoard().ToString();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img = new BitmapImage();
            Button clickedButton = (Button) sender;

            // Get guess (letter pressed)
            char buttonContent = clickedButton.Content.ToString().ToLower()[0];
            guess = buttonContent;

            //clickedButton.IsHitTestVisible = false;
            if (word.updateBoard(guess)) 
            {
                // Change the button pressed to green and update the board
                clickedButton.Style = (Style) Resources["CorrectGuessStyle"];
                Board.Text = word.getBoard().ToString();
            }
            else
            {
                // Change to onyx and increment the amount of wrong guesses and update picture
                clickedButton.Style = (Style) Resources["WrongGuessStyle"];

                attempts.incorrect();
                string imgPath = "./Assets/Character/" + attempts.wrongGuesses.ToString() + ".png";
                character.Source = newImage(imgPath);
                
            }
            clickedButton.IsEnabled = false;
        }

        private BitmapImage newImage(string path)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(path, UriKind.Relative);
            img.EndInit();

            return img;
        }
    }
}
