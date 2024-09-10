using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

using PageObject;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class PlaywrightTest : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        var playwrightPage = new PlaywrightPage(Page);
        await playwrightPage.GoToPage();

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [Test]
    public async Task GetStartedLink()
    {
        var playwrightPage = new PlaywrightPage(Page);
        await playwrightPage.GoToPage();

        // Click the get started link.
        await playwrightPage.ClickGetStartedLink();

        // Expects page to have a heading with the name of Installation.
        await Expect(playwrightPage.InstallationHeader).ToBeVisibleAsync();
    } 
}