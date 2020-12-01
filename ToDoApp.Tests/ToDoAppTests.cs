using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Xunit;
using System.Diagnostics;

namespace ToDoApp.Tests
{
    public class ToDoAppTests
    {
        public ToDoAppTests()
        {}

        public static IEnumerable<object[]> GetTestData()
        {
            return new List<object[]>
            {
                new object[]{TestBrowser.Chrome},
                new object[]{TestBrowser.InternetExplorer}
            };
         }

        [Theory]
        [Trait("Category","SmokeTests")]
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
    }
}