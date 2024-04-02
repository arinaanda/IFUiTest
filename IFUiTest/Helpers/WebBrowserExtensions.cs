using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace IFUiTest.Helpers;

public static class WebBrowserExtensions
{
    public static void TakeScreenshot(this IWebDriver chromeDriver)
    {
        var screenshot = ((ITakesScreenshot)chromeDriver).GetScreenshot();
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
        Directory.CreateDirectory(directory);
        screenshot?.SaveAsFile(Path.Combine(directory, "FailedTest.png"));
    }

    public static void ScrollToElement(this IWebDriver chromeDriver, IWebElement element)
    {
        var actions = new Actions(chromeDriver);
        actions.MoveToElement(element).Perform();
    }

    public static void WaitForElement(this IWebDriver chromeDriver, By selector, TimeSpan? timeout = null)
    {
        var waitTime = timeout ?? TimeSpan.FromSeconds(10);
        var wait = new WebDriverWait(chromeDriver, waitTime);
        wait.Until(driver => driver.FindElement(selector));
    }
}