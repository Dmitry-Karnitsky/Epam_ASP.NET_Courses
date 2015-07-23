using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueueGeneric
{
    public sealed class CustomQueue<T> : IEnumerable<T>, IEnumerable
    {
        private int longQueueLength;
        private int elementsNumber;
        private int beginPointer;
        private T[] items;

        public CustomQueue()
        {
            longQueueLength = 4;
            items = new T[longQueueLength];
            beginPointer = -1;
        }

        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity of queue can't be less than 0.");
            if (capacity == 0) ++capacity;
            this.longQueueLength = capacity;
            items = new T[capacity];
            beginPointer = -1;
            elementsNumber = 0;
        }

        public int Count
        {
            get
            {
                return elementsNumber;
            }
        }

        public int Size
        {
            get
            {
                return longQueueLength;
            }
        }

        public void Enqueue(T item)
        {
            if (beginPointer == -1)
            {
                items[0] = item;
                beginPointer = 0;
                elementsNumber = 1;
                return;
            }

            if (elementsNumber == longQueueLength)
            {
                longQueueLength = longQueueLength * 2;
                T[] newQueue = new T[longQueueLength];

                for (int i = 0; i < elementsNumber; i++)
                {
                    newQueue[i] = items[i + beginPointer];
                }

                items = newQueue;
            }

            if (beginPointer + elementsNumber == longQueueLength)
            {
                for (int i = 0; i < elementsNumber; i++)
                {
                    items[i] = items[i + beginPointer];
                }
                for (int i = elementsNumber; i < longQueueLength; i++)
                    items[i] = default(T);
                beginPointer = 0;
            }

            items[elementsNumber + beginPointer] = item;
            elementsNumber++;
        }

        public T Dequeue()
        {
            if (elementsNumber == 0)
            {
                throw new InvalidOperationException("Queue<" + typeof(T) + "> is empty.");
            }

            T result = items[beginPointer];
            items[beginPointer] = default(T);
            beginPointer++;
            elementsNumber--;
            return result;
        }

        public T Peek()
        {
            if (elementsNumber == 0)
            {
                throw new InvalidOperationException("Queue<" + typeof(T) + "> is empty.");
            }

            T result = items[beginPointer];
            return result;
        }

        public void Clear()
        {
            for (int i = 0; i < longQueueLength; i++)
            {
                items[i] = default(T);
            }

            beginPointer = -1;
            elementsNumber = 0;
        }

        public override string ToString()
        {
            return "Queue<" + typeof(T) + ">";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        #region Enumerator
        private class Enumerator<T> : IEnumerator<T>, IEnumerator
        {
            private readonly CustomQueue<T> queue;
            private int currentIndex;

            public Enumerator(CustomQueue<T> queue)
            {
                this.queue = queue;
                currentIndex = queue.beginPointer - 1;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new InvalidOperationException("Enumeration not started!");
                    if (currentIndex >= queue.elementsNumber + queue.beginPointer)
                        throw new InvalidOperationException("Past end of list!");
                    return queue.items[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                return ++currentIndex < queue.elementsNumber + queue.beginPointer;
            }

            public void Reset()
            {
                currentIndex = queue.beginPointer - 1;
            }

            void IDisposable.Dispose()
            {
                return;
            }
        }
        #endregion
    }
}
