
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
using Android.Content.PM;
using Android.Media;
using Android.Graphics;
using Android.Views.Animations;
using Android.Content.Res;
using Android.Graphics.Drawables;
using System.Threading.Tasks;

namespace MyLexics
{
	[Activity(Label = "AbjadBergambarVideoActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
	public class AbjadBergambarVideoActivity : Activity
	{
		private VideoView videoView;
		private BitmapFactory.Options options;
		private Bitmap bitmapToDisplay;
		private LinearLayout linearLayoutFront;
		private LinearLayout linearLayoutBack;
		//private List<Drawable> backgrounds;
		private Bitmap bitmapForBackground;
		private Drawable background;
		private ImageButton imgButton;
		private List<imageLoadingDetails> buttonResource;
		private TransitionDrawable crossfader;
		private List<videoAbjadBergambarDetails> videoAbjads;
		private videoAbjadBergambarDetails videoAbjadDetail;
		private Animation zoomIn;
		private int sequence;
		private string symbol;
		private Intent starterIntent;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			starterIntent = Intent;
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.AbjadBergambarVideoLayout);

			string category = Intent.Extras.GetString("category");
			symbol = Intent.Extras.GetString("key");
			videoAbjads = new List<videoAbjadBergambarDetails>();

			if (category.Equals("v")){
				videoAbjads.Add(new videoAbjadBergambarDetails("a", Resource.Raw.ayam, "v",1));
				videoAbjads.Add(new videoAbjadBergambarDetails("i", Resource.Raw.itik, "v", 2));
				videoAbjads.Add(new videoAbjadBergambarDetails("u", Resource.Raw.ular, "v", 3));
				videoAbjads.Add(new videoAbjadBergambarDetails("e", Resource.Raw.enam, "v", 4));
				videoAbjads.Add(new videoAbjadBergambarDetails("o", Resource.Raw.oren, "v", 5));
			}else if(category.Equals("k")){
				videoAbjads.Add(new videoAbjadBergambarDetails("b", Resource.Raw.bagus, "k", 1));
				videoAbjads.Add(new videoAbjadBergambarDetails("c", Resource.Raw.cicak, "k", 2));
				videoAbjads.Add(new videoAbjadBergambarDetails("d", Resource.Raw.duri, "k", 3));
				videoAbjads.Add(new videoAbjadBergambarDetails("f", Resource.Raw.filem, "k", 4));
				videoAbjads.Add(new videoAbjadBergambarDetails("g", Resource.Raw.gajah, "k", 5));
				videoAbjads.Add(new videoAbjadBergambarDetails("h", Resource.Raw.hero, "k", 6));
				videoAbjads.Add(new videoAbjadBergambarDetails("j", Resource.Raw.jam, "k", 7));
				videoAbjads.Add(new videoAbjadBergambarDetails("k", Resource.Raw.katak, "k", 8));
				videoAbjads.Add(new videoAbjadBergambarDetails("l", Resource.Raw.lilin, "k", 9));
				videoAbjads.Add(new videoAbjadBergambarDetails("m", Resource.Raw.meja, "k", 10));
				videoAbjads.Add(new videoAbjadBergambarDetails("n", Resource.Raw.naga, "k", 11));
				videoAbjads.Add(new videoAbjadBergambarDetails("p", Resource.Raw.pen, "k", 12));
				videoAbjads.Add(new videoAbjadBergambarDetails("q", Resource.Raw.qari, "k", 13));
				videoAbjads.Add(new videoAbjadBergambarDetails("r", Resource.Raw.roti, "k", 14));
				videoAbjads.Add(new videoAbjadBergambarDetails("s", Resource.Raw.semut, "k", 15));
				videoAbjads.Add(new videoAbjadBergambarDetails("t", Resource.Raw.tukul, "k", 16));
				videoAbjads.Add(new videoAbjadBergambarDetails("v", Resource.Raw.vas, "k", 17));
				videoAbjads.Add(new videoAbjadBergambarDetails("w", Resource.Raw.wayar, "k", 18));
				videoAbjads.Add(new videoAbjadBergambarDetails("x", Resource.Raw.xray, "k", 19));
				videoAbjads.Add(new videoAbjadBergambarDetails("y", Resource.Raw.yoyo, "k", 20));
				videoAbjads.Add(new videoAbjadBergambarDetails("z", Resource.Raw.zip, "k", 21));
			}


			videoAbjadDetail = (from d in videoAbjads
								where d.category.Equals(category) && d.symbol.Equals(symbol)
			                    select d).FirstOrDefault();

			videoView = (VideoView)FindViewById(Resource.Id.videoBergambarView);
			videoView.Completion += VideoView_Completion;
			String srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.videoID;
			videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
			videoView.Start();

			//Back button
			FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoBackBtn).Click += delegate {
				if (category.Equals("v"))
				{
					Intent intent = new Intent(this, typeof(AbjadVokalBergambarActivity));
					StartActivity(intent);
					this.Finish();
				}
				else if (category.Equals("k")){
					Intent intent = new Intent(this, typeof(AbjadKonsonanBergambarActivity));
					StartActivity(intent);
					this.Finish();
				}
			};

			// detect if the first & last of vokal & konsonan
			if (videoAbjadDetail.category.Equals("v") && videoAbjadDetail.sequence == 1)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoLeftBtn).Visibility = ViewStates.Invisible;
			} 
			else if (videoAbjadDetail.category.Equals("k") && videoAbjadDetail.sequence == 1)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoLeftBtn).Visibility = ViewStates.Invisible;
			}
			else if (videoAbjadDetail.category.Equals("v") && videoAbjadDetail.sequence == 5)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoRightBtn).Visibility = ViewStates.Invisible;
			}
			else if (videoAbjadDetail.category.Equals("k") && videoAbjadDetail.sequence == 21)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoRightBtn).Visibility = ViewStates.Invisible;
			}

			//function of left button
			FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoLeftBtn).Click += delegate
			{
				category = videoAbjadDetail.category;
				sequence = videoAbjadDetail.sequence - 1;
				symbol = (from p in videoAbjads
						  where p.category.Equals(category) && p.sequence == sequence
						  select p.symbol).FirstOrDefault();
				this.Finish();
				starterIntent.PutExtra("key", symbol);
				starterIntent.PutExtra("category", category);
				StartActivity(starterIntent);
				this.OverridePendingTransition(Resource.Animation.slide_in_left, Resource.Animation.slide_out_left);
			};

			//function of right button
			FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoRightBtn).Click += delegate
			{
				category = videoAbjadDetail.category;
				sequence = videoAbjadDetail.sequence + 1;
				symbol = (from p in videoAbjads
						  where p.category.Equals(category) && p.sequence == sequence
						  select p.symbol).FirstOrDefault();
				
				this.Finish();
				starterIntent.PutExtra("key", symbol);
				starterIntent.PutExtra("category", category);
				StartActivity(starterIntent);
				this.OverridePendingTransition(Resource.Animation.slide_in_right, Resource.Animation.slide_out_right);
			};

            FindViewById<ImageButton>(Resource.Id.AbjadBergambarVideoInfoBtn).Click += delegate
            {
                //Toast.MakeText(this, "Button Setting 2", ToastLength.Long).Show();
                new AlertDialog.Builder(this)
               .SetView(Resource.Layout.ContactInformation)
               .SetPositiveButton("OK", delegate { })
               .Show();

            };

            loadBackgroundImage();
			loadOtherImage();
		}



		private void VideoView_Completion(object sender, EventArgs e)
		{
			/*crossfader = new TransitionDrawable(backgrounds.ToArray());
			linearLayout.SetBackgroundDrawable(crossfader);
			crossfader.StartTransition(3000);*/
			zoomIn = AnimationUtils.LoadAnimation(this, Resource.Animation.zoom_in);
			linearLayoutFront = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadBergambarVideoFront);
			linearLayoutFront.StartAnimation(zoomIn);
		}

		private async void loadBackgroundImage()
		{
			options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Abjad_Stroke_BrownCircleBGnew, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Abjad_Stroke_BrownCircleBGnew, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayoutFront = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadBergambarVideoFront);
			linearLayoutFront.SetBackgroundDrawable(background);
			options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Abjad_main_OrangeBG, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Abjad_main_OrangeBG, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayoutBack = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadBergambarVideoBack);
			linearLayoutBack.SetBackgroundDrawable(background);
		}

		private async void loadOtherImage()
		{
			//Save button image resource with each view id
			buttonResource = new List<imageLoadingDetails>();
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadBergambarVideoBackBtn, drawableId = Resource.Drawable.Back_Button });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadBergambarVideoLeftBtn, drawableId = Resource.Drawable.arrowL });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadBergambarVideoRightBtn, drawableId = Resource.Drawable.arrowR });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadBergambarVideoInfoBtn, drawableId = Resource.Drawable.Option_info });
			foreach (imageLoadingDetails imageDetails in buttonResource)
			{
				options = await decodeImage.GetBitmapOptionsOfImageAsync(imageDetails.drawableId, Resources);
				bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, imageDetails.drawableId, options, 250, 250);
				imgButton = FindViewById<ImageButton>(imageDetails.resource);
				imgButton.SetImageBitmap(bitmapToDisplay);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Drawable drawable = linearLayoutFront.Background;
			linearLayoutFront.SetBackgroundDrawable(null);
			drawable.Dispose();
			drawable = linearLayoutBack.Background;
			linearLayoutBack.SetBackgroundDrawable(null);
			drawable.Dispose();
			foreach (imageLoadingDetails imageLoadingDetail in buttonResource)
			{
				imgButton = FindViewById<ImageButton>(imageLoadingDetail.resource);
				drawable = imgButton.Drawable;
				imgButton.SetImageBitmap(null);
				drawable.Dispose();
			}
			if (linearLayoutFront != null)
			{
				linearLayoutFront.Dispose();
				linearLayoutFront = null;
			}
			if (linearLayoutBack != null)
			{
				linearLayoutBack.Dispose();
				linearLayoutBack = null;
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
			if (imgButton != null)
			{
				imgButton.Dispose();
				imgButton = null;
			}
			if (background != null)
			{
				background.Dispose();
				background = null;
			}
			if (bitmapForBackground != null)
			{
				bitmapForBackground.Dispose();
				bitmapForBackground = null;
			}
			//backgrounds = null;
			buttonResource = null;
			videoAbjads = null;
			videoAbjadDetail = null;
			this.Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			GC.Collect(GC.MaxGeneration);
		}

        public override void OnBackPressed()
        {
            var view = LayoutInflater.Inflate(Resource.Layout.ExitDialog, null);
            var buttonOK = view.FindViewById<ImageButton>(Resource.Id.btnExitOK);
            var buttonCancel = view.FindViewById<ImageButton>(Resource.Id.btnExitCancel);
            buttonOK.Click += delegate
            {
                this.Finish();
            };
            AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
            dialogBuilder.SetView(view);
            var ad = dialogBuilder.Create();
            ad.Show();
            buttonCancel.Click += delegate
            {
                ad.Cancel();
            };
        }
    }
}

