﻿Feature: YamlFeature

A short summary of the feature

@tag1
Scenario: navigate to yaml view
	Given the application is initialized
	When the user clicks navigateYaml
	Then YamlView is put in the Content Region
@tag1
Scenario: navigate to status view
	Given the application is initialized
	When the user clicks navigateStatus
	Then YamlView is put in the Content Region
