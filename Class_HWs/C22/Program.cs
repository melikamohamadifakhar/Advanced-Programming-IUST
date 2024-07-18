using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace C22
{
    class Program
    {
        public class _country
        {
            public string _Name ;
            public int _Year ;
            public double _Estimate ;
        }
        static void Main(string[] args)
        {
            File.ReadAllLines("children-per-woman-UN.csv")
            .Skip(1)
            .Select(l => l.ToLower())
            .Select(s => {
                var toks = s.Split(',').Select(t => t.Trim('"')).ToArray();
                return new _country {
                    _Name = toks[0], 
                    _Year = Int32.Parse(toks[2]),
                    _Estimate = Convert.ToDouble(toks[3], CultureInfo.InvariantCulture)
                };
            })
            .GroupBy(b => b._Name)
            .Select(c =>
            {
                List<double> EstimateList = new List<double>{};
                List<double> DifEstimateList = new List<double>{};
                List<int> YearList = new List<int>{};
                List<Tuple<string, double , int, int , double >> ListTuple = new List<Tuple<string, double , int, int , double >>{};
                int year =0;
                double _min = 0 ;
                foreach (var d in c)
                {
                    EstimateList.Add(d._Estimate);
                    YearList.Add(d._Year);
                }
                for(int i = 0 ; i < EstimateList.Count()-1 ; i++)
                {
                    double dif = EstimateList[i+1] - EstimateList[i];
                    DifEstimateList.Add(dif);
                    if(_min > dif)
                    {
                        _min = dif ;
                        year = i+1 ;
                    }
                }
                (string t_name, double t_rate , int t_pyear, int t_cyear , double t_dif ) t = (c.Key,EstimateList[year],YearList[year-1],YearList[year],(-1)*_min);
                return t ;
            })
            .ToList()    
            .ForEach(d => System.Console.WriteLine(d));
        }
    }
}