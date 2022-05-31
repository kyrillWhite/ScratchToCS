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
    public class UpdateParticipantFormTests : Tests
    {
        protected override string Name { get; set; } = "UpdateParticipantForm";

        [Test]
        public void T01_UpdateUpdDelBtnEnable()
        {
            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            session.FindElementByAccessibilityId("btnUpdatePartic").Click();

            Assert.IsFalse(session.FindElementByAccessibilityId("btnDelSolution").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("btnUpdateSolution").Enabled);

            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();

            Assert.IsTrue(session.FindElementByAccessibilityId("btnDelSolution").Enabled);
            Assert.IsTrue(session.FindElementByAccessibilityId("btnUpdateSolution").Enabled);

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T04_UpdateDgvSolutions()
        {
            OpenTestSessionFile("T04_UpdateDgvSolutions.tsb3");

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();

            var updateParticipantForm = session.FindElementByAccessibilityId("UpdateParticipantForm");
            var problem1 = updateParticipantForm.FindElementByName("Задание Строка 0");
            var problem2 = updateParticipantForm.FindElementByName("Задание Строка 1");
            var sollution1 = updateParticipantForm.FindElementByName("Решение Строка 0");
            var sollution2 = updateParticipantForm.FindElementByName("Решение Строка 1");
            Assert.AreEqual(problem1.GetAttribute("Value.Value"), "Задание 1");
            Assert.AreEqual(problem2.GetAttribute("Value.Value"), "Задание 2");
            Assert.AreEqual(sollution1.GetAttribute("Value.Value"), "solution.sb3");
            Assert.AreEqual(sollution2.GetAttribute("Value.Value"), "Выбрать...");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T05_AddSolution()
        {
            OpenTestSessionFile("T05_AddSolution.tsb3");

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();

            var updateParticipantForm = session.FindElementByAccessibilityId("UpdateParticipantForm");
            var sollution1 = updateParticipantForm.FindElementByName("Решение Строка 0");
            Assert.AreEqual(sollution1.GetAttribute("Value.Value"), "Выбрать...");
            sollution1.Click();

            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("solution.sb3").Click();
            session.FindElementByName("Открыть").Click();

            sollution1 = updateParticipantForm.FindElementByName("Решение Строка 0");
            Assert.AreEqual(sollution1.GetAttribute("Value.Value"), "solution.sb3");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T06_SwapSolutions()
        {
            OpenTestSessionFile("T04_UpdateDgvSolutions.tsb3");

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();

            var updateParticipantForm = session.FindElementByAccessibilityId("UpdateParticipantForm");
            var cell1 = updateParticipantForm.FindElementByName("Решение Строка 0");
            var cell2 = updateParticipantForm.FindElementByName("Решение Строка 1");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "solution.sb3");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "Выбрать...");
            (new Actions(session)).ClickAndHold(cell1).MoveByOffset(1000, 1000).Release(cell2).Perform();
            cell1 = updateParticipantForm.FindElementByName("Решение Строка 0");
            cell2 = updateParticipantForm.FindElementByName("Решение Строка 1");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "Выбрать...");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "solution.sb3");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T07_btnOK_Click()
        {
            OpenTestSessionFile("T05_AddSolution.tsb3");

            WindowsElement problem = null;
            try { problem = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNull(problem);

            session.FindElementByAccessibilityId("btnUpdatePartic").Click(); 
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnOK").Click();

            problem = null;
            try { problem = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNotNull(problem);
        }

        [Test]
        public void T08_btnCancel_Click()
        {
            OpenTestSessionFile("T05_AddSolution.tsb3");

            WindowsElement problem = null;
            try { problem = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNull(problem);

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnCancel").Click();

            problem = null;
            try { problem = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNull(problem);
        }

        [Test]
        public void T10_btnDelSolution_Click()
        {
            OpenTestSessionFile("T10_btnDelSolution_Click.tsb3");

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();

            var solution = session.FindElementByName("Решение Строка 0");
            Assert.AreEqual(solution.GetAttribute("Value.Value"), "solution.sb3");
            session.FindElementByAccessibilityId("btnDelSolution").Click();
            solution = session.FindElementByName("Решение Строка 0");
            Assert.AreEqual(solution.GetAttribute("Value.Value"), "Выбрать...");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T11_btnUpdateSolution_Click()
        {
            OpenTestSessionFile("T10_btnDelSolution_Click.tsb3");

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();

            var solution = session.FindElementByName("Решение Строка 0");
            Assert.AreEqual(solution.GetAttribute("Value.Value"), "solution.sb3");
            session.FindElementByAccessibilityId("btnUpdateSolution").Click();

            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath);
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            session.FindElementByName("solution2.sb3").Click();
            session.FindElementByName("Открыть").Click();

            solution = session.FindElementByName("Решение Строка 0");
            Assert.AreEqual(solution.GetAttribute("Value.Value"), "solution2.sb3");

            session.FindElementByAccessibilityId("btnOK").Click();
        }

        [Test]
        public void T12_btnAddProblem_Click()
        {
            OpenTestSessionFile("T05_AddSolution.tsb3");

            WindowsElement problem = null;
            try { problem = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNull(problem);

            session.FindElementByAccessibilityId("btnUpdatePartic").Click();
            session.FindElementByAccessibilityId("btnAddProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnOK").Click();

            problem = null;
            try { problem = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNotNull(problem);
        }
    }
}
