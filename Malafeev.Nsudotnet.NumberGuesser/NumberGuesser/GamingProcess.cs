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
            prepare();

            Results results = new Results();
            results.start();

            Bot bot = new Bot();
            bot.generate();

            Console.Write( "Guess my number!" );

            bool flag = true;
            while ( flag )
            {
                if( ( results.get() % 4 ) == 0 )
                {
                    bot.call(username);
                }

                string user = Console.Read();
                Exit( userString );

                int user = Convert.ToInt32( userString );

                if ( !check( user ) )
                {
                    Console.Write( bot.giveHint( user ) );

                    results.increase();
                    results.saved( user + " " + bot.give( user ) );
                }
                else
                {
                    flag = false;
                    results.end();

                    finish( results.get(), results.getH(), results.getG() );
                    Console.Read();
                }
            }
        }

        public static void prepare()
        {
            init();
            Console.Write("Hi! I can play in game with you! Ha-ha-ha-ha...");
        }

        public static void init()
        {
            Console.Write("Enter your name");
            username = Console.Read();
        }

        public static bool check( int user )
        {
            return user == Bot.bot;
        }

        public static void checkE( string user )
        {
            if (user == "q")
            {
                Console.Write("Sorry, I have to go... Goodbye!");
                Console.Read();
                Environment.Exit(0);
            }
        }

        public static void finish( int countAttempt, List<string> historyGame, TimeSpan gamingTime )
        {
            Console.Write( "YOU WINS" );
            Console.Write ("Your attempt: " + countAttempt );
            Console.Write( "Your Time: " + gamingTime.Minutes.ToString() + " minutes");
            Console.Write( "Your History Game: " );
            history.ForEach(print);
        }

        public static void print( string attempt )
        {
            Console.Write( attempt );
        }
    }
}
