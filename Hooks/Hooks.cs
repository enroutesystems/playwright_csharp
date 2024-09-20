using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace playwright_c_.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        public IPage? _page;
        public IBrowser? _browser;
        public IBrowserContext? _browserContext;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _page = null;
            _browser = null;
            _browserContext = null;
        }

        [BeforeScenario]
        public async Task SetUp()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            _browserContext = await _browser.NewContextAsync();
            _page = await _browserContext.NewPageAsync();
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async void TearDown()
        {
            if (_page != null)
            {
                await _page.CloseAsync();
            }
            if (_browserContext != null)
            {
                await _browserContext.CloseAsync();
            }
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
        }
    }
}
