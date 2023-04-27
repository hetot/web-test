using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Applications;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Element = Aquality.Selenium.Core.Elements.Element;

namespace TestProject1.Forms;

public class MainPageObject : Form
{
    private ILink link = AqualityServices.Get<IElementFactory>()
        .GetLink(By.XPath("//a[contains(text(), 'HERE')]"), "link");

    public MainPageObject() : base(By.XPath("//p[contains(text(), 'Hi and welcome to User')]"),
        "User Interface main page")
    {
    }

    public void ClickLink() => link.Click();
}