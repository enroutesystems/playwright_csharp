
using Microsoft.Playwright;

namespace playwright_c_.pageObject
{
    public class LandingPage : Utils.PageObject
    {
        private readonly IPage _page;
        private readonly ILocator _icevButton;
        private readonly ILocator _topHeader;
        private readonly ILocator _login;
        private readonly ILocator _registerNow;
        private readonly ILocator _aboutUs;
        private readonly ILocator _blog;
        private readonly ILocator _headerMenu;
        private readonly ILocator _learningCenterMenuFrame;
        private readonly ILocator _search;
        private readonly ILocator _scheduleDemo;
        private readonly Dictionary<string, (ILocator, Dictionary<string, Dictionary<string, ILocator>>)> _menus;
        private readonly Dictionary<string, ILocator> _topMenu;
        private readonly Dictionary<string, Dictionary<string, ILocator>> _solutionsMenu;
        private readonly Dictionary<string, Dictionary<string, ILocator>> _learningCenterMenu;

        public LandingPage(IPage page) : base(page)
        {
            _page = page;
            _icevButton = _page.GetByLabel("Back to Home");
            _topHeader = _page.Locator("#pwr-header-top");
            _login = _page.GetByRole(AriaRole.Menuitem, new() { Name = "Login" });
            _registerNow = _page.GetByRole(AriaRole.Menuitem, new() { Name = "Register Now" });
            _headerMenu = _page.Locator("#pwr-js-header__menu");
            _learningCenterMenuFrame = _page.Locator("div:nth-child(2) > .pwr-adc > .pwr-adc__wrapper > .pwr-adc-main > .pwr-adc__cols > .pwr-adc__col");
            _blog = _headerMenu.GetByRole(AriaRole.Menuitem, new() { Name = "Blog" });
            _aboutUs = _headerMenu.GetByRole(AriaRole.Menuitem, new() { Name = "About Us" });
            _search = _headerMenu.GetByRole(AriaRole.Link, new() { Name = "Search" });
            _scheduleDemo = _page.Locator("#pwr-js-header-right-bar").GetByRole(AriaRole.Link, new() { Name = "Schedule A Demo + Trial" });
            _topMenu = new()
            {
                { "solutions", _headerMenu.GetByRole(AriaRole.Menuitem, new() { Name = "Solutions" }) },
                { "stateResources", _headerMenu.GetByRole(AriaRole.Menuitem, new() { Name = "State Resources" }) },
                { "learningCenter", _headerMenu.GetByRole(AriaRole.Menuitem, new() { Name = "Learning Center" }) }
            };
            _solutionsMenu = new()
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
            _learningCenterMenu = new()
            {
                { "menu", new Dictionary<string, ILocator>
                    {
                        { "tutorials", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Tutorials" }) },
                        { "guides", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Guides" }) },
                        { "webinars", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Virtual Events" }) },
                        { "caseStudies", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Case Studies" }) },
                        { "whitePapers", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "White Papers" }) },
                        { "infoGraphics", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Infographics" }) },
                        { "posters", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Posters" }) },
                        { "hireCertified", _learningCenterMenuFrame.GetByRole(AriaRole.Link, new() { Name = "Hire Certified" }) }
                    }
                }
            };
            _menus = new Dictionary<string, (ILocator, Dictionary<string, Dictionary<string, ILocator>>)>
            {
                { "solutions", (_topMenu["solutions"], _solutionsMenu) },
                { "learning center", (_topMenu["learningCenter"], _learningCenterMenu) }
            };
        }
        public (ILocator, Dictionary<string, Dictionary<string, ILocator>>) Menus(string menuName) => _menus[menuName];

        public async Task<Dictionary<string, Dictionary<string, ILocator>>> ExpandMenu(string menu)
        {
            try
            {
                await _menus[menu].Item1.HoverAsync();
                return _menus[menu].Item2;
            }
            catch (Exception e)
            {
                throw new Exception($"Menu {menu} has not been implemented", e);
            }
        }
    }
}