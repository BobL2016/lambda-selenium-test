using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace lambda_selenium_test
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(FunctionInput input, ILambdaContext context)
        {
            var output = "";
            output += "**** ifconfig" + Environment.NewLine;
            output += "ifconfig".Bash() + Environment.NewLine;
            output += "**** /usr/sbin/route" + Environment.NewLine;
            output += "/usr/sbin/route".Bash() + Environment.NewLine;
            output += "**** PING: google.com" + Environment.NewLine;
            output += "ping -c 4 google.com".Bash() + Environment.NewLine;
            output += "**** PING: 127.0.0.1" + Environment.NewLine;
            output += "ping -c 4 127.0.0.1".Bash() + Environment.NewLine;
            Console.WriteLine(output);

            return output;

        //     Console.WriteLine($"input.Url: {input.Url.ToString()}");

        //     // Setup Selenium driver
        //     ChromeOptions chromeOptions = new ChromeOptions();
        //     chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
        //     chromeOptions.AddArgument("--no-sandbox");
        //     chromeOptions.AddArgument("--headless");
        //     chromeOptions.AddArgument("--verbose");
        //     chromeOptions.AddArgument("--disable-dev-shm-usage");


        //     // Console.WriteLine(input.GoToUrl);
        //     IWebDriver driver = null;

        //     if (input.UseChromeDriver)
        //     {
        //         driver = new ChromeDriver(chromeOptions);
        //     }

        //     if (input.GoToUrl)
        //     {
        //         driver.Navigate().GoToUrl(input.Url);
        //         var about = driver.FindElement(By.LinkText("About"));
        //         Console.WriteLine($"about.Text: {about.Text}");
        //     }
        //     return input.Url.ToString();
        }
    }

    public record Casing(string Lower, string Upper);

    public class FunctionInput
    {
        public Uri Url { get; set; }
        public bool UseChromeDriver { get; set; }
        public bool GoToUrl { get; set; }
    }
}
