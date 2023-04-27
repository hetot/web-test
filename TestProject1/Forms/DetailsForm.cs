using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Forms;

public class DetailsForm : Form
{
    public DetailsForm() : base(By.XPath("//h3[contains(text(), 'Personal')]"), "personal details form")
    {
    }
}