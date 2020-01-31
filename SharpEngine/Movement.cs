using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;

namespace SharpEngine
{
    class Movement
    {
        public static float xMouse_t;
        public static float yMouse_t;

        public static float xHero_t;
        public static float yHero_t;

        public static double k;
        public static double b;

        public static double l;
        public static double a;
        public static double bfor_c;

        public static void Calc()
        {
            a = (double)Math.Abs(xMouse_t - xHero_t);
            bfor_c = (double)Math.Abs(yMouse_t - yHero_t);
            l = Math.Sqrt(a*a + bfor_c * bfor_c);
            //l = Math.Sqrt(Math.Pow((double)Math.Abs(Movement.xMouse_t - Movement.xHero_t), 2) + Math.Pow((double)Math.Abs(Movement.yMouse_t - Movement.yHero_t), 2));
            k = (yMouse_t - yHero_t) / (xMouse_t - xHero_t);
            b = (xMouse_t * yHero_t - xHero_t * yMouse_t) / (xMouse_t - xHero_t);
        }

        public static void Move()
        {
            if (Core.IsMove)
            {                             
                if (Core.Hero.X < xMouse_t)
                {
                    Core.Hero.X += a/ l;
                }
                else if (Core.Hero.X > xMouse_t)
                {
                    Core.Hero.X -= a / l ;                    
                }
                Core.Hero.Y = k * Core.Hero.X + b;
            }
        }

        public static void Check()
        {
            if (Core.Hero.X <= xMouse_t + a / l && Core.Hero.X >= xMouse_t - a / l && Core.Hero.Y <= yMouse_t + a / l && Core.Hero.Y >= yMouse_t - a / l)
            {
                Core.IsMove = false;
            }
            else
            {
                Core.IsMove = true;
            }
        }
        /*
        public static void Up_Right()
        {
            Core.Hero.X += 1 + Core.Hero.Speed;
            Core.Hero.Y -= 1 + Core.Hero.Speed;
        }
        public static void Up_Left()
        {
            Core.Hero.X -= 1 + Core.Hero.Speed;
            Core.Hero.Y -= 1 + Core.Hero.Speed;
        }
        public static void Down_Right()
        {
            Core.Hero.X += 1 + Core.Hero.Speed;
            Core.Hero.Y += 1 + Core.Hero.Speed;
        }
        public static void Down_Left()
        {
            Core.Hero.X -= 1 + Core.Hero.Speed;
            Core.Hero.Y += 1 + Core.Hero.Speed;
        }

        public static void Right()
        {
            Core.Hero.X += 1 + Core.Hero.Speed;
        }
        public static void Left()
        {
            Core.Hero.X -= 1 + Core.Hero.Speed;
        }
        public static void Up()
        {
            Core.Hero.Y -= 1 + Core.Hero.Speed;
        }
        public static void Down()
        {
            Core.Hero.Y += 1 + Core.Hero.Speed;
        }*/
    }
}
