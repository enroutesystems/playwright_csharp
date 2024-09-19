using Microsoft.Playwright;
using playwright_c_.pageObject;
using TechTalk.SpecFlow;
using static Microsoft.Playwright.Assertions;

namespace playwright_c_.Steps;

[Parallelizable(scope: ParallelScope.All)]
[Binding]
public class LandingSteps
{
    private readonly LandingPage _landingPage;

    public LandingSteps(LandingPage landingPage)
    {
        _landingPage = landingPage;
    }

    [Given(@"""(.*)"" page is open")]
    public async Task GivenPageIsOpen(string page)
    {
        if (page == "landing")
        {
            page = "";
        }
        await _landingPage.OpenAsync(page);
    }

    [When(@"the ""(.*)"" dropdown is clicked")]
    public async Task WhenTheDropdownIsClicked(string menuName)
    {
        await _landingPage.ExpandMenu(menuName);
    }

    [Then(@"all ""(.*)"" menu options are visible")]
    public async Task ThenAllMenuOptionsAreVisible(string menuName)
    {
        var menuToHover = _landingPage.Menus[menuName];
        await _landingPage.ExpandMenu(menuName);
        foreach (var menuSection in menuToHover.Item2.Keys)
        {
            foreach (var submenu in menuToHover.Item2[menuSection])
            {
                await Expect(submenu.Value).ToBeVisibleAsync();
            }
        }
    }
}