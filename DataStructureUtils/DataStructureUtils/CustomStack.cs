using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class CustomStack
    {
        /// <summary>
        /// Displays all elements of stack(top to bottom) 
        /// </summary>
        /// <param name="stack">Stack whose elements is to be displayed</param>
        public void GetAllElements(Stack stack)
        {
            Stack temporaryStack = new Stack();
            object element;
            if (stack.Count == 0)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            else
            {
                Console.WriteLine("Elements in the Stack are :");
                for (int i = stack.Count; i > 0; i--)
                {
                    element = stack.Pop();
                    Console.WriteLine(element);
                    temporaryStack.Push(element);

                }
            }
            while (temporaryStack.Count != 0)
            {
                stack.Push(temporaryStack.Pop());
            }

        }
        /// <summary>
        /// Updates value of an Element at a Particular Position
        /// </summary>
        /// <param name="position">Position of the Element to be Updated(position 1 = bottom of the stack)</param>
        /// <param name="updatedValue">New value of the Element to be Updated</param>
        /// <param name="stack">Stack in which the element is to be updated</param>
        public string UpdateElement(Stack stack, int position, object updatedValue)
        {
            Stack temporaryStack = new Stack();
            if (stack.Count != 0)
            {
                while (stack.Count != position)
                {
                    for (int i = stack.Count; i > position; i--)
                    {
                        temporaryStack.Push(stack.Pop());

                    }
                }
                stack.Pop();
                stack.Push(updatedValue);
                while (temporaryStack.Count != 0)
                {
                    stack.Push(temporaryStack.Pop());
                }
                return "Element is updated";
            }
            return "Element is not found in the Stack. So updation is not possible.";
        }
        /// <summary>
        /// Search a particular element in stack
        /// </summary>
        /// <param name="element">Element to be Searched</param>
        /// <param name="stack">Stack in which the element is to be searched</param>
        public bool SearchElement(Stack stack, object element)
        {
            if (stack.Contains(element))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
