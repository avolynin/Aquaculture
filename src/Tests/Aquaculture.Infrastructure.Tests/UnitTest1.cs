namespace Aquaculture.Infrastructure.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(" 56765666")]
        [TestCase(" 7777")]
        [TestCase(" 755")]
        [TestCase(" 56765777")]
        [TestCase(" 4657756777")]
        [TestCase(" 456456")]
        [TestCase(" 56455555")]
        [TestCase("456456 ")]
        [TestCase(" 2342342")]
        [TestCase("456456 ")]
        [TestCase(" 456666666")]
        [TestCase(" 234234")]
        [TestCase(" 456456")]
        [TestCase(" 544444")]
        [TestCase(" 234324")]
        [TestCase(" 324234")]
        [TestCase(" 324234")]
        [TestCase(" 3324234444444")]
        [TestCase(" 124314123")]
        [TestCase(" 1412341")]
        [TestCase(" 2141341")]
        [TestCase(" 1221121")]
        [TestCase(" 121212")]
        [TestCase(" 2342242322")]
        [TestCase(" 343434222")]
        [TestCase(" 343433344")]
        [TestCase(" 34343434333")]
        [TestCase(" 33344")]
        [TestCase(" 77773434")]
        [TestCase(" 666555666")]
        [TestCase(" 56565656565")]
        [TestCase(" 56565")]
        [TestCase(" 656")]
        [TestCase(" 665")]
        [TestCase(" 55566")]
        [TestCase(" 5555555555555")]
        [TestCase(" 444444444444444444")]
        [TestCase(" 3333333333333333333")]
        [TestCase(" 22222222222")]
        [TestCase(" 222222222222222222222")]
        [TestCase(" 111111112")]
        [TestCase(" 11111111111111111")]
        [TestCase(" 1111")]
        public void Test1(string name)
        {
            string list = "";
            for (int i = 0; i < 15156; i++)
            {
                var tmp = i + i;
                var tmp2 = (Object)tmp;
                var tmp3 = (int)tmp2;
                list += tmp2.ToString();
            }
            Assert.IsTrue(true);
        }
    }
}
