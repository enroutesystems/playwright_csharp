Feature: About us page
    This is the about page, where we can find information about the website
    We will verify that the page contains the correct information

  Scenario: Info boxes contain correct headings
    Given AboutUs page is loaded
    When the "first" grid box title contains the text "Always Up To Date"
    And the "second" grid box title contains the text "Saves You Time"
    And the "third" grid box title contains the text "Helps Certify Learners"
    Then all grid box title are visible

  Scenario: alternative to scenario above
    Given AboutUs page is loaded
    When the following information about us is displayed:
      | ALWAYS UP TO DATE      |
      | SAVES YOU TIME         |
      | HELPS CERTIFY LEARNERS |
    Then each section has the correct information
    """
    As the industry changes, your curriculum needs to keep up. That's why regular updates to our curriculum are at the top of our mind.
    ---
    Our solution is designed to do the heavy lifting of planning, grading, and reporting. In turn this gives you time back for the things that really matter.
    ---
    Certifications are critical to your learners’ career success. That’s why our curriculum aligns to prominent industry standards and exams.
    """