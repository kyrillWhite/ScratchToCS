using System;
using System.IO;
using NUnit.Framework;
using AutoTestApp;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace UnitTestsOfAppliction
{
    public abstract class Tests
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string TestApp = @"\AutoTestApp\bin\Debug\net5.0-windows\AutoTestApp.exe";
        protected virtual string Name { get; set; } = "";
        protected string TestFilesPath;

        protected static WindowsDriver<WindowsElement> session;
        public static WindowsDriver<WindowsElement> desktopSession;

        [SetUp]
        public void Setup()
        {
            if (session == null || desktopSession == null)
            {
                TearDown();
                var projectPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;

                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("app", projectPath + TestApp);
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                options.AddAdditionalCapability("platformName", "Windows");

                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

                AppiumOptions optionsDesktop = new AppiumOptions();
                optionsDesktop.AddAdditionalCapability("app", "Root");
                optionsDesktop.AddAdditionalCapability("deviceName", "WindowsPC");
                optionsDesktop.AddAdditionalCapability("ms:experimental-webdriver", true);
                desktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), optionsDesktop);

                TestFilesPath = projectPath + $@"\Example\appTests\{Name}\";
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (session != null)
            {
                session.FindElementByName("Закрыть").Click();
                WindowsElement dialog = null;
                try { dialog = session.FindElementByName("Завершение работы"); } catch { };
                if (dialog != null)
                {
                    dialog.FindElementByName("Нет").Click();
                }
                session.Quit();
                session = null;
            }

            if (desktopSession != null)
            {
                desktopSession.Quit();
                desktopSession = null;
            }
            File.Delete(TestFilesPath + @"\test.tsb3");
        }
        protected void OpenTestSessionFile(string testName)
        {
            session.FindElementByName("Файл").Click();
            session.FindElementByName("Открыть...").Click();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName(testName).Click();
            session.FindElementByName("Открыть").Click();
        }
    }
}
