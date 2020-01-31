using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SharpEngine
{
    static class Drawing
    {
        public static void Draw(Unit unit_)
        {
            unit_.Draw();
        }

        public static void DrawBackground()
        {
            int x1 = 0, y1 = 0, x2 = Core.width, y2 = Core.heigth; // координаты точек
            LinearGradientBrush gradBrush = new LinearGradientBrush(new Rectangle(x1, y1, x2, y2), Color.Black, Color.Black, LinearGradientMode.Horizontal);
            System.Drawing.Graphics MyFormPaint = Core.MainForm.CreateGraphics();
            MyFormPaint.FillRectangle(gradBrush, x1, y1, x2, y2);
            MyFormPaint.Dispose();
        }
    }
}
