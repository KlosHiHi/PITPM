using FlaUI.Core;
using FlaUI.UIA3;

namespace WpfTest
{
    public class UITestsFixture : IDisposable
    {
        public UIA3Automation Automation { get; set; }
        public Application Application { get; set; }

        public UITestsFixture()
        {
            Automation = new UIA3Automation();
            //Application = Application.Launch("C:\\lab8\\Wpf\\bin\\Debug\\net8.0-windows\\SimpleWpf.exe");
            Application = Application.Launch("C:\\Temp\\.ispp31\\course3\\PITPM\\labs\\lab8\\Wpf\\bin\\Debug\\net8.0-windows\\SimpleWpf.exe");
        }

        public void Dispose()
        {
            Application.Close();
            Application.Dispose();
            Automation.Dispose();
        }
    }
}
