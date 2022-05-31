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
    public class RatioFormTests : Tests
    {
        protected override string Name { get; set; } = "RatioForm";

        [Test]
        public void T01_UpdateDgvRatio()
        {
            OpenTestSessionFile("T01_UpdateDgvRatio.tsb3");

            session.FindElementByName("Решения").Click();
            session.FindElementByName("Соотношение с заданиями").Click();
            var ratioForm = session.FindElementByAccessibilityId("RatioForm");
            ratioForm.FindElementByName("Участник");
            ratioForm.FindElementByName("Задание 1");
            ratioForm.FindElementByAccessibilityId("btnCancel").Click();
            Assert.Pass();
        }

        [Test]
        public void T02_UpdateDgvRatioRow()
        {
            OpenTestSessionFile("T02_UpdateDgvRatioRow.tsb3");

            session.FindElementByName("Решения").Click();
            session.FindElementByName("Соотношение с заданиями").Click();
            var ratioForm = session.FindElementByAccessibilityId("RatioForm");

            var part1 = ratioForm.FindElementByName("Участник Строка 0, Не отсортировано.");
            var testRes1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var part2 = ratioForm.FindElementByName("Участник Строка 1, Не отсортировано.");
            var testRes2 = ratioForm.FindElementByName("Задание 1 Строка 1, Не отсортировано.");

            Assert.AreEqual(part1.GetAttribute("Value.Value"), "Участник 1");
            Assert.AreEqual(testRes1.GetAttribute("Value.Value"), "Задача 1.sb3");
            Assert.AreEqual(part2.GetAttribute("Value.Value"), "Участник 2");
            Assert.AreEqual(testRes2.GetAttribute("Value.Value"), "задача 4.sb3");

            ratioForm.FindElementByAccessibilityId("btnCancel").Click();
        }

        [Test]
        public void T04_btnOK_Click()
        {
            OpenTestSessionFile("T04_btnOK_Click.tsb3");

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
            ratioForm.FindElementByAccessibilityId("btnOK").Click();

            cell1 = session.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            cell2 = session.FindElementByName("Задание 2 Строка 0, Не отсортировано."); cell1.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution2.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
            cell2.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
        }

        [Test]
        public void T05_btnCancel_Click()
        {
            OpenTestSessionFile("T05_btnCancel_Click.tsb3");

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
            cell2 = session.FindElementByName("Задание 2 Строка 0, Не отсортировано."); cell1.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
            cell2.Click();
            solutionDetailsForm = session.FindElementByAccessibilityId("SolutionDetailsForm");
            Assert.AreEqual(solutionDetailsForm.GetAttribute("Name"), "solution2.sb3");
            solutionDetailsForm.FindElementByAccessibilityId("btnExit").Click();
        }


        [Test]
        public void T09_SwapSolutions()
        {
            OpenTestSessionFile("T09_SwapSolutions.tsb3");

            session.FindElementByName("Решения").Click();
            session.FindElementByName("Соотношение с заданиями").Click();
            var ratioForm = session.FindElementByAccessibilityId("RatioForm");
            var cell1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var cell2 = ratioForm.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "solution.sb3");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "solution2.sb3");
            (new Actions(session)).ClickAndHold(cell1).MoveByOffset(1000, 1000).Release(cell2).Perform();
            cell1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            cell2 = ratioForm.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "solution2.sb3");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "solution.sb3");

            ratioForm.FindElementByAccessibilityId("btnCancel").Click();
        }

        [Test]
        public void T10_btnUpdate_Click()
        {
            OpenTestSessionFile("T10_btnUpdate_Click.tsb3");

            session.FindElementByName("Решения").Click();
            session.FindElementByName("Соотношение с заданиями").Click();
            var ratioForm = session.FindElementByAccessibilityId("RatioForm");
            var cell1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            var cell2 = ratioForm.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "solution2.sb3");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "solution.sb3");
            ratioForm.FindElementByAccessibilityId("btnUpdate").Click();
            cell1 = ratioForm.FindElementByName("Задание 1 Строка 0, Не отсортировано.");
            cell2 = ratioForm.FindElementByName("Задание 2 Строка 0, Не отсортировано.");
            Assert.AreEqual(cell1.GetAttribute("Value.Value"), "solution.sb3");
            Assert.AreEqual(cell2.GetAttribute("Value.Value"), "solution2.sb3");

            ratioForm.FindElementByAccessibilityId("btnCancel").Click();
        }
    }
}
