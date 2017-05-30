using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Bot
    {
        public const String THIS_IS_BIG_NUMBER = "Введенное число больше загаданного";
        public const String THIS_IS_SMALL_NUMBER = "Введенное число меньше загаданного";

        public static string[] swearing = { "Shut up, you div!", "is such a weirdo",
            "You’re a loser, I hate you", "What’s the matter, cat got your tongue?",
            "Get lost, I am tired of hearing from you." };

        public static int bot = 0;

        public void generate()
        {
            Random random = new Random();
            bot = random.Next( 101 );
        }

        public string give(  int human )
        {
            if( bot < human )
            {
                return THIS_IS_BIG_NUMBER ;
            }
            else
            {
                return THIS_IS_SMALL_NUMBER;
            }
        }

        public void call( string username )
        {        
            Console.Write( username + "!" + swearing[ new Random().Next( 0, swearing.Length ) ] );
        }
    }
}
