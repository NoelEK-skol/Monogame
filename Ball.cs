using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class Ball
    {
        private Texture2D texture;
        private Rectangle rectangle = new Rectangle(390, 230, 20, 20);
        private float velocityX = 3;
        private float velocityY = 2;

        public Rectangle Rectangle{
            get{return rectangle;}
        }
        public Ball(Texture2D t){
            texture = t;

        }

        public void Reset(){
            rectangle.X = 390;
            rectangle.Y = 230;
            velocityX = 3;
            velocityY = 2;
        }
        public void update(){
            rectangle.X+= (int)velocityX;
            rectangle.Y+= (int)velocityY;

            if(rectangle.Y <= 0 || rectangle.Y + rectangle.Height >= 480){
                velocityY *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, rectangle, Color.LightGoldenrodYellow);
        }
    }
}