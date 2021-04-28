using OpenQA.Selenium;


namespace CSSelenium.PageObjectModels
{
    
    class SampleAppPage
    {

        private readonly IWebDriver Driver;

        const string HomeUrl = "http://uitestingplayground.com/sampleapp";
        const string PageTitle = "Selenium Easy - Best Demo website to practice Selenium Webdriver Online";

        public SampleAppPage(IWebDriver driver)
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
