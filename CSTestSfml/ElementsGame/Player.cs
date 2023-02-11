using CSTestSfml.framework;
using CSTestSfml.myApi;
using SFML.System;
using SFML.Window;

namespace CSTestSfml.ElementsGame
{
    internal class Player
    {
        private GameObject gameObject;
        private Collider collider;

        private const float speed = 5;
        private float speedShift;

        public Player() {
            gameObject = new GameObject("assets\\playerPrototype.png");
            gameObject.setScale(3, 3);
            gameObject.setLookAtMouse();
            collider = new Collider(50, 50);
            gameObject.Collider = collider;
        }

        public void Draw() {
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift)) speedShift = 3;
            else speedShift = 0;

            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) gameObject.addPosition(-speed + -speedShift, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) gameObject.addPosition(speed + speedShift, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) gameObject.addPosition(0, -speed + -speedShift);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) gameObject.addPosition(0, speed + speedShift);

            gameObject.draw();
            collider.Draw();
        }

        public Vector2f Position {
            get { return gameObject.getPosition(); }
        }

        internal GameObject GameObject { get => gameObject; }
    }
}
