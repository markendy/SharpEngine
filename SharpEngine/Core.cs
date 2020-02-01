using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;

namespace SharpEngine
{
    public static class Core
    {
        public static Form MainForm = Form.ActiveForm;
        public static int width = 800;
        public static int heigth = 600;
        public static string title = "TES";
        public static List<object> Register_Objects;
        public static Unit Hero;
        public static bool IsMove = false;

        //======================================ost
        //public static Timer timer = new Timer();
        public static int timetick;

        public static void Init()
        {
            CreateWindow(width, heigth, title);
            MainForm.Controls.Clear();           
            MainForm.KeyPreview = true;
            MainForm.KeyDown += MainForm_KeyDown;
            MainForm.MouseClick += MainForm_MouseClick;
            MainForm.Paint += MainForm_Paint;   
            LoadResourse();
            Register_Objects = new List<object>();
            //==================================
            //Interface.Scenes("MainMenu");
            CreateHumans createHumans = new CreateHumans();
            Hero = createHumans.Create_Knight("Hero", 10, 10);
            CreateTimer();
        }

        public static void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawFrame();
        }

        public static void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            //добавить проверку сцены
            Movement.xMouse_t = e.X - Interface.borderSize;
            Movement.yMouse_t = e.Y - Interface.borderSize;
            Movement.xHero_t = (float)Hero.X;
            Movement.yHero_t = (float)Hero.Y;
            Movement.Check();
        }

        public static void MainForm_KeyDown(object sender, KeyEventArgs e)
        {      
            /*
            if (e.KeyValue == (char)Keys.Left)
            {
                Movement.Left();
            }
            else if (e.KeyValue == (char)Keys.Right)
            {
                Movement.Right();
            }
            else if (e.KeyValue == (char)Keys.Up)
            {
                Movement.Up();
            }
            else if (e.KeyValue == (char)Keys.Down)
            {
                Movement.Down();
            }
            else if ((Keyboard.IsKeyDown(Key.LeftCtrl) e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
            {
                Movement.Down_Left();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                Movement.Down_Right();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                Movement.Up_Left();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
            {
                Movement.Up_Right();
            }*/
        }

        public static void LoadResourse()
        {
            
        }

        public static void ClearResourse()
        {

        }

        public static void CreateWindow(int w, int h, string title)
        {           
            MainForm.Size = new Size(w, h);
            MainForm.Text = title;
            MainForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            MainForm.MaximizeBox = false;
            Interface.CreateButton("!StartEngineButton! Чтобы это заработало, ушло 8 часов", 275, 275, "StartEngineButton", 1);
        }

        public static void CreateTimer()
        {
            Timer timer = new Timer();
            timer.Tick += timerTick;
            timer.Interval = 16;//(int)Hero.Speed;
            timer.Start();
        }

        public static void timerTick(object sender, EventArgs e)
        {
            DrawFrame();
            /*timetick += (int)Hero.Speed;   //fps?1000/60 
            if (timetick % (int)Hero.Speed == 0)
            {
                DrawFrame();
            }*/
        }

        public static void DrawFrame()
        {
            Drawing.DrawBackground();
            if (IsMove)
            {
                Movement.Calc();
                Movement.Move();
                Movement.Check();
            }   
            foreach (Unit t in Register_Objects)
            {
                t.Draw();
            }
        }

    }
}
