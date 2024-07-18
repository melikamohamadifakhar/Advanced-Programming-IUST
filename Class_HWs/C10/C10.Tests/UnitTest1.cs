using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C10.Tests
{   [TestClass]
    public class PointCompare
    {
        [TestMethod]
        public void xCompare()
        {
            Point[] points = new Point[] {
                new Point(0,0),
                new Point(9,4),
                new Point(7,8),
                new Point(2,10),
                new Point(11,1),
                new Point(1,2),
                new Point(10,7),
            };
            // bool d = PointComparer.PointXComparer(points[0], points[1]);
            Program.Sort<Point>(points , PointComparer.PointXComparer );
            int[] res = new int[] {0,1,2,7,9,10,11};
            for(int i = 0 ; i < 7 ; i++ ){
                Assert.AreEqual(points[i].X , res[i]);
            }
        }
        [TestMethod]
        public void yCompare()
        {
            Point[] points = new Point[] {
                new Point(0,0),
                new Point(9,4),
                new Point(7,8),
                new Point(2,10),
                new Point(11,1),
                new Point(1,2),
                new Point(10,7),
            };
            Program.Sort<Point>(points , PointComparer.PointYComparer );
            int [] res = new int[] {0,1,2,4,7,8,10};
            for(int i = 0 ; i < 7 ; i++ ){
                Assert.AreEqual(points[i].Y , res[i]);
            }

        }
        [TestMethod]
        public void MagnitudeComapare()
        {
            Point[] points = new Point[] {
                new Point(0,0),
                new Point(4,3),
                new Point(0,2),
                new Point(6,8)
            };
            Program.Sort<Point>(points , PointComparer.PointMagnitudeComparer);
            double[] res =new double[] {0,2,5,10};
            for(int i = 0 ; i<4 ; i++){
                Assert.AreEqual(points[i].magnitud() , res[i]);
            }
        }
    }
}
