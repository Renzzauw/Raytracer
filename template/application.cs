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
    class Application
    {
        //Member variables
        Raytracer raytracer = new Raytracer();

        void Something()
        {
            raytracer.Render();
        }
    }
}
