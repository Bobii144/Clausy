using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClausyGame.Objects;
using ClausyGame;
namespace ClausyGame.Physics
{
    class GamePhysics
    {
        public ClausyGame game = new ClausyGame();
        public bool CollisionVsObject(GameObject o1, GameObject o2)
        {
            //need to change it to Bounding box. Convert the base starting texture to the bounding box in case animation changes.
            Vector2 o1Pos = o1.Position;
            Vector2 o2Pos = o2.Position;
            return ((o1Pos.X < o2Pos.X + o2.Width && o1Pos.X + o1.Width > o2Pos.X) 
                && (o1Pos.Y < o2Pos.Y + o2.Height && o1Pos.Y + o1.Height > o2Pos.Y));
        }

        public bool OutOfBounds(GameObject o, GameObject w)
        {
            Vector2[] Corners = o.GetCorners();
            if (Corners[0].X < 0
                || Corners[0].Y < 0
                || Corners[1].X > w.Width
                || Corners[1].Y < 0
                || Corners[2].X > w.Width
                || Corners[2].Y > w.Height
                || Corners[3].X < 0
                || Corners[3].Y > w.Height)
            {
                return true;
            } else { return false; }

        }
    }
}
