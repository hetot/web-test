using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Forms;

public class TimerPageObject : Form
{
    private IButton hideHelpButton =
        ElementFactory.GetButton(By.XPath("//span[contains(text(), 'to bottom')]"), "to bottom");

    private IButton cookiesAcceptButton =
        ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Not really')]"), "Accept cookies");

    private ITextBox timer = ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'timer')]"), "timer element");

    private ITextBox heplForm =
        ElementFactory.GetTextBox(By.XPath("//div[@class='help-form is-hidden']"), "help form is hidden");

    public TimerPageObject() : base(By.XPath("//div[contains(@class, 'timer')]"),
        "Page with timer")
    {
    }

    public void HideHelp()
    {
        hideHelpButton.Click();
    }

    public bool HelpFormIsHidden()
    {
        return heplForm.State.IsExist;
    }

    public void AcceptCookies()
    {
        cookiesAcceptButton.Click();
    }

    public bool CookiesFormPresented()
    {
        return cookiesAcceptButton.State.IsExist;
    }

    public String GetTimer()
    {
        return timer.GetText();
    }
}