using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using FluentAssertions;

namespace UnitTests
{
    public class UITestsFixture : IDisposable
    {
        public UIA3Automation Automation { get; }
        public Application Application { get; }

        public UITestsFixture()
        {
            Automation = new UIA3Automation();
            Application = Application.Launch(Path.Combine("C:\\Temp\\.ispp31\\course3\\PITPM\\lections\\09262025\\TestApp\\bin\\Debug\\net8.0-windows\\TestApp.exe"));
        }

        public void Dispose()
        {
            Application.Close();
            Automation.Dispose();
            Application.Dispose();
        }
    }

    public class UnitTest1(UITestsFixture fixture) : IClassFixture<UITestsFixture>
    {
        private UITestsFixture fixture = fixture;

        [Fact]
        public async Task Test1Async()
        {
            var window = fixture.Application.GetMainWindow(fixture.Automation);

            var button = window.FindFirstDescendant(c => c.ByText("ÆÌÈ!")).AsButton();

            button.Invoke();

            var input = window.FindFirstDescendant(c => c.ByAutomationId("InputTextBox")).AsTextBox();

            input.Enter("éöóêåí");

            var label = window.FindFirstDescendant(c => c.ByAutomationId("CountTextBlock")).AsLabel();

            await Task.Delay(250);
            window.CaptureToFile("screen1.png");
            await Task.Delay(250);
            label.Text.Should().Be("1");

            var label1 = window.FindFirstDescendant(c => c.ByAutomationId("CountTextBlock")
                                            .Or(c.ByControlType(ControlType.Text))).AsLabel();
        }
    }
}