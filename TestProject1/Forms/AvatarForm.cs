using System.Diagnostics;
using System.Text.RegularExpressions;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Forms;

public class AvatarForm : Form
{
    private IButton uploadButton =
        ElementFactory.GetButton(By.XPath("//a[contains(text(), 'upload')]"), "upload button");

    private IButton uncheckAllButton =
        ElementFactory.GetButton(By.XPath("//label[@for='interest_unselectall']"), "uncheck all");

    private IButton nextButton =
        ElementFactory.GetButton(By.XPath("//button[contains(text(), 'Next')]"), "next button");

    public AvatarForm() : base(By.XPath("//*[contains(@class, 'avatar-and-interests')]"), "avatar form")
    {
    }

    public void ClickUpload()
    {
        uploadButton.WaitAndClick();
    }

    public void UncheckAll()
    {
        uncheckAllButton.Click();
    }

    public void CheckInterest(string interest)
    {
        ElementFactory.GetButton(By.XPath($"//label[@for='interest_{interest}']"), $"{interest} interest").Click();
    }

    public void ClickNext()
    {
        nextButton.Click();
    }
}