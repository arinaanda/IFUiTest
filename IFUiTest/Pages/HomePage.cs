using OpenQA.Selenium;

namespace IFUiTest.Pages;

internal class HomePage(IWebDriver chromeDriver)
{
    private static By AboutIfSelector => By.LinkText("Par If");
    private static By CookieDialogSelector => By.Id("onetrust-banner-sdk");
    private static By RejectAllCookiesSelector => By.Id("onetrust-reject-all-handler");

    public AboutPage NavigateToAboutIf()
    {
        chromeDriver.FindElement(AboutIfSelector).Click();
        return new AboutPage(chromeDriver);
    }

    public void HandleCookieDialog()
    {
        if (CookieDialogDisplayed())
        {
            chromeDriver.FindElement(RejectAllCookiesSelector).Click();
        }
    }

    private bool CookieDialogDisplayed()
    {
        try
        {
            return chromeDriver.FindElement(CookieDialogSelector).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}