using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int wordLength;
            int  gameLife = 10;
            char guessedWord;
            string word = "", blankWord = "";

            word = RandomWord();
            wordLength = word.Length;

            char[] blankWordCharacter = new char[wordLength];
  
            for (int i = 0; i < wordLength; i++)
            {
                blankWord += "_";
            }

            Console.WriteLine(word);
            Console.WriteLine(blankWord);



            char[] wordCharacters = StringToArray(word, wordLength, blankWord, out blankWordCharacter);
            

            do
            {
                Console.WriteLine("Guess the letters present in word (CAPITAL LETTER) :  ");
                guessedWord = Convert.ToChar(Console.ReadLine());
                if (word.Contains(guessedWord) /*&& !blankWord.Contains('_')*/)
                {
                    for (int i = 0; i < wordLength; i++)
                    {

                        
                        if (blankWord.Contains("_") && gameLife > 1)
                        {
                            if (guessedWord == word[i])
                            {
                                blankWordCharacter[i] = guessedWord;
                                blankWord = ArrayToString(blankWordCharacter);
                                

                                Console.WriteLine("blankword : " + blankWord);
                                Console.WriteLine(blankWordCharacter);
                                //word = RemoveDuplicate(wordCharacters, wordLength);
                                if (!blankWord.Contains('_'))
                                {
                                    Console.WriteLine("Word : " + word);
                                    Console.WriteLine("Game Over :) ");
                                    Environment.Exit(0);

                                }
                                

                                break;

                            }
                            
                            


                        }
                        
                        

                    }
                    
                }
                else if(!blankWord.Contains('_') || gameLife == 0)
                {
                    Console.WriteLine("Word : " + word);
                    Console.WriteLine("Game Over :) ");
                    Environment.Exit(0);
                }
                else
                {
                    gameLife--;
                    Console.WriteLine("Total No. Of Life : " + gameLife);
                    if (gameLife == 0)
                    {
                        Console.WriteLine("Word : " + word);
                        Console.WriteLine("Game Over :) ");
                        Environment.Exit(0);
                    }
                }
            } while (true);
        }
        static char[] StringToArray(string word, int wordLength, string blankWord, out char[] blan)
        {

            char[] wordCharacter = new char[wordLength];
            char[] blankWordCharacter = new char[wordLength];
            for (int i = 0; i < wordLength; i++)
            {
                wordCharacter[i] = word[i];
                blankWordCharacter[i] = blankWord[i];

            }
            blan = blankWordCharacter;

            return wordCharacter;
        }
        static string ArrayToString(char[] blankword)
        {
            String blankword1 = new string(blankword);
            return blankword1;
        }
        static bool RemoveDuplicate(char[] wordCharacter , int wordLength)
        {
            for(int i = 0; i < wordLength; i++)
            {
                for(int j = i+1; j < wordLength; j++)
                {
                    if (wordCharacter[i] == wordCharacter[j])
                    {
                        return true;
                    }
                        
                }
            }
            return false;
            
            
        }
        static string RandomWord()
        {
            Random random = new Random();
            int wordLength = random.Next(4, 6);

            int randomInt;
            string word = "";
            char wordChar;
            for (int i = 0; i < wordLength; i++)
            {
                randomInt = random.Next(65, 91);
                wordChar = (char)randomInt;
                word = word + wordChar;

            }
            if(RemoveDuplicate(word.ToCharArray(),wordLength) == true)
                RandomWord();
            return word;
        }
    }
}
