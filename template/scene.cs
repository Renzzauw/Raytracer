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
    class Scene
    {
        //Member variables
        List<Primitive> primitives = new List<Primitive>();
        List<Light> lights = new List<Light>();

        private void Intersect() /* DIT WORD PRIVATE INTERSECTION INTERSECT() ALS JE EEN INTERSECTION KAN RETURNEN */
        {
            foreach (Primitive primitive in primitives)
            {
                // Return closest intersection
            }
        }
    }
}
