Feature: RegisterAnUser

Comprehensive registration feature for validating user account creation scenarios

Scenario: Verify authorised user is able to create an account with valid data
	Given an authorised user is navigate to the URL
	When the user navigates to the Register Page
	And the user enters valid data in all the required fields
	And the user clicks on the Register button
	Then the user should be navigated to the My Account page

Scenario: Verify that clicking 'Register' throws an error if required fields are empty
	Given an authorised user is navigate to the URL
	When the user navigates to the Register Page
	And the user leaves all required fields empty
	And the user clicks on the Register button
	Then an error message should be displayed for empty fields
	And the account should not be created

Scenario: Verify the password and confirm password mismatch
	Given an authorised user is navigate to the URL
	When the user navigates to the Register Page
	And the user enters valid data in all the required fields
	And the user enters a different password in the confirm password field
	And the user clicks on the Register button
	Then an error message should indicate password mismatch
	And the account should not be created

Scenario: Verify user cannot register with an already existing username
	Given an authorised user is navigate to the URL
	When the user navigates to the Register Page
	And the user enters a username that already exists
	And the user enters valid data in remaining required fields
	And the user clicks on the Register button
	Then an error message should indicate username already exists
	And the account should not be created

Scenario: Verify Password and confirm password fields are masked
	Given an authorised user is navigate to the URL
	When the user navigates to the Register Page
	Then the password field should be masked
	And the confirm password field should be masked

