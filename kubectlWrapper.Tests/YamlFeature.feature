Feature: YamlFeature

A short summary of the feature
Background: 
	Given we have mocked all of our services

@tag1
Scenario: navigate to yaml view
	Given the application is initialized
	When the user clicks navigateYaml
	Then YamlView is put in the Content Region


@tag1
Scenario: navigate to status view
	Given the application is initialized
	When the user clicks navigateStatus
	Then StatusView is put in the Content Region
@tag1
Scenario: get status 
	Given you are at the status view
	When the user clicks getconfig button
	Then the correct config of the cluster is recieved


	

