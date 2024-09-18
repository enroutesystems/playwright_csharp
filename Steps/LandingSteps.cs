using PageObject;
using TechTalk.SpecFlow;
using static Microsoft.Playwright.Assertions;

namespace playwright_c_.Steps;

[Binding]
public class LandingSteps
{
    private readonly LandingPage _landingPage;

    public LandingSteps(LandingPage landingPage)
    {
        _landingPage = landingPage;
    }

    [Given(@"""(.*)"" page is open")]
    public async void GivenPageIsOpen(string landing)
    {
        await _landingPage.OpenAsync(landing);
    }

    [When(@"the ""(.*)"" dropdown is clicked")]
    public async void WhenTheDropdownIsClicked(string menu)
    {
        await _landingPage.ExpandMenu(menu);
    }

    [Then(@"all menu options are visible")]
    public async void ThenAllMenuOptionsAreVisible(Table table)
    {
        var options = table.Rows[0][1].Split(",");
        foreach (var option in options)
        {
            await Expect(_landingPage.getElementsWithText(option)).ToBeVisibleAsync();
        }
    }
}