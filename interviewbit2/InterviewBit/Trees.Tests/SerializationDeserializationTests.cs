using NUnit.Framework;
using System.Collections.Generic;

namespace Trees.Tests
{
    [TestFixture]
    public class SerializationDeserializationTests
    {
        [Test]
        public void ShouldSerializeBinarySearchTreePreOrder()
        {
            /*
                        5
                     /     \
                    2        7
                   / \      / \
                  1   3    6   8
                       \
                        4
             */

            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinarySearchTree();

            Serialization serialization = new Serialization();
            Deserialization deserialization = new Deserialization();

            List<int> serializedOutput = new List<int>();
            serialization.SerializeBinarySearchTreeToArray(root, serializedOutput);

            Assert.That(serializedOutput.Count, Is.EqualTo(8));

            TreeNode deserializedResult = deserialization
                .DeserializeBinarySearchTreeFromPreOrderArray(0, serializedOutput.Count - 1, serializedOutput);

            Assert.IsNotNull(deserializedResult);
            Assert.That(deserializedResult.Left.Val, Is.EqualTo(2));
            Assert.That(deserializedResult.Right.Val, Is.EqualTo(7));
        }

        [Test]
        public void ShouldSerializeBinaryTreeToStringPreOrder()
        {
            /*
                           10
                       /        \
                     11         -20
                    /  \        /  \
                   15   12     0    9
                              / \
                             16  18
             */

            TreeBuilder tb = new TreeBuilder();
            TreeNode root = tb.BuildBinaryTree();

            Serialization serialization = new Serialization();
            Deserialization deserialization = new Deserialization();

            string serializedResult = serialization.SerializeToString(root);

            TreeNode deserializedResult = deserialization
                .DeserializeBinaryTreeFromString(serializedResult);

            Assert.That(serializedResult, Is.Not.Null);
            Assert.That(deserializedResult, Is.Not.Null);
        }
    }
}