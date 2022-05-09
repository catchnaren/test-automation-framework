using CflowAutomationFramework.Pages;
using CflowAutomationFramework.Pages.AddWorkflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CflowAutomationFramework.Tests
{
    [TestClass]
    [TestCategory("AddWorkflowPage"), TestCategory("Regression")]
    public class PreBuiltWorkflowCreationFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Validate that user is able to create pre-built 'Support Process' workflow successfully.")]
        [TestProperty("Author", "Naren")]
        public void TCID5()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            cflowDashboardPage.IsLoaded();
            var addWorkflowPage = cflowDashboardPage.NavigationMenu.addWorkflow();
            addWorkflowPage.GoTo();
            addWorkflowPage.NavigateToSupportProcessWorkflow();
            addWorkflowPage.UseThisWorkflow();
            AssertSuccessMessage(addWorkflowPage);
        }

        [TestMethod]
        [Description("Validate that user is able to create pre-built 'Meeting Notes Action Items' workflow successfully.")]
        [TestProperty("Author", "Naren")]
        public void TCID6()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            cflowDashboardPage.IsLoaded();
            var addWorkflowPage = cflowDashboardPage.NavigationMenu.addWorkflow();
            addWorkflowPage.GoTo();
            addWorkflowPage.NavigateToMeetingNotesActionItemsWorkflow();
            addWorkflowPage.UseThisWorkflow();
            AssertSuccessMessage(addWorkflowPage);
        }

        [TestMethod]
        [Description("Validate that user is able to create pre-built 'Work Order' workflow successfully.")]
        [TestProperty("Author", "Naren")]
        public void TCID7()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            cflowDashboardPage.IsLoaded();
            var addWorkflowPage = cflowDashboardPage.NavigationMenu.addWorkflow();
            addWorkflowPage.GoTo();
            addWorkflowPage.NavigateToWorkOrderWorkflow();
            addWorkflowPage.UseThisWorkflow();
            AssertSuccessMessage(addWorkflowPage);
        }

        [TestMethod]
        [Description("Validate that user is able to create pre-built 'Task Assignment Process' workflow successfully.")]
        [TestProperty("Author", "Naren")]
        public void TCID8()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            cflowDashboardPage.IsLoaded();
            var addWorkflowPage = cflowDashboardPage.NavigationMenu.addWorkflow();
            addWorkflowPage.GoTo();
            addWorkflowPage.NavigateToTaskAssignmentProcessWorkflow();
            addWorkflowPage.UseThisWorkflow();
            AssertSuccessMessage(addWorkflowPage);
        }

        [TestMethod]
        [Description("Validate that user is able to create pre-built 'Project Management' workflow successfully.")]
        [TestProperty("Author", "Naren")]
        public void TCID9()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            cflowDashboardPage.IsLoaded();
            var addWorkflowPage = cflowDashboardPage.NavigationMenu.addWorkflow();
            addWorkflowPage.GoTo();
            addWorkflowPage.NavigateToProjectManagementWorkflow();
            addWorkflowPage.UseThisWorkflow();
            AssertSuccessMessage(addWorkflowPage);
        }

        [TestMethod]
        [Description("Validate that user is able to create pre-built 'Bug Tracker' workflow successfully.")]
        [TestProperty("Author", "Naren")]
        public void TCID10()
        {
            CflowLoginPage.GoTo();
            var cflowDashboardPage = CflowLoginPage.FillOutLoginFormAndSubmit(TheTestUser);
            cflowDashboardPage.IsLoaded();
            var addWorkflowPage = cflowDashboardPage.NavigationMenu.addWorkflow();
            addWorkflowPage.GoTo();
            addWorkflowPage.NavigateToBugTrackerWorkflow();
            addWorkflowPage.UseThisWorkflow();
            AssertSuccessMessage(addWorkflowPage);
        }

        private static void AssertSuccessMessage(AddWorkflowPage addWorkflowPage)
        {
            Assert.AreEqual(addWorkflowPage.SuccessMessage.Text, "Your workflow has been created successfully and is now ready for use.");
        }
    }
}
