using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TestProject1.Utilities;

public class KeyboardManipulations
{
    public static void UploadPhoto()
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
        Thread.Sleep(5000);
    }
}