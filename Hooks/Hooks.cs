using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace playwright_c_.Hooks
{
    [Binding]
    public class Hooks
    {
        // public ScenarioContext _ScenarioContext;
        private readonly IObjectContainer _objectContainer;
        public IPage _page;
        public IBrowser _browser;
        public IBrowserContext _browserContext;

        // public Hooks(IPage page, IBrowser browser, IBrowserContext browserContext)
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            // _page = page;
            // _browser = browser;
            // _browserContext = browserContext;
            // _ScenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async void SetUp()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            _browserContext = await _browser.NewContextAsync();
            _page = await _browserContext.NewPageAsync();
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
