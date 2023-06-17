using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_App
{
    internal class Word
    {
        private string word { get; }
        private char[] letters;
        public Word() 
        {
            this.word = string.Empty;
            this.letters = new char[this.word.Length];
        }
    }
}
