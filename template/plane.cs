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
    class Plane : Primitive
    {
        Vector3 normal;
        Vector3 distanceToOrigin;
        Vector3 color;
        Vector3 P0, P1, P2;

        public Plane(Vector3 normal, Vector3 distanceToOrigin, Vector3 color)
        {
            this.normal = normal;
            this.distanceToOrigin = distanceToOrigin;
            this.color = color;
        }
    }
}
