using NUnit.Framework;

namespace Program
{
    public class Tests
    {
        [Test]
        public void TimeSinceMidnight_Should_Return_Correct_Seconds()
        {
            MyTime t = new MyTime(13, 34, 56);

            int actualResult = Program.TimeSinceMidnight(t);
            int expectedResult = 48896;
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TimeSinceMidnight_Should_Return_Correct_Seconds_Int()
        {
            int t = 48896;
            
            MyTime actualResult = Program.TimeSinceMidnight(t);
            MyTime expectedResult = new MyTime(13, 34, 56);
            
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());
        }
        
        [Test]
        public void AddOneSecond_Should_Return_Correct_Result_Add_One_Seconds()
        {
            MyTime t = new MyTime(13, 34, 56);
            
            MyTime actualResult = Program.AddOneSecond(t);
            MyTime expectedResult = new MyTime(13, 34, 57);
            
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());
        }
        
        [Test]
        public void AddOneMinute_Should_Return_Correct_Result_Add_One_Minutes()
        {
            MyTime t = new MyTime(13, 34, 56);
            
            MyTime actualResult = Program.AddOneMinute(t);
            MyTime expectedResult = new MyTime(13, 35, 56);
            
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());
        }
        
        [Test]
        public void AddOneHour_Should_Return_Correct_Result_Add_One_Hours()
        {
            MyTime t = new MyTime(13, 34, 56);
            
            MyTime actualResult = Program.AddOneHour(t);
            MyTime expectedResult = new MyTime(14, 34, 56);
            
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());
        }

        [Test]
        public void DifferenceInSeconds_Should_Return_Correct_Difference_Between_Two_Points_In_Time()
        {
            MyTime mt1 = new MyTime(12, 00, 00);
            MyTime mt2 = new MyTime(13, 34, 56);

            int actualResult = Program.Difference(mt1, mt2);
            int expectedResult = 5696;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}