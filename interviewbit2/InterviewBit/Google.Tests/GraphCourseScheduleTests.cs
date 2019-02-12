using Graphs;
using NUnit.Framework;

namespace Google.Tests
{
    [TestFixture]
    public class GraphCourseScheduleTests
    {
        [Test]
        public void ShouldDetermineIfCanTakeCourses()
        {
            GraphCourseSchedule course = new GraphCourseSchedule();
            int num = 2;
            int[,] pre = GetPrerequisites(num);

            Graph g = new Graph(pre, 2);

            bool result = course.CanFinish(num, pre);
            Assert.That(result, Is.True);
        }

        private int[,] GetPrerequisites(int num)
        {
            int[,] pre = {
                {1,0 },
            };

            return pre;
        }
    }
}