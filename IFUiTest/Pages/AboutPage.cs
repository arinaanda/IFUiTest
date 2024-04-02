using OpenQA.Selenium;

namespace IFUiTest.Pages;

internal class AboutPage(IWebDriver chromeDriver)
{
    private static By AboutIfSelector => By.LinkText("Darbs If");

    public WorkAtIfPage NavigateToWorkAtIf()
    {
        chromeDriver.FindElement(AboutIfSelector).Click();
        return new WorkAtIfPage(chromeDriver);
    }
}