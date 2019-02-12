using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class MeetingRoomsTests
    {
        [Test]
        public void CanAttendMeetingsI()
        {
            MeetingRoomsI mr1 = new MeetingRoomsI();
            Interval[] input1 =
            {
                new Interval(0, 30),
                new Interval(5, 10),
                new Interval(15, 20)
            };
            bool result1 = mr1.CanAttendMeetings(input1);
            Assert.IsFalse(result1);

            Interval[] input2 =
            {
                new Interval(7, 10),
                new Interval(2, 4),
            };
            bool result2 = mr1.CanAttendMeetings(input2);
            Assert.IsTrue(result2);
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void CanAttendMeetingsII1()
        {
            MeetingRoomsII mr2 = new MeetingRoomsII();
            Interval[] input1 =
            {
                new Interval(0, 30),
                new Interval(5, 10),
                new Interval(15, 20)
            };
            int result1 = mr2.MinMeetingRooms(input1);
            Assert.That(result1, Is.EqualTo(2));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void CanAttendMeetingsII2()
        {
            MeetingRoomsII mr2 = new MeetingRoomsII();
            Interval[] input2 =
            {
                new Interval(7, 10),
                new Interval(2, 4),
            };
            int result2 = mr2.MinMeetingRooms(input2);
            Assert.That(result2, Is.EqualTo(1));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void CanAttendMeetingsII3()
        {
            MeetingRoomsII mr2 = new MeetingRoomsII();

            Interval[] input3 =
            {
                new Interval(9, 10),
                new Interval(4, 9),
                new Interval(4, 17),
            };
            int result3 = mr2.MinMeetingRooms(input3);
            Assert.That(result3, Is.EqualTo(2));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void CanAttendMeetingsII4()
        {
            MeetingRoomsII mr2 = new MeetingRoomsII();
            Interval[] input4 =
            {
                new Interval(9, 10),
                new Interval(4, 9),
                new Interval(4, 17),
            };
            int result4 = mr2.MinMeetingRooms(input4);
            Assert.That(result4, Is.EqualTo(2));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void CanAttendMeetingsII5()
        {
            MeetingRoomsII mr2 = new MeetingRoomsII();
            Interval[] input4 =
            {
                new Interval(1, 5),
                new Interval(8, 9),
                new Interval(8, 9),
            };
            int result4 = mr2.MinMeetingRooms(input4);
            Assert.That(result4, Is.EqualTo(2));
        }
    }
}