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

        public string PageTitle => driver.Title;
        public IWebElement FirstCheckBox => driver.FindElement(By.Name("li1"));
        public IWebElement SecondCheckBox => driver.FindElement(By.Name("li2"));
        public IWebElement Textfield => driver.FindElement(By.Id("sampletodotext"));
        public IWebElement AddButton => driver.FindElement(By.Id("addbutton"));
        public IWebElement Itemtext => driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
        }
    }
}