using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSANamePlate
{
    public static class Utility
    {
        public static Point ToPoint(this string str)
        {
            int x, y;
            string[] dt = str.Trim().Split(',');
            if (dt.Length != 2) return new Point(0,0);
            if (!int.TryParse(dt[0], out x) || !int.TryParse(dt[1], out y)) return new Point(0,0);
            return new Point(x, y);
        }

        public static Color ToColor(this string str)
        {
            int r, g, b;
            string[] dt = str.Trim().Split(',');
            if (dt.Length != 3) return Color.Black;
            if (!int.TryParse(dt[0], out r) || !int.TryParse(dt[1], out g)
                || !int.TryParse(dt[2], out b)) return Color.Black;
            return Color.FromArgb(r, g, b);
        }
    }
}
