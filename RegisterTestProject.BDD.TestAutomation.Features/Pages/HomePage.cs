using Microsoft.Playwright;
using RegisterTestProject.BDD.TestAutomation.Features.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterTestProject.BDD.TestAutomation.Features.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IPage page) : base(page) { }

        public async Task NavigateToHomePage()
        {
            string url = Helpers.Get("Url");
            await page.GotoAsync(url);
        }

        public async Task NavigateToRegisterPage()
        {
            await page.Locator("//a[text()='Register']").ClickAsync();
        }
    }
}
