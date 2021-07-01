using System;
using System.Drawing;
using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Applitools
{
    public class BaseClass
    {
        public IWebDriver Driver { get; set; }
        public Eyes Eyes { get; set; }
        public Size Resolution1249x888P => new Size(1249, 888);
        public Size Resolution929x888P => new Size(929, 888);
        public const string AppName = "sample app 1";
        public const string TestCaseName = "TestCase1";
        public By PriceLocator => By.ClassName("et_pb_sum");
        public By SubheaderLocator => By.XPath("//*[@class='et_pb_text_inner']/p");
        public static BatchInfo BatchInfo { get; set; }

        public IWebElement SocialSharingToolbar => Driver.FindElement(
            By.XPath("//*[@class='et_social_sidebar_networks et_social_visible_sidebar " +
                     "et_social_slideright et_social_animated et_social_rectangle et_social_sidebar_flip " +
                     "et_social_sidebar_withcounts et_social_withtotalcount et_social_mobile_on']"));


        public IJavaScriptExecutor Javascript { get; set; }

        public void GoToPricingPage()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/fake-pricing-page/");
        }

        public void UpdateElements()
        {

            var javascript = Driver as IJavaScriptExecutor;

            javascript.ExecuteScript(
                "document.getElementsByClassName('et_pb_sum')[0].innerText = \"€0\";");

            javascript.ExecuteScript(
                "document.getElementsByClassName('et_pb_sum')[1].innerText = \"€80\";");

            javascript.ExecuteScript(
                "document.getElementsByClassName('et_pb_sum')[2].innerText = \"€900\";");
        }

        public void ChangeToEuroAndUpdateColor()
        {
            //Atualiza o primeiro valor $0 para €0
            Javascript.ExecuteScript(
                "document.getElementsByClassName('et_pb_sum')[0].innerText = \"€0\";");

            var element = Driver.FindElement(By.TagName("h1"));
            //Muda a cor do subtítulo para amarelo 
            Javascript.ExecuteScript(
                "arguments[0].setAttribute('style', 'color:#f9ca33!important')", element);
        }

        public void ChangeSocialFloatingPanelPosition()
        {
            Javascript.ExecuteScript(
                "document.getElementsByClassName('swp_social_panelSide swp_floating_panel swp_social_panel swp_boxed swp_default_full_color swp_other_full_color swp_individual_full_color slide swp_float_left swp_side_center scale-100 float-position-center-left')[0].style = \"top: 500.75px; left: 5px\";");
        }

        public void UpdateSubheadingAndCurrency()
        {
            var subheadingElement = Driver.FindElement(SubheaderLocator);

            Javascript.ExecuteScript(
                $"arguments[0].textContent=" +
                $"\"These are the best\"", subheadingElement);

            Javascript.ExecuteScript(
                "document.getElementsByClassName('et_pb_sum')[0].innerText = \"USD 0\";");
        }

        [SetUp]
        public void SetupForEverySingleTestMethod()
        {
            Driver = new ChromeDriver();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Eyes = new Eyes
            {
                ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY",
                    EnvironmentVariableTarget.User)

            };

            Javascript = (IJavaScriptExecutor)Driver;
        }

        [TearDown]
        public void TearDownForEverySingleTestMethod()
        {
            Driver.Quit();
            Eyes.Close();
            Eyes.AbortIfNotClosed();
        }
    }
}