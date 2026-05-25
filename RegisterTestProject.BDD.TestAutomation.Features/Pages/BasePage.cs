using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterTestProject.BDD.TestAutomation.Features.Pages
{
    public class BasePage
    {
        public IPage page;

        public BasePage(IPage page)
        {
            this.page = page;
        }
    }
}
