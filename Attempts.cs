using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_App
{
    internal class Attempts
    {
        public int maxGuesses { get; }
        public int wrongGuesses { get; private set; }
        public int remaining => maxGuesses - wrongGuesses;

        public Attempts() 
        { 
            this.maxGuesses = 6;
            this.wrongGuesses = 0;
        }

        // increments wrong guesses and updates remaining
        public void incorrect() { this.wrongGuesses++; }
        public void reset() { this.wrongGuesses = 0; }
    }
}
