using OpenQA.Selenium;
using OpenQA.Selenium.Edge; 
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTestProj
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver Driver;

        [TestInitialize]
        public void Setup()
        {
            var driverPath = @"C:\webDrivers"; 
            Driver = new EdgeDriver(driverPath);
        }

        [TestMethod]
        public void TestCalendarPopupVisibility()
        {
            Driver.Navigate().GoToUrl("file:///C:/Users/AMejd/source/repos/3SemProj/3semEx/index.html");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            var calendarButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("calendarbutton")));
            calendarButton.Click();

            var calendarPopup = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".calendar-popup.active")));
            Assert.IsTrue(calendarPopup.Displayed, "Kalender-popup vises ikke!");
        }

        [TestMethod]
        public void TestGetAllTeachers()
        {
            Driver.Navigate().GoToUrl("file:///C:/Users/AMejd/source/repos/3SemProj/3semEx/index.html");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            var teacherList = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("teacherlist")));
            Assert.IsTrue(teacherList.Displayed, "Lærerlisten vises ikke!");
        }

        [TestMethod]
        public void TestAddTeacher()
        {
            Driver.Navigate().GoToUrl("file:///C:/Users/AMejd/source/repos/3SemProj/3semEx/index.html");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var nameInput = Driver.FindElement(By.Id("nameinput"));
            var salaryInput = Driver.FindElement(By.Id("salaryinput"));
            var addButton = Driver.FindElement(By.Id("AddTeacherButton"));

            nameInput.SendKeys("John Doe");
            salaryInput.SendKeys("50000");
            addButton.Click();

            var teacherList = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("teacherlist")));

            Assert.IsTrue(teacherList.Text.Contains("John Doe"), "Læreren blev ikke tilføjet korrekt!");
        }

        [TestMethod]
        public void TestUpdateTeacher()
        {
            Driver.Navigate().GoToUrl("file:///C:/Users/AMejd/source/repos/3SemProj/3semEx/index.html");

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            var idInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("idInput")));
            var nameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nameInput")));
            var salaryInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("salaryInput")));
            var updateButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("updateTeacherButton")));

            idInput.SendKeys("6");
            nameInput.SendKeys("Anders Larsen");
            salaryInput.SendKeys("60000");

            updateButton.Click();
            //WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));
           // Thread.Sleep(1000);

            var teacherList = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("teacherlist")));
            Assert.IsTrue(teacherList.Text.Contains("Anders Larsen"), "Læreren blev ikke opdateret korrekt!");
        }



        [TestCleanup]
        public void TearDown()
        {
            //Driver.Quit();
        }
    }
}