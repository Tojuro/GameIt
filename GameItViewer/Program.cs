using GameItShared;
using GameItViewerUI;
using System;
using System.Windows.Forms;

namespace GameItViewer
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var viewDefForm = new ViewDefinitionPicker();
            viewDefForm.ShowDialog();

            var valTxt = (TextBox)viewDefForm?.Controls["txtSelectedValue"];
            if (valTxt != null && valTxt?.Text.Length > 0)
            {
                var viewDef = new ViewDefinition
                {
                    ViewDefinitionName = valTxt.Text,
                };

                using (var game = new View(viewDef))
                    game.Run();
            }

        }
    }
#endif
}
