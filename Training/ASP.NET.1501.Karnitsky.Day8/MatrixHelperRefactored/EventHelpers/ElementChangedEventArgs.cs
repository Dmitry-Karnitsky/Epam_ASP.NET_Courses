using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelperRefactored
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        private readonly string message;
        private readonly T elementBefore;
        private readonly T elementAfter;
        private readonly int i;
        private readonly int j;

        public ElementChangedEventArgs(string message, T elementBefore, T elementAfter, int i, int j)
        {
            this.message = message;
            this.elementBefore = elementBefore;
            this.elementAfter = elementAfter;
            this.i = i;
            this.j = j;
        }

        public string Message
        { 
            get { return message; } 
        }

        public T ElementBefore
        {
            get { return elementBefore; }
        }

        public T ElementAfter
        {
            get { return elementAfter; }
        }

        public int I
        {
            get { return i; }
        }

        public int J
        {
            get { return j; }
        }

    } 
}
