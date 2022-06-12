using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Application.ViewModels.External.SomethingWrapper;

namespace TravelApp.Infrastructure.Services.Managers.WebScraping
{
    public class WebScrapingManager : IWebScrapingManager
    {
        private static IWebDriver driver;
        public async Task<List<SomethingWrapper>> GetSomethingFromURL(string url)
        {

            driver = new ChromeDriver("C:/Users/Facultate/source/repos/proiect_mds/Backend/TravelApp"); //path of the current project 
            driver.Navigate().GoToUrl("https://www.momondo.ro/explore/BUH-anywhere/20220709,20220716");
            Thread.Sleep(2000);
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var noThxButton = driver.FindElements(By.ClassName("Iqt3-button-content"));
            var wrapperArray = new List<SomethingWrapper>();


            if (noThxButton[2].Text == "Accept")
            {
                noThxButton[2].Click();
                Thread.Sleep(4000);
                var collections = driver.FindElements(By.ClassName("Button-No-Standard-Style"));

                for (int i = 9; i < 21; i++)
                {

                    //.WriteLine(collections[i].Text);
                    var text = collections[i].Text.Replace("\n", " ");
                    text = text.Replace("\r", "");
                    text = text.Replace(",", "");
                    var newString = text.Split(" ");
                    SomethingWrapper smthwrppr = new SomethingWrapper();
                    smthwrppr.OrasDestinatie = newString[0];
                    smthwrppr.TaraDestinatie = newString[5];
                    smthwrppr.PretInEuro = float.Parse(newString[3]);
                    smthwrppr.Perioada = newString[6] + " " + newString[7] + " " + newString[8] + "-" + newString[10] + " " + newString[11] + " " + newString[12];
                    wrapperArray.Add(smthwrppr);

                }

            }
            return wrapperArray;




        }
    }
}
