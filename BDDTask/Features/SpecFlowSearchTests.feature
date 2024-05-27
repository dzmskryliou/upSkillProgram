﻿Feature: SpecFlowSearchTests
In order to easily find needed documentation
	As a specflow user
	I want to be able to navigate to pages through main menu and search for an item using search functionality
	
Scenario: Search from SpecFlow documentation page
	Given I open official SpecFlow web site
	When I hover the Docs item from the main menu
	And I click SpecFlow option from the main menu
	And I click on the 'search docs' field
    And I type Installation in the popup window
    And I select the Installation page from the suggestions
	Then Page with Installation title should be opened