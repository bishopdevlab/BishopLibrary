using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bishop.DesignPattern.Test
{
    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void CreateInstanceTest()
        {
            Assert.IsInstanceOfType(UserClass.Instance, typeof(UserClass));
            var result = UserClass.Instance.Run();
            Assert.IsTrue(result);
        }

        public class UserClass : Singleton<UserClass>
        {
            public bool Run()
            {
                return true;
            }
        }
    }
}
