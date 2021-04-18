using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;
using System.Collections.ObjectModel;

namespace CSSelenium
{
    /// <summary>
    /// This class contains multiple tests to demonstrate diffrent test scenarios.
    /// The tests demontrates how some we can use selenium webdriver and C# (with XUnit) to perform web application testing.
    /// Please note that you can do the same thing with NUnit or MSTest or anyy other test framework. 
    /// We are perfoming tests on some of the open websites declared as constants in the class.
    /// You can grab the concept to test on the website of your choice.
    /// 
    /// We are using the below versions for this demo
    /// Selenium Webdriver: 3.141.0
    /// Chrome Driver: 90.0
    /// Chrome: 90.0
    /// XUnit: 2.4.1
    /// </summary>
    public class CSSeleniumDemo
    {
        // below are the links that are used in the demonstrations.
        const string HomeUrl = "https://www.seleniumeasy.com/test/";
        const string sampleAppUrl= "http://uitestingplayground.com/sampleapp";
        const string uiTestPlayUrl = "http://uitestingplayground.com/";
        const string automationPracticeUrl = "http://automationpractice.com/index.php";
        const string basicCalculatorUrl = "https://testsheepnz.github.io/BasicCalculator.html";
        const string progressBarUrl = "http://uitestingplayground.com/progressbar";
        const string PageTitle = "Selenium Easy - Best Demo website to practice Selenium Webdriver Online";

        // This is set to write additional outputs to debug the tests.
        private readonly ITestOutputHelper output;

        /// <summary>
        /// This method demonstrates the below concepts
        /// - Opening Chrome
        /// - Loading a webpage
        /// - Verifying the page title 
        /// - Verifying the page url
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);

                //Act
                

                //Assert
                Assert.Equal(PageTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        /// <summary>
        /// This method demonstrates how we can refresh the webpage using selenium webdriver.
        /// Below concepts are demonstrated in this method:
        /// - Refresh the web page
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void RefreshAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);

                //Act
                driver.Navigate().Refresh();


