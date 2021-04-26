# Selenium with C# Introduction

This is the basic architecture of CS and Selenium test:

![Architecture Diagram](/images/Architecture.PNG)

This class contains multiple tests to demonstrate diffrent test scenarios.
The tests demontrates how some we can use selenium webdriver and C# (with XUnit) to perform web application testing.
Please note that you can do the same thing with NUnit or MSTest or anyy other test framework. 
We are perfoming tests on some of the open websites declared as constants in the class.
You can grab the concept to test on the website of your choice.

* We are using the below versions for this demo
	* Selenium Webdriver: 3.141.0
	* Chrome Driver: 90.0
	* Chrome: 90.0
	* XUnit: 2.4.1


Below are list of methods and description on the uses of these methods.

## **Selenium Basic Functions**

### 1. LoadAppPage():
This method demonstrates the below concepts
- Opening Chrome
- Loading a webpage
- Verifying the page title 
- Verifying the page url

### 2. RefreshAppPage()
This method demonstrates how we can refresh the webpage using selenium webdriver.
Below concepts are demonstrated in this method:
- Refresh the web page

### 3. GoBackOnAppPage()
This method demonstrates how we can go back on the webpage using selenium webdriver.
Below concepts are demonstrated in this method:
- Going back on the web page

### 4. GoForwardOnAppPage()
This method demonstrates how we can go forward on the webpage using selenium webdriver.
Below concepts are demonstrated in this method:
- Going forward on the web page

### 5. FindElementByID()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding the element by ID

### 6. ClickOnElementByID()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding the element by ID and click on it. 

### 7. ClickOnElementByLinkText()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding the element by Link Text

### 8. ClickOnElementByCSSSelector()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding the element by CSS Selector

### 9. GetMultipleElementByCSSSelector()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding multiple elements by CSS Selector by providing the path of CSS Selector

### 10. ClickOnElementByClass()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding the element by it's class

### 11. FindElementByTag()
This method demonstrates one of the many ways of locating a web element. Also see FindElementsByTag() method that is used to find multiple elements of same tag.
Below concepts are demonstrated in this method:
- Finding the element by it's Tag

### 12. FindElementByFullXPath()
This method demonstrates one of the many ways of locating a web element.
Note that XPath is not the best way to locat eelement this will break easily if the XPath changes.
Below concepts are demonstrated in this method:
- Finding the element by it's full XPath (Absolute XPath)

### 13. FindElementByRelativeXPath()
This method demonstrates one of the many ways of locating a web element.
Note that XPath is not the best way to locat eelement this will break easily if the XPath changes.
Below concepts are demonstrated in this method:
- Finding the element by it's relative XPath

### 14. WaitTillUsingLambdaFunction()
This method demos how we can wait for an element to be available before we perform any action on it.
This is a good practice for elements that might not be available on the screen instantly as soon as the page loads.
Using this we can avoid using hardoded wait times.
Below concepts are demonstrated here:
- Using Explicit Wait

### 15. WaitTillUsingPreBuiltFunction()
This method demos how we can wait for an element to be available before we perform any action on it.
This in continution of above WaitTill() funtion. 
In this case instead of using a lambda method call we will use a pre-built funtion.
We need to install selenium. support from the nuget packages to make use of this pr-built function.
Using this we can avoid using hardoded wait times.
Below concepts are demonstrated here:
- Using Explicit Wait

### 16. WaitTillUsingImplicitWiat()
This method demos how we can use implicit wait to wait for an element to be available before we perform any action on it.
This is more for demonstration and AVOID USING IT.
Also NOTE that you cannot use implicit wait and explicit wait together. 
This also demontrate how we can write additional outputs for debugging.
Below concepts are demonstrated here:
- Using implicit Wait
- Writing additional outputs

### 17. FindElementsByTag()
This method demonstrates one of the many ways of locating a web element.
Also see FindElementByTag() method that is used to find the first elements that is found of the given tag.
Below concepts are demonstrated in this method:
- Finding multiple elements by it's Tag

### 18. FindElementsByPartialLinkText()
This method demonstrates one of the many ways of locating a web element.
Below concepts are demonstrated in this method:
- Finding an element by partial link text

## **Fill and Submitt HTML Form**

### 19. Login()
This method demonstrates how we can login to an application by filling the username and password.
This demonstrates the below concepts
- filling data in text field.
- clicking login button

### 20. EnterMessage()
This method demonstrates how we can 
- filling data in text field.

### 21. EnterNumbersToGetTotal()
This method also demonstrates how we can 
- filling data in text field.

### 22. SelectRadioButton()
This method demonstrates how we can 
- Select A Radio Button.

### 23. SelectCheckBox() 
This method demonstrates how we can 
- Select A Check Box

### 24. SelectFromDropdown()
This method demonstrates how we can 
- Select an item from dropdown list

### 25. SubmitForm()
This method demonstrates how we can submit form by
- .Submit() method
- .Click method


## **Browser Manipulation**

### 26. ManageBrowerWindow()
This method demonstrates the below concepts to
- Maximize the window
- Minimize the window
- Set Window size
- Set Window position
- Make window fullscreen

### 27. ManageNewWindow()
This method demonstrates the below concepts to
- Get handles of all open tabs
- switch between tabs

### 28. ManageSimpleAlerts()
This method demonstrates the below concepts to
- manage an alert box (get it's handle)
- extract text of alert box.
- accept the alert box


### 29. GetScreenShot()
This method demonstrates the below concepts to
- Get and Save screenshot of a page

### 30. IntractWithIWebElementUsingActions()
This method demonstrates another way of interacting with web page.
Basically we can also use actions to interact with web page. 
This page demonstrates Actions and how it can be used.
- Actions



## **Page Object Model**

### 32. POMLoadAppPage()
This method is used to demonstrate the use of **page object model**.
This shows how using page oject model we can do the following:
- Opening Chrome
- Loading a webpage
- Verifying the page title 
- Verifying the page url

### 32. POMRefreshAppPage()
This method is used to demonstrate the use of **page object model**.
This shows how using page oject model we can do the following:
- Refresh the web page

### 33. GoForwardOnAppPage()
This method is used to demonstrate the use of **page object model**.
This shows how using page oject model we can do the following:
- Going back on the page
- Going forward on the web page
