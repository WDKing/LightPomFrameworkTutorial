using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCreatingReports.Instructor
{
    [TestClass]
    public static class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
