using IFUiTest.Helpers;
using OpenQA.Selenium;

namespace IFUiTest.Pages;

internal class PositionPage(IWebDriver chromeDriver)
{
    private static By HeaderTitleSelector => By.XPath("//*[@data-automation-id='jobPostingHeader']");

    public string GetPositionHeadingText()
    {
        var headingText = chromeDriver.FindElement(HeaderTitleSelector).Text;
        return headingText;
    }

    public void WaitForPageToBeLoaded()
    {
        chromeDriver.WaitForElement(HeaderTitleSelector);
    }
}