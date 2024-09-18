using Microsoft.Playwright;

namespace playwright_c_.pageObject
{
    public class AboutUsPage
    {
        public readonly IPage Page;
        // private readonly ILocator _getStartedLink;
        // public ILocator InstallationHeader => _installationHeader;
        // private readonly string _url;
        public AboutUsPage(IPage page)
        {
            Page = page;
            // _getStartedLink = page.GetByRole(AriaRole.Link, new() { Name = "Get started" });
            // _url = "https://playwright.dev";
        }

        public ILocator GridBoxTitles => Page.Locator(".pwr-services-item__title");

        public ILocator GetGridBoxTitleByIndex(int index)
        {
            return this.GridBoxTitles.Nth(index);
        }
    }

}