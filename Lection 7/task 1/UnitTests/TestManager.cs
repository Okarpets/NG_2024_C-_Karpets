using UnitTests.DataLayerTests;

namespace UnitTests
{
    public static class TestManager
    {
        public static void Main(string[] args)
        {
            DataSeederTests test = new DataSeederTests();
            test.TestSeed();
        }
    }
}
