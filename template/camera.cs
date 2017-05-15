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
    public class Camera
    {
        //position and direction
        public Vector3 position = new Vector3(0, 0, 0);
        public Vector3 direction = new Vector3(0, 0, 1);
        public Vector3 distance;
        public Vector3 center;

        public float FOV; //TODO: moet nog gelinkt worden aan distance

        //Screen Corners
        public Vector3 topLeft = new Vector3(-1, 1, 1);
        public Vector3 topRight = new Vector3(1, 1, 1);
        public Vector3 bottomLeft = new Vector3(-1, -1, 1);
        public Vector3 bottomRight = new Vector3(1, -1, 1);
        
        public void Init()
        {
            //C = 𝐸 + 𝑑V
            center += new Vector3(distance.X * direction.X, distance.Y * direction.Y, distance.Z * direction.Z);

            //center + position corner
            topLeft += center;
            topRight += center;
            bottomLeft += center;
            bottomRight += center;

        }

        //𝑝 (𝑢, 𝑣) = 𝑝0 + 𝑢 𝑝1 − 𝑝0 + 𝑣(𝑝2 − 𝑝0), 𝑢, 𝑣 ∈ [0,1) 
        //TODO: de u en v zijn tussen 0 en 1, dit moet omgezet worden in screen pixel coordinates
        //Calculate a point on screen
        public Vector2 PointOnScreen(float u, float v)
        {
            Vector3 Point = new Vector3(0, 0, 0);
            Point = topLeft + u * (topRight - topLeft) + v * (bottomLeft - topLeft);
            return new Vector2(Point.X, Point.Y);
        }

        //Sets a ray's direction and position based on a point on screen
        public void SetVectorDirAndOr(float u, float v, Ray ray)
        {
            Vector2 Point = PointOnScreen(u, v);
            ray.D = new Vector3(Point.X - position.X, Point.Y - position.Y, position.Z - distance.Z); //not sure dat de Z-waarde hier juist is
            ray.O = position;
            ray.normalize();
        }
    }

}
