using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace PhilsMagic8Ball
{
    class Program
    {
        //Create UserInfo Vars
        static string UserName;
        static string UserAge;
        static int UserAge32;

        //Create Text Colour Variables
        static ConsoleColor oldColour = Console.ForegroundColor;
        static ConsoleColor WelcomeTextColor = ConsoleColor.Cyan;
        static ConsoleColor UserInputColor = ConsoleColor.Gray;
        static ConsoleColor AskColor = ConsoleColor.Green;
        static ConsoleColor Magic8ASCIICol = ConsoleColor.White;
        static ConsoleColor otherColor = ConsoleColor.Yellow;
        static ConsoleColor answerColor = ConsoleColor.Magenta;

        //Create other variables
        static int AnswerNumResult = 10;
        static bool debugMode = false;


        /// <summary>
        /// The main bulk of the program, and entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Print Magic 8 Ball ASCII Art
            Console.ForegroundColor = Magic8ASCIICol;
            Magic8BallAsciiArt();
            //Change current Colour and Print Welcome Text
            Console.ForegroundColor = WelcomeTextColor;
            WelcomeText();

            //Get the Users Info using the UserInfo() Function. This will be used later.
            UserInfo();
            
            //Starts the Infinite Loop
            while (true)
            {
                questionPrompt:
                AskQuestion();
            }
        }

        #region Functions
        
        /// <summary>
        /// The Function that holds the commands to print the Welcome Text
        /// </summary>
        static void WelcomeText()
        {
            Console.WriteLine("Welcome to the Magic 8 Ball by Philster Gaming");
            Console.WriteLine("Original Code by Jerry (aka. Barnacules)");
        }
        
        /// <summary>
        /// Gets the User's Info and Stores them in variables
        /// </summary>
        public static void UserInfo()
        {
            Console.ForegroundColor = AskColor;
            Console.Write("Please enter your Name: ");
            Console.ForegroundColor = UserInputColor;
            UserName = Console.ReadLine();
            Console.ForegroundColor = answerColor;           
            Console.Write("Hello ");
            Console.ForegroundColor = UserInputColor;
            Console.WriteLine("{0}", UserName);
            Console.WriteLine("");
            Console.ForegroundColor = AskColor;
            AgePrompt:
            Console.Write("Please enter your Age (Failing to do so WILL crash the program): ");
            Console.ForegroundColor = UserInputColor;
            UserAge = Console.ReadLine();
            if (Regex.IsMatch(UserAge, @"^[a-zA-Z]+$"))
            {
                Console.ForegroundColor = answerColor;
                Console.WriteLine("You entered a letter! Try again!");
                goto AgePrompt;
            }
            if (UserAge.Length == 0)
            {
                Console.ForegroundColor = answerColor;
                Console.WriteLine("You must have an age... Try again!");
                goto AgePrompt;
            }
            else
            {
                UserAge32 = Convert.ToInt32(UserAge);
                Console.ForegroundColor = answerColor;
                Console.Write("You have input your age as ");
                Console.ForegroundColor = UserInputColor;
                Console.WriteLine("{0}", UserAge);
                Console.ForegroundColor = otherColor;
                if (UserAge32 <= 16)
                {
                    Console.WriteLine("As you are under 16 years of age, ");
                    Console.WriteLine("We have enabled our child filter for you.");
                    Console.WriteLine("All Magic 8 Ball answers will be child friendly");
                }
            }
            
           
        }

        /// <summary>
        /// Generates a random number and uses it to get the appropriate answer based on user's age
        /// </summary>
        public static void GenerateAnswer()
        {
            Random answerNum = new Random();
            int AnswerNumResult = answerNum.Next(5);
            //int AnswerNumResult = 0;
            if (debugMode == true)
            {
                Console.ForegroundColor = otherColor;
                Console.WriteLine ("Your randomly generated number was {0}", AnswerNumResult);
            }
            Console.ForegroundColor = answerColor;
            if (UserAge32 <= 16)
            {
                #region CF Answers
                switch (AnswerNumResult)
                {
                    case 0:
                        {
                            Console.WriteLine("No way Josè");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Of course!!");
                            break;
                        }              
                    case 2:
                        {
                            Console.WriteLine("Nuh Huh..");
                            break;
                        }                    
                    case 3:
                        {
                            Console.WriteLine("Maybe, Maybe Not");
                            break;
                        }                   
                    case 4:
                        {
                            Console.WriteLine("Definately");
                            break;
                        }                   

                }
                #endregion
            }
            else
            {
                #region Non-CF Answers
                            switch (AnswerNumResult)
                            {
                                case 0:
                                    {
                                        Console.WriteLine("Fuck No!");
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.WriteLine("The same probability as you getting laid tonight... 0%");
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("How the hell would you expect me to know. I'm a load of text. (You Dumb Git..)");
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("C'mon, you can do it");
                                        break;
                                    }
                                case 4:
                                    {
                                        Console.WriteLine("Mate, You and Me... We're fucking unstoppable");
                                        break;
                                    }

                            }
                            #endregion
            }
            


        }

        /// <summary>
        /// Function to print the Magic 8 Ball ASCII Art
        /// </summary>
        public static void Magic8BallAsciiArt()
        {
            Console.WriteLine("              _.a$$$$$a._ \r\n            ,$$$$$$$$$$$$$.\r\n          ,$$$$$$$$$$$$$$$$$.\r\n         d$$$$$$$$$$$$$$$$$$$b\r\n        d$$$$$$$$~''`~$$$$$$$$b\r\n       ($$$$$$$p   _   q$$$$$$$)\r\n       $$$$$$$$   (_)   $$$$$$$$\r\n       $$$$$$$$   (_)   $$$$$$$$\r\n       ($$$$$$$b       d$$$$$$$)\r\n        q$$$$$$$$a._.a$$$$$$$$p\r\n         q$$$$$$$$$$$$$$$$$$$p\r\n           $$$$$$$$$$$$$$$$$'\r\n             $$$$$$$$$$$$$\r\n              `~$$$$$$$~'");
            Console.Write("\r\n \r\n");
        }

        public static void AskQuestion()
        {
            Console.ForegroundColor = AskColor;
            Console.WriteLine("Ask me a question {0} and I will answer it for you, as I am the magic 8 ball!! - ", UserName);
            Console.ForegroundColor = UserInputColor;
            string UserQuestion = Console.ReadLine();
            Console.ForegroundColor = answerColor;
            if (UserQuestion == "debugon")
            {
                debugMode = true;
                Console.WriteLine("Debug Mode On");       
            }
            if (UserQuestion == "debugoff")
            {
                debugMode = false;
                Console.WriteLine("Debug Mode Off");
            }
            if (UserQuestion == "quit")
            {
                QuitCode();                           
            }
            Console.WriteLine("Ok then {0}, let me think about your question -", UserName);
            Random sleep = new Random();
            Thread.Sleep(sleep.Next(5000));
            GenerateAnswer();
        }

        public static void QuitCode()
        {
            Console.ForegroundColor = otherColor;
            Console.WriteLine("Thankyou for using Phil's Magic 8 Ball");
            Thread.Sleep(1000);
            Console.WriteLine("In 10 seconds you will see two browser windows pop up.");
            Thread.Sleep(1000);
            Console.WriteLine("One will be my YouTube Channel");
            Thread.Sleep(1000);
            Console.WriteLine("The other will be the channel of Barnacules, the maker of the original code");
            Thread.Sleep(1000);
            Console.WriteLine("Goodbye");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        #endregion
    }
}
