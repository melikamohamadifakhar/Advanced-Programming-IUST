using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C13.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Compare_X()
        {
            Point[] points = new Point[] {
                new Point(4, 5),
                new Point(0, 7),
                new Point(2,6),
                new Point(1, 5),
                new Point(9, 4),
            };
            Program.Sort<Point>(points , (a,b)=>a.X<b.X);
            int[] res = new int[] {9, 4, 2, 1, 0};
            for(int i = 0 ; i < 5 ; i++ ){
                Assert.AreEqual(points[i].X , res[i]);
            }
        }
        [TestMethod]
        public void Compare_Y()
        {
            Point[] points = new Point[] {
                new Point(4, 5),
                new Point(0, 7),
                new Point(2,6),
                new Point(1, 12),
                new Point(9, 4),
            };
            Program.Sort<Point>(points , (a,b)=>a.Y<b.Y);
            int [] res = new int[] {12, 7, 6, 5, 4};
            for(int i = 0 ; i < 5 ; i++ ){
                Assert.AreEqual(points[i].Y , res[i]);
            }

        }
        [TestMethod]
        public void Comapare_Magnitud()
        {
            Point[] points = new Point[] {
                new Point(0, 0),
                new Point(3, 4),
                new Point(6, 8),
                new Point(0, 4),
                new Point(6, 0)
            };
            Program.Sort<Point>(points , (a,b)=>a.magnitud()<b.magnitud());
            double[] res =new double[] {10,6,5,4,0};
            for(int i = 0 ; i<5 ; i++){
                Assert.AreEqual(points[i].magnitud() , res[i]);
            }
        }
    }
}