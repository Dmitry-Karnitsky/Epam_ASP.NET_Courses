using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHelperRefactored
{
    public abstract class AbstractSquareMatrix<T> : IEquatable<AbstractSquareMatrix<T>>
    {    
        public virtual event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        public abstract int Order { get; protected set; }

        public abstract T this[int x, int y] { get; set; }        

        protected abstract void OnElementChanged(ElementChangedEventArgs<T> e);

        public virtual bool Equals(AbstractSquareMatrix<T> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.Order != this.Order)
                return false;

            for (int i = 0; i < other.Order; i++)
            {
                for (int j = 0; j < other.Order; j++)
                {
                    if (this[i, j].Equals(other[i, j]) == false)
                        return false;
                }
            }
            return true;
        }       
    }
}
