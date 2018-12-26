using IndependentResolutionRendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AndroidApplication {

    public class Menu : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Button btnStart;
        GraphicsDevice GraphicsDevice;
        int gameState;
        
        public Menu(GraphicsDeviceManager graphicsDeviceManager, ContentManager contentManager){
            graphics = graphicsDeviceManager;
            Content = contentManager;

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            Resolution.Init(ref graphics);
            Resolution.SetVirtualResolution(1280, 720);
            Resolution.SetResolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, false);

        }

        public void LoadContent(GraphicsDevice graphicsDevice) {
            // TODO: use this.Content to load your game content here
            GraphicsDevice = graphicsDevice ;
            spriteBatch = new SpriteBatch(graphicsDevice);
            background = Content.Load<Texture2D>("Background");
            btnStart = new Button(new Vector2(640,360), Content.Load<Texture2D>("Button"));
            
        }

        public void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        public void Update(GameTime gameTime) {
            // TODO: Add your update logic here
            if (btnStart.IsClicked( Resolution.getTransformationMatrix())) {
                gameState = 1;
            }
            
        }

        public void Draw(GameTime gameTime) {
            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Resolution.getTransformationMatrix());
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            btnStart.Draw(spriteBatch);
            spriteBatch.End();
            
        }

        public int GetGameState() {
            return gameState;
        }

        public void SetGameState(int gameState) {
            this.gameState = gameState;
        }
    }
}
