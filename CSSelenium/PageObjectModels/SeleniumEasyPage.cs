

using OpenQA.Selenium;
using Xunit.Sdk;

namespace CSSelenium.PageObjectModels
{
    class SeleniumEasyPage
    {
        private readonly IWebDriver Driver;
        
        const string HomeUrl = "https://www.seleniumeasy.com/test/";
        const string PageTitle = "Selenium Easy - Best Demo website to practice Selenium Webdriver Online";

        public SeleniumEasyPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string URL
        {
            get { return Driver.Url; }
        }

        public string Title
        {
            get { return Driver.Title; }
        }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            isPageLoaded();
        }

        public void isPageLoaded()
        {
            bool isPageLoaded = ((Driver.Url == HomeUrl) && (Driver.Title == PageTitle));
            if (!isPageLoaded)
            {
                throw new System.Exception($"Failed to load the page {Driver.Url}");
            }
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void GoBackOnPage()
        {
            Driver.Navigate().Back();
            Driver.Navigate().Forward();
        }

        public void GoForwardOnPage()
        {
            Driver.Navigate().Forward();
        }

        public SeleniumTutorialPage ClickSeleniumTutorialLink()
        {
            Driver.FindElement(By.LinkText("Selenium Tutorials")).Click();
            return new SeleniumTutorialPage(Driver);
        }

    }
}
