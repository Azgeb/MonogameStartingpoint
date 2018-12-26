using IndependentResolutionRendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AndroidApplication {

    public class Game1 : Game{
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tex;
        Camera camera;
        GraphicsDevice GraphicsDevice;
        int gameState;

        public Game1(GraphicsDeviceManager graphicsDeviceManager, ContentManager contentManager) {
            // TODO: Add constructor Logic
            graphics = graphicsDeviceManager;
            Content = contentManager;
            
            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            Resolution.Init(ref graphics);

            Resolution.SetVirtualResolution(1280, 720);
            Resolution.SetResolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, false);

        }
        
        public void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        
        public void LoadContent(GraphicsDevice graphicsDevice) {
            // TODO: use this.Content to load your game content here
            GraphicsDevice = graphicsDevice;

            spriteBatch = new SpriteBatch(graphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport);
            tex = Content.Load<Texture2D>("BackgroundGame");

          
        }

        public void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }
        
        public void Update(GameTime gameTime) {
            // TODO: Add your update logic here
            camera.Position = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            camera.UpdateCamera(GraphicsDevice.Viewport);
          
        }
        
        public void Draw(GameTime gameTime) {
            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, /*camera.Transform * */ Resolution.getTransformationMatrix());
            spriteBatch.Draw(tex, new Vector2(0, 0), Color.White);
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
