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
    public class ProblemsTestsFormTests : Tests
    {
        protected override string Name { get; set; } = "ProblemsTestsForm";

        [Test]
        public void T01_DataChanged()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            var problemsTestsForm = session.FindElementByAccessibilityId("ProblemsTestsForm");
            var prevTitle = problemsTestsForm.GetAttribute("Name");
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            var curTitle = problemsTestsForm.GetAttribute("Name");
            session.FindElementByAccessibilityId("btnOK").Click();

            Assert.AreEqual("*" + prevTitle, curTitle);
        }

        [Test]
        public void T02_InnerDataChanged()
        {
            OpenTestSessionFile("T02_InnerDataChanged.tsb3");

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            var problemsTestsForm = session.FindElementByAccessibilityId("ProblemsTestsForm");
            var prevTitle = problemsTestsForm.GetAttribute("Name");
            session.FindElementByAccessibilityId("tbInputData").SendKeys("1");
            var curTitle = problemsTestsForm.GetAttribute("Name");
            session.FindElementByAccessibilityId("btnOK").Click();

            Assert.AreEqual("*" + prevTitle, curTitle);
        }

        [Test]
        public void T03_UpdateDgvProblems()
        {
            OpenTestSessionFile("T03_UpdateDgvProblems.tsb3");

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            session.FindElementByName("Задание Строка 0");
            session.FindElementByAccessibilityId("btnOK").Click();
            Assert.Pass();
        }

        [Test]
        public void T07_UpdateUpdDelBtnEnable()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            Assert.IsFalse(session.FindElementByAccessibilityId("btnDeleteProblem").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("btnUpdateProblem").Enabled);

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            Assert.IsTrue(session.FindElementByAccessibilityId("btnDeleteProblem").Enabled);
            Assert.IsTrue(session.FindElementByAccessibilityId("btnUpdateProblem").Enabled);

            session.FindElementByAccessibilityId("btnDeleteProblem").Click();

            Assert.IsFalse(session.FindElementByAccessibilityId("btnDeleteProblem").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("btnUpdateProblem").Enabled);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T08_UpdateTestPanel()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddTest").Click();

            var test = session.FindElementByName("Тест Строка 0");
            Assert.AreEqual(test.GetAttribute("Value.Value"), "Тест 1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T11_tbInputData_TextChanged()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            session.FindElementByAccessibilityId("btnAddTest").Click();
            var tbInputData = session.FindElementByAccessibilityId("tbInputData");
            tbInputData.SendKeys("1");
            session.FindElementByName("Задание Строка 1").Click();
            Assert.IsTrue(string.IsNullOrEmpty(tbInputData.GetAttribute("Value.Value")));

            session.FindElementByName("Задание Строка 0").Click();
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T12_tbOutputData_TextChanged()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            session.FindElementByAccessibilityId("btnAddTest").Click();
            var tbOutputData = session.FindElementByAccessibilityId("tbOutputData");
            tbOutputData.SendKeys("1");
            session.FindElementByName("Задание Строка 1").Click();
            Assert.IsTrue(string.IsNullOrEmpty(tbOutputData.GetAttribute("Value.Value")));

            session.FindElementByName("Задание Строка 0").Click();
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T13_TestsSelectionChanged()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            session.FindElementByAccessibilityId("btnAddTest").Click();
            var tbInputData = session.FindElementByAccessibilityId("tbInputData");
            var tbOutputData = session.FindElementByAccessibilityId("tbOutputData");
            tbInputData.SendKeys("1");
            tbOutputData.SendKeys("1");
            session.FindElementByName("Задание Строка 1").Click();
            Assert.IsTrue(string.IsNullOrEmpty(tbInputData.GetAttribute("Value.Value")));
            Assert.IsTrue(string.IsNullOrEmpty(tbOutputData.GetAttribute("Value.Value")));
            Assert.IsFalse(session.FindElementByAccessibilityId("tbInputData").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("tbOutputData").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("btnDeleteTest").Enabled);

            session.FindElementByName("Задание Строка 0").Click();
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "1");
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "1");
            Assert.IsTrue(session.FindElementByAccessibilityId("tbInputData").Enabled);
            Assert.IsTrue(session.FindElementByAccessibilityId("tbOutputData").Enabled);
            Assert.IsTrue(session.FindElementByAccessibilityId("btnDeleteTest").Enabled);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T14_dgvTests_SelectionChanged()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            session.FindElementByAccessibilityId("btnAddTest").Click();
            var tbInputData = session.FindElementByAccessibilityId("tbInputData");
            var tbOutputData = session.FindElementByAccessibilityId("tbOutputData");
            tbInputData.SendKeys("1");
            tbOutputData.SendKeys("1");
            session.FindElementByAccessibilityId("btnAddTest").Click();
            Assert.IsTrue(string.IsNullOrEmpty(tbInputData.GetAttribute("Value.Value")));
            Assert.IsTrue(string.IsNullOrEmpty(tbOutputData.GetAttribute("Value.Value")));

            session.FindElementByName("Тест Строка 0").Click();
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "1");
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T15_btnAddTest_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddTest").Click();

            var test = session.FindElementByName("Тест Строка 0");
            Assert.AreEqual(test.GetAttribute("Value.Value"), "Тест 1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T16_btnAddSevTests_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            session.FindElementByAccessibilityId("btnAddSevTests").Click();
            
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"tests");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("1.txt").Click();
            (new Actions(session))
                .KeyDown(Keys.LeftShift)
                .Click(session.FindElementByName("2.txt"))
                .KeyUp(Keys.LeftShift)
                .Perform();
            session.FindElementByName("Открыть").Click();

            var tbInputData = session.FindElementByAccessibilityId("tbInputData");
            var tbOutputData = session.FindElementByAccessibilityId("tbOutputData");
            var test1 = session.FindElementByName("Тест Строка 0");
            test1.Click();
            Assert.AreEqual(test1.GetAttribute("Value.Value"), "Тест 1");
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "2");
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "2");

            var test2 = session.FindElementByName("Тест Строка 1");
            test2.Click();
            Assert.AreEqual(test2.GetAttribute("Value.Value"), "Тест 2");
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "1");
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T17_btnSelectFolder_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            session.FindElementByAccessibilityId("btnSelectFolder").Click();

            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + "tests");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            var dialog = session.FindElementByName("Выбор папки");
            dialog.FindElementByAccessibilityId("1").Click();

            var tbInputData = session.FindElementByAccessibilityId("tbInputData");
            var tbOutputData = session.FindElementByAccessibilityId("tbOutputData");
            var test1 = session.FindElementByName("Тест Строка 0");
            test1.Click();
            Assert.AreEqual(test1.GetAttribute("Value.Value"), "Тест 1");
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "1");
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "1");

            var test2 = session.FindElementByName("Тест Строка 1");
            test2.Click();
            Assert.AreEqual(test2.GetAttribute("Value.Value"), "Тест 2");
            Assert.AreEqual(tbInputData.GetAttribute("Value.Value"), "2");
            Assert.AreEqual(tbOutputData.GetAttribute("Value.Value"), "2");

            session.FindElementByAccessibilityId("btnOK").Click();
        }


        [Test]
        public void T19_btnDeleteTest_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddTest").Click();

            WindowsElement test = null;
            try { test = session.FindElementByName("Тест Строка 0"); } catch { };
            Assert.IsNotNull(test);

            session.FindElementByAccessibilityId("btnDeleteTest").Click();

            test = null;
            try { test = session.FindElementByName("Тест Строка 0"); } catch { };
            Assert.IsNull(test);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T20_btnAddProblem_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            WindowsElement problem = null;
            try { problem = session.FindElementByName("Задание Строка 0"); } catch { };
            Assert.IsNull(problem);

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            problem = null;
            try { problem = session.FindElementByName("Задание Строка 0"); } catch { };
            Assert.IsNotNull(problem);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T21_btnUpdateProblem_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            var problem = session.FindElementByName("Задание Строка 0");
            Assert.AreEqual(problem.GetAttribute("Value.Value"), "Задание 1");

            session.FindElementByAccessibilityId("btnUpdateProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("tbName").SendKeys("Задание 2");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            problem = session.FindElementByName("Задание Строка 0");
            Assert.AreEqual(problem.GetAttribute("Value.Value"), "Задание 2");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T22_btnDeleteProblem_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            WindowsElement problem = null;
            try { problem = session.FindElementByName("Задание Строка 0"); } catch { };
            Assert.IsNotNull(problem);

            session.FindElementByAccessibilityId("btnDeleteProblem").Click();

            problem = null;
            try { problem = session.FindElementByName("Задание Строка 0"); } catch { };
            Assert.IsNull(problem);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T26_dgvProblems_SelectionChanged()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddTest").Click();

            var problem1 = session.FindElementByName("Задание Строка 0");
            problem1.Click();
            WindowsElement test = null;
            try { test = session.FindElementByName("Тест Строка 0"); } catch { };
            Assert.IsNotNull(test);

            var problem2 = session.FindElementByName("Задание Строка 1");
            problem2.Click();
            test = null;
            try { test = session.FindElementByName("Тест Строка 0"); } catch { };
            Assert.IsNull(test);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T29_SwapRows()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            var cell1 = session.FindElementByName("Задание Строка 0");
            var cell2 = session.FindElementByName("Задание Строка 1");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "Задание 1");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "Задание 2");
            (new Actions(session)).ClickAndHold(cell1).MoveByOffset(1000, 1000).Release(cell2).Perform();
            cell1 = session.FindElementByName("Задание Строка 0");
            cell2 = session.FindElementByName("Задание Строка 1");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "Задание 2");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "Задание 1");

            session.FindElementByAccessibilityId("btnOK").Click();
        }
    }
}
