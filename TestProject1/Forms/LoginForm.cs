using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Forms;

public class LoginForm : Form
{
    private ITextBox passwordField =
        ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Choose Password')]"), "password field");

    private ITextBox emailBodyField =
        ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Your email')]"), "mail body");

    private ITextBox emailTailField =
        ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder, 'Domain')]"), "mail tail");

    private IButton showListButton =
        ElementFactory.GetButton(By.XPath("//span[contains(@class, 'icon-chevron-down')]"), "mail tail list button");

    private IButton orgButton =
        ElementFactory.GetButton(By.XPath("//div[contains(text(), '.org')]"), ".org option");

    private IButton termsCheckBox =
        ElementFactory.GetButton(By.XPath("//span[contains(@class, 'checkbox__check')]"), "terms checkbox");

    private IButton nextButton =
        ElementFactory.GetButton(By.XPath("//a[contains(text(), 'Next')]"), "next button");

    public LoginForm() : base(By.XPath("//div[contains(@class, 'login-form')]"),
        "Login form")
    {
    }

    public void SendPassword(String password)
    {
        passwordField.ClearAndType(password);
    }

    public void SendMailBody(String body)
    {
        emailBodyField.ClearAndType(body);
    }

    public void SendMailTail(String tail)
    {
        emailTailField.ClearAndType(tail);
    }

    public void SelectMailTail()
    {
        showListButton.Click();
        orgButton.Click();
    }

    public void CheckTerms()
    {
        termsCheckBox.Click();
    }

    public void ClickNextButton()
    {
        nextButton.Click();
    }
}