using GameItShared;
using GameItViewerUI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
                        BackBar = new TeamBar
                        {
                            Text = "Backlog",
                            Length = 0,
                            Start = 0,
                            TextAlign = TextAlign.Right
                        },
                        BarLayers = new List<TeamBar>
                        {
                            new TeamBar
                            {
                                Text = "Target",
                                Length = 990,
                                Color = Color.Red,
                                TextAlign = TextAlign.Right
                            },
                            new TeamBar
                            {
                                Text = "Current",
                                Length = 500,
                                Color = Color.Green,
                                TextAlign = TextAlign.Left
                            },
                        }
                    },

                    IndividualLeaderBoard = new List<VideoDefinitionRow>
                    {
                        new VideoDefinitionRow {Name = "Mordecai  Brown", Values = new Dictionary<string, int> { { "VVOE", 297 }, { "Disclosure", 175 }, { "Documents", 85 }, { "Verification", 133 }, { "VOR", 45 }, } },
                        new VideoDefinitionRow {Name = "King  Cole", Values = new Dictionary<string, int> { { "1", 275 }, { "2", 175 }, { "3", 150 }, { "4", 110 },  } },
                        new VideoDefinitionRow {Name = "Harry  McIntire", Values = new Dictionary<string, int> { { "1", 274 }, { "2", 166 }, { "3", 85 }, { "4", 133 }, { "5", 3 }, } },
                        new VideoDefinitionRow {Name = "Ed  Reulbach", Values = new Dictionary<string, int> { { "1", 277 }, { "2", 95 }, { "3", 85 }, { "4", 93 }, { "5", 2 }, } },
                        new VideoDefinitionRow {Name = "Orval  Overall", Values = new Dictionary<string, int> { { "1", 280 }, { "2", 95 }, { "3", 65 }, { "4", 93 }, { "5", 12 }, } },
                        new VideoDefinitionRow {Name = "Lew  Richie", Values = new Dictionary<string, int> { { "1", 280 }, { "2", 95 }, { "3", 55 }, { "4", 93 }, { "5", 4 }, } },
                        new VideoDefinitionRow {Name = "Jack  Pfeister", Values = new Dictionary<string, int> { { "1", 280 }, { "2", 85 }, { "3", 65 }, { "4", 83 }, { "5", 4 }, } },
                        new VideoDefinitionRow {Name = "Big  Jeff  Pfeffer", Values = new Dictionary<string, int> { { "1", 280 }, { "2", 85 }, { "3", 65 }, { "4", 73 },  } },
                        new VideoDefinitionRow {Name = "Orlie  Weaver", Values = new Dictionary<string, int> { { "1", 256 }, { "2", 80 }, { "3", 85 }, { "4", 45 },   } },
                        new VideoDefinitionRow {Name = "Rube  Kroh", Values = new Dictionary<string, int> { { "1", 244 }, { "2", 85 }, { "3", 60 }, { "4", 70 }, { "5", 4 }, } },
                        new VideoDefinitionRow {Name = "Al  Carson", Values = new Dictionary<string, int> { { "1", 237 }, { "2", 75 }, { "3", 55 }, { "4", 68 }, { "5", 2 }, } },
                        new VideoDefinitionRow {Name = "Bill  Foxen", Values = new Dictionary<string, int> { { "1", 248 }, { "2", 85 }, { "3", 45 }, { "4", 60 }, } },
                    },

                    TeamBars = new List<TeamBar>
                    {
                        new TeamBar {Color = Color.Red, Length = 855, Start = 0, Text = "Boston Beaneaters", TextAlign = TextAlign.Right},
                        new TeamBar {Color = Color.DarkRed, Length = 820, Start = 0, Text = "Detroit Stars", TextAlign = TextAlign.Right},
                        new TeamBar {Color = Color.Orange, Length = 777, Start = 0, Text = "Cleveland Spiders", TextAlign = TextAlign.Right},
                        new TeamBar {Color = Color.Navy, Length = 740, Start = 0, Text = "Brooklyn Bridegrooms", TextAlign = TextAlign.Right},
                        new TeamBar {Color = Color.LawnGreen, Length = 710, Start = 0, Text = "Minnesota North Stars", TextAlign = TextAlign.Right},
                    }
                };

                using (var game = new View(viewDef))
                    game.Run();
            }

        }
    }
#endif
}
