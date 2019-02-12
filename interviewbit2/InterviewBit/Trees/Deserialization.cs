using System;
using System.Collections.Generic;

namespace Trees
{
    public class Deserialization
    {
        /*
         * https://www.geeksforgeeks.org/serialize-deserialize-binary-tree/
         *
         * Binary Tree
         * https://www.youtube.com/watch?v=jwzo6IsMAFQ&t=12s
         *
         * Binary Search Tree
         */

        private int i = 0;

        public TreeNode DeserializeBinarySearchTreeFromArray(int start, int end, List<int> array)
        {
            /*
             * Base case: the current portion of the array is empty
             */
            if (start > end) return null;

            TreeNode root = new TreeNode(array[start]);
            int pivot = DeserializeBinarySearchTreeFromArrayHelper(start, end, array, array[start]);

            root.Left = DeserializeBinarySearchTreeFromArray(start + 1, pivot - 1, array);
            root.Right = DeserializeBinarySearchTreeFromArray(pivot, end, array);

            return root;
        }

        public TreeNode DeserializeBinaryTreeFromArray(List<int> array)
        {
            if (i == array.Count || array[i] == -1)
            {
                i += 1;
                return null;
            }

            TreeNode root = new TreeNode(array[i]);
            i++;

            root.Left = DeserializeBinaryTreeFromArray(array);
            root.Right = DeserializeBinaryTreeFromArray(array);

            return root;
        }

        public TreeNode DeserializeBinaryTreeFromString(string data)
        {
            string[] splitData = data.Split(',');
            TreeNode root = DeserializeBinaryTreeFromStringHelper(splitData, 0);
            return root;
        }

        public TreeNode DeserializeBinaryTreeFromStringHelper(string[] data, int index)
        {
            if (index == data.Length || data[index] == "null")
            {
                index += 1;
                return null;
            }

            TreeNode root = new TreeNode(Convert.ToInt32(data[index]));

            index += 1;
            root.Left = DeserializeBinaryTreeFromStringHelper(data, index);
            root.Right = DeserializeBinaryTreeFromStringHelper(data, index);

            return root;
        }

        private int DeserializeBinarySearchTreeFromArrayHelper(int start, int end, List<int> array, int rootValue)
        {
            int j;
            for (j = start; j <= end; j++)
            {
                if (rootValue < array[j])
                    break;
            }

            return j;
        }
    }
}