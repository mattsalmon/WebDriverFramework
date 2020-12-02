using System;
using System.Collections.Generic;
using Xunit;

namespace ToDoApp.Tests
{
    public class ToDoAppTests
    {
        public ToDoAppTests()
        { }

        public static IEnumerable<object[]> GetTestData()
        {
            return new List<object[]>
            {
                new object[]{TestBrowser.Chrome},
                new object[]{TestBrowser.InternetExplorer}
            };
        }

        [Theory]
        [Trait("Category", "SmokeTests")]
        [MemberData(nameof(GetTestData))]
        public void VerifyPageTitle(TestBrowser browser)
        {
            var testConfiguration = new TestConfiguration(browser);
            var driver = testConfiguration.GetDriver();
            var page = new ToDoAppPage(driver);
            driver.Manage().Window.Maximize();
            page.GoToPage();
            Assert.Equal("Sample page - lambdatest.com", page.PageTitle);
            driver.Quit();
        }

        [Theory]
        [Trait("Category", "SmokeTests")]
        [MemberData(nameof(GetTestData))]
        public void AddAndVerifyToDoItem(TestBrowser browser)
        {
            var testConfiguration = new TestConfiguration(browser);
            var driver = testConfiguration.GetDriver();
            var page = new ToDoAppPage(driver);
            driver.Manage().Window.Maximize();
            page.GoToPage();

            String itemName = "Yey, Let's add it to list";

            // Click on First Check box
            page.FirstCheckBox.Click();

            // Click on Second Check box
            page.SecondCheckBox.Click();

            // Enter Item name 
            page.Textfield.SendKeys(itemName);

            // Click on Add button
            page.AddButton.Click();

            // Verified Added Item name
            Assert.True(itemName.Contains(page.Itemtext.Text));

            driver.Quit();
        }
    }
}