using NUnit.Framework;

namespace Trees.Tests
{
    [TestFixture]
    public class SerializationDeserializationTests
    {
        [Test]
        public void ShouldSerializeToStringPreOrder()
        {
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