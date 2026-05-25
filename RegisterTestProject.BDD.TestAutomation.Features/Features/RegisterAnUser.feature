Feature: RegisterAnUser

A short summary of the feature

Scenario: Verify authorised user is able to create an account with valid data
	Given an authorised user is navigate to the URL
	When the user navigates to the Register Page
	And the user enters valid data in all the required fields
	And the user clicks on the Register button
	Then the user should be navigated to the My Account page
	

