

using OpenQA.Selenium;

namespace CSSelenium.PageObjectModels
{
    class SeleniumEasyPage
    {
        private readonly IWebDriver Driver;

        public SeleniumEasyPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string PageURL
        {
            get { return Driver.Url; }
        }

        public string PageTitle
        {
            get { return Driver.Title; }
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

    }
}