                //Assert
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        /// <summary>
        /// This method demonstrates how we can go back on the webpage using selenium webdriver.
        /// Below concepts are demonstrated in this method:
        /// - Going back on the web page
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void GoBackOnAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeUrl);
                driver.Navigate().GoToUrl(sampleAppUrl);

                //Act
                driver.Navigate().Back();

                //Assert
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        /// <summary>
        /// This method demonstrates how we can go forward on the webpage using selenium webdriver.
        /// Below concepts are demonstrated in this method:
        /// - Going forward on the web page
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void GoForwardOnAppPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(sampleAppUrl);
                driver.Navigate().GoToUrl(HomeUrl);                

                //Act
                driver.Navigate().Back();
                driver.Navigate().Forward();

                //Assert
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by ID
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void FindElementByID()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(sampleAppUrl);
                
                var expectedElementText = "Log In";

                //Act
                IWebElement webElement = driver.FindElement(By.Id("login"));
                var actualElemntText = webElement.Text;

                //Assert
                Assert.Equal(expectedElementText, actualElemntText);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by ID and click on it. 
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickOnElementByID()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(sampleAppUrl);

                var expectedElementText = "Invalid username/password";

                //Act
                IWebElement loginButton = driver.FindElement(By.Id("login"));
                loginButton.Click();

                IWebElement loginStatusMessage = driver.FindElement(By.Id("loginstatus"));
                var actualElement = loginStatusMessage.Text;

                //Assert
                Assert.Equal(expectedElementText, actualElement);
            }
        }


        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by Link Text
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickOnElementByLinkText()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(uiTestPlayUrl);
                var expectedPageTitle = "Dynamic ID";

                //Act
                IWebElement linkText = driver.FindElement(By.LinkText("Dynamic ID"));
                linkText.Click();

                var actualPageTitle = driver.Title;

                //Assert
                Assert.Equal(expectedPageTitle, actualPageTitle);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by CSS Selector
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickOnElementByCSSSelector()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(automationPracticeUrl);
                var expectedPageTitle = "Order - My Store";

                //Act
                IWebElement shoppingCartLink = driver.FindElement(By.CssSelector("[title='View my shopping cart']"));
                DemoHelper.Pause(1000);
                shoppingCartLink.Click();                

                var actualPageTitle = driver.Title;

                //Assert
                Assert.Equal(expectedPageTitle, actualPageTitle);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by it's class
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void ClickOnElementByClass()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(uiTestPlayUrl);
                string expectedTitle = "UI Test Automation Playground";

                //Act
                // Note that class name should not contain space else this will not work.
                IWebElement branLink = driver.FindElement(By.ClassName("navbar-brand"));
                DemoHelper.Pause(1000);
                branLink.Click();

                var actualPageTitle = driver.Title;

                //Assert
                Assert.Equal(expectedTitle, actualPageTitle);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Also see FindElementsByTag() method that is used to find multiple elements of same tag.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by it's Tag
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void FindElementByTag()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(basicCalculatorUrl);
                string expectedLabelText = "Build";

                //Act
                // Note that class if multiple tags are present on the page this will return the first tag found.
                IWebElement labelElement = driver.FindElement(By.TagName("label"));
                var actualLabelText = labelElement.Text;                

                //Assert
                Assert.Equal(expectedLabelText, actualLabelText);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Note that XPath is not the best way to locat eelement this will break easily if the XPath changes.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by it's full XPath
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void FindElementByFullXPath()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(basicCalculatorUrl);
                string expectedLabelText = "Calculate";

                //Act
                // Note that class if multiple tags are present on the page this will return the first tag found.
                IWebElement labelElement = driver.FindElement(By.XPath("/html/body/section/div/div/div/form[2]/h2"));
                var actualLabelText = labelElement.Text;

                //Assert
                Assert.Equal(expectedLabelText, actualLabelText);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Note that XPath is not the best way to locat eelement this will break easily if the XPath changes.
        /// Below concepts are demonstrated in this method:
        /// - Finding the element by it's relative XPath
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void FindElementByRelativeXPath()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(basicCalculatorUrl);
                string expectedLabelText = "Calculate";

                //Act
                // Note that class if multiple tags are present on the page this will return the first tag found.
                IWebElement labelElement = driver.FindElement(By.XPath("//*[@id='calcForm']/h2"));
                var actualLabelText = labelElement.Text;

                //Assert
                Assert.Equal(expectedLabelText, actualLabelText);
            }
        }

        /// <summary>
        /// This method demos how we can wait for an element to be available before we perform any action on it.
        /// This is a good practice for elements that might not be available on the screen instantly as soon as the page loads.
        /// Using this we can avoid using hardoded wait times.
        /// Below concepts are demonstrated here:
        /// - Using Explicit Wait
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void WaitTillUsingLambdaFunction()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(progressBarUrl);
                var expectedProgressStatus = "100%";

                //Act                
                IWebElement startProgress = driver.FindElement(By.Id("startButton"));
                startProgress.Click();               

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement progessStatus = wait.Until((d) => d.FindElement(By.CssSelector("[aria-valuenow='100']")));

                var actualProgressStatus = progessStatus.Text;               

                //Assert
                Assert.Equal(expectedProgressStatus, actualProgressStatus);
            }
        }


        /// <summary>
        /// This method demos how we can wait for an element to be available before we perform any action on it.
        /// This in continution of above WaitTill() funtion. 
        /// In this case instead of using a lambda method call we will use a pre-built funtion.
        /// We need to install selenium. support from the nuget packages to make use of this pr-built function.
        /// Using this we can avoid using hardoded wait times.
        /// Below concepts are demonstrated here:
        /// - Using Explicit Wait
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void WaitTillUsingPreBuiltFunction()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(progressBarUrl);
                var expectedProgressStatus = "100%";

                //Act                
                IWebElement startProgress = driver.FindElement(By.Id("startButton"));
                startProgress.Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement progessStatus = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[aria-valuenow='100']")));

                var actualProgressStatus = progessStatus.Text;

                //Assert
                Assert.Equal(expectedProgressStatus, actualProgressStatus);
            }
        }

        /// <summary>
        /// This method demos how we can use implicit wait to wait for an element to be available before we perform any action on it.
        /// This is more for demonstration and AVOID USING IT.
        /// Also NOTE that you cannot use implicit wait and explicit wait together. 
        /// This also demontrate how we can write additional outputs for debugging.
        /// Below concepts are demonstrated here:
        /// - Using implicit Wait
        /// - Writing additional outputs
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void WaitTillUsingImplicitWiat()
        {
            using (IWebDriver driver = new ChromeDriver())            {

                //Arrange      
                // Writing additional output
                output.WriteLine("We are writing additional output to the test using ITestOutputHelper output");
                // Setting implicit wait
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl(progressBarUrl);
                var expectedProgressStatus = "100%";

                //Act                
                IWebElement startProgress = driver.FindElement(By.Id("startButton"));
                startProgress.Click();
                
                IWebElement progessStatus = driver.FindElement(By.CssSelector("[aria-valuenow='100']"));

                var actualProgressStatus = progessStatus.Text;

                //Assert
                Assert.Equal(expectedProgressStatus, actualProgressStatus);
            }
        }

        /// <summary>
        /// This method demonstrates one of the many ways of locating a web element.
        /// Below concepts are demonstrated in this method:
        /// - Finding multiple elements by it's Tag
        /// </summary>
        [Fact]
        [Trait("Category", "Smoke")]
        public void FindElementsByTag()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(basicCalculatorUrl);
                string expectedBuildText = "Build";
                string expectedFirstNumber = "First number";

                //Act
                // Note that driver.FindElements return all the tags found on the page as ReadOnlyCollection<IWebElement>.
                ReadOnlyCollection<IWebElement> labelElements = driver.FindElements(By.TagName("label"));
                var actualBuildText = labelElements[0].Text;
                var actualFirstNumber = labelElements[2].Text;

                //Assert
                Assert.Equal(expectedBuildText, actualBuildText);
                Assert.Equal(expectedFirstNumber, actualFirstNumber);
            }
        }
    }
}
