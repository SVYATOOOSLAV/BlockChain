using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Block<T>
    {
        public int currentHash { get; set; }
        public int previousHash { get; set; }
        public T data;
        public DateTime time;

        public Block<T> next;

        public Block(T data, Block<T> previous)
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
}
