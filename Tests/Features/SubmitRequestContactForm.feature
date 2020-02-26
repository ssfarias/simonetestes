Feature: Submit a request contact Form
	In order to test the functionaly submit a request contact form 
	As a user of UBS site
	I want to be able to fill all mandatory fields and submit it	
	

@mytag
Scenario: Fill all mandatory fields and submit the contact form
	Given user clicks in the Gogal Contact link
	And user clicks the contact link
	And user acess the contact form
	And user Fills all mandatory fields
	When user press button submit
	Then a success message should be shown
