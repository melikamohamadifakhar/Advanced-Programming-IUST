
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C5.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Point p1 = new Point(3,2,0);
            Point p2 = new Point(3,-1,4);
            Assert.AreEqual(Point.DistanceTo(p1,p2),5);
            Assert.AreEqual(p1.DistanceTo(p2),Point.DistanceTo(p1,p2));

            p1 = new Point(0,7,-2);
            p2 = new Point(3,5,5);
            Assert.AreEqual(p1.DistanceTo(p2),p2.DistanceTo(p1));
            Assert.AreEqual(Point.DistanceTo(p1,p2),p2.DistanceTo(p1));

            
            PointValue s1 = new PointValue(2,1,3);
            PointValue s2 = new PointValue(-1,1,-1);
            Assert.AreEqual(s1.DistanceTo(s2),PointValue.DistanceTo(s1,s2));
            Assert.AreEqual(s1.DistanceTo(s1),0);
        }
    }
}