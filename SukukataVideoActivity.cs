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
	[Activity(Label = "SukukataVideoActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
	public class SukukataVideoActivity : Activity
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
			SetContentView(Resource.Layout.SukukataVideoLayout);

			string category = Intent.Extras.GetString("category");
			symbol = Intent.Extras.GetString("key");
			videoAbjads = new List<videoAbjadDetails>();

			if (category.Equals("v")){
			}else if(category.Equals("k")){
				videoAbjads.Add(new videoAbjadDetails("b", Resource.Raw.bagus, "k", 1, new videoAbjadExampleDetails(Resource.Drawable.ba, Resource.Raw.ba), new videoAbjadExampleDetails(Resource.Drawable.bi, Resource.Raw.bi), new videoAbjadExampleDetails(Resource.Drawable.bu, Resource.Raw.bu), new videoAbjadExampleDetails(Resource.Drawable.be, Resource.Raw.be), new videoAbjadExampleDetails(Resource.Drawable.bo, Resource.Raw.bo)));
				videoAbjads.Add(new videoAbjadDetails("c", Resource.Raw.cicak, "k", 2, new videoAbjadExampleDetails(Resource.Drawable.ca, Resource.Raw.example_ceri), new videoAbjadExampleDetails(Resource.Drawable.ci, Resource.Raw.example_cawan), new videoAbjadExampleDetails(Resource.Drawable.cu, Resource.Raw.example_cicak), new videoAbjadExampleDetails(Resource.Drawable.ce, Resource.Raw.example_cicak), new videoAbjadExampleDetails(Resource.Drawable.co, Resource.Raw.example_cicak)));
				videoAbjads.Add(new videoAbjadDetails("d", Resource.Raw.duri, "k", 3, new videoAbjadExampleDetails(Resource.Drawable.da, Resource.Raw.example_dadu), new videoAbjadExampleDetails(Resource.Drawable.di, Resource.Raw.example_duri), new videoAbjadExampleDetails(Resource.Drawable.du, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.de, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.doo, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("f", Resource.Raw.filem, "k", 4, new videoAbjadExampleDetails(Resource.Drawable.fa, Resource.Raw.example_feri), new videoAbjadExampleDetails(Resource.Drawable.fi, Resource.Raw.example_foto), new videoAbjadExampleDetails(Resource.Drawable.fu, Resource.Raw.example_filem), new videoAbjadExampleDetails(Resource.Drawable.fe, Resource.Raw.example_filem), new videoAbjadExampleDetails(Resource.Drawable.fo, Resource.Raw.example_filem)));
				videoAbjads.Add(new videoAbjadDetails("g", Resource.Raw.gajah, "k", 5, new videoAbjadExampleDetails(Resource.Drawable.ga, Resource.Raw.example_guli), new videoAbjadExampleDetails(Resource.Drawable.gi, Resource.Raw.example_gajah), new videoAbjadExampleDetails(Resource.Drawable.gu, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.ge, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.go, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("h", Resource.Raw.hero, "k", 6, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_h, Resource.Raw.example_hon), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_h, Resource.Raw.example_hoki), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_h, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_h, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_h, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("j", Resource.Raw.jam, "k", 7, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_j, Resource.Raw.example_jam), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_j, Resource.Raw.example_jala), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_j, Resource.Raw.example_jari), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_j, Resource.Raw.example_jari), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_j, Resource.Raw.example_jari)));
				videoAbjads.Add(new videoAbjadDetails("k", Resource.Raw.katak, "k", 8, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_k, Resource.Raw.example_keju), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_k, Resource.Raw.example_kuda), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_k, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_k, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_k, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("l", Resource.Raw.lilin, "k", 9, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_l, Resource.Raw.example_laci), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_l, Resource.Raw.example_lori), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_l, Resource.Raw.example_lilin), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_l, Resource.Raw.example_lilin), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_l, Resource.Raw.example_lilin)));
				videoAbjads.Add(new videoAbjadDetails("m", Resource.Raw.meja, "k", 10, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_m, Resource.Raw.example_madu), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_m, Resource.Raw.example_mata), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_m, Resource.Raw.example_meja), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_m, Resource.Raw.example_meja), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_m, Resource.Raw.example_meja)));
				videoAbjads.Add(new videoAbjadDetails("n", Resource.Raw.naga, "k", 11, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_n, Resource.Raw.example_naga), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_n, Resource.Raw.example_nasi), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_n, Resource.Raw.example_nuri), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_n, Resource.Raw.example_nuri), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_n, Resource.Raw.example_nuri)));
                videoAbjads.Add(new videoAbjadDetails("p", Resource.Raw.pen, "k", 12, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_p, Resource.Raw.example_pen), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_p, Resource.Raw.example_pos), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_p, Resource.Raw.example_paku), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_p, Resource.Raw.example_paku), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_p, Resource.Raw.example_paku)));
				videoAbjads.Add(new videoAbjadDetails("q", Resource.Raw.qari, "k", 13, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_q, Resource.Raw.example_qari), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_q, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_q, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_q, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_q, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("r", Resource.Raw.roti, "k", 14, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_r, Resource.Raw.example_roda), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_r, Resource.Raw.example_ros), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_r, Resource.Raw.example_roti), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_r, Resource.Raw.example_roti), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_r, Resource.Raw.example_roti)));
				videoAbjads.Add(new videoAbjadDetails("s", Resource.Raw.semut, "k", 15, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_s, Resource.Raw.example_sup), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_s, Resource.Raw.example_susu), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_s, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_s, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_s, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("t", Resource.Raw.tukul, "k", 16, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_t, Resource.Raw.example_tali),new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_t, Resource.Raw.example_topi),new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_t, Resource.Raw.example_tukul), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_t, Resource.Raw.example_tukul), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_t, Resource.Raw.example_tukul)));
				videoAbjads.Add(new videoAbjadDetails("v", Resource.Raw.vas, "k", 17, new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_v, Resource.Raw.example_vas), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_v, Resource.Raw.example_video), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_v, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_v, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_v, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("w", Resource.Raw.wayar, "k", 18,new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_w, Resource.Raw.example_wau),new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_w, Resource.Raw.example_wang), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_w, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_w, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_w, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("x", Resource.Raw.xray, "k", 19,new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_x, Resource.Raw.example_xray), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_x, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_x, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_x, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_x, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("y", Resource.Raw.yoyo, "k", 20,new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_y, Resource.Raw.example_yu),new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_y, Resource.Raw.example_yoyo), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_y, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_y, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_y, Resource.Raw.examples_api)));
				videoAbjads.Add(new videoAbjadDetails("z", Resource.Raw.zip, "k", 21,new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_z, Resource.Raw.example_zip),new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_z, Resource.Raw.example_zoo), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_z, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_z, Resource.Raw.examples_api), new videoAbjadExampleDetails(Resource.Drawable.Abjad_Button_z, Resource.Raw.examples_api)));
			}


			videoAbjadDetail = (from d in videoAbjads
								where d.category.Equals (category) && d.symbol.Equals(symbol)
			                    select d).FirstOrDefault();

            videoView = (VideoView)FindViewById(Resource.Id.videoView);
            String srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.videoID;
            videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
            videoView.SeekTo(2000);
            videoView.SetZOrderOnTop(true);
            videoView.SetBackgroundColor(Color.Transparent);


            //Back button
            FindViewById<ImageButton>(Resource.Id.AbjadVideoBackBtn).Click += delegate {
					Intent intent = new Intent(this, typeof(SukukataSelectionActivity));
					StartActivity(intent);
					this.Finish();
			};

			// link example 1 with video
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Invisible;
			FindViewById<ImageButton>(Resource.Id.AbjadVideoExample1).Click += delegate {
                videoView.SetZOrderOnTop(true);
                videoView.SetBackgroundColor(Color.Transparent);
                videoView.Completion -= VideoView_Completion;
				srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.abjadExample1.videoPath;
				videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
				videoView.Start();
                videoView.SetBackgroundColor(Color.Transparent);
            };

			//if example 2 is not null
			if (videoAbjadDetail.abjadExample2 != null)
			{
                videoView.SetZOrderOnTop(true);
                videoView.SetBackgroundColor(Color.Transparent);
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
                videoView.SetZOrderOnTop(true);
                videoView.SetBackgroundColor(Color.Transparent);
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

            if (videoAbjadDetail.abjadExample4 != null)
            {
                videoView.SetZOrderOnTop(true);
                videoView.SetBackgroundColor(Color.Transparent);
                // link example 4 with video
                FindViewById<ImageButton>(Resource.Id.AbjadVideoExample4).Click += delegate
                {
                    videoView.Completion -= VideoView_Completion;
                    srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.abjadExample4.videoPath;
                    videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
                    videoView.Start();
                };
            }

            if (videoAbjadDetail.abjadExample5 != null)
            {
                videoView.SetZOrderOnTop(true);
                videoView.SetBackgroundColor(Color.Transparent);
                // link example 5 with video
                FindViewById<ImageButton>(Resource.Id.AbjadVideoExample5).Click += delegate
                {
                    videoView.Completion -= VideoView_Completion;
                    srcPath = "android.resource://" + PackageName + "/" + videoAbjadDetail.abjadExample5.videoPath;
                    videoView.SetVideoURI(Android.Net.Uri.Parse(srcPath));
                    videoView.Start();
                };
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
            zoomIn = AnimationUtils.LoadAnimation(this, Resource.Animation.zoom_in);
            linearLayoutFront = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVideoFront);
            linearLayoutFront.StartAnimation(zoomIn);
            FindViewById<ImageButton>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Visible;
            FindViewById<ImageButton>(Resource.Id.AbjadVideoExample2).Visibility = ViewStates.Visible;
            FindViewById<ImageButton>(Resource.Id.AbjadVideoExample3).Visibility = ViewStates.Visible;

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
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoExample4, drawableId = videoAbjadDetail.abjadExample4.imgPath });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoExample5, drawableId = videoAbjadDetail.abjadExample5.imgPath });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoExample1, drawableId = videoAbjadDetail.abjadExample1.imgPath});
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
			drawable = linearLayoutBack.Background;
			linearLayoutBack.SetBackgroundDrawable(null);
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

