using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumAutomationPractice
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test,Order(1)]
        public void OpenPracticeForm()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            // Wait until first name label is visible - confirms form is loaded
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'First Name')]")));

            Assert.Pass("Page loaded successfully");
        }

        [Test,Order(2)]
        public void EnterFirstNameField()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'First Name')]")));

            var firstNameInput = driver.FindElement(By.XPath("//label[contains(text(),'First Name')]/following::input[1]"));

            Thread.Sleep(1000);
            string name = "Ritwik";
            firstNameInput.SendKeys(name);
            Thread.Sleep(2000);

            Assert.That(firstNameInput.GetAttribute("value"), Is.EqualTo(name));
        }

        [Test,Order(3)]
public void SelectGender()
{
    driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'Gender')]")));

    // Click input using ID (completely stable and reliable)
    var maleRadio = driver.FindElement(By.XPath("//input[@id='male']"));

    Thread.Sleep(1000);
    maleRadio.Click();  // click the actual input directly
    Thread.Sleep(2000);

    Assert.That(maleRadio.Selected, Is.True);
}

        [Test , Order(4)]
        public void SelectHobbyReading()
{
    driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'Hobbies')]")));

    // Locate the checkbox using its ID
    var readingCheckbox = driver.FindElement(By.XPath("//input[@id='Reading']"));

    Thread.Sleep(1000);
    readingCheckbox.Click(); // select Reading hobby
    Thread.Sleep(2000);

    Assert.That(readingCheckbox.Selected, Is.True); // verify selection
}
        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
