using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Games_
{
    internal class Jumble_Word
    {
       private string jumble { get; set; }
        private List<string> words { get; set; }
        string answer = string.Empty;

        public Jumble_Word()
        {
            jumble = string.Empty;
            words = new List<string> { "python", "jumble" , "easy", "difficult", "answer", "xylophone" };
        }

        internal void StartGame()
        {
            GameStarting();
            for (int iword = words.Count; iword > 0; iword--)
            {
                BeginTheGame();
                for (int retry = 0; retry < 5; retry++)
                {
                    if (ValidateAnswer(GetUserInput()))
                    {
                        words.Remove(answer);
                        if (words.Count == 0)
                            Console.WriteLine("Congrats! You have completed! all the words.");
                        break;
                    }
                }
            }
        }

        private void SetJumbleWord()
        {
            var random = new Random();
            var word = words[random.Next(0,words.Count-1)];
            answer = word;

            while (word.Length != 0)
            {
                var position = random.Next(word.Length-1);
                jumble += word[position];
                word = word.Remove(position,1);
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
            jumble = string.Empty;
            
            SetJumbleWord();

            Console.WriteLine($"The jumble word is:{jumble}");
        }

        private bool ValidateAnswer(string userAnswer)
        {
            if (answer == userAnswer)
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
