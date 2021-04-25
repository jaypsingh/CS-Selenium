using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace CSSelenium
{
    public class BrowserManipulation
    {
        // below are the links that are used in the demonstrations.
        const string HomeUrl = "https://www.seleniumeasy.com/test/";
        const string NewWindowURL = "https://the-internet.herokuapp.com/windows";
        const string AlertURL = "https://the-internet.herokuapp.com/javascript_alerts";
        const string BasicCalculatorURL = "https://testsheepnz.github.io/BasicCalculator.html";

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

        /// <summary>
        /// This method demonstrates the below concepts to
        /// - Get and Save screenshot of a page
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void GetScreenShot()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);

                //Act
                // Create the screenshot driver
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;

                // Take the screenshot file
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Save the screenshot file to disk
                screenshot.SaveAsFile("screenshotFile.png", ScreenshotImageFormat.Png);

                //Assert               
            }
        }


        /// <summary>
        /// This method demonstrates another way of interacting with web page.
        /// Basically we can also use actions to interact with web page. 
        /// This page demonstrates Actions and how it can be used.
        /// - Actions
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void IntractWithIWebElementUsingActions()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(BasicCalculatorURL);

                //Act                
                driver.FindElement(By.Id("number1Field")).SendKeys("10");
                driver.FindElement(By.Id("number2Field")).SendKeys("9");

                // Below are the steps to use Actions
                // Find the web element
                IWebElement CalculateButton = driver.FindElement(By.Id("calculateButton"));

                // Create an Action constructor by passing the driver to it
                Actions actions = new Actions(driver);

                // Move to the iWebElement
                actions.MoveToElement(CalculateButton);
                // Perform Click by .click() followed by .Perform() opertaions.
                actions.Click();
                actions.Perform();

               
                //Assert               
            }
        }

    }
}
