using Microsoft.Xna.Framework;

namespace AndroidApplication {

    public class SceneManager : Game
    {
        GraphicsDeviceManager graphics;
        Menu menu;
        Game1 game;
        int gameState;
        
        public SceneManager(){
            // TODO: Add your construct logic here
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            
        }

       
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();

        }

       
        protected override void LoadContent() {
            // TODO: Add your load code here
            menu = new Menu(graphics, Content);
            game = new Game1(graphics, Content);

            menu.LoadContent(GraphicsDevice);
            game.LoadContent(GraphicsDevice);

        }

      
        protected override void UnloadContent() {
            // TODO: Add your unload code here
            switch (gameState) {
                case 0:
                    menu.UnloadContent();
                    break;
                case 1:
                    game.UnloadContent();
                    break;
            }

        }

     
        protected override void Update(GameTime gameTime) {
            // TODO: Add your update code here
            switch (gameState) {
                case 0:
                    menu.SetGameState(gameState);
                    menu.Update(gameTime);
                    gameState = menu.GetGameState();
                    break;
                case 1:
                    game.SetGameState(gameState);
                    game.Update(gameTime);
                    gameState = game.GetGameState();
                    break;
            }
            base.Update(gameTime);

        }

       
        protected override void Draw(GameTime gameTime) {
            // TODO: Add your drawing code here
            switch (gameState) {
                case 0:
                    menu.Draw(gameTime);
                    break;
                case 1:
                    game.Draw(gameTime);
                    break;
            }
            base.Draw(gameTime);

        }
    }
}
