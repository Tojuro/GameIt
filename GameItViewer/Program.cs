using GameItShared;
using GameItViewerUI;
using Microsoft.Xna.Framework;
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
                    ProgressBar = new GameItShared.ProgressBar
                    {
                        HasBackBar = true,
                        BackBar = new Bar
                        {
                            Text = "Backlog",
                            Length = 0,
                            Start = 0,
                            TextAlign = TextAlign.Right
                        },
                        BarLayers = new System.Collections.Generic.List<Bar>
                        {
                            new Bar
                            {
                                Text = "Target",
                                Length = 990,
                                Color = Color.Red,
                                TextAlign = TextAlign.Right
                            },
                            new Bar
                            {
                                Text = "Current",
                                Length = 500,
                                Color = Color.Green,
                                TextAlign = TextAlign.Left
                            },
                        }
                    }
                };

                using (var game = new View(viewDef))
                    game.Run();
            }

        }
    }
#endif
}
