using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace ToDoApp.Tests
{
    public class TestConfiguration
    {
        private const string remoteUserName = "your.username";
        private const string remoteAccessKey = "your.accesskey";
        private string remoteTestUrl = $"https://{remoteUserName}:{remoteAccessKey}@hub.lambdatest.com/wd/hub";
        private const bool isRemoteTestingSession = true;
        private IWebDriver driver;
        public TestConfiguration(TestBrowser browser)
        {
            switch (browser)
            {
                case TestBrowser.Chrome:
                    driver = GetChromeDriver();
                    break;
                case TestBrowser.InternetExplorer:
                    driver = GetIEDriver();
                    break;
            }
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
        private IWebDriver GetChromeDriver()
        {
            var chromeOptions = GetChromeDriverOptions();

            if (isRemoteTestingSession)
                return new RemoteWebDriver(new Uri(remoteTestUrl),
                    chromeOptions.ToCapabilities(),
                    TimeSpan.FromSeconds(600));
            else
                return new ChromeDriver(chromeOptions);
        }
        private ChromeOptions GetChromeDriverOptions()
        {
            var chromeOptions = new ChromeOptions();
            if (isRemoteTestingSession)
            {
                chromeOptions.AddAdditionalCapability("user", remoteUserName, true);
                chromeOptions.AddAdditionalCapability("accessKey", remoteAccessKey, true);
                chromeOptions.AddAdditionalCapability("name", "CSharpTestSample", true);
                chromeOptions.AddAdditionalCapability("build", "LambdaTestSampleApp", true);
                chromeOptions.AddAdditionalCapability("version", "86", true);
                chromeOptions.AddAdditionalCapability("platform", "Windows 10", true);
                chromeOptions.AddAdditionalCapability("network", true, true); // To enable network logs
                chromeOptions.AddAdditionalCapability("visual", true, true); // To enable step by step screenshot
                chromeOptions.AddAdditionalCapability("video", true, true); // To enable video recording
                chromeOptions.AddAdditionalCapability("console", true, true); // To capture console logs
                // Add other options for remote testing here
            }
            else
            {
                chromeOptions.BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
                // Add other options for local testing here
            }
            return chromeOptions;
        }

        private IWebDriver GetIEDriver()
        {
            var internetExplorerOptions = GetIEOptions();
            if (isRemoteTestingSession)
                return new RemoteWebDriver(new Uri(remoteTestUrl),
                internetExplorerOptions.ToCapabilities(),
                TimeSpan.FromSeconds(600));
            else
                return new InternetExplorerDriver(internetExplorerOptions);
        }
        private InternetExplorerOptions GetIEOptions()
        {
            var ieOptions = new InternetExplorerOptions();
            if (isRemoteTestingSession)
            {
                ieOptions.AddAdditionalCapability("user", remoteUserName, true);
                ieOptions.AddAdditionalCapability("accesskey", remoteAccessKey, true);
                ieOptions.AddAdditionalCapability("platform", "Windows 10", true);
                ieOptions.AddAdditionalCapability("version", "11", true);
                ieOptions.AddAdditionalCapability("name", "CSharpTestSample", true);
                ieOptions.AddAdditionalCapability("build", "LambdaTestSampleApp", true);
                ieOptions.AddAdditionalCapability("network", true, true); // To enable network logs
                ieOptions.AddAdditionalCapability("visual", true, true); // To enable step by step screenshot
                ieOptions.AddAdditionalCapability("video", true, true); // To enable video recording
                ieOptions.AddAdditionalCapability("console", true, true); // To capture console logs
                // Add other options for remote testing here
            }
            else
            {
                // Add other options for local testing here
            }
            return ieOptions;
        }
    }
}