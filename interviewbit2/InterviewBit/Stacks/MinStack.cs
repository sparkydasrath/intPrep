using System.Collections.Generic;

namespace Stacks
{
    public class MinStack
    {
        /*
         * 155. Min Stack https://leetcode.com/problems/min-stack/
            Easy

            Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

                push(x) -- Push element x onto stack.
                pop() -- Removes the element on top of the stack.
                top() -- Get the top element.
                getMin() -- Retrieve the minimum element in the stack.

            Example:

            MinStack minStack = new MinStack();
            minStack.push(-2);
            minStack.push(0);
            minStack.push(-3);
            minStack.getMin();   --> Returns -3.
            minStack.pop();
            minStack.top();      --> Returns 0.
            minStack.getMin();   --> Returns -2.

            https://www.youtube.com/watch?v=8Ub73n4ySYk&t=208s

         */

        private readonly Stack<int> minStack;
        private readonly Stack<int> stack;

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public int GetMin() => minStack.Peek();

        public void Pop()
        {
            if (stack.Count == 0) return;

            int val = stack.Pop();
            int minTop = minStack.Peek();
            if (val == minTop) minStack.Pop();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minStack.Count == 0)
            {
                minStack.Push(x);
                return;
            }
            if (x <= minStack.Peek()) minStack.Push(x);
        }

        public int Top() => stack.Peek();
    }
}