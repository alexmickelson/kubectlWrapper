Feature: YamlFeature

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
	Then StatusView is put in the Content Region

@tag1
Scenario: get status 
	Given you are at the status view
	When the user clicks getconfig button
	Then the correct config of the cluster is recieved

@tag1
Scenario: valid input allow yaml to be applied
	Given you are at the Yaml View
	When the user provides directory validDir
	And the user selects file valid.yaml 
	Then the button is true
#Examples:
#| dir        | file                      | enabled |
#| validDir   | valid.yaml                | true    |
#| validDir   | valid.yml                 | true    |
#| invalidDir | invalid.not               | false   |
#| validDir   | invalid.not               | false   |
#| invalidDir | valid.aspiresbutfailstobe | false   |
	

