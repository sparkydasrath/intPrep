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

        private int btDeserialIndex = 0;

        public TreeNode DeserializeBinarySearchTreeFromPreOrderArray(int start, int end, List<int> array)
        {
            /*
             * Base case: the current portion of the array is empty
             */
            if (start > end) return null;

            TreeNode root = new TreeNode(array[start]);
            int pivot = DeserializeBinarySearchTreeFromPreOrderArrayHelper(start, end, array, array[start]);

            root.Left = DeserializeBinarySearchTreeFromPreOrderArray(start + 1, pivot - 1, array);
            root.Right = DeserializeBinarySearchTreeFromPreOrderArray(pivot, end, array);

            return root;
        }

        public TreeNode DeserializeBinaryTreeFromPreOrderArray(List<int> array)
        {
            if (btDeserialIndex == array.Count || array[btDeserialIndex] == -1)
            {
                btDeserialIndex += 1;
                return null;
            }

            TreeNode root = new TreeNode(array[btDeserialIndex]);
            btDeserialIndex++;

            root.Left = DeserializeBinaryTreeFromPreOrderArray(array);
            root.Right = DeserializeBinaryTreeFromPreOrderArray(array);

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

        private int DeserializeBinarySearchTreeFromPreOrderArrayHelper(int start, int end, List<int> array, int rootValue)
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