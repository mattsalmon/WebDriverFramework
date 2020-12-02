# LambdaTest WebDriver Framework

This repository contains example code for a simple xUnit test project which makes use of LambdaTest as a remote Selenium cloud. 


# To try it out
1.  Sign up for a free [LambdaTest](https://www.lambdatest.com/) account.
2.  Log in to your LambdaTest dashboard, click on 'Automate' in the left navigation, and then up in the top-right click on the key icon to retrieve your credentials, as shown in the image below.
3.  Get a copy of the example code from the GitHub repo, and replace the **remoteUserName** and **remoteAccessKey** within the **TestConfiguration.cs** class.
4. Ensure that the **isRemoteTestingSession** boolean within the **TestConfiguration** class is set to true, otherwise your tests will start spawning local browser instances.
5.  You should then be able to compile the code and run the tests in the **ToDoAppTests** class

# Frameworks
To facilitate testing, the solution uses the following frameworks (added as local project references):
- xUnit as the Unit Testing framework

# File Structure

There is a single master solution file, with references to 1 project as follows:
- **WebdriverTestFramework.sln**: The top level solution
- **ToDoApp.Tests/ToDoApp.Tests.csproj**: The main xUnit test project
-- **ToDoApp.Tests/PageObjects**: The Page Object Model classes supporting the tests