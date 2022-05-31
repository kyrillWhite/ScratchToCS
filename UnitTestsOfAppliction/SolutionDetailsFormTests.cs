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
    public class SolutionDetailsFormTests : Tests
    {
        protected override string Name { get; set; } = "SolutionDetailsForm";

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
