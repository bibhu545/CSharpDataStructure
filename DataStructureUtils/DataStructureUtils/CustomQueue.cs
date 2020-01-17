using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class CustomQueue<T> where T : IComparable
    {
        public Queue<T> queue = new Queue<T>();

        /// <summary>
        /// Adds an object to the end of Queue<T>
        /// </summary>
        /// <param name="item">T as a child of IComparable</param>
        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        /// <summary>
        /// Removes and returns an object from the beginning of the Queue<T>
        /// </summary>
        /// <param name="item"></param>
        public T Dequeue()
        {
            return queue.Dequeue();
        }

        /// <summary>
        /// Adds an object to the end of Queue<T>
        /// </summary>
        /// <param name="item">T as a child of IComparable</param>
        public T Peek()
        {
            return queue.Peek();
        }

        /// <summary>
        /// Determines whether an element is in the Queue<T>
        /// </summary>
        /// <param name="item">T as a child of IComparable</param>
        public bool Contains(T item)
        {
            return queue.Contains(item);
        }

        /// <summary>
        /// Copies the Queue<T> elements to a new array.
        /// </summary>
        /// <param name="item">T as a child of IComparable</param>
        public T[] ToArray()
        {
            return queue.ToArray();
        }

        /// <summary>
        /// Clears all the elements from the Queue<T>
        /// </summary>
        /// <param name="item"></param>
        public void clear()
        {
            queue.Clear();
        }

        /// <summary>
        /// Determines the position of item from the beginning of the Queue<T>
        /// </summary>
        /// <param name="item">T as a child of IComparable</param>
        public int IndexOf(T serachItem)
        {
            int index = -1, i = 0;
            foreach (var item in queue)
            {
                if (item.CompareTo(serachItem) == 0)
                {
                    index = i;
                }
                ++i;
            }
            return index;
        }

        /// <summary>
        /// returns all elements of Queue<T> as a string
        /// </summary>
        /// <param name="item"></param>
        public String show()
        {
            String result = "[";
            foreach (var item in queue)
            {
                result += item.ToString() + ", ";
            }
            if (queue.Count > 0)
            {
                result = result.Substring(0, result.Length - 2);
            }
            result += "]";
            return result;
        }

        /// <summary>
        /// return maximum element of the Queue<T>
        /// </summary>
        /// <param name="item"></param>
        public T Max()
        {
            var big = queue.Peek();
            foreach (var item in queue)
            {
                if (item.CompareTo(big) > 0)
                {
                    big = item;
                }
            }
            return big;
        }

        /// <summary>
        /// returns minimum element of the Queue<T>
        /// </summary>
        /// <param name="item"></param>
        public T Min()
        {
            var big = queue.Peek();
            foreach (var item in queue)
            {
                if (item.CompareTo(big) < 0)
                {
                    big = item;
                }
            }
            return big;
        }

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <param name="item"></param>
        public override string ToString()
        {
            return queue.ToString();
        }
    }
}
