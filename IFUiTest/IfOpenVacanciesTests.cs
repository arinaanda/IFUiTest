using IFUiTest.Helpers;
using IFUiTest.Pages;
using OpenQA.Selenium.Chrome;

namespace IFUiTest;

public sealed class IfOpenVacanciesTests : IDisposable
{
    private readonly ChromeDriver _chromeDriver;
    private const string BaseUrl = "http://if.lv";
    private const string QasPositionExpectedTitle = "Quality Assurance Specialist";

    public IfOpenVacanciesTests()
    {
        _chromeDriver = new ChromeDriver();
        _chromeDriver.Manage().Window.Maximize();
    }

    [Fact]
    public void VerifyQasPositionHeadingTest()
    {
        try
        {
            // Open if.lv
            _chromeDriver.Navigate().GoToUrl(BaseUrl);
            var homePage = new HomePage(_chromeDriver);
            homePage.HandleCookieDialog();

            // Navigate to “Par If”
            var aboutPage = homePage.NavigateToAboutIf();

            // Navigate to “Darbs If”
            var workAtIfPage = aboutPage.NavigateToWorkAtIf();

            // Navigate to “Vakances”
            var vacanciesPage = workAtIfPage.NavigateToVacancies();

            // Click button that leads to Quality Assurance Specialist
            var qasPositionPage = vacanciesPage.NavigateToQasPosition();

            // Assert that heading is “Quality Assurance Specialist”
            qasPositionPage.WaitForPageToBeLoaded();
            Assert.Equal(QasPositionExpectedTitle, qasPositionPage.GetPositionHeadingText());
        }
        catch (Exception)
        {
            _chromeDriver.TakeScreenshot();
            throw;
        }
    }

    public void Dispose()
    {
        _chromeDriver.Quit();
        _chromeDriver.Dispose();
    }
}