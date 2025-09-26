using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace UnitTests
{
    public class UITestsFixture : IDisposable
    {
        public UIA3Automation Automation { get; }
        public Application Application { get; }

        public UITestsFixture() 
        { 
            Automation = new UIA3Automation();
            Application = Application.Launch(Path.Combine(Environment.CurrentDirectory, "TestApp.exe"));
        }

        public void Dispose() 
        { 
            Automation.Dispose();
            Application.Dispose();
        }
    } 

    public class UnitTest1(UITestsFixture fixture) :IClassFixture<UITestsFixture>
    {
        private UITestsFixture fixture = fixture;

        [Fact]
        public void Test1()
        {
            var window = fixture.Application.GetMainWindow(fixture.Automation);

            var button = window.FindFirstDescendant(c=> c.ByText("∆Ã»!")).AsButton;

            button.Invoke();
        }
    }
}