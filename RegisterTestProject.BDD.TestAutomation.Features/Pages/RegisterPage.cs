using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.Playwright.Assertions;

namespace RegisterTestProject.BDD.TestAutomation.Features.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IPage page) : base(page)
        {
        }

        public string firstname;
        public string lastname;


        public async Task PopulateRegistrationForm()
        {
             firstname = "John" + GenerateRandomNumber().ToString();
             lastname = "Doe" + GenerateRandomNumber().ToString();


            await page.FillAsync("#customer\\.firstName", firstname);
            await page.FillAsync("#customer\\.lastName", lastname);
            await page.FillAsync("#customer\\.address\\.street", "123 Main St");
            await page.FillAsync("#customer\\.address\\.city", "Anytown");
            await page.FillAsync("#customer\\.address\\.state", "CA");
            await page.FillAsync("#customer\\.address\\.zipCode", "12345");
            await page.FillAsync("#customer\\.phoneNumber", "555-123-4567");
            await page.FillAsync("#customer\\.ssn", "123-45-6789");
            await page.FillAsync("#customer\\.username", firstname+lastname);
            await page.FillAsync("#customer\\.password", "Password123!");
            await page.FillAsync("#repeatedPassword", "Password123!");
        }

        public async Task ClickRegisterButton()
        {
            await page.ClickAsync("input[type='submit'][value='Register']");
        }

        public async Task VerifyMyAccountOverviewPage()
        {
            await page.Locator("//h1[text()='Welcome']").IsVisibleAsync();
            await Expect(page.Locator("//div[@id='rightPanel']//h1")).ToHaveTextAsync("Welcome " + firstname  + lastname);
            await page.Locator("//p[contains(text(),'Your account was created successfully')]").IsVisibleAsync();
        }

        public int GenerateRandomNumber()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 1000);
            return randomNumber;
        }
    }
}
