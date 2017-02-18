using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Project.Biz;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Web.Test
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void Test()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://m.jiaoyimao.com/";
        }
    }
}
