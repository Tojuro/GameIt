using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameItShared
{
    public class ViewDefinition
    {
        public ViewDefinition()
        {
            Rows = new List<VideoDefinitionRow>();
            ResetColorList();
        }

        public ProgressBar ProgressBar { get; set;}

        public List<Bar> TeamBars { get; set;}

        public string ViewDefinitionName { get; set; }

        public List<VideoDefinitionRow> Rows { get; set; }
        
        public Queue<Color> MultiColorList { get; set; }

        public List<Achievement> Achievements { get; set; }

        public void ResetColorList()
        {
            MultiColorList = new Queue<Color>();

            MultiColorList.Enqueue(Color.Red);
            MultiColorList.Enqueue(Color.Blue);
            MultiColorList.Enqueue(Color.Green);
            MultiColorList.Enqueue(Color.Yellow);
            MultiColorList.Enqueue(Color.Purple);
            MultiColorList.Enqueue(Color.Teal);
            MultiColorList.Enqueue(Color.Orange);
            MultiColorList.Enqueue(Color.Pink);
            MultiColorList.Enqueue(Color.Turquoise);
            MultiColorList.Enqueue(Color.ForestGreen);
            MultiColorList.Enqueue(Color.OrangeRed);
            MultiColorList.Enqueue(Color.HotPink);
            MultiColorList.Enqueue(Color.DodgerBlue);
            MultiColorList.Enqueue(Color.Red);
            MultiColorList.Enqueue(Color.Blue);
            MultiColorList.Enqueue(Color.Green);
            MultiColorList.Enqueue(Color.Yellow);
            MultiColorList.Enqueue(Color.Purple);
            MultiColorList.Enqueue(Color.Teal);
            MultiColorList.Enqueue(Color.Orange);
            MultiColorList.Enqueue(Color.Pink);
            MultiColorList.Enqueue(Color.Turquoise);
            MultiColorList.Enqueue(Color.ForestGreen);
            MultiColorList.Enqueue(Color.OrangeRed);
            MultiColorList.Enqueue(Color.HotPink);
            MultiColorList.Enqueue(Color.DodgerBlue);

        }
        
    }

    public class VideoDefinitionRow
    {
        public string Name { get; set; }

        public Dictionary<string, int> Values { get; set; }

    }

    public class ProgressBar
    {
        public string Title { get; set; }

        public List<Bar> BarLayers { get; set;}

        public Bar BackBar { get; set; }

        public bool HasBackBar { get; set; } 
    }

    public class Bar
    {
        public int Length { get; set; }
        public string Text { get; set; }
        public TextAlign TextAlign { get; set; }
        public int Start { get; set; }
        public Color Color { get; set; } = Color.Red;
    }

    public class Achievement
    {
        public string Title { get; set; }
        public string Name { get; set; }

    }

}
