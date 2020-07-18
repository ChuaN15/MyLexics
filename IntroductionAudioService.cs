using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Media;
using MyLexics;

namespace MyLexics
{

    [Service]
    public class IntroductionAudioService : Service
    {
        MediaPlayer mp;

        public override void OnCreate()
        {
            base.OnCreate();
            mp = MediaPlayer.Create(this, Resource.Raw.selamatdatang);
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            mp.Start();
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }


        public override void OnDestroy()
        {
            mp.Release();
            base.OnDestroy();
        }

        void HandleTimerCallback(object state)
        {

        }
    }
}
        