using Microsoft.Playwright;
using NUnit.Framework;
using RegisterTestProject.BDD.TestAutomation.Features.WebDriver;
using Reqnroll;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RegisterTestProject.BDD.TestAutomation.Features.Utils
{
    /// <summary>
    /// Provides a simple Playwright driver and NUnit hooks to initialize and dispose browser resources
    /// for each test. Step definitions or tests can access PlaywrightDriver.Page / Context / Browser.
    /// </summary>

    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {

            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 0)]
        public async Task BeforeScenario()
        {
            Console.WriteLine("Before Scenario");

            IPlaywright playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);

            _scenarioContext["page"] = page;
            _scenarioContext["browser"] = browser;

            // Register IPage and IBrowser with Reqnroll's DI container for step definition injection
            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IPage>(page);
            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IBrowser>(browser);

        }


        [AfterScenario]
        public async Task AfterScenario()
        {

            Console.WriteLine("After Scenario");
            var page = _scenarioContext["page"] as IPage;
            var browser = _scenarioContext["browser"] as IBrowser;
            await page?.CloseAsync();
            await browser.CloseAsync();


        }


        //[BeforeStep]
        //public void BeforeStep()
        //{

        //    Console.WriteLine("Before Step");
        //}



        //[AfterStep]
        //public void AfterStep()
        //{

        //    Console.WriteLine("After Step");
        //}


        //[BeforeFeature]
        //public static void BeforeFeature()
        //{

        //    TestContext.Progress.WriteLine("Before Feature");
        //}

        //[AfterFeature]
        //public static void AfterFeature()
        //{
        //    TestContext.Progress.WriteLine("After Feature");
        //}


        //[BeforeTestRun]
        //public static void BeforeTestRun()
        //{
        //    TestContext.Progress.WriteLine("Before Test Run");

        //}


        //[AfterTestRun]
        //public static void AfterTestRun()
        //{
        //    TestContext.Progress.WriteLine("After Test Run");

        //}




    }
}


