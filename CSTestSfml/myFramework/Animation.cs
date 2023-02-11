using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTestSfml.myApi {
    internal class Animation {

        private GameObject gameObject;
        private List<float[]> keys;
        private int currentKey;
        private Vector2f initiallyPos;
        private float stateTime;

        private const int keySeconds = 0;
        private const int keyPosition = 1;// and 2;
        private const int keyRotate = 3;
        private const int keyScale = 4;
        private const int keyExpand = 5;

        private bool loop;
        private bool loopNow;

        private bool finish;

        public Animation(bool loop) {
            keys = new List<float[]>();
            this.loop = loop;
            loopNow = true;
        }

        /*
        new float[] {
            10 - *seconds
            0, 0 - *position
            0 - rotate
            0 - scale
            -1/1 - expand
        }
         */
        public void addKey(float[] options) {
            keys.Add(options);
        }
        public void update() {
            if (stateTime > keys[currentKey][0]) {
                if (currentKey + 1 < keys.Count)  {
                    currentKey++;
                    stateTime = 0;
                    initiallyPos = gameObject.getPosition();
                    return;
                }
                else {
                    currentKey = 0;
                    if(!loop) loopNow = false;
                    stateTime = 0;
                    initiallyPos = gameObject.getPosition();
                    return;
                }
            }
            if (stateTime == 0 && keys[currentKey].Length == 6) {
                if (keys[currentKey][keyExpand] == -1) gameObject.expand();
            }

            if (!loopNow)
            {
                finish = true;
                return;
            }
            stateTime += Game.getDelta();


            float delta = Game.getDelta() * 40;
            float dX = initiallyPos.X + keys[currentKey][keyPosition] - gameObject.getPosition().X;
            float dY = initiallyPos.Y + keys[currentKey][keyPosition + 1] - gameObject.getPosition().Y; 
            gameObject.addPosition(dX / (20 + (13 * (keys[currentKey][keySeconds] - 1))) * delta, dY / (100 + (13 * (keys[currentKey][keySeconds] - 1))) * delta);
            gameObject.addRotate(keys[currentKey][keyRotate] / 300 / keys[currentKey][keySeconds] * delta);
            gameObject.addScale(keys[currentKey][keyScale] / 150 / keys[currentKey][keySeconds] * delta);
        }

        public void setGameObject(GameObject gameObject) {
            this.gameObject = gameObject;
            initiallyPos = gameObject.getPosition();
        }

        public void clear() {
            loopNow = true;
            finish = false;
        }

        public bool isEnd() {
            return finish;
        }
    }
}
