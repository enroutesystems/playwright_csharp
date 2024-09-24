# Playwright with c#
Follow [these playwright instructions](https://playwright.dev/dotnet/docs/intro) to install playwright and get the project running

# Running the tests
To run the tests just use the `dotnet test` command

# Generating a report
Requirements:
- [LivingDoc CLI tool](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Installing-the-command-line-tool.html)
- Your terminal path should have access to "/.dotnet/tools" in order to use it as a command line executable.

Run the following command to generate a report, the argument after "-t" should be the latest TestExecution.json
```shell
livingdoc feature-folder Features -t bin/Debug/net8.0/TestExecution.json
```