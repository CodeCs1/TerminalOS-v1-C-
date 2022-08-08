using System;
using Sys = Cosmos.System;
using graphics = Cosmos.System.Graphics;
using touhougraphics = TerminalOSv1.Games;

namespace TerminalOSv1.Graphics
{
    /// <summary>
    /// A Graphics User Inderface (GUI) class for making desktop =)
    /// </summary>
    public class GraphicsUserInterface
    {

        public static graphics.Canvas canvas;

        /// <summary>
        /// Initialize graphics user inderface
        /// </summary>

        public static void Initialize() //initialize a graphic
        {
            Console.Clear();

            touhougraphics.VGADriverII.Initialize(touhougraphics.VGAMode.Pixel320x200DB);

            touhougraphics.VGADriverII.SetMode(touhougraphics.VGAMode.Text80x25);

            touhougraphics.VGAGraphics.DrawPixel(0, 0, touhougraphics.VGAColor.PaleGreen1);

            //touhougraphics.VGAGraphics.Display();
            touhougraphics.VGADriverII.Display();

            //touhougraphics.VGADriverII.Clear();
        }
    }
}
