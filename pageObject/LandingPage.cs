
using Microsoft.Playwright;

namespace playwright_c_.pageObject
{
    public class LandingPage
    {
        private readonly IPage _page;
        public readonly Dictionary<string, (ILocator, Dictionary<string, Dictionary<string, ILocator>>)> Menus;

        public LandingPage(IPage page)
        {
            _page = page;
            Menus = new Dictionary<string, (ILocator, Dictionary<string, Dictionary<string, ILocator>>)>
            {
                { "solutions", (TopMenu["solutions"], SolutionsMenu) },
                { "learning center", (TopMenu["learningCenter"], LearningCenterMenu) }
            };
        }
        
        public async Task OpenAsync(string page)
        {
            await _page.GotoAsync("https://www.icevonline.com/" + page);
        }

        public ILocator ICEVButton => _page.GetByLabel("Back to Home");
        public ILocator TopHeader => _page.Locator("#pwr-header-top");
        public ILocator Login => _page.GetByRole(AriaRole.Menuitem, new() { Name = "Login" });
        public ILocator RegisterNow => _page.GetByRole(AriaRole.Menuitem, new() { Name = "Register Now" });

        public ILocator HeaderMenu => _page.Locator("#pwr-js-header__menu");
        public Dictionary<string, ILocator> TopMenu => new()
        {
            { "solutions", HeaderMenu.GetByRole(AriaRole.Menuitem, new() { Name = "Solutions" }) },
            { "stateResources", HeaderMenu.GetByRole(AriaRole.Menuitem, new() { Name = "State Resources" }) },
            { "learningCenter", HeaderMenu.GetByRole(AriaRole.Menuitem, new() { Name = "Learning Center" }) }
        };

        public Dictionary<string, Dictionary<string, ILocator>> SolutionsMenu => new()
        {
            { "curriculum", new Dictionary<string, ILocator>
                {
                    { "cteCurriculum", _page.Locator("#pwr-header-fixed").GetByRole(AriaRole.Link, new() { Name = "CTE Curriculum" }) },
                    { "alternativeEducation", _page.GetByRole(AriaRole.Link, new() { Name = "Alternative Education" }) }
                }
            },
            { "industryCertifications", new Dictionary<string, ILocator>
                {
                    { "certifications", _page.Locator("#pwr-header-fixed").GetByRole(AriaRole.Link, new() { Name = "Industry Certifications" }) },
                    { "iCEVTestingPlatform", _page.GetByRole(AriaRole.Link, new() { Name = "iCEV Testing Platform" }) },
                    { "certificationAlignments", _page.GetByRole(AriaRole.Link, new() { Name = "Certification Alignments" }) }
                }
            },
            { "reportingAndAnalytics", new Dictionary<string, ILocator>
                {
                    { "eduthings", _page.GetByRole(AriaRole.Link, new() { Name = "Eduthings" }) }
                }
            }
        };

        public ILocator LearningCenterMenuFrame => _page.Locator("div:nth-child(2) > .pwr-adc > .pwr-adc__wrapper > .pwr-adc-main > .pwr-adc__cols > .pwr-adc__col");
        public Dictionary<string, Dictionary<string, ILocator>> LearningCenterMenu => new()
        {
            { "menu", new Dictionary<string, ILocator>
                {
                    { "tutorials", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Tutorials" }) },
                    { "guides", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Guides" }) },
                    { "webinars", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Virtual Events" }) },
                    { "caseStudies", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Case Studies" }) },
                    { "whitePapers", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "White Papers" }) },
                    { "infoGraphics", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Infographics" }) },
                    { "posters", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Posters" }) },
                    { "hireCertified", LearningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Hire Certified" }) }
                }
            }
        };

        public ILocator Blog => HeaderMenu.GetByRole(AriaRole.Menuitem, new() { Name = "Blog" });
        public ILocator AboutUs => HeaderMenu.GetByRole(AriaRole.Menuitem, new() { Name = "About Us" });
        public ILocator Search => HeaderMenu.GetByRole(AriaRole.Link, new() { Name = "Search" });
        public ILocator ScheduleDemo => _page.Locator("#pwr-js-header-right-bar").GetByRole(AriaRole.Link, new() { Name = "Schedule A Demo + Trial" });

        public async Task<Dictionary<string, Dictionary<string, ILocator>>> ExpandMenu(string menu)
        {
            try
            {
                await Menus[menu].Item1.HoverAsync();
                return Menus[menu].Item2;
            }
            catch (Exception e)
            {
                throw new Exception($"Menu {menu} has not been implemented", e);
            }
        }
        
        public ILocator getElementsWithText(string text)
        {
            return _page.GetByText(text);
        }
    }
}