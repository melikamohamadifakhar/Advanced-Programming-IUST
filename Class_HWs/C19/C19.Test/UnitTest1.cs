using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C19.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MultiplyTest()
        {
            Complex c1 = new Complex(2,2);
            Complex c2 = new Complex(1,3);
            Complex multiplied =c1 * c2;
            Assert.AreEqual(8,multiplied[0]);
            Assert.AreEqual(4,multiplied[1]);
        }

        [TestMethod]
        public void EqualityTest()
        {
            Complex c = new Complex(5, 7);
            Complex c1 = new Complex(6, 1);
            Complex c2 = new Complex(5, 7);
            Assert.AreEqual(true,c.Equals(c2));
            Assert.AreNotEqual(true, c1.Equals(c2));
        }

        [TestMethod]
        public void EqualityOperationTest()
        {
            Complex c = new Complex(5, 7);
            Complex c1 = new Complex(6, 1);
            Complex c2 = new Complex(5, 7);
            Assert.IsTrue(c2==c);
            Assert.IsFalse(c2==c1);
            Assert.IsTrue(c1!=c2);
            Assert.IsFalse(c2!=c);
        }

        [TestMethod]
        public void ToStringMethod(){
            Complex c = new Complex(5, 7);
            Assert.AreEqual("7+5i",c.ToString());
        }

        [TestMethod]
        public void ExplicitOpString()
        {
            string c = (string) new Complex(1,3);
            Assert.AreEqual("3+1i",c);
        }

        [TestMethod]
        public void ExplicitOpComplex()
        {
            Complex c = (Complex) "1i+3";
            Assert.AreEqual(1,c[0]);
            Assert.AreEqual(3,c[1]);
        }
    }
}