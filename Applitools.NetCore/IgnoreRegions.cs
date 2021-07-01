using Applitools.Selenium;
using NUnit.Framework;

namespace Applitools
{
    [TestFixture]
    [Category("Ignore Regions")]
    public class IgnoreRegions : BaseClass
    {
        [SetUp]
        public void ExecuteBeforeEveryTest()
        {
            //Will open the fake pricing page
            GoToPricingPage();
            //Will update the subheading text and the currency.
            UpdateSubheadingAndCurrency();
        }

        [Test]
        public void IgnoreRegionUsingBy()
        {
            Eyes.Open(Driver, AppName, "IgnoreRegionUsingBy", Resolution929x888P);
            //Ignoring an element with By
            Eyes.Check("IgnoreRegionUsingBy", Target.Window().Ignore(PriceLocator));
        }

        [Test]
        public void IgnoreRegionUsingFindElements()
        {
            Eyes.Open(Driver, AppName, "IgnoreRegionUsingFindElements", Resolution929x888P);

            //Ignoring with FindElement()
            Eyes.Check("IgnoreRegionUsingFindElements", Target.Window().
                Ignore(Driver.FindElements(PriceLocator)[1]));
        }

        [Test]
        public void IgnoreMultipleElements()
        {
            Eyes.Open(Driver, AppName, "IgnoreMultipleElements", Resolution929x888P);

            //Ignore multiple elements with a single Check()
            Eyes.Check("IgnoreMultipleElements", Target.Window().Ignore(PriceLocator, SubheaderLocator));
        }

        [Test]
        public void StrictRegion()
        {
            Eyes.Open(Driver, AppName, "StrictRegion", Resolution929x888P);

            Eyes.MatchLevel = MatchLevel.Layout;
            //This will add a strict region to all the price options
            Eyes.Check("StrictRegion", Target.Window().Strict(PriceLocator));
        }

        [Test]
        public void ContentRegion()
        {
            Eyes.Open(Driver, AppName, "ContentRegion", Resolution929x888P);

            //This will add a content region to all the price options
            Eyes.Check("ContentRegion", Target.Window().Content(PriceLocator));
        }
    }
}