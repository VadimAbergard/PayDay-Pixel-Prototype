using CSTestSfml.framework;
using CSTestSfml.myApi;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTestSfml.ElementsGame
{
    internal class Enemy
    {
        private GameObject gameObject;
        private Collider collider;

        private GameObject player;

        private const float speed = 5;
        private bool death;

        public Enemy()
        {
            gameObject = new GameObject("assets\\playerPrototype.png");
            gameObject.setScale(3, 3);
            //gameObject.setLookAtGameObject(look);
            
            gameObject.setColor(Color.Red);
            collider = new Collider(50, 50);
            gameObject.Collider = collider;
        }

        public void Draw()
        {
            if(death) { return; }

            if (gameObject.getPosition().X > player.getPosition().X) gameObject.addPosition(-1, 0);
            if (gameObject.getPosition().X < player.getPosition().X) gameObject.addPosition(1, 0);
            if (gameObject.getPosition().Y < player.getPosition().Y) gameObject.addPosition(0, 1);
            if (gameObject.getPosition().Y > player.getPosition().Y) gameObject.addPosition(0, -1);

            gameObject.draw();
            collider.Draw();
        }

        public void setLookOnPlayer(GameObject player) {
            this.player = player;
        }

        public Vector2f Position
        {
            get { return gameObject.getPosition(); }
            set { gameObject.setPosition(value.X, value.Y); }
        }

        public bool Death { get => death; set => death = value; }
        internal Collider Collider { get => collider; }
    }
}
