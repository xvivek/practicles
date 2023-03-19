using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.GeeksForGeeks.SDE.Arrays
{
    public class EquilibriumPoint
    {
        public int findElement(int[] arr, int N)
        {
            int leftSum=0;
            int rightSum=0;
            for(int i=0,j= N - 1; i< N; i++,j--)
            {
                if (i == j)
                    break;

                leftSum = leftSum + arr[i];
                rightSum = rightSum + arr[j];

                if (leftSum == rightSum)
                    return arr[i+1];
            }

            return 0;
        }


        public int findElement2(int[] arr, int N)
        {
            int leftSum = 0;
            int rightSum = 0;

            int[] sum =  new int[N];

            if (N == 1)
                return 1;

            sum[0] = arr[0];
            for (int i = 0; i < N; i++)
            {
                rightSum += arr[i];
            }

            leftSum = arr[0];           
            for (int i = 0; i < N;i++)
            {              
                if (leftSum == rightSum -  leftSum - arr[i])
                    return i+1;
                leftSum += arr[i];
            }

            return -1;
        }


        public int findElement3(int[] arr, int N)
        {
            int leftSum = 0;
            int rightSum = 0;
                       
            for (int i = 0; i < N; i++)
            {
                rightSum += arr[i];
            }
            
            for (int i = 0; i < N; i++)
            {                
                if (leftSum == (rightSum - leftSum - arr[i]))
                    return i + 1;

                leftSum += arr[i];
            }

            return -1;
        }
    }
}
