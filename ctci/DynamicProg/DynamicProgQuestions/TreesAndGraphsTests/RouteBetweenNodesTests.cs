using NUnit.Framework;
using TreesAndGraphs;

namespace TreesAndGraphsTests
{
    [TestFixture]
    public class RouteBetweenNodesTests
    {
        public GraphNode MakeGraphNode()
        {
            GraphNode three = new GraphNode(3)
            {
                GraphNodes = new[]
                {
                    new GraphNode(4)
                    {
                        GraphNodes = new[]
                        {
                            new GraphNode(5)
                        }
                    }
                }
            };

            GraphNode n = new GraphNode(1)
            {
                GraphNodes = new[]
                {
                    new GraphNode(2)
                    {
                        GraphNodes = new[]
                        {
                            three,
                            new GraphNode(5)
                        }
                    },
                    three
                    /*new GraphNode(3)
                    {
                        GraphNodes = new[]
                        {
                            new GraphNode(4)
                            {
                                GraphNodes = new[]
                                {
                                    new GraphNode(5)
                                }
                            }
                        }
                    }*/
                }
            };
            return n;
        }

        [Test]
        public void ShouldReturnTrueIfPathExists()
        {
            RouteBetweenNodes rbn = new RouteBetweenNodes();
            GraphNode n = MakeGraphNode();
            bool res = rbn.IsPath(n, 5);
            Assert.That(res, Is.True);
        }
    }
}