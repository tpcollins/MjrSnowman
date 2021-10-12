using System;

namespace mjr
{
    class Program
    {
        static void Main(string[] args)
        {
            int  userScore = 0;
            Console.WriteLine("Hi, welcome to the Snowman Game! We will randomly pick one word out of 12 words, and you will guess letter by letter what the word is. Be careful though, because you only get 7 incorrect guesses! Good luck!");
            string randomWord = GeneratingRandomWord();
            char [] userGuess = new char [randomWord.Length];
            char [] wordBlanks = new char [randomWord.Length];

            Menu(userScore, ref wordBlanks, userGuess, randomWord);
        }

        static void Menu(int userScore, ref char [] wordBlanks, char [] userGuess, string randomWord)
        {
            bool exitGame = false;
            Console.WriteLine("Please pick a choice \n1. Play the game \n2. See the scoreboard \n3. Exit the system.");
                int userMenuChoice = int.Parse(Console.ReadLine());
            while(exitGame == false)
                if(userMenuChoice == 1)
                {
                    PlayGame(ref wordBlanks, userGuess, randomWord, ref userScore);
                    exitGame = true;
                 
                }
                else if(userMenuChoice == 2)
                {
                    SeeScoreboard(userScore);
                    exitGame = true;
                   
                }
                else if(userMenuChoice ==3)
                {
                    exitGame = false;
                }
                else if(userMenuChoice != 1 || userMenuChoice != 2 || userMenuChoice != 3)
                {
                    Console.WriteLine("Please pick a choice \n1. Play the game \n2. See the scoreboard \n3. Exit the system.");
                    userMenuChoice = int.Parse(Console.ReadLine());
                }
            Console.WriteLine("Please pick a choice \n1. Play the game \n2. See the scoreboard \n3. Exit the system.");
            userMenuChoice = int.Parse(Console.ReadLine());
        }

        static void SeeScoreboard(int userScore)
        {
            Console.WriteLine($"You have won " + userScore + " times.");
        }

        static string GeneratingRandomWord()
        {
            string [] potentialWords = {"capstone", "alabama", "awkward", "unknown", "bookworm", "joyful", "starbucks", "hawaii", "zombie", "christmas", "cheerleader", "balcony"};
            Random number = new Random();
            int randomNum = number.Next(11);
            string randomWord = potentialWords [randomNum];
            return randomWord;
        }
        

        static void PlayGame(ref char [] wordBlanks, char [] userGuess, string randomWord, ref int userScore)
        {
            Console.WriteLine("Displayed below is how many blanks your word has.");
            char[] underscore = DisplayBlanks(ref wordBlanks, randomWord);
            System.Console.WriteLine(underscore);
            int missedCount = 0;

            Console.WriteLine("Please enter a letter");
            System.Console.WriteLine(randomWord);
            char userGuessed = char.Parse(Console.ReadLine()); 
            GamePlayRules(randomWord, ref wordBlanks, userGuess, underscore, ref missedCount, userGuessed);

            while(KeepGoing(wordBlanks, missedCount))
            { 
                Console.WriteLine("Please enter a letter");
                System.Console.WriteLine(randomWord);
                userGuessed = char.Parse(Console.ReadLine());
                GamePlayRules(randomWord, ref wordBlanks, userGuess, underscore, ref missedCount, userGuessed);
            }

            if (missedCount == 7)
            {
                Console.WriteLine("Sorry, you lost");
                userScore += userScore;

            }else{
                System.Console.WriteLine("You won!");
            }
        }



        static void GamePlayRules(string randomWord, ref char [] wordBlanks, char [] userGuess, char[] underscore, 
                                    ref int missedCount, char userGuessed)
        {
            bool badGuess = true;
            for(int i = 0; i < randomWord.Length; i++)
            { 
                if(randomWord[i] == userGuessed)
                {
                    wordBlanks[i] = userGuessed;
                    Console.WriteLine(underscore);
                    badGuess =  false;
                }
            }
            if (badGuess)
            {
                Console.WriteLine(underscore);
                missedCount++;
            }
        }
        public static Boolean KeepGoing(char[] wordBlanks, int missedCount){
            int underscores = 0;
            foreach (char underscore in wordBlanks)
            {
                if (underscore == '_'){
                    underscores++;
                    break;
                }
            }

            if ((underscores > 0) && (missedCount < 7)){
                return true;
            }else{
                return false;
            }
        }

        static char [] DisplayBlanks(ref char [] wordBlanks, string randomWord)
        {   
            wordBlanks = new char [randomWord.Length];
            for(int i = 0; i < randomWord.Length; i++)
            {
                if(randomWord[i] == ' ')
                {
                    wordBlanks[i] = ' ';
                }
                else
                {
                    wordBlanks[i] = '_';
                }
            }
            return wordBlanks;
        }
    }
}