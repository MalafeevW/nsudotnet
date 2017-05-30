using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class GamingProcess
    {
        public static String username;

        static void Main(string[] args)
        {
            prepareGame();

            Results results = new Results();
            results.startTimer();

            Bot bot = new Bot();
            bot.generateNumber();

            Console.WriteLine( "Guess my number!" );

            bool flag = true;
            while ( flag )
            {
                if( ( results.getCountAttempt() % 4 ) == 0 )
                {
                    bot.callNames(username);
                }

                string userString = Console.ReadLine();
                checkExitGame( userString );

                int userNumber = Convert.ToInt32( userString );

                if ( !checkUserNumber( userNumber ) )
                {
                    Console.WriteLine( bot.giveHint( userNumber ) );

                    results.increaseCurrentAttempt();
                    results.savedHistoryAttempt( userNumber + " " + bot.giveHint( userNumber ) );
                }
                else
                {
                    flag = false;
                    results.endTimer();

                    finish( results.getCountAttempt(), results.getHistory(), results.getGamingTime() );
                    Console.ReadLine();
                }
            }
        }

        public static void prepareGame()
        {
            initNewUser();
            Console.WriteLine("Hi! I can play in game with you! Ha-ha-ha-ha...");
        }

        public static void initNewUser()
        {
            Console.WriteLine("Enter your name");
            username = Console.ReadLine();
        }

        public static bool checkUserNumber( int userNumber )
        {
            return userNumber == Bot.botNumber;
        }

        public static void checkExitGame( string userString )
        {
            if (userString == "q")
            {
                Console.WriteLine("Sorry, I have to go... Goodbye!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        public static void finish( int countAttempt, List<string> historyGame, TimeSpan gamingTime )
        {
            Console.WriteLine( "YOU WINS" );
            Console.WriteLine ("Your attempt: " + countAttempt );
            Console.WriteLine( "Your Time: " + gamingTime.Minutes.ToString() + " minutes");
            Console.WriteLine( "Your History Game: " );
            historyGame.ForEach(print);
        }

        public static void print( string attempt )
        {
            Console.WriteLine( attempt );
        }
    }
}
