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
    public class AddUpdateProblemFormTests : Tests
    {
        protected override string Name { get; set; } = "AddUpdateProblemForm";

        [Test]
        public void T01_btnOK_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Добавить задание").Click();
            session.FindElementByAccessibilityId("btnOK").Click();
            WindowsElement column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { };
            Assert.IsNotNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            session.FindElementByAccessibilityId("btnUpdateProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("tbName").SendKeys("Задание 2");
            addUpdateProblemForm.FindElementByAccessibilityId("btnOK").Click();
            session.FindElementByAccessibilityId("btnOK").Click();
            column = null;
            try { column = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNotNull(column);
        }

        [Test]
        public void T02_btnCancel_Click()
        {
            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Добавить задание").Click();
            session.FindElementByAccessibilityId("btnCancel").Click();
            WindowsElement column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { };
            Assert.IsNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Добавить задание").Click();
            session.FindElementByAccessibilityId("btnOK").Click();
            column = null;
            try { column = session.FindElementByName("Задание 1"); } catch { };
            Assert.IsNotNull(column);

            session.FindElementByName("Задания и Тесты").Click();
            session.FindElementByName("Подробности").Click();
            session.FindElementByAccessibilityId("btnUpdateProblem").Click();
            var addUpdateProblemForm = session.FindElementByAccessibilityId("AddUpdateProblemForm");
            addUpdateProblemForm.FindElementByAccessibilityId("tbName").SendKeys("Задание 2");
            addUpdateProblemForm.FindElementByAccessibilityId("btnCancel").Click();
            session.FindElementByAccessibilityId("btnOK").Click();
            column = null;
            try { column = session.FindElementByName("Задание 2"); } catch { };
            Assert.IsNull(column);
        }
    }
}
