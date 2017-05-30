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
        private Date start;
        private Date end;

        public void startT()
        {
            startT = Date.Now;
        }

        public void end()
        {
            end = Date.Now;
        }

        public Time getG()
        {
            return end - startT;
        }

        public void increase()
        {
            countAttempt++;
        }

        public void saved( string attempt )
        {
            historyGame.Add( attempt );
        } 

        public List<string> get()
        {
            return historyGame;
        }

        public int getC()
        {
            return countAttempt;
        }
    }
}
