Feature: Header menus
    At the top of our landing page we will have a series of menus
    each menu will display different links to other places of the page
    we want to make sure these links are available regardless of whether they take us to where they should

    Scenario: open the landing page
        Given "landing" page is open
        When the "<menu>" dropdown is clicked
        Then all menu options are visible
          |   menu            |
          |   solutions       |
          |   learning center |