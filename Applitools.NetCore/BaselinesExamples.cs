using NUnit.Framework;

namespace Applitools
{
    [TestFixture]
    [Category("Examples of different baselines")]
    [Parallelizable]

    public class BaselinesExamples : BaseClass
    {
        [Test]
        public void TestSetBaseline()
        {
            GoToPricingPage();
            UpdateElements();
            Eyes.Open(Driver, "baseline1", TestCaseName);
            Eyes.CheckWindow();
        }

        [Test]
        public void TestSetBaselineDifferentResolution()
        {
            GoToPricingPage();
            Eyes.Open(Driver, "appSample21", TestCaseName, Resolution929x888P);
            Eyes.CheckWindow();
        }
    }
}