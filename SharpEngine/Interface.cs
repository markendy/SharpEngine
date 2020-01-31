using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SharpEngine
{
    public static class Interface
    {
        public static int captionHeight = SystemInformation.CaptionHeight;
        public static int borderSize = SystemInformation.BorderSize.Width;

        public static Graphics graphics = Core.MainForm.CreateGraphics();
        public static Pen pen = new Pen(Color.Red, 3);
        
        public static void CreateButton(string text, int x, int y, string name, int type)
        {
            int[] size = ChooseSizeButton(type);
            Button button = new Button
            {
                Name = name,
                Size = new Size(size[0], size[1]),
                Location = new Point(x, y),
                Text = text
            };
            button.Click += Button_Click;
            Core.MainForm.Controls.Add(button);
        }

        private static int[] ChooseSizeButton(int type)
        {
            int[] size = { 0, 0 };
            switch (type)
            {
                case 1:
                    size[0] = 250;
                    size[1] = 50;
                    break;
                case 2:
                    size[0] = 120;
                    size[1] = 35;
                    break;
                case 3:
                    size[0] = 60;
                    size[1] = 22;
                    break;
                default:
                    size[0] = 120;
                    size[1] = 35;
                    break;
            }
            return size;
        }

        private static void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string b_name = button.Name;
            switch (b_name)
            {
                case "MainMenu_StartGameButton":
                    //ChooseScense = "TestField";
                    break;
                case "MainMenu_SettingButton":
                    Scenes("Setting");
                    //ChooseScense = "Setting";
                    break;
                case "MainMenu_ExitButton":
                    //ClearResourse();
                    Application.Exit();
                    break;
                case "MainMenu_MainMenuButton":
                    Scenes("MainMenu");
                    //ChooseScense = "MainMenu";
                    break;
            }
        }

        public static void CreateLable(Color color, string text, int x, int y, string name)
        {
            Label lable = new Label
            {
                Name = name,
                AutoSize = true,
                Location = new Point(x, y),
                ForeColor = color,
                BackColor = Color.Transparent,
                Text = text
            };
            Core.MainForm.Controls.Add(lable);
        }

        public static void CreateField()
        {

        }

        public static void Scenes(string name)
        {
            Core.MainForm.Controls.Clear();
            switch (name)
            {              
                case "MainMenu":
                    CreateButton("Start", 275, 275, "MainMenu_StartGameButton", 1);
                    CreateButton("Options", 275, 375, "MainMenu_SettingButton", 1);
                    CreateButton("Exit", 275, 475, "MainMenu_ExitButton", 1);
                    break;
                case "Setting":
                    CreateLable(Color.Black, "In development...", 275, 275, "Setting_SettingInfoLable");
                    CreateButton("Main Menu", 275, 325, "MainMenu_MainMenuButton", 1);
                    break;
            }
        }

        public static void PlayAnimation(object target, string name_animation)
        {

        }

        /*public static void CreatePramoug()
        {
            int x1 = 10, y1 = 10, x2 = 750, y2 = 50; // координаты точек
            LinearGradientBrush gradBrush = new LinearGradientBrush(new Rectangle(x1, y1, x2, y2), Color.Red, Color.Green, LinearGradientMode.Horizontal);
            System.Drawing.Graphics MyFormPaint = Core.MainForm.CreateGraphics();
            MyFormPaint.FillRectangle(gradBrush, x1, y1, x2, y2);
            MyFormPaint.Dispose();
        }*/
    }
}
