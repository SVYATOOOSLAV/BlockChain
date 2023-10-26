using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chain<int> chain = new Chain<int>();
            chain.addBlock(1);
            chain.addBlock(2);
            chain.addBlock(3);

            chain.showAllInfo();
            Console.WriteLine(chain.isValidChain());
            Console.WriteLine();

            Chain<int>.Block block = chain.getBlock(2);
            block.data = 50;

            chain.showAllInfo();
            Console.WriteLine(chain.isValidChain());


        }
    }
}
