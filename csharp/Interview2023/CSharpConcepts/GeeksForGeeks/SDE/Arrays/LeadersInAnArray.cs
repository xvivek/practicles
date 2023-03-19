using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.GeeksForGeeks.SDE.Arrays
{
    public class LeadersInAnArray
    {

        public List<int> GetLeaders(List<int> numbers)
        {
            List<int> results = new List<int>();

            if (numbers == null || numbers.Count == 0)
                return results;
           
            int leader;
            for(int i=0;i<numbers.Count();i++)
            {
                leader = numbers[i];
                for (int j = i+1; j< numbers.Count(); j++)
                {
                    if (leader < numbers[j])
                    {
                        leader = numbers[j];                       
                    }
                }

                if(!results.Contains(leader))
                    results.Add(leader);
            }

            return results;
        }

        public int[] GetLeaders2(int[] numbers, int N)
        {
            List<int> results = new List<int>();

            if (numbers == null || N == 0)
                return results.ToArray();

            int leader = numbers[N - 1];
            results.Add(leader);
            for (int i= N - 2; i >= 0; i--)
            {                
                if (numbers[i] >= leader)
                {                                      
                    results.Insert(0,numbers[i]);
                    //results.Add(numbers[i]);
                    leader = numbers[i];                  
                }               
            }

            return results.ToArray();
        }

    }
}
