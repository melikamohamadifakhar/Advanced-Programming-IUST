using System;
using System.Collections.Generic;
using System.Linq;

namespace E2.Q4
{
    public class Country : IVoter
    {
        State[]  States;
        public Country(string name, State[] states)
        {
            this.States = states;
        }
        /// <summary>
        /// generating vote result for the entire country by summing all the vote results of the states located in  the country
        /// and caaling each state's vote function which itself calls the located cities' vote function and so on (call hierarchy)
        /// </summary>
        /// <param name="issue"></param>
        public VoteResult Vote(string issue){
            List<VoteResult> list = new List<VoteResult>(); 
            int y=0, n=0, w=0;
            foreach (var item in States)
                list.Add(item.Vote(issue));
            foreach (var item in list){
                y += item.YesCount;
                n += item.NoCount;
                w += item.WhiteCount;
            }
            return new VoteResult(issue, y, n, w);
        }
    }
}