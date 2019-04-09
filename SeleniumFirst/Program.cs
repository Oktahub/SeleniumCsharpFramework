using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    class Program
    {

        static void Main(string[] args)
        {

        }

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();

            PropertiesCollection.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            
        }

        [Test]
        public void ExecuteTest()
        {
            ExcelLibrary.PopulateInCollection(@"C:\Data.xlsx");

            LoginPageObject pageLogin = new LoginPageObject();
            EAPageObject pageEA = pageLogin.Login(ExcelLibrary.ReadData(1, "UserName"), ExcelLibrary.ReadData(1, "Password"));

            pageEA.FillUserForm(ExcelLibrary.ReadData(1, "Initial"), ExcelLibrary.ReadData(1, "MiddleName"), ExcelLibrary.ReadData(1, "FirstName"));

            
            //EAPageObject pageEA = pageLogin.Login("Oktav", "Selenium");
            //pageEA.FillUserForm("OS", "Oktav", "Selenium");
            
            //SeleniumSetMethods.SelectDropDown("TitleId", "Mr.", propertyType.Id);

            //SeleniumSetMethods.EnterText("Initial", "Oktav", propertyType.Name);
            //Console.WriteLine("The value from my Title is: " + SeleniumGetMethods.GetText("TitleId", propertyType.Id));
            //Console.WriteLine("The value from my Initial is: " + SeleniumGetMethods.GetText("Initial", propertyType.Name));

            //SeleniumSetMethods.Click("Save", propertyType.Name);
        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
        }
    }
}
