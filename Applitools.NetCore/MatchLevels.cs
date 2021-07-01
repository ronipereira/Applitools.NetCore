using NUnit.Framework;

namespace Applitools
{
    [TestFixture]
    [Category("MatchLevels")]
    public class MatchLevels : BaseClass
    {
        [Test]
        public void StrictMatchLevel()
        {
            Eyes.MatchLevel = MatchLevel.Strict;
            GoToPricingPage();
            ChangeToEuroAndUpdateColor();
            Eyes.Open(Driver, AppName, TestCaseName, Resolution1249x888P);
            Eyes.CheckWindow("MatchLevel.Strict");
        }

        [Test]
        public void ContentMatchLevel()
        {
            Eyes.MatchLevel = MatchLevel.Content;
            GoToPricingPage();
            //ChangeToEuroAndUpdateColor();
            Eyes.Open(Driver, AppName, TestCaseName, Resolution1249x888P);
            Eyes.CheckWindow("MatchLevel.Content");
        }

        [Test]
        public void LayoutMatchLevel()
        {
            Eyes.MatchLevel = MatchLevel.Layout;
            GoToPricingPage();
            ChangeToEuroAndUpdateColor();
            Eyes.Open(Driver, AppName, TestCaseName, Resolution1249x888P);
            Eyes.CheckWindow("MatchLevel.Layout");
        }

    }
}