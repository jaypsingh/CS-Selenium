
using OpenQA.Selenium;

namespace CSSelenium.PageObjectModels
{
    class SeleniumTutorialPage
    {
        private readonly IWebDriver Driver;

        const string HomeUrl = "https://www.seleniumeasy.com/selenium-tutorials";
        const string PageTitle = "Selenium Tutorials | Selenium Easy";

        public SeleniumTutorialPage(IWebDriver driver)
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
    }
}
