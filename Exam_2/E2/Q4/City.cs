using System;
using System.Collections.Generic;
using System.Linq;

namespace E2.Q4
{
    public class City : IVoter
    {
        public Person[] people1;
        public string name;
        public City(string name, Person[] people)
        {
            this.name = name;
            people1 = people;
        }
        /// <summary>
        /// shows the entire vote result of a city by calculating the sum of all people's vote who live in this city
        /// by calling each person's vote function
        /// </summary>
        public VoteResult Vote(string issue){
            List<VoteResult> list = new List<VoteResult>(); 
            int y=0, n=0, w=0;
            foreach (var item in people1)
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