using CSTestSfml.ElementsGame.Music_Heist;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTestSfml.ElementsGame
{
    internal class Assault
    {
        private float FTtimeAnticipation;
        private float FTimeAssault;
        private float FTimeControl;
        private float timeAnticipation;
        private float timeControl;
        private float timeAssault;

        private MusicHeist music;

        /*0 - control; 1 - anticipation; 2 - assault*/
        private int stage;
        private bool assaultGo;
        private bool anticipationGo;

        public float TimeAnticipation { get => FTtimeAnticipation; }

        //private bool anticipationGo;

        public Assault(int timeControl, int timeAssault, MusicHeist music)
        {
            this.music = music;
            this.timeAnticipation = (music.AnticipationEnd - music.AnticipationStart) * 1;
            this.timeAssault = timeAssault;
            this.timeControl = timeControl;
            FTtimeAnticipation = timeAnticipation;
            FTimeAssault = timeAssault;
            FTimeControl = timeControl;
        }

        public void update(float delta)
        {
            music.update();
            assaultGo = false;
            anticipationGo = false;
            if (timeControl >= 0) {
                if (stage == 2) music.setPosition(MusicHeistMoment.CONTROL);
                stage = 0;
                timeControl -= delta;
                Console.WriteLine(timeControl);
            }
            else if(timeAnticipation >= 0) {
                if (stage == 0) music.setPosition(MusicHeistMoment.ANTICIPATION);
                stage = 1;
                timeAnticipation -= delta;
                anticipationGo = true;
                Console.WriteLine(timeAnticipation);
            }
            else if (timeAssault >= 0) {
                if (stage == 1) music.setPosition(MusicHeistMoment.ASSAULT);
                stage = 2;
                timeAssault -= delta;
                assaultGo = true;
                Console.WriteLine(timeAssault);
            }
            else {
                this.timeAnticipation = FTtimeAnticipation;
                this.timeAssault = FTimeAssault;
                this.timeControl = FTimeControl;
            }
        }

        public bool isAssaultGo()
        {
            return assaultGo;
        }

        public bool isAnticipationGo(){
           return anticipationGo;
        }
    }
}
