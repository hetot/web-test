using System.Text.RegularExpressions;
using Aquality.Selenium.Browsers;
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
        browser.Maximize();
        mainPage = new MainPageObject();
        timerPage = new TimerPageObject();
        Console.WriteLine(Regex.Replace(Environment.CurrentDirectory, "bin.*", "") +
                          "Resources/test_data.json");
        TestDataLoader.Instance.LoadTestData(Regex.Replace(Environment.CurrentDirectory, "bin.*", "") +
                                             "Resources/test_data.json");
        testData = TestDataLoader.Instance.GetTestData();
    }

    [SetUp]
    public void Setup()
    {
        browser.GoTo("https://userinyerface.com/");
        browser.WaitForPageToLoad();
    }

    [Test]
    public void TestCase1()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();

        LoginForm loginForm = new LoginForm();
        Assert.True(loginForm.State.IsDisplayed, "card 1 is not displayed");
        loginForm.SendPassword(testData.password);
        loginForm.SendMailBody(testData.mail_body);
        loginForm.SendMailTail(testData.mail_tail);
        loginForm.SelectMailTail();
        loginForm.CheckTerms();
        loginForm.ClickNextButton();

        AvatarForm avatarForm = new AvatarForm();
        Assert.True(avatarForm.State.IsDisplayed, "card 2 is not displayed");
        avatarForm.ClickUpload();
        avatarForm.UploadPhoto();
        Thread.Sleep(5000);
        avatarForm.UncheckAll();
        avatarForm.CheckThreeInterests();
        Thread.Sleep(1000);
        avatarForm.ClickNext();
        Assert.True(new DetailsForm().State.IsDisplayed, "card 3 is not displayed");
    }

    [Test]
    public void TestCase2()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();
        timerPage.HideHelp();
        Assert.True(timerPage.HelpFormIsHidden(), "Help form is not hidden");
    }

    [Test]
    public void TestCase3()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();
        timerPage.AcceptCookies();
        Assert.False(timerPage.CookiesFormPresented(), "cookies form is not disappeared");
    }

    [Test]
    public void TestCase4()
    {
        Assert.True(mainPage.State.IsDisplayed, "main page is not opened");
        mainPage.ClickLink();
        Assert.True(timerPage.GetTimer().Equals("00:00:00"), "timer is not started from 00:00:00");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        browser.Quit();
    }
}