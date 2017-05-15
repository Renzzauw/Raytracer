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
    class Sphere : Primitive
    {
        //Member variables
        Vector3 center; //Vector c
        float radius; //Vector r
        Vector3 color;

        public Sphere(Vector3 center, float radius, Vector3 color)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
        }

        /*public Vector3 GetNormal()
        {

        }

        public bool Intersect(Ray ray)
        {

        }*/
    }
}
