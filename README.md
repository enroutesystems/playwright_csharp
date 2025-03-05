# Playwright with c#
Follow [these playwright instructions](https://playwright.dev/dotnet/docs/intro) to install playwright and get the project running

# Running the tests
To run the tests just use the `dotnet test` command

# Generating a report
Requirements:
- [Allure CLI tool](https://allurereport.org/docs/install/)

Run the following command to generate a report
```shell
allure generate bin/Debug/net8.0/allure-results
```
Open the report with the following command. This will open a new browser tab with the report
```shell
allure open allure-report
```