using CflowAutomationFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CflowAutomationFramework.Tests
{
    [TestClass]
    [TestCategory("LoginFeature"), TestCategory("Regression")]
    public class LoginFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Validate that user is able to login successfully using valid data.")]
        [TestProperty("Author", "Naren")]
        public void TCID1()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            AssertPageVisible(cflowDashboardPage);
        }

        [TestMethod]
        [Description("Validate that user gets 'Invalid Client.' error message with invalid client id.")]
        [TestProperty("Author", "Naren")]
        public void TCID2()
        {
            TheTestUser.clientId = "abc.com";
            CflowLoginPage.GoTo();
            CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            AssertInvalidClientErrorMessage();
        }

        [TestMethod]
        [Description("Validate that user gets 'Invalid Username Or Password.' error message with invalid username.")]
        [TestProperty("Author", "Naren")]
        public void TCID3()
        {
            TheTestUser.userName = "xyz@abc.com";
            CflowLoginPage.GoTo();
            CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            AssertInvalidUsernameOrPasswordErrorMessage();
        }

        [TestMethod]
        [Description("Validate that user gets 'Invalid Username Or Password.' error message with invalid password.")]
        [TestProperty("Author", "Naren")]
        public void TCID4()
        {
            TheTestUser.password = "xyz1";
            CflowLoginPage.GoTo();
            CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            AssertInvalidUsernameOrPasswordErrorMessage();
        }

        private static void AssertPageVisible(CflowDashboardPage cflowDashboardPage)
        {
            Assert.IsTrue(cflowDashboardPage.IsVisible, "Cflow dashboard page was not visible.");
        }

        private void AssertInvalidClientErrorMessage()
        {
            Assert.AreEqual(CflowLoginPage.ErrorMessage.Text, "Invalid Client.");
        }

        private void AssertInvalidUsernameOrPasswordErrorMessage()
        {
            Assert.AreEqual(CflowLoginPage.ErrorMessage.Text, "Invalid Username Or Password.");
        }
    }
}
