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
    class Intersection
    {
        //Member variables
        float intersectionDistance;
        Primitive nearestPrimitive;
        Vector3 normalAtIntersectionPoint;
    }
}
