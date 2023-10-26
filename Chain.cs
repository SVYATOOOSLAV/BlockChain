using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    
    public class Chain<T>
    {
        private Block<T> head;
        private Block<T> last;
        private int cntBlock = 0;

        public Block<T> getHead()
        {
            return head;
        }

        public void addBlock(T data)
        {
            if(head == null)
            {
                head = new Block<T>(data, null);
                last = head;
            }
            else
            {
                Block<T> newBlock = new Block<T>(data, last);
                last.next = newBlock;
                last = newBlock;
            }
            cntBlock++;
        }

        public bool isValidChain()
        {
            Block<T> block1 = head;
            Block<T> block2 = head.next;
            while(block2 != null)
            {
                if (block2.previousHash != block1.currentHash) // check hash
                {
                    return false;
                }

                if (block2.currentHash !=
                    block2.GetHashCode(block1.data)) // generate new hash and check it
                {
                    return false;
                }

                block1 = block1.next;
                block2 = block2.next;
            }

            return true;
        }

        public void showAllInfo()
        {
            Block<T> temp = head;
            while(temp != null)
            {
                Console.WriteLine(temp);
                temp = temp.next;
            }
        }

        public Block<T> getBlock(int index)
        {
            if(index >= 0 && index < cntBlock)
            {
                Block<T> temp = head;
                int currentIndex = 0;

                while (currentIndex != index)
                {
                    temp = temp.next;
                    currentIndex++;
                }

                return temp;
            }
            else
            {
                throw new IndexOutOfRangeException("Выход за пределы цепи");
            }
        }
    }
}
