using IFUiTest.Helpers;
using OpenQA.Selenium;

namespace IFUiTest.Pages;

internal class VacanciesPage(IWebDriver chromeDriver)
{
    private static By QasPositionVacancyReadMoreSelector => By.XPath("//span[contains(text(),'Quality Assurance Specialist')]/following-sibling::a[@title='Read more']");

    public PositionPage NavigateToQasPosition()
    {
        var qasPositionReadMoreLink = chromeDriver.FindElement(QasPositionVacancyReadMoreSelector);

        chromeDriver.ScrollToElement(qasPositionReadMoreLink);
        qasPositionReadMoreLink.Click();

        return new PositionPage(chromeDriver);
    }
}