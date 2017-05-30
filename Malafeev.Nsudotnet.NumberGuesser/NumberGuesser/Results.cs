using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Results
    {
        private int countAttempt = 1;
        private List< string > historyGame = new List< string >();
        private DateTime startTime;
        private DateTime endTime;

        public void startTimer()
        {
            startTime = DateTime.Now;
        }

        public void endTimer()
        {
            endTime = DateTime.Now;
        }

        public TimeSpan getGamingTime()
        {
            return endTime - startTime;
        }

        public void increaseCurrentAttempt()
        {
            countAttempt++;
        }

        public void savedHistoryAttempt( string attempt )
        {
            historyGame.Add( attempt );
        } 

        public List<string> getHistory()
        {
            return historyGame;
        }

        public int getCountAttempt()
        {
            return countAttempt;
        }
    }
}
