Feature: SpecFlowFeature2
	In order to update my profile 
	As a skill trader
	I want to add the skills that I have

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Skills tab under Profile page
	When I add a new skill
	Then that skill should be displayed on my listings
