namespace Aquaculture.Api.Tests;

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
    [TestCase(" 234")]
    [TestCase(" 123")]
    [TestCase(" 22")]
    [TestCase(" 333")]
    [TestCase(" 11")]
    [TestCase(" ")]
    [TestCase(" a")]
    [TestCase("f ")]
    [TestCase("ff ")]
    [TestCase(" s")]
    public void Test1(string name)
    {
        string list = "";
        for (int i = 0; i < 13156; i++)
        {
            var tmp = i + i;
            var tmp2 = (Object)tmp;
            var tmp3 = (int)tmp2;
            list += tmp2.ToString();
        }
        Assert.IsTrue(true);
    }
}
