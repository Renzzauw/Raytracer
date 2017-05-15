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
    public class Ray
    {
        //𝑝(𝑡) = 𝑂 + 𝑡𝐷, where 𝑡 > 0.
        public Vector3 O; // ray origin
        public Vector3 D; // ray direction
        public float t; // distance   

        public Vector3 normalize()
        {
            float length = (float)Math.Sqrt(D.X * D.X + D.Y * D.Y + D.Z * D.Z);
            return new Vector3(D.X / length, D.Y / length, D.Z / length);
        }

    }
}
