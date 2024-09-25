using Microsoft.Playwright;

namespace playwright_c_.PageObject;

public class Page
{
    private readonly IPage _page;
    private readonly string _baseurl;

    public Page(IPage page)
    {
        _page = page;
        _baseurl = "https://www.icevonline.com/";
    }
    
    public async Task GoToPage(string page)
    {
        await _page.GotoAsync(_baseurl + page);
    }

    public ILocator GetByText(string text)
    {
        return _page.GetByText(text);
    }

    public async Task ClickElement(string elementLocator)
    {
        await _page.Locator(elementLocator).ClickAsync();
    }
}