using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A00.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int is_greater = A00.Program.is_greater(1, 5);
            Assert.AreEqual(is_greater, 5);
            is_greater = A00.Program.is_greater(4, -1);
            Assert.AreEqual(is_greater, 4);
        }
    }
}
