using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterTestProject.BDD.TestAutomation.Features.WebDriver
{
    public class PlaywrightDriver
    {
        public static IPlaywright? Playwright { get; private set; }
        public static IBrowser? Browser { get; private set; }
        public static IBrowserContext? Context { get; private set; }
        public static IPage? Page { get; private set; }

    //    public static async Task<IBrowserContext> CreateContext(Models.BrowserType inBrowser, BrowserTypeLaunchOptions)
    //    {
    //        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

    //        var launchOptions = new BrowserTypeLaunchOptions
    //        {
    //            Headless = headless,
    //        };

    //        // You can switch to Playwright.Chromium/Firefox/Webkit as needed
    //        Browser = await Playwright.Chromium.LaunchAsync(launchOptions);
    //        Context = await Browser.NewContextAsync();
    //        Page = await Context.NewPageAsync();

    //        // Optional: set default timeouts / viewports here
    //        Page.SetDefaultTimeout(30_000);
    //        Page.SetDefaultNavigationTimeout(30_000);
    //    }
    //}

    //public static async Task DisposeAsync()
    //    {
    //        if (Page is not null)
    //        {
    //            try { await Page.CloseAsync(); } catch { }
    //            Page = null;
    //        }

    //        if (Context is not null)
    //        {
    //            try { await Context.CloseAsync(); } catch { }
    //            Context = null;
    //        }

    //        if (Browser is not null)
    //        {
    //            try { await Browser.CloseAsync(); } catch { }
    //            Browser = null;
    //        }

    //        if (Playwright is not null)
    //        {
    //            try { await Playwright.DisposeAsync(); } catch { }
    //            Playwright = null;
    //        }
    //    }
    }

}
