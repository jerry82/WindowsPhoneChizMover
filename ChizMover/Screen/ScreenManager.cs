using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChizMover
{
    public class ScreenManager
    {
        public Vector2 Dimensions { get; private set; }
        public ContentManager Content { get; private set; }

        //transition happen when _newScreen is create and assign
        //to _currentScreen

        private GameScreen _currentScreen;
        private GameScreen _newScreen;

        //singleton 
        private static ScreenManager _instance = null;

        public static ScreenManager Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new ScreenManager();
                return _instance;
            }
        }

        private ScreenManager() 
        {
            Dimensions = new Vector2(480, 800);
            _currentScreen = new InGameScreen();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            _currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            _currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            _currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(spriteBatch);
        }
    }
}
