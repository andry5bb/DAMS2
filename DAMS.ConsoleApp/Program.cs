using System;
using Terminal.Gui;

namespace DAMS.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitApp();
            Application.Run();
        }

        static void InitApp()
        {
            Application.Init();
            var top = Application.Top;

            var window = new Window("DAMS Console")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(window);
        }
    }
}
