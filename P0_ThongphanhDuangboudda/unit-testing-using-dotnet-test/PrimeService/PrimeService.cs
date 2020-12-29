using System;

namespace PrimeService
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            Console.WriteLine("called");
            if (candidate == 1)
            {
                     return false;
            }
                throw new NotImplementedException("Not fully implemented.");
        }
        
    }
}
