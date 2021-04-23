using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSSelenium
{
    public class FillFormElement
    {
        // below are the links that are used in the demonstrations.
        const string HomeURL = "https://www.saucedemo.com/";
        const string TextURL = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        const string RadioButtonURL = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
        const string DropDownURL = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        const string CheckBoxURL = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";


        /// <summary>
        /// This method demonstrates how we can login to an application by filling the username and password.
        /// This demonstrates the below concepts
        /// - filling data in text field.
        /// - clicking login button
        /// </summary>
        [Fact]
        [Trait("Category", "smoke")]
        public void Login()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(HomeURL);

                //Act
                // Note the diffrent approches we can take to enter a text field. 
                // either we can take the value in a variable and use send keys command.
                IWebElement userName = driver.FindElement(By.Id("user-name"));
                userName.SendKeys("standard_user");

                // or we can use send keys command firectly with driver.FindElement()
                driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
                driver.FindElement(By.Id("login-button")).Click();

                //Assert
                Assert.Equal("Swag Labs", driver.Title);
                Assert.Equal("https://www.saucedemo.com/inventory.html", driver.Url);
            }
        }



        /// <summary>
        /// This method demonstrates how we can 
        /// - filling data in text field.
        /// </summary>
        [Fact]
        [Trait("Category", "smoke")]
        public void EnterMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange                
                driver.Navigate().GoToUrl(TextURL);
                var expectedText = "Danzer Zone";

                //Act

                // below is the step to fill in the text box.
                driver.FindElement(By.Id("user-message")).SendKeys("Danzer Zone");

                // This step is to click ShowText button and retrieve the text for assertion
                driver.FindElement(By.CssSelector("[onclick='showInput();']")).Click();
                IWebElement messageElement = driver.FindElement(By.Id("display"));               

                DemoHelper.Pause(5000);

                //Assert
                Assert.Equal(expectedText, messageElement.Text);
            }
        }

        /// <summary>
        /// This method also demonstrates how we can 
        /// - filling data in text field.
        /// </summary>
        [Fact]
        [Trait("Category", "smoke")]
        public void EnterNumbersToGetTotal()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(TextURL);
                var expectedText = "19";

                //Act

                // below is the step to fill in the text box.
                driver.FindElement(By.Id("sum1")).SendKeys("10");
                driver.FindElement(By.Id("sum2")).SendKeys("9");

                // This step is to click Get Total button and retrieve the text for assertion
                driver.FindElement(By.CssSelector("[onclick='return total()']")).Click();
                IWebElement sumElement = driver.FindElement(By.Id("displayvalue"));

                DemoHelper.Pause(5000);

                //Assert
                Assert.Equal(expectedText, sumElement.Text);
            }
        }

        /// <summary>
        /// This method demonstrates how we can 
        /// - Select A Radio Button.
        /// </summary>
        [Fact]
        [Trait("Category", "smoke")]
        public void SelectRadioButton()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(RadioButtonURL);
                
                var expectedMaleText = "Radio button 'Male' is checked";
                var expectedFemaleText = "Radio button 'Female' is checked";

                //Act

                // below is the step to select the Radio Button
                driver.FindElement(By.CssSelector("[value='Male']")).Click();

                // This step is to click Get Checked Value button and retrieve the text for assertion
                driver.FindElement(By.Id("buttoncheck")).Click();
                IWebElement selectedMaleRadioButton = driver.FindElement(By.ClassName("radiobutton"));
                var actualMaleText = selectedMaleRadioButton.Text;                

                // below is the step to select the Radio Button
                driver.FindElement(By.CssSelector("[value='Female']")).Click();

                // This step is to click Get Checked Value button and retrieve the text for assertion
                driver.FindElement(By.Id("buttoncheck")).Click();
                IWebElement selectedFemaleRadioButton = driver.FindElement(By.ClassName("radiobutton"));
                var actualFemaleText = selectedFemaleRadioButton.Text;                

                //Assert
                Assert.Equal(expectedMaleText, actualMaleText);
                Assert.Equal(expectedFemaleText, actualFemaleText);
            }
        }


        /// <summary>
        /// This method demonstrates how we can 
        /// - Select A Check Box
        /// </summary>
        [Fact]
        [Trait("Category", "smoke")]
        public void SelectCheckBox()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(CheckBoxURL);

                //Act
                // below is the step to select the Checkbox Button
                driver.FindElement(By.Id("isAgeSelected")).Click();

                driver.FindElements(By.ClassName("cb1-element"))[0].Click();
                
                driver.FindElements(By.ClassName("cb1-element"))[1].Click();
                
                driver.FindElements(By.ClassName("cb1-element"))[2].Click();
                
                driver.FindElements(By.ClassName("cb1-element"))[3].Click();
                DemoHelper.Pause(2000);

                //Assert
            }
        }

        /// <summary>
        /// This method demonstrates how we can 
        /// - Select an item from dropdown list
        /// </summary>
        [Fact]
        [Trait("Category", "smoke")]
        public void SelectFromDropdown()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //Arrange
                driver.Navigate().GoToUrl(DropDownURL);

                //Act
                // below is the step to select from dropdown.
                IWebElement dayList = driver.FindElement(By.Id("select-demo"));
                SelectElement listElement = new SelectElement(dayList);

                //Assert
                //Check default selected Option
                Assert.Equal("Please select", listElement.SelectedOption.Text);
                Assert.Equal(8, listElement.Options.Count);

                // Select an optiom in the list by Value
                listElement.SelectByValue("Sunday");
                Assert.Equal("Sunday", listElement.SelectedOption.Text);

                // Select an optiom in the list by Text
                listElement.SelectByText("Monday");
                Assert.Equal("Monday", listElement.SelectedOption.Text);

                // Select an optiom in the list by Index (0 based)
                listElement.SelectByIndex(3);
                Assert.Equal("Tuesday", listElement.SelectedOption.Text);
            }
        }

    }
}
