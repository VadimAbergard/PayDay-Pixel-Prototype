using CSTestSfml.myApi;
using CSTestSfml.myApi.button;
using CSTestSfml.Scenes;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTestSfml {
    internal class Core {

        private static void Main(string[] args) {
            Game.start(new GameScene(), "game 2d", 1200, 900, new Texture("assets\\assault.png"), false);
        }
    }
}
