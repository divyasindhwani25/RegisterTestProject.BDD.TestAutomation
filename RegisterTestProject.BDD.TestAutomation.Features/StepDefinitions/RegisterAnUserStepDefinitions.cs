using System;
using Microsoft.Playwright;
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
            await _homepage.NavigateToHomePage();
        }

        [When("the user navigates to the Register Page")]
        public async Task WhenTheUserNavigatesToThePage()
        {
            await _homepage.NavigateToRegisterPage();
        }

        [When("the user enters valid data in all the required fields")]
        public async Task WhenTheUserEntersValidDataInAllTheRequiredFields()
        {
            await _registerPage.PopulateRegistrationForm();
        }

        [When("the user clicks on the Register button")]
        public async Task WhenTheUserClicksOnTheButton()
        {
            await _registerPage.ClickRegisterButton();
        }

        [Then("the user should be navigated to the My Account page")]
        public async Task ThenTheUserShouldBeNavigatedToThePage()
        {
            await _registerPage.VerifyMyAccountOverviewPage();
        }

    }
}
