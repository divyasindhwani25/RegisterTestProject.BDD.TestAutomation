using Microsoft.Playwright;
using NUnit.Framework;
using RegisterTestProject.BDD.TestAutomation.Features.Utils;
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright.NUnit;

namespace RegisterTestProject.BDD.TestAutomation.Features.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IPage page) : base(page)
        {
        }


        // Field Locators
        public string FirstNameField = "#customer\\.firstName";
        public string LastNameField = "#customer\\.lastName";
        public string StreetField = "#customer\\.address\\.street";
        public string CityField = "#customer\\.address\\.city";
        public string StateField = "#customer\\.address\\.state";
        public string ZipCodeField = "#customer\\.address\\.zipCode";
        public string PhoneField = "#customer\\.phoneNumber";
        public string SSNField = "#customer\\.ssn";
        public string UsernameField = "#customer\\.username";
        public string PasswordField = "#customer\\.password";
        public string ConfirmPasswordField = "#repeatedPassword";
        public string RegisterButton = "input[type='submit'][value='Register']";

        // Error Message Locators
        public string EmptyFieldError = "//span[@class='error']";
        public string PasswordMismatchError = "//span[contains(text(),'Passwords')]";
        public string UsernameExistsError = "//span[@id='customer.username.errors']";
        public string FieldLengthError = "//span[contains(text(),'length')]";

        public string firstName;
        public string lastName;
        public string username;
        public string phone;
        public string ssn;
        public string zipCode;
        public string password;

       

        /// <summary>
        /// Populates the registration form with valid random test data
        /// </summary>
        public async Task PopulateRegistrationForm()
        {
            firstName = TestDataGenerator.GenerateFirstName();
            lastName = TestDataGenerator.GenerateLastName();
            username = firstName + lastName;
            phone = TestDataGenerator.GeneratePhoneNumber();
            ssn = TestDataGenerator.GenerateSSN();
            zipCode = TestDataGenerator.GenerateZipCode();
            password = "Password123!";

            await page.FillAsync(FirstNameField, firstName);
            await page.FillAsync(LastNameField, lastName);
            await page.FillAsync(StreetField, "123 Main St");
            await page.FillAsync(CityField, "Anytown");
            await page.FillAsync(StateField, "CA");
            await page.FillAsync(ZipCodeField, zipCode);
            await page.FillAsync(PhoneField, phone);
            await page.FillAsync(SSNField, ssn);
            await page.FillAsync(UsernameField, username);
            await page.FillAsync(PasswordField, password);
            await page.FillAsync(ConfirmPasswordField, password);
        }

        
        /// Fills the form with mismatched password and confirm password
       
        public async Task EnterMismatchedPasswords()
        {
            firstName = TestDataGenerator.GenerateFirstName();
            lastName = TestDataGenerator.GenerateLastName();
            username = firstName + lastName;
            phone = TestDataGenerator.GeneratePhoneNumber();
            ssn = TestDataGenerator.GenerateSSN();
            zipCode = TestDataGenerator.GenerateZipCode();
            password = "Password123!";
            string confirmPassword = "DifferentPassword123!";

            await page.FillAsync(FirstNameField, firstName);
            await page.FillAsync(LastNameField, lastName);
            await page.FillAsync(StreetField, "123 Main St");
            await page.FillAsync(CityField, "Anytown");
            await page.FillAsync(StateField, "CA");
            await page.FillAsync(ZipCodeField, zipCode);
            await page.FillAsync(PhoneField, phone);
            await page.FillAsync(SSNField, ssn);
            await page.FillAsync(UsernameField, username);
            await page.FillAsync(PasswordField, password);
            await page.FillAsync(ConfirmPasswordField, confirmPassword);
        }

        /// Fills the form with an existing username
        public async Task EnterExistingUsername()
        {
            firstName = TestDataGenerator.GenerateFirstName();
            lastName = TestDataGenerator.GenerateLastName();
            username = firstName + lastName;
            string existingUsername = "JohnDoe"; // Known existing username
            phone = TestDataGenerator.GeneratePhoneNumber();
            ssn = TestDataGenerator.GenerateSSN();
            zipCode = TestDataGenerator.GenerateZipCode();
            string password = "Password123!";

            await page.FillAsync(FirstNameField, firstName);
            await page.FillAsync(LastNameField, lastName);
            await page.FillAsync(StreetField, "123 Main St");
            await page.FillAsync(CityField, "Anytown");
            await page.FillAsync(StateField, "CA");
            await page.FillAsync(ZipCodeField, zipCode);
            await page.FillAsync(PhoneField, phone);
            await page.FillAsync(SSNField, ssn);
            await page.FillAsync(UsernameField, existingUsername);
            await page.FillAsync(PasswordField, password);
            await page.FillAsync(ConfirmPasswordField, password);
        }

        /// Fills remaining fields after username (used when username is already filled)
        public async Task FillRemainingFields()
        {
            firstName = TestDataGenerator.GenerateFirstName();
            lastName = TestDataGenerator.GenerateLastName();
            phone = TestDataGenerator.GeneratePhoneNumber();
            ssn = TestDataGenerator.GenerateSSN();
            zipCode = TestDataGenerator.GenerateZipCode();
            password = "Password123!";

            await page.FillAsync(FirstNameField, firstName);
            await page.FillAsync(LastNameField, lastName);
            await page.FillAsync(StreetField, "123 Main St");
            await page.FillAsync(CityField, "Anytown");
            await page.FillAsync(StateField, "CA");
            await page.FillAsync(ZipCodeField, zipCode);
            await page.FillAsync(PhoneField, phone);
            await page.FillAsync(SSNField, ssn);
            await page.FillAsync(PasswordField, password);
            await page.FillAsync(ConfirmPasswordField, password);
        }

        /// <summary>
        /// Fills form with data exceeding maximum field lengths
        /// </summary>
        public async Task EnterDataExceedingMaxLength()
        {
            string longFirstName = new string('A', 100); // Exceeds max length
            string longLastName = new string('B', 100);
            string longPhone = "555-123-456789012345"; // Too long

            await page.FillAsync(FirstNameField, longFirstName);
            await page.FillAsync(LastNameField, longLastName);
            await page.FillAsync(PhoneField, longPhone);
            await page.FillAsync(UsernameField, longFirstName + longLastName);
        }

     
        /// Clicks the Register button
        public async Task ClickRegisterButton()
        {
            await page.ClickAsync(RegisterButton);
        }

        /// Verifies the My Account Overview page is displayed after successful registration

        public async Task VerifyMyAccountOverviewPage()
        {
            // Assertion 1: Verify Welcome message is visible
            await page.Locator("//div[@id='rightPanel']//h1").IsVisibleAsync();
            await Assertions.Expect(page.Locator("//div[@id='rightPanel']//h1")).ToHaveTextAsync("Welcome " + username);
            // Assertion 2: Verify success message is visible
            await page.Locator("//p[contains(text(),'Your account was created successfully')]").IsVisibleAsync();
           
        }

        
        /// Verifies error messages are displayed for empty required fields
       
        public async Task VerifyEmptyFieldsErrorMessage()
        {
            int errorCount = await page.Locator(EmptyFieldError).CountAsync();
            Assert.That(errorCount, Is.GreaterThan(0), "Error messages should be displayed for empty fields");

            // Verify specific error messages for required fields
            var requiredFieldErrors = await page.Locator(EmptyFieldError).AllAsync();
            bool hasRequiredError = false;
            foreach (var error in requiredFieldErrors)
            {
                var text = await error.TextContentAsync();
                if (text.Contains("required", StringComparison.OrdinalIgnoreCase))
                {
                    hasRequiredError = true;
                    break;
                }
            }
            Assert.That(hasRequiredError, Is.True, "Should display 'required' error message");
        }

        /// <summary>
        /// Verifies error message is displayed for password mismatch
        /// </summary>
        public async Task VerifyPasswordMismatchErrorMessage()
        {
            bool isErrorVisible = await page.Locator(PasswordMismatchError).IsVisibleAsync();
            Assert.That(isErrorVisible, Is.True, "Password mismatch error should be visible");

            var errorText = await page.Locator(PasswordMismatchError).TextContentAsync();
            Assert.That(errorText, Does.Contain("Passwords did not match"), "Error message should mention password mismatch");
        }

        /// <summary>
        /// Verifies error message is displayed when username already exists
        /// </summary>
        public async Task VerifyUsernameAlreadyExistsErrorMessage()
        {
            bool isErrorVisible = await page.Locator(UsernameExistsError).IsVisibleAsync();
            Assert.That(isErrorVisible, Is.True, "Username exists error should be visible");

            var errorText = await page.Locator(UsernameExistsError).TextContentAsync();
            Assert.That(errorText, Does.Contain("This username already exists"), "Error message should mention username");
        }

        

        /// <summary>
        /// Verifies that account was not created (user still on register page)
        /// </summary>
        public async Task VerifyAccountNotCreated()
        {
            // Check if we're still on the registration page
            var registerButton = await page.Locator(RegisterButton).IsVisibleAsync();
            Assert.That(registerButton, Is.True, "Should still be on registration page if account creation failed");

            // Verify we did NOT navigate to My Account page
            bool isMyAccountVisible = await page.Locator("//h1[text()='My Account']").IsVisibleAsync();
            Assert.That(isMyAccountVisible, Is.False, "Should not navigate to My Account page on failed registration");
        }

       

        /// <summary>
        /// Verifies password field is masked (type='password')
        /// </summary>
        public async Task VerifyPasswordFieldIsMasked()
        {
            var fieldType = await page.Locator(PasswordField).GetAttributeAsync("type");
            Assert.That(fieldType, Is.EqualTo("password"), "Password field should have type='password' for masking");
        }

        /// <summary>
        /// Verifies confirm password field is masked (type='password')
        /// </summary>
        public async Task VerifyConfirmPasswordFieldIsMasked()
        {
            var fieldType = await page.Locator(ConfirmPasswordField).GetAttributeAsync("type");
            Assert.That(fieldType, Is.EqualTo("password"), "Confirm password field should have type='password' for masking");
        }
    }
}