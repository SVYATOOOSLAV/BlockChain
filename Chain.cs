using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    
    public class Chain<T>
    {
        public class Block
        {
            public int currentHash { get; set; }
            public int previousHash { get; set; }
            public T data;
            public DateTime time;

            public Block next;

            public Block(T data, Block previous)
            {
                this.data = data;
                time = DateTime.Now;

                currentHash = previous == null ? GetHashCode() :
                    GetHashCode(previous.data);

                previousHash = previous == null ? 0 : previous.currentHash;
            }


            public int GetHashCode(T prevData)
            {
                int hashCode = -961760943;
                hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(data);
                hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(prevData);
                hashCode = hashCode * -1521134295 + time.GetHashCode();
                return hashCode;
            }

            public override int GetHashCode()
            {
                int hashCode = -961760943;
                hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(data);
                hashCode = hashCode * -1521134295 + time.GetHashCode();
                return hashCode;
            }

            public override string ToString() => $"Block Date of creation:{time} Data:{data}";

        }

        private Block head;
        private Block last;
        private int cntBlock = 0;


        public void addBlock(T data)
        {
            if(head == null)
            {
                head = new Block(data, null);
                last = head;
            }
            else
            {
                Block newBlock = new Block(data, last);
                last.next = newBlock;
                last = newBlock;
            }
            cntBlock++;
        }

        public bool isValidChain()
        {
            Block block1 = head;
            Block block2 = head.next;
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
            Block temp = head;
            while(temp != null)
            {
                Console.WriteLine(temp);
                temp = temp.next;
            }
        }

        public Block getBlock(int index)
        {
            if(index >= 0 && index < cntBlock)
            {
                Block temp = head;
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
