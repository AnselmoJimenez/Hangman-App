using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_App
{
    internal class Word
    {
        private string word { set; get; }
        private char[] board;
        public Word() 
        {
            this.word = generateWord();
            this.board = new char[this.word.Length];
            generateBoard();
        }

        private string generateWord()
        {
            // Choose random line from the text file
            Random random = new Random();
            Console.WriteLine(File.Exists("./words.txt"));
            string[] words = File.ReadAllLines("./words.txt");

            return words[random.Next(words.Length)];
        }

        private void generateBoard()
        {
            // insert a '_' for every letter
            for (int i = 0; i < this.word.Length; i++)
            {
                if (this.word[i] == ' ') { this.board[i] = '!'; }
                else { this.board[i] = '_'; }
            }
        }

        public string getWord() { return this.word; }

        public string getBoard() 
        {
            string result = "";
            foreach (char c in this.board) 
            {
                if (c == '!') { result += " "; }
                else { result += c; }

                result += " ";
            }

            return result;
        }

        public bool updateBoard(char guess)
        {
            // if the board does not contain the guess
            if (!this.word.Contains(guess)) { return false; }

            // update the board with the guess
            for (int i = 0; i < this.word.Length; i++)
            {
                if (this.word[i] == guess) { this.board[i] = guess; }
            }

            return true;
        }

        public bool checkBoard()
        {
            if (this.board.Contains('_')) { return false; }
            else                          { return true;  }
        }

        public void reset()
        {
            this.word = generateWord();
            this.board = new char[this.word.Length];
            generateBoard();
        }
    }
}
