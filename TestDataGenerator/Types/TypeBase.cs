using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGenerator.Infrastructure;

namespace TestDataGenerator.Types
{
    public abstract class TypeBase<T>
    {
        protected string dataDir = @"\Data";

        protected List<T> Items { get; set; }
        protected List<int> RandomSeq; 
        protected int Position;

        public virtual T Next()
        {
            CheckReset();
            return Items[RandomSeq[Position++]];
        }

        public virtual void Reset()
        {
            RandomSeq = Helper.UniqueRandomSequence(0, Items.Count - 1);
            Position = 0;
        }

        protected void CheckReset()
        {
            if (Position >= Items.Count)
                Reset();
        }
    }
}
