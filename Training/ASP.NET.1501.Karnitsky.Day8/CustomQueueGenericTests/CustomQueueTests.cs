using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomQueueGeneric;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CustomQueueGeneric.Tests
{
    [TestClass()]
    public class CustomQueueTests
    {
        [TestMethod()]
        public void EnqueueOnlyTest()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();
            queue.Enqueue(new TestClass() { str = "First" });
            queue.Enqueue(new TestClass() { str = "Second" });

            List<TestClass> actual = QueueToList<TestClass>(queue);
            List<TestClass> expected = new List<TestClass>();

            expected.Add(new TestClass() { str = "First" });
            expected.Add(new TestClass() { str = "Second" });

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EnqueueThanDequeueTest1()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();
            queue.Enqueue(new TestClass() { str = "First" });
            queue.Enqueue(new TestClass() { str = "Second" });
            queue.Enqueue(new TestClass() { str = "Third" });
            queue.Dequeue();

            List<TestClass> actual = QueueToList<TestClass>(queue);
            List<TestClass> expected = new List<TestClass>();

            expected.Add(new TestClass() { str = "Second" });
            expected.Add(new TestClass() { str = "Third" });

            CollectionAssert.AreEqual(expected, actual);
        }        

        [TestMethod()]
        public void EnqueueThanDequeueTest2()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();
            queue.Enqueue(new TestClass() { str = "First" });
            queue.Enqueue(new TestClass() { str = "Second" });
            queue.Enqueue(new TestClass() { str = "Third" });
            queue.Dequeue();
            queue.Enqueue(new TestClass() { str = "Fourth" });
            queue.Dequeue();
            queue.Enqueue(new TestClass() { str = "Fifth" });


            List<TestClass> actual = QueueToList<TestClass>(queue);
            List<TestClass> expected = new List<TestClass>();

            expected.Add(new TestClass() { str = "Third" });
            expected.Add(new TestClass() { str = "Fourth" });
            expected.Add(new TestClass() { str = "Fifth" });

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EnqueueThanDequeueTest3()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();
            queue.Enqueue(new TestClass() { str = "First" });
            queue.Dequeue();

            List<TestClass> actual = QueueToList<TestClass>(queue);
            List<TestClass> expected = new List<TestClass>();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EnqueueThanPeekTest()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();
            queue.Enqueue(new TestClass() { str = "First" });
            queue.Enqueue(new TestClass() { str = "Second" });
            queue.Enqueue(new TestClass() { str = "Third" });
            queue.Peek();

            List<TestClass> actual = QueueToList<TestClass>(queue);
            List<TestClass> expected = new List<TestClass>();

            expected.Add(new TestClass() { str = "First" });
            expected.Add(new TestClass() { str = "Second" });
            expected.Add(new TestClass() { str = "Third" });

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueEmptyQueueTest()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();            
            queue.Dequeue();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekEmptyQueueTest()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>();
            queue.Peek();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateQueueWithNegativeCapacityTest()
        {
            CustomQueue<TestClass> queue = new CustomQueue<TestClass>(-1);            
        }        

        // This method also implicitly checks correct work of the Enumerator
        internal List<T> QueueToList<T>(CustomQueue<T> queue)
        {
            List<T> result = new List<T>();
            foreach(T elem in queue)
            {
                result.Add(elem);
            }
            return result;
        }

    }

    internal class TestClass
    {
        public string str = "String";

        public override bool Equals(object obj)
        {
            return (str.CompareTo(((TestClass)obj).str) == 0) ? true : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
