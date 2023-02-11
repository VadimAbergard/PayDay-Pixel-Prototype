
using CSTestSfml.myApi;
using SFML.Audio;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTestSfml.ElementsGame.Music_Heist
{
    internal class MusicHeist
    {
        private Music music;
        private MusicHeistMoment moment;

        private float controlStart;
        private float controlEnd;
        private float anticipationStart;
        private float anticipationEnd;
        private float assaultStart;
        private float assaultEnd;
        private float bpm;

        public float AnticipationEnd { get => anticipationEnd; }
        public float AnticipationStart { get => anticipationStart; }
        public float Bpm { get => bpm; }

        public MusicHeist(MusicHeistType type) {

            switch (type) {
                case MusicHeistType.LEFT_IN_THE_COLD:
                    init("assets\\Music\\LeftInTheCold.ogg", 85, 170, 170.7f, 212, 216, 224, 366);
                    break;
                case MusicHeistType.KICKING_ASS_AND_TAKING_NAMES:
                    init("assets\\Music\\Kicking_Ass_and_Taking_Names.ogg", 1.5f, 29.6f, 121.95f, 160, 160, 236.15f, 126);
                    break;
            }
        }

        public void Stop()
        {
            music.Stop();
        }

        public void Dispose()
        {
            music.Dispose();
        }

        public void setPosition(MusicHeistMoment type) {
            moment = type;
            switch (type)
            {
                case MusicHeistMoment.CONTROL:
                    music.PlayingOffset = Time.FromSeconds(controlStart);
                    break;
                case MusicHeistMoment.ANTICIPATION:
                    music.PlayingOffset = Time.FromSeconds(AnticipationStart);
                    //music.PlayingOffset = Time.FromSeconds(160);
                    break;
                case MusicHeistMoment.ASSAULT:
                    music.PlayingOffset = Time.FromSeconds(assaultStart);
                    //music.PlayingOffset = Time.FromSeconds(230);
                    break;
            }
        }

        public void update()
        {
            switch (moment)
            {
                case MusicHeistMoment.CONTROL:
                    if (music.PlayingOffset.AsSeconds() >= controlEnd) music.PlayingOffset = Time.FromSeconds(controlStart);
                    //Console.WriteLine(music.PlayingOffset.AsSeconds() + " >= " + controlEnd);
                    break;
                case MusicHeistMoment.ANTICIPATION:
                    if(music.PlayingOffset.AsSeconds() >= AnticipationEnd) music.PlayingOffset = Time.FromSeconds(AnticipationStart);
                    //Console.WriteLine(music.PlayingOffset.AsSeconds() + " >= " + anticipationEnd);
                    break;
                case MusicHeistMoment.ASSAULT:
                    //Console.WriteLine(music.PlayingOffset.AsSeconds() + " >= " + assaultEnd);
                    if (music.PlayingOffset.AsSeconds() >= assaultEnd) music.PlayingOffset = Time.FromSeconds(assaultStart);
                    break;
            }
        }

        public void play() {
            music.Play();
            setPosition(MusicHeistMoment.CONTROL);
        }

        private void init(string path, float controlStart, float controlEnd, float anticipationStart, float anticipationEnd, float assaultStart, float assaultEnd, float bpm) {
            this.music = new Music(path);
            this.controlStart = controlStart;
            this.controlEnd = controlEnd;
            this.anticipationStart = anticipationStart;
            this.anticipationEnd = anticipationEnd;
            this.assaultStart = assaultStart;
            this.assaultEnd = assaultEnd;
            this.bpm = 60f / bpm;
        }
    }
}
