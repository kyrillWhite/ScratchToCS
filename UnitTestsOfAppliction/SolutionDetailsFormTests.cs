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
    public class SolutionDetailsFormTests
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string TestApp = @"\AutoTestApp\bin\Debug\net5.0-windows\AutoTestApp.exe";
        private string testFilesPath;

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

                testFilesPath = projectPath + @"\Example\appTests\SolutionDetailsForm\";
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
            File.Delete(testFilesPath + @"\test.tsb3");
        }

        private void OpenTestSessionFile(string testName)
        {
            session.FindElementByName("Файл").Click();
            session.FindElementByName("Открыть...").Click();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(testFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName(testName).Click();
            session.FindElementByName("Открыть").Click();
        }

        [Test]
        public void T01_UpdateButtons()
        {
            OpenTestSessionFile("T01-T06.tsb3");

            session.FindElementByName("Задание 1 Строка 0, Не отсортировано.").Click();
            Assert.IsFalse(session.FindElementByAccessibilityId("btnTestAll").Enabled);
            session.FindElementByAccessibilityId("btnExit").Click();

            session.FindElementByName("Задание 2 Строка 0, Не отсортировано.").Click();
            Assert.IsTrue(session.FindElementByAccessibilityId("btnTestAll").Enabled);
            session.FindElementByAccessibilityId("btnExit").Click();

            session.FindElementByName("Задание 3 Строка 0, Не отсортировано.").Click();
            Assert.IsFalse(session.FindElementByAccessibilityId("btnTestAll").Enabled);
            session.FindElementByAccessibilityId("btnExit").Click();
        }

        [Test]
        public void T02_UpdateDgvTests()
        { 
            OpenTestSessionFile("T01-T06.tsb3");

            session.FindElementByName("Задание 2 Строка 0, Не отсортировано.").Click();
            var cell1 = session.FindElementByName("Тест Строка 0");
            var cell2 = session.FindElementByName("Ошибка выполнения Строка 0");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "Тест 1");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "Время выполнения программы превысило заданное ограничение (0.5 сек).");
            session.FindElementByAccessibilityId("btnExit").Click();

            session.FindElementByName("Задание 3 Строка 0, Не отсортировано.").Click();
            cell1 = session.FindElementByName("Тест Строка 0");
            cell2 = session.FindElementByName("Ошибка выполнения Строка 0");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "Тест 1");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "(null)");
            session.FindElementByAccessibilityId("btnExit").Click();
        }

        [Test]
        public void T05_btnDeleteSolution_Click()
        {
            OpenTestSessionFile("T01-T06.tsb3");

            var cell = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell.GetAttribute("Value.Value"), "0/0");
            cell.Click();
            session.FindElementByAccessibilityId("btnDeleteSolution").Click();
            cell = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell.GetAttribute("Value.Value"), "Выбрать...");
        }

        [Test]
        public void T06_dgvTests_SelectionChanged()
        {
            OpenTestSessionFile("T01-T06.tsb3");

            session.FindElementByName("Задание 2 Строка 0, Не отсортировано.").Click();
            session.FindElementByName("Тест Строка 0").Click();
            var tbInputTest = session.FindElementByAccessibilityId("tbInputTest");
            var tbOutputTest = session.FindElementByAccessibilityId("tbOutputTest");
            Assert.IsTrue(string.IsNullOrEmpty(tbInputTest.GetAttribute("Value.Value")));
            Assert.IsTrue(string.IsNullOrEmpty(tbOutputTest.GetAttribute("Value.Value")));

            session.FindElementByName("Тест Строка 1").Click();
            tbInputTest = session.FindElementByAccessibilityId("tbInputTest");
            tbOutputTest = session.FindElementByAccessibilityId("tbOutputTest");
            Assert.AreEqual(tbInputTest.GetAttribute("Value.Value"), "1");
            Assert.AreEqual(tbOutputTest.GetAttribute("Value.Value"), "1");

            session.FindElementByAccessibilityId("btnExit").Click();
        }
    }
}
