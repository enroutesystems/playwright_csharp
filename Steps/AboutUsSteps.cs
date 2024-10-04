using Microsoft.Playwright;
using playwright_c_.PageObject;
using PlaywrightTests.Utils;
using Reqnroll;
using static Microsoft.Playwright.Assertions;

namespace playwright_c_.Steps;

[Parallelizable(scope: ParallelScope.All)]
[Binding]
public class AboutUsSteps
{
    private readonly AboutUsPage _aboutUsPage;

    public AboutUsSteps(AboutUsPage aboutUsPage)
    {
        _aboutUsPage = aboutUsPage;
    }

    [Given(@"AboutUs page is loaded")]
    public async Task GivenAboutUsPageIsLoaded()
    {
        await _aboutUsPage.GoToPage("about-us");
    }

    [When(@"the ""(.*)"" grid box title contains the text ""(.*)""")]
    public async Task WhenTheGridBoxTitleContainsTheText(string sequence, string expectedText)
    {
        int indexNumber = Helpers.sequenceToIndexNumber(sequence);
        var element = _aboutUsPage.GetGridBoxTitleByIndex(indexNumber);
        await Expect(element).ToHaveTextAsync(expectedText);
    }

    [Then(@"all grid box title are visible")]
    public async Task ThenAllGridBoxTitleAreVisible()
    {
        var elements = await _aboutUsPage.GetAllGridBoxTitles();
        foreach (var element in elements)
        {
            await Expect(element).ToBeVisibleAsync();
        }
    }

    [When(@"the following information about us is displayed:")]
    public async Task WhenTheFollowingInformationAboutUsIsDisplayed(Table dataTable)
    {
        var boxes = dataTable.Rows.Select(row => row[0]).ToList();
        for (int i = 0; i < boxes.Count; i++)
        {
            // search in the page for the box title, don't use the index or the page object, only check for any element with the text
            await Expect(_aboutUsPage.GetByText(boxes[i])).ToBeVisibleAsync();
        }
    }

    [Then(@"each section has the correct information")]
    public async Task ThenEachSectionHasTheCorrectInformation(string multilineText)
    {
        var sectionText = multilineText.Split("---");
        for (int i = 0; i < sectionText.Length; i++)
        {
            var element = _aboutUsPage.GetByText(sectionText[i]);
            await Expect(element).ToBeVisibleAsync();
        }
    }
}