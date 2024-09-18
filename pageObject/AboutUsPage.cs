using Microsoft.Playwright;

namespace playwright_c_.pageObject
{
    public class AboutUsPage
    {
        private readonly IPage _page;
        public AboutUsPage(IPage page)
        {
            _page = page;
        }

        public async Task goToPage(string page)
        {
            await _page.GotoAsync("https://www.icevonline.com/" + page);
        }
        public ILocator getByText(string text)
        {
            return _page.GetByText(text);
        }
        public ILocator GridBoxTitles => _page.Locator(".pwr-services-item__title");

        public ILocator GetGridBoxTitleByIndex(int index)
        {
            return this.GridBoxTitles.Nth(index);
        }
    }

}