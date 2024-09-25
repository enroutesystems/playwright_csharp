using Microsoft.Playwright;

namespace playwright_c_.PageObject;
public class AboutUsPage : Page
{
    private readonly IPage _page;
    private readonly ILocator _gridBoxTitles;
    public AboutUsPage(IPage page) : base(page)
    {
        _page = page;
        _gridBoxTitles = _page.Locator(".pwr-services-item__title");
    }

    public ILocator GetGridBoxTitleByIndex(int index)
    {
        return _gridBoxTitles.Nth(index);
    }
    public async Task<IReadOnlyList<ILocator>> GetAllGridBoxTitles()
    {
        return await _gridBoxTitles.AllAsync();
    }
}