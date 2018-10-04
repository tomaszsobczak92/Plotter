using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace Plotter.Infrastructures
{
    public static class ColorManager
    {
        static Color[] color =
        {
            Color.Black,
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.CornflowerBlue,
            Color.DarkBlue,
            Color.DarkGreen,
            Color.DarkSlateBlue,
            Color.DeepPink,
            Color.DodgerBlue,
            Color.ForestGreen,
            Color.Fuchsia,
            Color.Gold,
            Color.Indigo,
            Color.Khaki,
            Color.LemonChiffon,
            Color.LightGray,
            Color.LightSlateGray,
            Color.Magenta,
            Color.MintCream
        };

        public static Color GetColor(int index)
        {
            if(index > color.Length || index < 0)
                throw new ArgumentException("Color index is out of array");
            return color[index];
        }
    }
}
