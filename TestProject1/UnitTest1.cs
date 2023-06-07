using System.Text.RegularExpressions;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Applications;
using TestProject1.Forms;
using TestProject1.Utilities;

namespace TestProject1;

public class Tests
{
    private Browser browser;
    private MainPageObject mainPage;
    private TimerPageObject timerPage;
    private TestData testData;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        browser = AqualityServices.Browser;
//         browser.Maximize();
        mainPage = new MainPageObject();
        timerPage = new TimerPageObject();
        TestDataLoader.Instance.LoadTestData();
        testData = TestDataLoader.Instance.GetTestData();
    }

    [SetUp]
    public void Setup()
    {
        browser.GoTo(testData.url);
        browser.WaitForPageToLoad();
    }

    [Test]
    public void LoginTest()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();

        LoginForm loginForm = new LoginForm();
        Assert.True(loginForm.State.IsDisplayed, "card 1 is not displayed");
        loginForm.SendPassword(RandomGenerator.GenerateRandomString(10) + testData.mail_body + "1" + "A");
        loginForm.SendMailBody(testData.mail_body);
        loginForm.SendMailTail(testData.mail_tail);
        loginForm.SelectMailTail();
        loginForm.CheckTerms();
        loginForm.ClickNextButton();

        // AvatarForm avatarForm = new AvatarForm();
        // Assert.True(avatarForm.State.IsDisplayed, "card 2 is not displayed");
        // avatarForm.ClickUpload();
        // KeyboardManipulations.UploadPhoto();
        // avatarForm.UncheckAll();
        // foreach (string interest in testData.interests)
        // {
        //     avatarForm.CheckInterest(interest);
        // }
        //
        // avatarForm.ClickNext();
        // Assert.True(new DetailsForm().State.IsDisplayed, "card 3 is not displayed");
    }

    [Test]
    public void HelpFormTest()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();
        timerPage.HideHelp();
        Assert.True(timerPage.HelpFormIsHidden(), "Help form is not hidden");
    }

    [Test]
    public void CookiesTest()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();
        timerPage.AcceptCookies();
        Assert.False(timerPage.CookiesFormPresented(), "cookies form is not disappeared");
    }

    [Test]
    public void TimerTest()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();
        Assert.True(timerPage.GetTimer().Equals(testData.timer), "timer is not started from 00:00:00");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        browser.Quit();
    }
}
