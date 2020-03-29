// Bloom filter: https://www.jasondavies.com/bloomfilter/
using System;
using System.Collections;
using System.Linq;
using TestCommon;


namespace A10
{
    public class Q4BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;

        public Q4BloomFilter(int filterSize, int hashFnCount)
        {
            // Write your code here to Initialize 'Filter' and 'HashFunctions' ... 
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];
            HashFunctions[0] = (string str) => (int)Q2HashingWithChain.PolyHash(str, 0, str.Length, 1000000007, 10)%filterSize;
            HashFunctions[1] = (string str) => (int)Q2HashingWithChain.PolyHash(str, 0, str.Length, 1000000007, 20) % filterSize;
            HashFunctions[2] = (string str) => (int)Q2HashingWithChain.PolyHash(str, 0, str.Length, 1000000007, 30) % filterSize;
            HashFunctions[3] = (string str) => (int)Q2HashingWithChain.PolyHash(str, 0, str.Length, 1000000007, 40) % filterSize;

        }


        public void Add(string str)
        {
            for (int i=0; i< HashFunctions.Length; i++)
            {
                Filter[HashFunctions[i](str)] = true;
            }
        }

        public bool Test(string str)
        {
            for (int i=0; i<HashFunctions.Length; i++)
            {
                if (Filter[HashFunctions[i](str)] == true)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}