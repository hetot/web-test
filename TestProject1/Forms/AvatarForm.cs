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

    public AvatarForm() : base(By.XPath("//h2[contains(text(), 'This is me')]"), "avatar form")
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

    public void CheckThreeInterests()
    {
        ElementFactory.GetButton(By.XPath("//label[@for='interest_ponies']"), "ponies interest").Click();
        ElementFactory.GetButton(By.XPath("//label[@for='interest_polo']"), "polo interest").Click();
        ElementFactory.GetButton(By.XPath("//label[@for='interest_dough']"), "dough interest").Click();
    }

    public void UploadPhoto()
    {
        Thread.Sleep(1000);
        var proc1 = new Process
        {
            StartInfo =
            {
                FileName = Regex.Replace(Environment.CurrentDirectory, "bin.*", "") +
                           "Resources/simulateKey.sh",
                // Arguments = args,
                UseShellExecute = false,
                RedirectStandardError = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = false
            }
        };
        proc1.Start();
    }

    public void ClickNext()
    {
        nextButton.Click();
    }
}