using MbUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestimonialsUnitTests
{
    [TestFixture]
    public class IAmAUnitTestSuite
    {
        [Test]
        [Author("Nyan Cat")]
        public static void IAmAPassingUnitTest()
        {
            Assert.IsFalse(1 == 2);
        }

        [Test]
        [Author("Doge")]
        public static void IAmAFailingUnitTest()
        {
            Assert.IsTrue(1 == 1);
        }
    }
}
