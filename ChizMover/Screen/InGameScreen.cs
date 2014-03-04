using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System.Diagnostics;

namespace ChizMover
{
    public class InGameScreen : GameScreen
    {
        private GameBackground _gameBg;
        private Bot _bot;
        private List<string> _currentLevelStrings;

        #region overrided standard methods
        public override void LoadContent()
        {
            base.LoadContent();

            PrepareSprites();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            RenderScene(spriteBatch);
        }
        #endregion

        #region helpers
        /// <summary>
        /// sprites are created based on level's content
        /// </summary>
        private void PrepareSprites()
        {
            /*
            _currentLevelStrings = GameLogic.Instance.GetLevelContent(1, 1);
            ShowLevel();
            */
            _gameBg = new GameBackground();
            _gameBg.Texture = content.Load<Texture2D>(GameConfig.GetBackground());
            _gameBg.Position = new Vector2(0, 0);

            _bot = new Bot();
            _bot.Texture = content.Load<Texture2D>(GameConfig.GetBot());
            _bot.Position = new Vector2(ScreenManager.Instance.Dimensions.X / 2,
                                        ScreenManager.Instance.Dimensions.Y / 2);
        }

        private void RenderScene(SpriteBatch spriteBatch)
        {
            //render background
            _gameBg.RenderFit(spriteBatch, 1f, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y);

            //render bot
            _bot.Render(spriteBatch);

            //render maze
        }

        private void ShowLevel()
        {
            foreach (string line in _currentLevelStrings)
            {
                Debug.WriteLine(line);
            }
        }
        #endregion
    }
}
