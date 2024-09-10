using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PageObject
{
    class PlaywrightPage
    {
        private readonly IPage _page;
        private readonly ILocator _getStartedLink;
        private readonly ILocator _installationHeader;
        public ILocator InstallationHeader => _installationHeader;
        private readonly string _url;
        public PlaywrightPage(IPage page)
        {
            _page = page;
            _getStartedLink = page.GetByRole(AriaRole.Link, new() { Name = "Get started" });
            _installationHeader = page.GetByRole(AriaRole.Heading, new() { Name = "Installation" });
            _url = "https://playwright.dev";
        }


        public async Task GoToPage()
        {
            await _page.GotoAsync(_url);
        }

        public async Task ClickGetStartedLink()
        {
            await _getStartedLink.ClickAsync();
        }
    }

}