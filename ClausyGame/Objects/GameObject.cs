using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClausyGame
{
    class GameObject
    {
        public Rectangle BoundingBox;
        public Texture2D Texture;
        public float Speed;
        public int HalfWidth;
        public int HalfHeight;
        public int Width;
        public int Height;
        public Vector2 TopLeftCorner;
        public Vector2 TopRightCorner;
        public Vector2 BotLeftCorner;
        public Vector2 BotRightCorner;
        public Vector2 Position;

        public void Init()
        {
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            Width = Texture.Width;
            Height = Texture.Height;
            HalfHeight = Height / 2;
            HalfWidth = Width / 2;

        }

        public Vector2[] GetCorners()
        {
            TopLeftCorner = Position;
            TopRightCorner = new Vector2(Position.X + Width, Position.Y);
            BotLeftCorner = new Vector2(Position.X, Position.Y + Height);
            BotRightCorner = new Vector2(Position.X + Width, Position.Y + Height);

            Vector2[] Corners = new Vector2[]
            {
                TopLeftCorner,
                TopRightCorner,
                BotLeftCorner,
                BotRightCorner
            };
            return Corners;
            
        }
    }
}
