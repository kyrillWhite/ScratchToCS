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
    class AddParticipantFormTests : Tests
    {
        protected override string Name { get; set; } = "AddParticipantForm";

        [Test]
        public void T01_UpdateVisiblePart()
        {
            session.FindElementByAccessibilityId("btnAddPartic").Click();

            session.FindElementByAccessibilityId("rbAddWOSolution").Click();
            WindowsElement pnlDataWO = null;
            WindowsElement pnlDataW = null;
            WindowsElement pnlDataSev = null;
            try { pnlDataWO = session.FindElementByAccessibilityId("pnlDataWO"); } catch { };
            try { pnlDataW = session.FindElementByAccessibilityId("pnlDataW"); } catch { };
            try { pnlDataSev = session.FindElementByAccessibilityId("pnlDataSev"); } catch { };
            Assert.IsNotNull(pnlDataWO);
            Assert.IsNull(pnlDataW);
            Assert.IsNull(pnlDataSev);

            session.FindElementByAccessibilityId("rbAddWSolution").Click();
            pnlDataWO = null;
            pnlDataW = null;
            pnlDataSev = null;
            try { pnlDataWO = session.FindElementByAccessibilityId("pnlDataWO"); } catch { };
            try { pnlDataW = session.FindElementByAccessibilityId("pnlDataW"); } catch { };
            try { pnlDataSev = session.FindElementByAccessibilityId("pnlDataSev"); } catch { };
            Assert.IsNull(pnlDataWO);
            Assert.IsNotNull(pnlDataW);
            Assert.IsNull(pnlDataSev);

            session.FindElementByAccessibilityId("rbAddSevWSolution").Click();
            pnlDataWO = null;
            pnlDataW = null;
            pnlDataSev = null;
            try { pnlDataWO = session.FindElementByAccessibilityId("pnlDataWO"); } catch { };
            try { pnlDataW = session.FindElementByAccessibilityId("pnlDataW"); } catch { };
            try { pnlDataSev = session.FindElementByAccessibilityId("pnlDataSev"); } catch { };
            Assert.IsNull(pnlDataWO);
            Assert.IsNull(pnlDataW);
            Assert.IsNotNull(pnlDataSev);

            session.FindElementByAccessibilityId("btnCancelFPage").Click();
        }

        [Test]
        public void T02_SetChooseAddTypePage()
        {
            session.FindElementByAccessibilityId("btnAddPartic").Click();

            session.FindElementByAccessibilityId("rbAddWSolution").Click();

            WindowsElement pnlSelectAddTypePage = null;
            WindowsElement pnlUnpackProgress = null;
            try { pnlSelectAddTypePage = session.FindElementByAccessibilityId("pnlSelectAddTypePage"); } catch { };
            try { pnlUnpackProgress = session.FindElementByAccessibilityId("pnlUnpackProgress"); } catch { };
            Assert.IsNotNull(pnlSelectAddTypePage);
            Assert.IsNull(pnlUnpackProgress);

            session.FindElementByAccessibilityId("btnSelectFiles").Click();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"participants\participant1");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            var dialog = session.FindElementByName("Выбор папки");
            dialog.FindElementByAccessibilityId("1").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();

            pnlSelectAddTypePage = null;
            pnlUnpackProgress = null;
            try { pnlSelectAddTypePage = session.FindElementByAccessibilityId("pnlSelectAddTypePage"); } catch { };
            try { pnlUnpackProgress = session.FindElementByAccessibilityId("pnlUnpackProgress"); } catch { };
            Assert.IsNull(pnlSelectAddTypePage);
            Assert.IsNotNull(pnlUnpackProgress);

            WindowsElement btnCloseUnpack = null;
            while (btnCloseUnpack == null)
            {
                btnCloseUnpack = session.FindElementByAccessibilityId("btnCloseUnpack");
            }
            btnCloseUnpack.Click();
        }

        [Test]
        public void T04_btnNext_Click()
        {
            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("rbAddWOSolution").Click();
            var tbNameWO = session.FindElementByAccessibilityId("tbNameWO");
            tbNameWO.SendKeys("_");
            (new Actions(session)).SendKeys(Keys.Backspace).Perform();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            var messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();
            tbNameWO.SendKeys("Участник 1");
            session.FindElementByAccessibilityId("btnNextFPage").Click();


            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("rbAddWSolution").Click();

            var tbNameW = session.FindElementByAccessibilityId("tbNameW");
            tbNameW.SendKeys("_");
            (new Actions(session)).SendKeys(Keys.Backspace).Perform();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();
            tbNameW.SendKeys("Участник 1");
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();
            session.FindElementByAccessibilityId("btnSelectFiles").Click();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"participants\participant1");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            var dialog = session.FindElementByName("Выбор папки");
            dialog.FindElementByAccessibilityId("1").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            WindowsElement btnCloseUnpack = null;
            while (btnCloseUnpack == null)
            {
                btnCloseUnpack = session.FindElementByAccessibilityId("btnCloseUnpack");
            }
            btnCloseUnpack.Click();


            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("rbAddWSolution").Click();
            session.FindElementByAccessibilityId("rbSevFiles").Click();

            tbNameW = session.FindElementByAccessibilityId("tbNameW");
            tbNameW.SendKeys("_");
            (new Actions(session)).SendKeys(Keys.Backspace).Perform();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();
            tbNameW.SendKeys("Участник 1");
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();
            session.FindElementByAccessibilityId("btnSelectFiles").Click();
            session.FindElementByName("Все папки").Click();
            addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"participants\participant1");

            session.FindElementByName("solution1.sb3").Click();
            (new Actions(session))
                .KeyDown(Keys.LeftShift)
                .Click(session.FindElementByName("solution2.sb3"))
                .KeyUp(Keys.LeftShift)
                .Perform();
            session.FindElementByName("Открыть").Click();

            session.FindElementByAccessibilityId("btnNextFPage").Click();
            btnCloseUnpack = null;
            while (btnCloseUnpack == null)
            {
                btnCloseUnpack = session.FindElementByAccessibilityId("btnCloseUnpack");
            }
            btnCloseUnpack.Click();


            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("rbAddSevWSolution").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();

            session.FindElementByAccessibilityId("btnSelectFolders").Click();
            session.FindElementByName("Все папки").Click();
            addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"incorrectFolder");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            dialog = session.FindElementByName("Выбор папки");
            dialog.FindElementByAccessibilityId("1").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            messageBox = session.FindElementByClassName("#32770");
            messageBox.FindElementByAccessibilityId("2").Click();

            session.FindElementByAccessibilityId("btnSelectFolders").Click();
            session.FindElementByName("Все папки").Click();
            addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"participants");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            dialog = session.FindElementByName("Выбор папки");
            dialog.FindElementByAccessibilityId("1").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            btnCloseUnpack = null;
            while (btnCloseUnpack == null)
            {
                btnCloseUnpack = session.FindElementByAccessibilityId("btnCloseUnpack");
            }
            btnCloseUnpack.Click();
        }

        [Test]
        public void T08_btnCorrelation_Click()
        {
            session.FindElementByAccessibilityId("btnAddPartic").Click();
            session.FindElementByAccessibilityId("rbAddWSolution").Click();

            session.FindElementByAccessibilityId("btnSelectFiles").Click();
            session.FindElementByName("Все папки").Click();
            var addresField = session.FindElementByName("Адрес");
            addresField.SendKeys(TestFilesPath + @"participants\participant1");
            (new Actions(session)).SendKeys(Keys.Enter).Perform();
            var dialog = session.FindElementByName("Выбор папки");
            dialog.FindElementByAccessibilityId("1").Click();
            session.FindElementByAccessibilityId("btnNextFPage").Click();
            WindowsElement btnCorrelation = null;
            while (btnCorrelation == null)
            {
                btnCorrelation = session.FindElementByAccessibilityId("btnCorrelation");
            }
            btnCorrelation.Click();

            session.FindElementByAccessibilityId("btnCancel").Click();
        }
    }
}
