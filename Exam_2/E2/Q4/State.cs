using System;
using System.Collections.Generic;
using System.Linq;

namespace E2.Q4
{
    public class State : IVoter
    {
        public City[] cities;
        public State(string name, City[] city)
        {
            cities = city;
        }
        /// <summary>
        /// generating vote result for a state by summing all the vote results of the cities located in  this state
        /// and calling each city's vote function
        /// </summary>
        public VoteResult Vote(string issue){
            List<VoteResult> list = new List<VoteResult>(); 
            int y=0, n=0, w=0;
            foreach (var item in cities)
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