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
	[Activity(Label = "TestVideoActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
	public class AbjadVideoActivity : Activity
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
		private List<videoAbjadDetails> videoAbjads;
		private videoAbjadDetails videoAbjadDetail;
		private Animation zoomIn;
		private int sequence;
		private string symbol;
		private Intent starterIntent;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			starterIntent = Intent;
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.AbjadVideoLayout);

			string category = Intent.Extras.GetString("category");
			symbol = Intent.Extras.GetString("key");
			videoAbjads = new List<videoAbjadDetails>();

			if (category.Equals("v")){
				videoAbjads.Add(new videoAbjadDetails("a", Resource.Raw.A, "v", 1,new videoAbjadExampleDetails(Resource.Drawable.api,Resource.Raw.examples_api),new videoAbjadExampleDetails(Resource.Drawable.ayam, Resource.Raw.examples_ayam), new videoAbjadExampleDetails(Resource.Drawable.awam,Resource.Raw.examples_awam),null,null));
				videoAbjads.Add(new videoAbjadDetails("i", Resource.Raw.I, "v", 2,new videoAbjadExampleDetails(Resource.Drawable.ikan,Resource.Raw.examples_ikan),new videoAbjadExampleDetails(Resource.Drawable.itik,Resource.Raw.examples_itik),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("u", Resource.Raw.U, "v", 3,new videoAbjadExampleDetails(Resource.Drawable.ubi,Resource.Raw.examples_ubi),new videoAbjadExampleDetails(Resource.Drawable.ular,Resource.Raw.examples_ular),new videoAbjadExampleDetails(Resource.Drawable.ulat,Resource.Raw.examples_ulat), null, null));
				videoAbjads.Add(new videoAbjadDetails("e", Resource.Raw.E, "v", 4,new videoAbjadExampleDetails(Resource.Drawable.emak,Resource.Raw.examples_emak),new videoAbjadExampleDetails(Resource.Drawable.emas,Resource.Raw.examples_emas),new videoAbjadExampleDetails(Resource.Drawable.enam,Resource.Raw.examples_enam), null, null));
				videoAbjads.Add(new videoAbjadDetails("e2", Resource.Raw.EA, "v", 5, new videoAbjadExampleDetails(Resource.Drawable.ekor, Resource.Raw.examples_ekor), new videoAbjadExampleDetails(Resource.Drawable.epal, Resource.Raw.examples_epal),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("o", Resource.Raw.O, "v", 6, new videoAbjadExampleDetails(Resource.Drawable.otak, Resource.Raw.examples_otak), new videoAbjadExampleDetails(Resource.Drawable.oren, Resource.Raw.examples_oren), new videoAbjadExampleDetails(Resource.Drawable.obor, Resource.Raw.examples_obor), null, null));
			}else if(category.Equals("k")){
				videoAbjads.Add(new videoAbjadDetails("b", Resource.Raw.B, "k", 1, new videoAbjadExampleDetails(Resource.Drawable.bas, Resource.Raw.example_bas), new videoAbjadExampleDetails(Resource.Drawable.bola, Resource.Raw.example_bola),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("c", Resource.Raw.C, "k", 2, new videoAbjadExampleDetails(Resource.Drawable.ceri, Resource.Raw.example_ceri), new videoAbjadExampleDetails(Resource.Drawable.cawan, Resource.Raw.example_cawan), new videoAbjadExampleDetails(Resource.Drawable.cicak, Resource.Raw.example_cicak), null, null));
				videoAbjads.Add(new videoAbjadDetails("d", Resource.Raw.D, "k", 3, new videoAbjadExampleDetails(Resource.Drawable.dadu, Resource.Raw.example_dadu), new videoAbjadExampleDetails(Resource.Drawable.duri, Resource.Raw.example_duri), null, null, null));
				videoAbjads.Add(new videoAbjadDetails("f", Resource.Raw.F, "k", 4, new videoAbjadExampleDetails(Resource.Drawable.feri, Resource.Raw.example_feri), new videoAbjadExampleDetails(Resource.Drawable.foto, Resource.Raw.example_foto), new videoAbjadExampleDetails(Resource.Drawable.filem, Resource.Raw.example_filem), null, null));
				videoAbjads.Add(new videoAbjadDetails("g", Resource.Raw.G, "k", 5, new videoAbjadExampleDetails(Resource.Drawable.guli, Resource.Raw.example_guli), new videoAbjadExampleDetails(Resource.Drawable.gajah, Resource.Raw.example_gajah),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("h", Resource.Raw.H, "k", 6, new videoAbjadExampleDetails(Resource.Drawable.hon, Resource.Raw.example_hon), new videoAbjadExampleDetails(Resource.Drawable.hoki, Resource.Raw.example_hoki),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("j", Resource.Raw.J, "k", 7, new videoAbjadExampleDetails(Resource.Drawable.jam, Resource.Raw.example_jam), new videoAbjadExampleDetails(Resource.Drawable.jala, Resource.Raw.example_jala), new videoAbjadExampleDetails(Resource.Drawable.jari, Resource.Raw.example_jari), null, null));
				videoAbjads.Add(new videoAbjadDetails("k", Resource.Raw.K, "k", 8, new videoAbjadExampleDetails(Resource.Drawable.keju, Resource.Raw.example_keju), new videoAbjadExampleDetails(Resource.Drawable.kuda, Resource.Raw.example_kuda), null, null, null));
                videoAbjads.Add(new videoAbjadDetails("l", Resource.Raw.L, "k", 9, new videoAbjadExampleDetails(Resource.Drawable.laci, Resource.Raw.example_laci), new videoAbjadExampleDetails(Resource.Drawable.lori, Resource.Raw.example_lori), new videoAbjadExampleDetails(Resource.Drawable.lilin, Resource.Raw.example_lilin), null, null));
				videoAbjads.Add(new videoAbjadDetails("m", Resource.Raw.M, "k", 10, new videoAbjadExampleDetails(Resource.Drawable.madu, Resource.Raw.example_madu), new videoAbjadExampleDetails(Resource.Drawable.mata, Resource.Raw.example_mata), new videoAbjadExampleDetails(Resource.Drawable.meja, Resource.Raw.example_meja), null, null));
				videoAbjads.Add(new videoAbjadDetails("n", Resource.Raw.N, "k", 11, new videoAbjadExampleDetails(Resource.Drawable.naga, Resource.Raw.example_naga), new videoAbjadExampleDetails(Resource.Drawable.nasi, Resource.Raw.example_nasi), new videoAbjadExampleDetails(Resource.Drawable.nuri, Resource.Raw.example_nuri), null, null));
                videoAbjads.Add(new videoAbjadDetails("p", Resource.Raw.P, "k", 12, new videoAbjadExampleDetails(Resource.Drawable.pen, Resource.Raw.example_pen), new videoAbjadExampleDetails(Resource.Drawable.pos, Resource.Raw.example_pos), new videoAbjadExampleDetails(Resource.Drawable.paku, Resource.Raw.example_paku), null, null));
				videoAbjads.Add(new videoAbjadDetails("q", Resource.Raw.Q, "k", 13, new videoAbjadExampleDetails(Resource.Drawable.qari, Resource.Raw.example_qari), null, null, null, null));
				videoAbjads.Add(new videoAbjadDetails("r", Resource.Raw.R, "k", 14, new videoAbjadExampleDetails(Resource.Drawable.roda, Resource.Raw.example_roda), new videoAbjadExampleDetails(Resource.Drawable.ros, Resource.Raw.example_ros), new videoAbjadExampleDetails(Resource.Drawable.roti, Resource.Raw.example_roti), null, null));
				videoAbjads.Add(new videoAbjadDetails("s", Resource.Raw.S, "k", 15, new videoAbjadExampleDetails(Resource.Drawable.sup, Resource.Raw.example_sup), new videoAbjadExampleDetails(Resource.Drawable.susu, Resource.Raw.example_susu), null, null, null));
				videoAbjads.Add(new videoAbjadDetails("t", Resource.Raw.T, "k", 16, new videoAbjadExampleDetails(Resource.Drawable.tali, Resource.Raw.example_tali),new videoAbjadExampleDetails(Resource.Drawable.topi, Resource.Raw.example_topi),new videoAbjadExampleDetails(Resource.Drawable.tukul, Resource.Raw.example_tukul), null, null));
				videoAbjads.Add(new videoAbjadDetails("v", Resource.Raw.V, "k", 17, new videoAbjadExampleDetails(Resource.Drawable.vas, Resource.Raw.example_vas), new videoAbjadExampleDetails(Resource.Drawable.video, Resource.Raw.example_video), null, null, null));
				videoAbjads.Add(new videoAbjadDetails("w", Resource.Raw.W, "k", 18,new videoAbjadExampleDetails(Resource.Drawable.wau, Resource.Raw.example_wau),new videoAbjadExampleDetails(Resource.Drawable.wang, Resource.Raw.example_wang),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("x", Resource.Raw.X, "k", 19,new videoAbjadExampleDetails(Resource.Drawable.xray2, Resource.Raw.example_xray),null,null, null, null));
				videoAbjads.Add(new videoAbjadDetails("y", Resource.Raw.Y, "k", 20,new videoAbjadExampleDetails(Resource.Drawable.yu, Resource.Raw.example_yu),new videoAbjadExampleDetails(Resource.Drawable.yoyo, Resource.Raw.example_yoyo),null, null, null));
				videoAbjads.Add(new videoAbjadDetails("z", Resource.Raw.Z, "k", 21,new videoAbjadExampleDetails(Resource.Drawable.zip, Resource.Raw.example_zip),new videoAbjadExampleDetails(Resource.Drawable.zoo, Resource.Raw.example_zoo),null, null, null));
			}


			videoAbjadDetail = (from d in videoAbjads
								where d.category.Equals(category) && d.symbol.Equals(symbol)
			                    select d).FirstOrDefault();

			videoView = (VideoView)FindViewById(Resource.Id.videoView);
			videoView.Completion += VideoView_Completion;
			String srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.videoID;
			videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
			videoView.Start();

			//Back button
			FindViewById<ImageButton>(Resource.Id.AbjadVideoBackBtn).Click += delegate {
				if (category.Equals("v"))
				{
					Intent intent = new Intent(this, typeof(AbjadVokalActivity));
					StartActivity(intent);
					this.Finish();
				}
				else if (category.Equals("k")){
					Intent intent = new Intent(this, typeof(AbjadKonsonanActivity));
					StartActivity(intent);
					this.Finish();
				}
			};

			// link example 1 with video
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Invisible;
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample1).Click += delegate {
				videoView.Completion -= VideoView_Completion;
				srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.abjadExample1.videoPath;
				videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
				videoView.Start();
			};

			//if example 2 is not null
			if (videoAbjadDetail.abjadExample2 != null)
			{
				// link example 2 with video
				FindViewById<ImageButton>(Resource.Id.AbjadVideoExample2).Visibility = ViewStates.Invisible;
				FindViewById<ImageButton>(Resource.Id.AbjadVideoExample2).Click += delegate
				{
					videoView.Completion -= VideoView_Completion;
					srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.abjadExample2.videoPath;
					videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
					videoView.Start();
				};
			}

			//if example 3 is not null
			if (videoAbjadDetail.abjadExample3 != null)
			{
				// link example 3 with video
				FindViewById<ImageButton>(Resource.Id.AbjadVideoExample3).Visibility = ViewStates.Invisible;
				FindViewById<ImageButton>(Resource.Id.AbjadVideoExample3).Click += delegate
				{
					videoView.Completion -= VideoView_Completion;
					srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.abjadExample3.videoPath;
					videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
					videoView.Start();
				};
			} else //if example 3 is null
            {
                FindViewById<LinearLayout>(Resource.Id.AbjadVideoExampleLinearLayout3).Visibility = ViewStates.Gone;
            }

			// detect if the first & last of vokal & konsonan
			if (videoAbjadDetail.category.Equals("v") && videoAbjadDetail.sequence == 1)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoLeftBtn).Visibility = ViewStates.Invisible;
			} 
			else if (videoAbjadDetail.category.Equals("k") && videoAbjadDetail.sequence == 1)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoLeftBtn).Visibility = ViewStates.Invisible;
			}
			else if (videoAbjadDetail.category.Equals("v") && videoAbjadDetail.sequence == 6)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoRightBtn).Visibility = ViewStates.Invisible;
			}
			else if (videoAbjadDetail.category.Equals("k") && videoAbjadDetail.sequence == 21)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoRightBtn).Visibility = ViewStates.Invisible;
			}

			//function of left button
			FindViewById<ImageButton>(Resource.Id.AbjadVideoLeftBtn).Click += delegate
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
			FindViewById<ImageButton>(Resource.Id.AbjadVideoRightBtn).Click += delegate
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

            FindViewById<ImageButton>(Resource.Id.AbjadVideoInfoBtn).Click += delegate
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

		void VideoView_Completion(object sender, EventArgs e)
		{
			/*crossfader = new TransitionDrawable(backgrounds.ToArray());
			linearLayout.SetBackgroundDrawable(crossfader);
			crossfader.StartTransition(3000);*/
			zoomIn = AnimationUtils.LoadAnimation(this, Resource.Animation.zoom_in);
			linearLayoutFront = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVideoFront);
			linearLayoutFront.StartAnimation(zoomIn);
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Visible;
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample2).Visibility = ViewStates.Visible;
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample3).Visibility = ViewStates.Visible;
		}

		private async void loadBackgroundImage()
		{
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Abjad_Stroke_BrownCircleBGnew, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Abjad_Stroke_BrownCircleBGnew, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayoutFront = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVideoFront);
			linearLayoutFront.SetBackgroundDrawable(background);
			options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Abjad_main_OrangeBG, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Abjad_main_OrangeBG, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayoutBack = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVideoBack);
			linearLayoutBack.SetBackgroundDrawable(background);
		}

		private async void loadOtherImage()
		{
			//Save button image resource with each view id
			buttonResource = new List<imageLoadingDetails>();
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoBackBtn, drawableId = Resource.Drawable.Back_Button });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoLeftBtn, drawableId = Resource.Drawable.arrowL });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoRightBtn, drawableId = Resource.Drawable.arrowR });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoInfoBtn, drawableId = Resource.Drawable.Option_info });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoExample1, drawableId =  videoAbjadDetail.abjadExample1.imgPath});
			if (videoAbjadDetail.abjadExample2 != null)
			{
				buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoExample2, drawableId = videoAbjadDetail.abjadExample2.imgPath });
			}
			if (videoAbjadDetail.abjadExample3 != null)
			{
				buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoExample3, drawableId = videoAbjadDetail.abjadExample3.imgPath });
			}
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

