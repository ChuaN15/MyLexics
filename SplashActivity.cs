
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Timers;
using Android.Content.PM;
using System.Threading;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Java.Lang;

namespace MyLexics
{
	//Set MainLauncher = true makes this Activity Shown First on Running this Application
	//Theme property set the Custom Theme for this Activity
	//No History= true removes the Activity from BackStack when user navigates away from the Activity
	[Activity(Label = "MyLexics", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.Menu", NoHistory = true, ScreenOrientation = ScreenOrientation.Landscape)]
	public class SplashScreen : Activity
	{
		private LinearLayout linearLayout;
		private BitmapDrawable background;
		private BitmapFactory.Options options;
		private Bitmap bitmapToDisplay;
		private int mProgress = 3000; //3 seconds
		Handler mHandler = new Handler();
		Runnable mProgressRunner;

		public SplashScreen()
		{
			mProgressRunner = new Runnable(Run);
		}

		public void Run()
		{
			jump();
		}

		class Runnable : Java.Lang.Object, Java.Lang.IRunnable
		{
			Action action;
			public Runnable(Action action)
			{
				this.action = action;
			}
			public void Run()
			{
				action();
			}
		}

		protected async override void OnCreate(Bundle bundle)
		{
			
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.SplashLayout);

			options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Splash, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Splash, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutSplash);
			linearLayout.SetBackgroundDrawable(background);

			/*await Task.Delay(4000);

			this.StartActivity(typeof(MainActivity));
			this.Finish();*/

			mHandler.PostDelayed(mProgressRunner, mProgress);
		}

		private void jump()
		{
			if (IsFinishing)
			{
				return;
			}
			StartActivity(new Intent(this, typeof(SelectionActivity)));
			this.Finish();
			
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Drawable drawable = linearLayout.Background;
			linearLayout.SetBackgroundDrawable(null);
			drawable.Dispose();
			if (linearLayout != null)
			{
				linearLayout.Dispose();
				linearLayout = null;
			}
			if (background != null)
			{
				background.Dispose();
				background = null;
			}
			if (options != null)
			{
				options.Dispose();
				options = null;
			}
			if (bitmapToDisplay != null)
			{
				bitmapToDisplay.Dispose();
				bitmapToDisplay = null;
			}
			this.Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			GC.Collect(GC.MaxGeneration);
		}

	}
}
