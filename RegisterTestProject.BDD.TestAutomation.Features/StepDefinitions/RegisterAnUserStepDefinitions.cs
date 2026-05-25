using System;
using Microsoft.Playwright;
using NUnit.Framework;
using RegisterTestProject.BDD.TestAutomation.Features.Pages;
using Reqnroll;

namespace RegisterTestProject.BDD.TestAutomation.Features.StepDefinitions
{
    [Binding]
    public class RegisterAnUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IPage _page;
        private HomePage _homepage;
        private RegisterPage _registerPage;

        public RegisterAnUserStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            if (_page == null && _scenarioContext.TryGetValue("page", out IPage page))
            {
                _page = page;
                _homepage = new HomePage(_page);
                _registerPage = new RegisterPage(_page);
            }
        }

        private IPage Page
        {
            get
            {
                if (_page == null && _scenarioContext.TryGetValue("page", out IPage page))
                {
                    _page = page;
                    _homepage = new HomePage(_page);
                    _registerPage = new RegisterPage(_page);
                }
                return _page;
            }
        }

      

        [Given("an authorised user is navigate to the URL")]
        public async Task GivenAnAuthorisedUserIsNavigateToTheURL()
        {
            if (_homepage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _homepage = new HomePage(_page);
            }
            await _homepage.NavigateToHomePage();
        }

        

        [When("the user navigates to the Register Page")]
        public async Task WhenTheUserNavigatesToThePage()
        {
            if (_homepage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _homepage = new HomePage(_page);
            }
            await _homepage.NavigateToRegisterPage();
        }

       

        [When("the user enters valid data in all the required fields")]
        public async Task WhenTheUserEntersValidDataInAllTheRequiredFields()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.PopulateRegistrationForm();
        }

        [When("the user leaves all required fields empty")]
        public async Task WhenTheUserLeavesAllRequiredFieldsEmpty()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            // Simply don't fill any fields - they remain empty
            await Task.CompletedTask;
        }

        [When("the user enters a different password in the confirm password field")]
        public async Task WhenTheUserEntersADifferentPasswordInTheConfirmPasswordField()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.EnterMismatchedPasswords();
        }

        [When("the user enters a username that already exists")]
        public async Task WhenTheUserEntersAUsernameThatAlreadyExists()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.EnterExistingUsername();
        }

        [When("the user enters valid data in remaining required fields")]
        public async Task WhenTheUserEntersValidDataInRemainingRequiredFields()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.FillRemainingFields();
        }

        [When("the user enters data exceeding maximum field length")]
        public async Task WhenTheUserEntersDataExceedingMaximumFieldLength()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.EnterDataExceedingMaxLength();
        }


        [When("the user clicks on the Register button")]
        public async Task WhenTheUserClicksOnTheButton()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.ClickRegisterButton();
        }

       

        [Then("the user should be navigated to the My Account page")]
        public async Task ThenTheUserShouldBeNavigatedToThePage()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyMyAccountOverviewPage();
        }

        [Then("the user should be able to create an account successfully")]
        public async Task ThenTheUserShouldBeAbleToCreateAnAccountSuccessfully()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyMyAccountOverviewPage();
        }

       

        [Then("an error message should be displayed for empty fields")]
        public async Task ThenAnErrorMessageShouldBeDisplayedForEmptyFields()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyEmptyFieldsErrorMessage();
        }

        [Then("an error message should indicate password mismatch")]
        public async Task ThenAnErrorMessageShouldIndicatePasswordMismatch()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyPasswordMismatchErrorMessage();
        }

        [Then("an error message should indicate username already exists")]
        public async Task ThenAnErrorMessageShouldIndicateUsernameAlreadyExists()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyUsernameAlreadyExistsErrorMessage();
        }

        [Then("the account should not be created")]
        public async Task ThenTheAccountShouldNotBeCreated()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyAccountNotCreated();
        }


        [Then("the password field should be masked")]
        public async Task ThenThePasswordFieldShouldBeMasked()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyPasswordFieldIsMasked();
        }

        [Then("the confirm password field should be masked")]
        public async Task ThenTheConfirmPasswordFieldShouldBeMasked()
        {
            if (_registerPage == null)
            {
                _page = _scenarioContext["page"] as IPage;
                _registerPage = new RegisterPage(_page);
            }
            await _registerPage.VerifyConfirmPasswordFieldIsMasked();
        }

     
    }
}
