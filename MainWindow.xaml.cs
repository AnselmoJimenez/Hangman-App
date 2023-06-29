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
            correctWord.Text = word.getWord();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
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
                character.Source = updateImage("./Assets/Character/" + attempts.wrongGuesses.ToString() + ".png");
            }

            clickedButton.IsEnabled = false;

            // Check for the end of the game
            checkWin();
        }

        private void resetGame(object sender, RoutedEventArgs e)
        {
            // Reset Classes
            word.reset();
            attempts.reset();

            // Get a new word
            Board.Text = word.getBoard().ToString();
            character.Source = updateImage("./Assets/Character/default.png");
            correctWord.Text = word.getWord();

            // Set visibility settings for appropriate panels
            keyboard.Visibility = Visibility.Visible;
            winMessage.Visibility = Visibility.Collapsed;
            lossPanel.Visibility = Visibility.Collapsed;
            playAgainPanel.Visibility = Visibility.Collapsed;

            // Reset all buttons to default style setting
            A.Style = (Style) Resources["DefaultButtonStyle"]; A.IsEnabled = true;
            B.Style = (Style) Resources["DefaultButtonStyle"]; B.IsEnabled = true;
            C.Style = (Style) Resources["DefaultButtonStyle"]; C.IsEnabled = true;
            D.Style = (Style) Resources["DefaultButtonStyle"]; D.IsEnabled = true;
            E.Style = (Style) Resources["DefaultButtonStyle"]; E.IsEnabled = true;
            F.Style = (Style) Resources["DefaultButtonStyle"]; F.IsEnabled = true;
            G.Style = (Style) Resources["DefaultButtonStyle"]; G.IsEnabled = true;
            H.Style = (Style) Resources["DefaultButtonStyle"]; H.IsEnabled = true;
            I.Style = (Style) Resources["DefaultButtonStyle"]; I.IsEnabled = true;
            J.Style = (Style) Resources["DefaultButtonStyle"]; J.IsEnabled = true;
            K.Style = (Style) Resources["DefaultButtonStyle"]; K.IsEnabled = true;
            L.Style = (Style) Resources["DefaultButtonStyle"]; L.IsEnabled = true;
            M.Style = (Style) Resources["DefaultButtonStyle"]; M.IsEnabled = true;
            N.Style = (Style) Resources["DefaultButtonStyle"]; N.IsEnabled = true;
            O.Style = (Style) Resources["DefaultButtonStyle"]; O.IsEnabled = true;
            P.Style = (Style) Resources["DefaultButtonStyle"]; P.IsEnabled = true;
            Q.Style = (Style) Resources["DefaultButtonStyle"]; Q.IsEnabled = true;
            R.Style = (Style) Resources["DefaultButtonStyle"]; R.IsEnabled = true;
            S.Style = (Style) Resources["DefaultButtonStyle"]; S.IsEnabled = true;
            T.Style = (Style) Resources["DefaultButtonStyle"]; T.IsEnabled = true;
            U.Style = (Style) Resources["DefaultButtonStyle"]; U.IsEnabled = true;
            V.Style = (Style) Resources["DefaultButtonStyle"]; V.IsEnabled = true;
            W.Style = (Style) Resources["DefaultButtonStyle"]; W.IsEnabled = true;
            X.Style = (Style) Resources["DefaultButtonStyle"]; X.IsEnabled = true;
            Y.Style = (Style) Resources["DefaultButtonStyle"]; Y.IsEnabled = true;
            Z.Style = (Style) Resources["DefaultButtonStyle"]; Z.IsEnabled = true;
        }

        private void quitGame(object sender, RoutedEventArgs e) { this.Close(); }

        private BitmapImage updateImage(string path)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(path, UriKind.Relative);
            img.EndInit();

            return img;
        }

        private void checkWin()
        {
            if (attempts.wrongGuesses == 6) 
            {
                keyboard.Visibility = Visibility.Collapsed;

                lossPanel.Visibility = Visibility.Visible;
                playAgainPanel.Visibility = Visibility.Visible;
            }
            else if (word.checkBoard())
            {
                keyboard.Visibility = Visibility.Collapsed;
                lossPanel.Visibility = Visibility.Collapsed;

                winMessage.Visibility = Visibility.Visible;
                playAgainPanel.Visibility = Visibility.Visible;
            }
        }
    }
}
