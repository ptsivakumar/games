using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Games_
{
    internal class Jumble_Word
    {
        private string _jumble { get; set; }
        private List<string> _Words { get; set; }
        string _answer = string.Empty;
        int _score = 0;

        public Jumble_Word()
        {
            _jumble = string.Empty;
            _Words = new List<string> { "python", "jumble", "easy", "difficult", "answer", "xylophone" };
        }

        internal void StartGame()
        {
            GameStarting();
            for (int iword = _Words.Count; iword > 0; iword--)
            {
                BeginTheGame();
                for (int retry = 0; retry < 5; retry++)
                {
                    if (ValidateAnswer(GetUserInput()))
                    {
                        _score += 1;
                        _Words.Remove(_answer);
                        if (_Words.Count == 0)
                            Console.WriteLine($"You have completed! all the words."
                                +$"{Environment.NewLine} Total Score:{_score}");
                        break;
                    }
                }
            }
        }

        private void SetJumbleWord()
        {
            var random = new Random();
            var word = _Words[random.Next(0, _Words.Count - 1)];
            _answer = word;

            while (word.Length != 0)
            {
                var position = random.Next(word.Length - 1);
                _jumble += word[position];
                word = word.Remove(position, 1);
            }
        }

        private void GameStarting()
        {
            Console.WriteLine("Welcome to Word Jumble!" +
                $" {Environment.NewLine}Unscramble the letters to make a word.+" +
                $"{Environment.NewLine}(Press the enter key at the prompt to quit.)");
        }

        private void BeginTheGame()
        {
            _jumble = string.Empty;

            SetJumbleWord();

            Console.WriteLine($"The jumble word is:{_jumble}");
        }

        private bool ValidateAnswer(string userAnswer)
        {
            if (_answer == userAnswer)
            {
                Console.WriteLine("Congrats! You have Own!");
                return true;
            }
            else
            {
                Console.WriteLine("Please, Try Again!");
                return false;
            }
        }

        private string GetUserInput()
        {
            Console.WriteLine("Please Enter Your Answer:");
            return Console.ReadLine();
        }
    }
}
