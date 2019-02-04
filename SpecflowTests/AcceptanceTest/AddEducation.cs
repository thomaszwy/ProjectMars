using OpenQA.Selenium;
using SpecflowPages;
using System;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;
using RelevantCodes.ExtentReports;
using static SpecflowPages.CommonMethods;
using OpenQA.Selenium.Interactions;

namespace OpenQA.Selenium.Support.UI
{

    [Binding]
    public class SpecFlowFeature3Steps
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        }
        
        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            //Delete the previous entry
            try {
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i")).Click();
            }
            catch { }

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            //Add the name of institution
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys("MIT");

            //Click on country of institution
            Driver.driver.FindElement(By.Name("country")).Click();

            //Choose the country of institution, but SelectElement doesn't work
            //new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("United States");
            //driver.FindElement(By.Name("country")).Click();

            //Choose the country of institution
            IWebElement Country = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option"))[147];
            Country.Click();

            //Click on title
            Driver.driver.FindElement(By.Name("title")).Click();

            //Choose the title
            IWebElement Title = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option"))[11];
            Title.Click();

            //Add degree
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys("Engineering");

            //Click on year of graduation
            Driver.driver.FindElement(By.Name("yearOfGraduation")).Click();

            //Choose the year of graduation
            IWebElement Year = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option"))[12];
            Year.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();

        }

        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add an Education");

                //Check the education info
                Thread.Sleep(1000);
                string ExpectedValue = "United States"; 
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(1000);

                //Scroll to element
                var element = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
                Actions actions = new Actions(Driver.driver);
                actions.MoveToElement(element);
                actions.Perform();
                Thread.Sleep(500);

                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added an Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
