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
    private ILink link = ElementFactory.GetLink(By.XPath("//a[@class='start__link']"), "link");

    public MainPageObject() : base(By.XPath("//a[@class='start__link']"),
        "User Interface main page")
    {
    }

    public void ClickLink() => link.Click();
}