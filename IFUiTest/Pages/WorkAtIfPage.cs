using OpenQA.Selenium;

namespace IFUiTest.Pages;

internal class WorkAtIfPage(IWebDriver chromeDriver)
{
    private static By VacanciesSelector => By.LinkText("Vakances");

    public VacanciesPage NavigateToVacancies()
    {
        chromeDriver.FindElement(VacanciesSelector).Click();
        return new VacanciesPage(chromeDriver);
    }
}