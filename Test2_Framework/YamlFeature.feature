Feature: YamlFeature

A short summary of the feature

@tag1
Scenario Outline: valid input allow yaml to be applied
	Given you are at the Yaml View
	When the user provides directory <dir>
	And the user selects file <file>
	Then the button is <enabled>
Examples:
| dir        | file                      | enabled |
| validDir   | valid.yaml                | true    |
| validDir   | valid.yml                 | true    |
| invalidDir | invalid.not               | false   |
| validDir   | invalid.not               | false   |
| invalidDir | valid.aspiresbutfailstobe | false   |
