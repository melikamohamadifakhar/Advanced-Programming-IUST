using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C18.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_Test()
        {
            MyPoint P1 = new MyPoint(5, 4, 7, 8, 12);
            MyPoint P2 = new MyPoint(6, 1, 4, 9, 2);
            MyPoint Add = P1 + P2;
            int[] expected = {11, 5, 11, 17, 14};
            for(int i =0 ;i<expected.Length;i++)
                Assert.AreEqual(expected[i],Add[i]);
        }

        [TestMethod]
        public void Subtract_Test()
        {
            MyPoint P1 = new MyPoint(5, 4, 7, 8, 12);
            MyPoint P2 = new MyPoint(6, 1, 4, 9, 2);
            MyPoint Subtract = P1 - P2;
            int[] expected = {-1,3, 3, -1, 10};
            for(int i =0 ;i<expected.Length;i++)
                Assert.AreEqual(expected[i],Subtract[i]);
        }

        [TestMethod]
        public void Multiply_Test()
        {
            MyPoint P1 = new MyPoint(5, 4, 7, 8, 12);
            MyPoint P2 = new MyPoint(6, 1, 4, 9, 2);
            MyPoint Mul = P1 * P2;
            int[] expected = {30, 4, 28, 72, 24};
            for(int i =0 ;i<expected.Length;i++)
                Assert.AreEqual(expected[i],Mul[i]);
        }

        [TestMethod]
        public void Division_Test()
        {
            MyPoint P1 = new MyPoint(5, 4, 7, 8, 12);
            MyPoint P2 = new MyPoint(6, 1, 4, 9, 2);
            MyPoint Div = P1 / P2;
            int[] expected = {0, 4, 1, 0, 6};
            for(int i =0 ;i<expected.Length;i++)
                Assert.AreEqual(expected[i],Div[i]);
        }
        [TestMethod]
        public void OtherOperators()
        {
            MyPoint p1 = new MyPoint(2, 3, 4, 5, 6);
            MyPoint p2 = new MyPoint(3, 5, 7, 9, 11);
            MyPoint p3 = new MyPoint(2, 3, 4, 5, 6);

            Assert.AreEqual(2, p1[0]);
            Assert.AreEqual(5, p2[1]);
            Assert.AreEqual(6, p1[4]);
            Assert.AreEqual(7, p2[2]);
            Assert.AreEqual(true , p1==p3);
            Assert.AreEqual(true , p1!=p2);
            Assert.AreEqual(false , p1!=p3);
            Assert.AreEqual(true , p2>p1);
            Assert.AreEqual(false , p3>p1);
            Assert.AreEqual(false , p2<p1);
            Assert.AreEqual(false , p3<p1);

            Assert.AreEqual(0, p1.CompareTo(p3));
            Assert.AreEqual(-1, p1.CompareTo(p2));
            Assert.AreEqual(1, p2.CompareTo(p1));
        }
    }
}

