using OpenQA.Selenium;

namespace ToDoApp.Tests
{
    public class ToDoAppPage
    {
        private IWebDriver driver;
        public ToDoAppPage(IWebDriver driver) 
        {           
            this.driver = driver; 
        }

        public string PageTitle
        {
            get
            {
                return driver.Title;
            }
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
        }
    }
}