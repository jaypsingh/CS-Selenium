using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace CSSelenium
{
    public class BrowserManipulation
    {
        // below are the links that are used in the demonstrations.
        const string HomeUrl = "https://www.seleniumeasy.com/test/";
        const string NewWindowURL = "https://the-internet.herokuapp.com/windows";
        const string AlertURL = "https://the-internet.herokuapp.com/javascript_alerts";

        /// <summary>
        /// This method demonstrates the below concepts to
        /// - Maximize the window
        /// - Minimize the window
        /// - Set Window size
        /// - Set Window position
        /// - Make window fullscreen
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ManageBrowerWindow()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);

                //Act
                // Maximize the chrome window.
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();

                //Minimize the chrome window.
                driver.Manage().Window.Minimize();
                DemoHelper.Pause();

                //Set size of chrome window
                driver.Manage().Window.Size = new System.Drawing.Size(300, 400);
                DemoHelper.Pause();

                driver.Manage().Window.Position = new System.Drawing.Point(1, 1);
                DemoHelper.Pause();

                driver.Manage().Window.Position = new System.Drawing.Point(100, 100);
                DemoHelper.Pause();

                driver.Manage().Window.Position = new System.Drawing.Point(200, 200);
                DemoHelper.Pause();

                driver.Manage().Window.FullScreen();

                //Assert
            }                
        }

        /// <summary>
        /// This method demonstrates the below concepts to
        /// - Get handles of all open tabs
        /// - switch between tabs
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ManageNewWindow()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(NewWindowURL);

                //Act
                driver.FindElement(By.PartialLinkText("Click Here")).Click();
                
                // Getting all window handles
                ReadOnlyCollection<string> allTabs = driver.WindowHandles;

                // getting the handle of all tabs
                string homeTab = allTabs[0];
                string newTab = allTabs[1];

                // Switing the driver to newTab
                driver.SwitchTo().Window(newTab);

                //Assert
                Assert.Equal("New Window", driver.Title);
            }
        }


        /// <summary>
        /// This method demonstrates the below concepts to
        /// - manage an alert box (get it's handle)
        /// - extract text of alert box.
        /// - accept the alert box
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ManageSimpleAlerts()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(AlertURL);

                //Act
                driver.FindElement(By.CssSelector("[onclick='jsAlert()']")).Click();
                IAlert alertHandle = driver.SwitchTo().Alert();
                
                //Assert
                // See how we can access to the text of alert box.
                Assert.Equal("I am a JS Alert", alertHandle.Text);

                DemoHelper.Pause(5000);

                // this demonstrates how we cacn accept the alert box.
                alertHandle.Accept();
            }

        }

    }
}
