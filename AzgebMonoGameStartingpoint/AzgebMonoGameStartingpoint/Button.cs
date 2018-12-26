using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace AndroidApplication {

    public class Button {

        Vector2 position;
        Texture2D texture;

        public Button(Vector2 position, Texture2D texture) {
            this.texture = texture;
            this.position = new Vector2(position.X - texture.Width/2, position.Y -texture.Height/2);
        }

        public bool IsClicked(Matrix matrix) {

            var buttonRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            bool isInputPressed = false;
            var touchPanelState = TouchPanel.GetState();
            Vector2 touchPosition;
            var mouseState = Mouse.GetState();

            if (touchPanelState.Count >= 1) {

                var touch = touchPanelState[0];
                touchPosition = touch.Position;
                touchPosition = Vector2.Transform(touchPosition, Matrix.Invert(matrix));
                isInputPressed = touch.State == TouchLocationState.Pressed || touch.State == TouchLocationState.Moved;

                if (isInputPressed && buttonRectangle.Contains(touchPosition.X, touchPosition.Y)) return true;
                else return false;
            } else return false;
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
