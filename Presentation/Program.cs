using Presentation.Forms;

namespace Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new EntryForm());
        }
    }
}