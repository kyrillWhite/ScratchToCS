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
    public class MainFormTests
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

                testFilesPath = projectPath + @"\Example\appTests\MainForm\";
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
        public void T01_DataChange()
        {
            var mainForm = session.FindElementByAccessibilityId("MainForm");
            var prevTitle = mainForm.GetAttribute("Name");
            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            session.FindElementByAccessibilityId("btnTestSelected").Click();
            var curTitle = mainForm.GetAttribute("Name");

            Assert.AreEqual(prevTitle, curTitle);

            OpenTestSessionFile("T01_DataChange.tsb3");
            prevTitle = mainForm.GetAttribute("Name");
            session.FindElementByAccessibilityId("btnTestSelected").Click();
            curTitle = mainForm.GetAttribute("Name");

            Assert.AreEqual("*" + prevTitle, curTitle);
        }

        [Test]
        public void T02_UpdateDgvTestResults()
        {
            OpenTestSessionFile("T02_UpdateDgvTestResults.tsb3");
            session.FindElementByName("Участник");
            session.FindElementByName("Задание 1");
            session.FindElementByName("Итог");
            Assert.Pass();
        }

        [Test]
        public void T03_UpdateDgvTestResultsRow()
        {
            OpenTestSessionFile("T03_UpdateDgvTestResultsRow.tsb3");
            var part1 = session.FindElementByName("Участник Строка 0, Не отсортировано.");
            var testRes1 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var score1 = session.FindElementByName("Итог Строка 0, Не отсортировано.");
            var part2 = session.FindElementByName("Участник Строка 1, Не отсортировано.");
            var testRes2 = session.FindElementByName("Задание 1 Строка 1, Не отсортировано.");
            var score2 = session.FindElementByName("Итог Строка 1, Не отсортировано.");

            Assert.AreEqual(part1.GetAttribute("Value.Value"), "Участник 1");
            Assert.AreEqual(testRes1.GetAttribute("Value.Value"), "1/1");
            Assert.AreEqual(score1.GetAttribute("Value.Value"), "1");
            Assert.AreEqual(part2.GetAttribute("Value.Value"), "Участник 2");
            Assert.AreEqual(testRes2.GetAttribute("Value.Value"), "0/1");
            Assert.AreEqual(score2.GetAttribute("Value.Value"), "0");
        }


        [Test]
        public void T04_SetCellStyle()
        {

            OpenTestSessionFile("T04_SetCellStyle.tsb3");
            var part = session.FindElementByName("Участник Строка 0, Не отсортировано.");
            var testRes1 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var testRes2 = session.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            var testRes3 = session.FindElementByName("Задание 3 Строка 0, Не отсортировано.");
            var testRes4 = session.FindElementByName("Задание 4 Строка 0, Не отсортировано.");
            var testRes5 = session.FindElementByName("Задание 5 Строка 0, Не отсортировано.");
            var testRes6 = session.FindElementByName("Задание 6 Строка 0, Не отсортировано.");
            var score = session.FindElementByName("Итог Строка 0, Не отсортировано.");

            Assert.AreEqual(part.GetAttribute("Value.Value"), "Участник 1");
            Assert.AreEqual(testRes1.GetAttribute("Value.Value"), "Выбрать...");
            Assert.AreEqual(testRes2.GetAttribute("Value.Value"), "?/1");
            Assert.AreEqual(testRes3.GetAttribute("Value.Value"), "1/2");
            Assert.AreEqual(testRes4.GetAttribute("Value.Value"), "0/1");
            Assert.AreEqual(testRes5.GetAttribute("Value.Value"), "1/2");
            Assert.AreEqual(testRes6.GetAttribute("Value.Value"), "1/1");
            Assert.AreEqual(score.GetAttribute("Value.Value"), "1.5");
        }


        [Test]
        public void T05_UpdateBtnEnable()
        {
            Assert.IsFalse(bool.Parse(session.FindElementByAccessibilityId("btnUpdatePartic")
                .GetAttribute("IsEnabled")));
            Assert.IsFalse(bool.Parse(session.FindElementByAccessibilityId("btnDeletePartic")
                .GetAttribute("IsEnabled")));
            Assert.IsFalse(bool.Parse(session.FindElementByAccessibilityId("btnTestSelected")
                .GetAttribute("IsEnabled")));
            Assert.IsFalse(bool.Parse(session.FindElementByAccessibilityId("btnTestAll")
                .GetAttribute("IsEnabled")));
            Assert.IsFalse(bool.Parse(session.FindElementByAccessibilityId("btnSaveTable")
                .GetAttribute("IsEnabled")));

            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();

            Assert.IsTrue(bool.Parse(session.FindElementByAccessibilityId("btnUpdatePartic")
                .GetAttribute("IsEnabled")));
            Assert.IsTrue(bool.Parse(session.FindElementByAccessibilityId("btnDeletePartic")
                .GetAttribute("IsEnabled")));
            Assert.IsTrue(bool.Parse(session.FindElementByAccessibilityId("btnTestSelected")
                .GetAttribute("IsEnabled")));
            Assert.IsTrue(bool.Parse(session.FindElementByAccessibilityId("btnTestAll")
                .GetAttribute("IsEnabled")));
            Assert.IsTrue(bool.Parse(session.FindElementByAccessibilityId("btnSaveTable")
                .GetAttribute("IsEnabled")));
        }

        [Test]
        public void T06_dgvTestResults_SelectionChanged()
        {
            T05_UpdateBtnEnable();
        }

        [Test]
        public void T07_btnAddPartic_Click()
        {
            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("AddParticipantForm");
            session.FindElementByAccessibilityId("btnNextFPage").Click();

            WindowsElement cell = null;
            try { cell = session.FindElementByName("Участник Строка 0, Не отсортировано."); } catch { }
            Assert.IsNotNull(cell);

            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("AddParticipantForm");
            session.FindElementByAccessibilityId("btnCancelFPage").Click();

            cell = null;
            try { cell = session.FindElementByName("Участник Строка 1, Не отсортировано."); } catch { }
            Assert.IsNull(cell);
        }

        [Test]
        public void T08_btnUpdatePartic_Click()
        {
            OpenTestSessionFile("T08_btnUpdatePartic_Click.tsb3");
            var cell = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell.GetAttribute("Value.Value"), "1/1");

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();
            session.FindElementByAccessibilityId("tbName").SendKeys("Участник");
            session.FindElementByAccessibilityId("btnCancel").Click();

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();
            session.FindElementByAccessibilityId("tbName").SendKeys("Участник");
            session.FindElementByAccessibilityId("btnOK").Click();

            Assert.AreEqual(cell.GetAttribute("Value.Value"), "?/1");


            WindowsElement column = null;
            try { column = session.FindElementByName("Задание 2"); } catch { }
            Assert.IsNull(column);

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnOK").Click();

            column = null;
            try { column = session.FindElementByName("Задание 2"); } catch { }
            Assert.IsNotNull(column);
        }

        [Test]
        public void T09_btnDeletePartic_Click()
        {
            OpenTestSessionFile("T09_btnDeletePartic_Click.tsb3");

            WindowsElement cell = null;
            try { cell = session.FindElementByName("Участник Строка 0, Не отсортировано."); } catch { }
            Assert.IsNotNull(cell);

            session.FindElementByAccessibilityId("btnDeletePartic").Click();

            cell = null;
            try { cell = session.FindElementByName("Участник Строка 0, Не отсортировано."); } catch { }
            Assert.IsNull(cell);
        }


        [Test]
        public void T12_AddSolution()
        {
            OpenTestSessionFile("T12_AddSolution.tsb3");

            var cell = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell.GetAttribute("Value.Value"), "Выбрать...");

            cell.Click();
            session.FindElementByName("solution.sb3").Click();
            session.FindElementByName("Отмена").Click();

            Assert.AreEqual(cell.GetAttribute("Value.Value"), "Выбрать...");

            cell.Click();
            session.FindElementByName("solution.sb3").Click();
            session.FindElementByName("Открыть").Click();

            Assert.AreEqual(cell.GetAttribute("Value.Value"), "?/0");
        }

        [Test]
        public void T13_dgvTestResults_CellMouseDown()
        {
            OpenTestSessionFile("T13_dgvTestResults_CellMouseDown.tsb3");

            session.FindElementByName("Задание 1 Строка 0, Не отсортировано.").Click();
            session.FindElementByAccessibilityId("SolutionDetailsForm");
            session.FindElementByAccessibilityId("btnExit").Click();

            Assert.Pass();
        }

        [Test]
        public void T14_tsmiProblemDetails_Click()
        {
            WindowsElement column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { }
            Assert.IsNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            var problemsTestsForm = session.FindElementByAccessibilityId("ProblemsTestsForm");
            problemsTestsForm.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            problemsTestsForm.FindElementByAccessibilityId("btnCancel").Click();

            column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { }
            Assert.IsNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            problemsTestsForm = session.FindElementByAccessibilityId("ProblemsTestsForm");
            problemsTestsForm.FindElementByAccessibilityId("btnAddProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            problemsTestsForm.FindElementByAccessibilityId("btnOK").Click();

            column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { }
            Assert.IsNotNull(column);
        }

        [Test]
        public void T15_tsmiProblemAdd_Click()
        {
            WindowsElement column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { }
            Assert.IsNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Добавить задание").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnCancel").Click();

            column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { }
            Assert.IsNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Добавить задание").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { }
            Assert.IsNotNull(column);
        }

        [Test]
        public void T16_tsmiAddParticipant_Click()
        {
            session.FindElementByName("Участники").Click();
            session.FindElementByName("Добавить").Click();
            session.FindElementByAccessibilityId("AddParticipantForm");
            session.FindElementByAccessibilityId("btnNextFPage").Click();

            WindowsElement cell = null;
            try { cell = session.FindElementByName("Участник Строка 0, Не отсортировано."); } catch { }
            Assert.IsNotNull(cell);

            session.FindElementByName("Участники").Click();
            session.FindElementByName("Добавить").Click();
            session.FindElementByAccessibilityId("AddParticipantForm");
            session.FindElementByAccessibilityId("btnCancelFPage").Click();

            cell = null;
            try { cell = session.FindElementByName("Участник Строка 1, Не отсортировано."); } catch { }
            Assert.IsNull(cell);
        }

        [Test]
        public void T17_tsmiRatio_Click()
        {
            OpenTestSessionFile("T17_tsmiRatio_Click.tsb3");

            var cell1 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var cell2 = session.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            cell1.Click();
            var solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
            cell2.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution2.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();

            session.FindElementByName("Решения").Click();
            session.FindElementByName("Соотношение с заданиями").Click();
            var ratioForm = session.FindElementByAccessibilityId("RatioForm");
            var _cell1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var _cell2 = ratioForm.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            (new Actions(session)).ClickAndHold(_cell1).MoveByOffset(1000, 1000).Release(_cell2).Perform();
            ratioForm.FindElementByAccessibilityId("btnCancel").Click();

            cell1 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            cell2 = session.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            cell1.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
            cell2.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution2.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();

            session.FindElementByName("Решения").Click();
            session.FindElementByName("Соотношение с заданиями").Click();
            ratioForm = session.FindElementByAccessibilityId("RatioForm");
            _cell1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            _cell2 = ratioForm.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            (new Actions(session)).ClickAndHold(_cell1).MoveByOffset(1000, 1000).Release(_cell2).Perform();
            ratioForm.FindElementByAccessibilityId("btnOK").Click();

            cell1 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            cell2 = session.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            cell1.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution2.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
            cell2.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
        }

        [Test]
        public void T26_ClearAll()
        {
            OpenTestSessionFile("T26_ClearAll.tsb3");

            WindowsElement cell1 = null, cell2 = null, cell3 = null, column = null;
            try { 
                cell1 = session.FindElementByName("Участник Строка 0, Не отсортировано."); 
                cell2 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано."); 
                cell3 = session.FindElementByName("Итог Строка 0, Не отсортировано.");
                column = session.FindElementByName("Задание 1"); 
            } catch { }
            Assert.IsNotNull(cell1);
            Assert.IsNotNull(cell2);
            Assert.IsNotNull(cell3);
            Assert.IsNotNull(column);

            session.FindElementByName("Файл").Click();
            session.FindElementByName("Создать").Click();
            cell1 = cell2 = cell3 = column = null;
            try
            {
                cell1 = session.FindElementByName("Участник Строка 0, Не отсортировано.");
                cell2 = session.FindElementByName("Задание Строка 0, Не отсортировано.");
                cell3 = session.FindElementByName("Итог Строка 0, Не отсортировано.");
                column = session.FindElementByName("Задание 1");
            }
            catch { }
            Assert.IsNull(cell1);
            Assert.IsNull(cell2);
            Assert.IsNull(cell3);
            Assert.IsNull(column);
        }

        [Test]
        public void T29_SaveAs()
        {
            session.FindElementByName("Файл").Click();
            session.FindElementByName("Сохранить как...").Click();
            (new Actions(session)).SendKeys("test").Perform();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(testFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("Отмена").Click();
            System.Threading.Thread.Sleep(500);
            Assert.IsFalse(File.Exists(testFilesPath + @"test.tsb3"));

            session.FindElementByName("Файл").Click();
            session.FindElementByName("Сохранить как...").Click();
            (new Actions(session)).SendKeys("test").Perform();
            session.FindElementByName("Все папки").Click();
            addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(testFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("Сохранить").Click();
            System.Threading.Thread.Sleep(500);
            Assert.IsTrue(File.Exists(testFilesPath + @"test.tsb3"));
            File.Delete(testFilesPath + @"test.tsb3");
        }

        [Test]
        public void T30_Save()
        {
            session.FindElementByName("Файл").Click();
            session.FindElementByName("Сохранить").Click();
            (new Actions(session)).SendKeys("test").Perform();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(testFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("Отмена").Click();
            System.Threading.Thread.Sleep(500);
            Assert.IsFalse(File.Exists(testFilesPath + @"test.tsb3"));

            session.FindElementByName("Файл").Click();
            session.FindElementByName("Сохранить").Click();
            (new Actions(session)).SendKeys("test").Perform();
            session.FindElementByName("Все папки").Click();
            addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(testFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("Сохранить").Click();
            System.Threading.Thread.Sleep(500);
            Assert.IsTrue(File.Exists(testFilesPath + @"test.tsb3"));

            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();

            session.FindElementByName("Файл").Click();
            session.FindElementByName("Сохранить").Click();
            System.Threading.Thread.Sleep(500);

            OpenTestSessionFile("test.tsb3");
            WindowsElement cell = null;
            try { cell = session.FindElementByName("Участник Строка 0, Не отсортировано."); } catch { }
            Assert.IsNotNull(cell);
            File.Delete(testFilesPath + @"test.tsb3");
        }
    }
}