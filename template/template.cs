using System;
using System.IO;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Template
{
	public class OpenTKApp : GameWindow
	{
		static int screenID;
		static Raytracer raytracer;
		static bool terminated = false;
        public Camera camera = new Camera();

        protected override void OnLoad( EventArgs e )
		{
			// called upon app init
			GL.ClearColor( Color.Black );
			GL.Enable( EnableCap.Texture2D );
			GL.Disable( EnableCap.DepthTest );
			GL.Hint( HintTarget.PerspectiveCorrectionHint, HintMode.Nicest );
			ClientSize = new Size( 1024, 512 );
			raytracer = new Raytracer();
			raytracer.screen = new Surface( Width, Height );
			Sprite.target = raytracer.screen;
			screenID = raytracer.screen.GenTexture();
			raytracer.Init();
		}

        protected override void OnUnload( EventArgs e )
		{
			// called upon app close
			GL.DeleteTextures( 1, ref screenID );
			Environment.Exit( 0 ); // bypass wait for key on CTRL-F5
		}

        protected override void OnResize( EventArgs e )
		{
			// called upon window resize
			GL.Viewport(0, 0, Width, Height);
			GL.MatrixMode( MatrixMode.Projection );
			GL.LoadIdentity();
			GL.Ortho( -1.0, 1.0, -1.0, 1.0, 0.0, 4.0 );
		}

        protected override void OnUpdateFrame( FrameEventArgs e )
		{
			// called once per frame; app logic
			var keyboard = OpenTK.Input.Keyboard.GetState();
			if (keyboard[OpenTK.Input.Key.Escape]) this.Exit();
		}

        protected override void OnRenderFrame( FrameEventArgs e )
		{
			// called once per frame; render
			raytracer.Tick();
			if (terminated) 
			{
				Exit();
				return;
			}
			// convert Raytracer.screen to OpenGL texture
			GL.BindTexture( TextureTarget.Texture2D, screenID );
			GL.TexImage2D( TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 
						   raytracer.screen.width, raytracer.screen.height, 0, 
						   OpenTK.Graphics.OpenGL.PixelFormat.Bgra, 
						   PixelType.UnsignedByte, raytracer.screen.pixels 
						 );
			// clear window contents
			GL.Clear( ClearBufferMask.ColorBufferBit );
			// setup camera
			GL.MatrixMode( MatrixMode.Modelview );
			GL.LoadIdentity();
			GL.MatrixMode( MatrixMode.Projection );
			GL.LoadIdentity();
			// draw screen filling quad
			GL.Begin( PrimitiveType.Quads );
			GL.TexCoord2( 0.0f, 1.0f ); GL.Vertex2( camera.bottomLeft.X, camera.bottomLeft.Y );
			GL.TexCoord2( 1.0f, 1.0f ); GL.Vertex2( camera.bottomRight.X, camera.bottomRight.Y );
			GL.TexCoord2( 1.0f, 0.0f ); GL.Vertex2( camera.topRight.X, camera.topRight.Y );
			GL.TexCoord2( 0.0f, 0.0f ); GL.Vertex2( camera.topLeft.X, camera.topLeft.Y );
			GL.End();

            /*GL.Color3(1.0f, 0f, 0f);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(camera.bottomLeft.X, camera.bottomLeft.Y, camera.bottomLeft.Z);
            GL.Vertex3(camera.bottomRight.X, camera.bottomRight.Y, camera.bottomRight.Z);
            GL.Vertex3(camera.topRight.X, camera.topRight.Y, camera.topRight.Z);
            GL.End();*/
            // tell OpenTK we're done rendering
            SwapBuffers();
		}

        public static void Main( string[] args ) 
		{ 
			// entry point
			using (OpenTKApp app = new OpenTKApp()) { app.Run( 30.0, 0.0 ); }
		}
	}
}