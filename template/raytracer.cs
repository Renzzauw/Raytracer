using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Template
{
    class Raytracer
    {
        //Member variables
        public Scene scene;
        public Camera camera;
        public Surface screen;

        // initialize
        public void Init()
        {
            scene = new Scene();
            camera = new Camera();
            screen = new Surface(1024, 512);

            camera.Init();
        }

        // tick: renders one frame
        public void Tick()
        {
            screen.Clear(0);
            screen.Print("hello world", 2, 2, 0xffffff);
            screen.Line(2, 20, 160, 20, 0xff0000);
            screen.Box(0, 0, 1, 1, 0xffffff);
        }

        public void Render()
        {

        }
    }
}
