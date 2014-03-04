using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChizMover
{
    public class GameObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        //depth from 0:front to 1:back
        public void RenderFit(SpriteBatch spriteBatch, float depth, int Width, int Height)
        {
            Vector2 scale = new Vector2( (float)Width / this.Texture.Width, (float)Height / this.Texture.Height);

            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, new Vector2(0,0), scale, SpriteEffects.None, depth); 
        }
    }

    public class GameBackground : GameObject
    {
    }

    /*
     * wall
     **/
    public class Wall : GameObject
    {
    }

    public class Bot : GameObject
    {
    }
}
