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
	[Activity(Label = "PerkataanVideoActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
	public class PerkataanVideoActivity : Activity
	{
		private ImageView imageView;
		private BitmapFactory.Options options;
		private Bitmap bitmapToDisplay;
		private LinearLayout linearLayoutFront;
		private LinearLayout linearLayoutBack;
		//private List<Drawable> backgrounds;
		private Bitmap bitmapForBackground;
		private Drawable background;
		private ImageButton imgButton;
        private TextView txtView;
        private List<imageLoadingDetails> buttonResource;
        private List<textLoadingDetails> textResource;
        private TransitionDrawable crossfader;
		private List<videoPerkataanDetails> videoPerkataans;
		private videoPerkataanDetails videoPerkataanDetail;
		private Animation zoomIn;
		private int sequence;
		private string symbol;
		private Intent starterIntent;
        MediaPlayer mp;

        protected async override void OnCreate(Bundle savedInstanceState)
		{
			starterIntent = Intent;
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.PerkataanVideoLayout);

			string category = Intent.Extras.GetString("category");
			symbol = Intent.Extras.GetString("key");
            videoPerkataans = new List<videoPerkataanDetails>();

			if (category.Equals("v")){
			}else if(category.Equals("k")){
                videoPerkataans.Add(new videoPerkataanDetails("b", Resource.Raw.bagus, "k", 1, new videoPerkataanExampleDetails("buka", Resource.Raw.buka,Resource.Drawable.buka01), new videoPerkataanExampleDetails("cuka", Resource.Raw.cuka, Resource.Drawable.cuka01), new videoPerkataanExampleDetails("duka", Resource.Raw.duka, Resource.Drawable.duka01), new videoPerkataanExampleDetails("luka", Resource.Raw.luka, Resource.Drawable.luka01), new videoPerkataanExampleDetails("muka", Resource.Raw.muka, Resource.Drawable.muka01), new videoPerkataanExampleDetails("suka", Resource.Raw.suka, Resource.Drawable.suka01),null,null));
                videoPerkataans.Add(new videoPerkataanDetails("c", Resource.Raw.cicak, "k", 2, new videoPerkataanExampleDetails("kaku", Resource.Raw.kaku, Resource.Drawable.kaku01), new videoPerkataanExampleDetails("paku", Resource.Raw.paku, Resource.Drawable.paku01), new videoPerkataanExampleDetails("saku", Resource.Raw.saku, Resource.Drawable.saku01), new videoPerkataanExampleDetails("beku", Resource.Raw.beku, Resource.Drawable.beku01), new videoPerkataanExampleDetails("buku", Resource.Raw.buku, Resource.Drawable.buku01), new videoPerkataanExampleDetails("duku", Resource.Raw.duku, Resource.Drawable.duku01), new videoPerkataanExampleDetails("kuku", Resource.Raw.kuku, Resource.Drawable.kuku01), new videoPerkataanExampleDetails("liku", Resource.Raw.liku, Resource.Drawable.liku01)));
                videoPerkataans.Add(new videoPerkataanDetails("d", Resource.Raw.duri, "k", 3, new videoPerkataanExampleDetails("batik", Resource.Raw.batik, Resource.Drawable.batik01), new videoPerkataanExampleDetails("katik", Resource.Raw.katik, Resource.Drawable.katik01), new videoPerkataanExampleDetails("betik", Resource.Raw.betik, Resource.Drawable.betik01), new videoPerkataanExampleDetails("detik", Resource.Raw.detik, Resource.Drawable.detik01), new videoPerkataanExampleDetails("petik", Resource.Raw.petik, Resource.Drawable.petik01), null,null,null));
                videoPerkataans.Add(new videoPerkataanDetails("f", Resource.Raw.filem, "k", 4, new videoPerkataanExampleDetails("batuk", Resource.Raw.batuk, Resource.Drawable.batuk01), new videoPerkataanExampleDetails("catuk", Resource.Raw.catuk, Resource.Drawable.catuk01), new videoPerkataanExampleDetails("datuk", Resource.Raw.datuk, Resource.Drawable.datuk01), new videoPerkataanExampleDetails("patuk", Resource.Raw.patuk, Resource.Drawable.patuk01), new videoPerkataanExampleDetails("cucuk", Resource.Raw.cucuk, Resource.Drawable.cucuk01), new videoPerkataanExampleDetails("pucuk", Resource.Raw.pucuk, Resource.Drawable.pucuk01), new videoPerkataanExampleDetails("tusuk", Resource.Raw.tusuk, Resource.Drawable.tusuk01), null));
                videoPerkataans.Add(new videoPerkataanDetails("g", Resource.Raw.gajah, "k", 5, new videoPerkataanExampleDetails("dakap", Resource.Raw.dakap, Resource.Drawable.dakap01), new videoPerkataanExampleDetails("dapat", Resource.Raw.dapat, Resource.Drawable.dapat01), new videoPerkataanExampleDetails("lekat", Resource.Raw.lekat, Resource.Drawable.lekat01), new videoPerkataanExampleDetails("lepat", Resource.Raw.lepat, Resource.Drawable.lepat01), new videoPerkataanExampleDetails("lipat", Resource.Raw.lipat, Resource.Drawable.lipat01), new videoPerkataanExampleDetails("lumut", Resource.Raw.lumut, Resource.Drawable.lumut01), new videoPerkataanExampleDetails("luput", Resource.Raw.luput, Resource.Drawable.luput01), null));
                videoPerkataans.Add(new videoPerkataanDetails("h", Resource.Raw.hero, "k", 6, new videoPerkataanExampleDetails("parut", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("perut", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("kerut", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("lutut", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("pulut", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("susut", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null));
                videoPerkataans.Add(new videoPerkataanDetails("j", Resource.Raw.jam, "k", 7, new videoPerkataanExampleDetails("berus", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("rebus", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("terus", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("kurus", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("lurus", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null, null));
                videoPerkataans.Add(new videoPerkataanDetails("k", Resource.Raw.katak, "k", 8, new videoPerkataanExampleDetails("kesan", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("pesan", Resource.Raw.examples_ayam, Resource.Drawable.p1), null, null, null, null, null, null));
                videoPerkataans.Add(new videoPerkataanDetails("l", Resource.Raw.lilin, "k", 9, new videoPerkataanExampleDetails("canda", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("tanda", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("denda", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("renda", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("bonda", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("ronda", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("tunda", Resource.Raw.examples_awam, Resource.Drawable.p1), null));
                videoPerkataans.Add(new videoPerkataanDetails("m", Resource.Raw.meja, "k", 10, new videoPerkataanExampleDetails("laksa", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("paksa", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("raksa", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null, null, null, null));
                videoPerkataans.Add(new videoPerkataanDetails("n", Resource.Raw.naga, "k", 11, new videoPerkataanExampleDetails("sampah", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("rempah", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("rendah", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("pindah", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null, null, null));
                videoPerkataans.Add(new videoPerkataanDetails("p", Resource.Raw.pen, "k", 12, new videoPerkataanExampleDetails("balung", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("palung", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("gelung", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("relung", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("gulung", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("sulung", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("menung", Resource.Raw.examples_awam, Resource.Drawable.p1), null));
                videoPerkataans.Add(new videoPerkataanDetails("q", Resource.Raw.qari, "k", 13, new videoPerkataanExampleDetails("lotong", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("potong", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("sotong", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null, null, null, null));
                videoPerkataans.Add(new videoPerkataanDetails("r", Resource.Raw.roti, "k", 14, new videoPerkataanExampleDetails("gelama", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("celana", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("kelana", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("pelana", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("delima", Resource.Raw.examples_awam, Resource.Drawable.p1), new videoPerkataanExampleDetails("terima", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null));
                videoPerkataans.Add(new videoPerkataanDetails("s", Resource.Raw.semut, "k", 15, new videoPerkataanExampleDetails("meradang", Resource.Raw.examples_api, Resource.Drawable.p1), new videoPerkataanExampleDetails("peladang", Resource.Raw.examples_ayam, Resource.Drawable.p1), new videoPerkataanExampleDetails("seladang", Resource.Raw.examples_awam, Resource.Drawable.p1), null, null, null, null, null));
            }


            videoPerkataanDetail = (from d in videoPerkataans
								where d.category.Equals (category) && d.symbol.Equals(symbol)
			                    select d).FirstOrDefault();

            imageView = (ImageView)FindViewById(Resource.Id.imageView);
            String srcPath = "";
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.blank, Resources);
            bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.blank, options, 1260, 1080);
            background = new BitmapDrawable(bitmapToDisplay);
            imageView.SetImageDrawable(background);


            //Back button
            FindViewById<ImageButton>(Resource.Id.AbjadVideoBackBtn).Click += delegate {
					Intent intent = new Intent(this, typeof(PerkataanSelectionActivity));
					StartActivity(intent);
					this.Finish();
			};

			// link example 1 with video
			FindViewById<TextView>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Invisible;
			FindViewById<TextView>(Resource.Id.AbjadVideoExample1).Click += async delegate {
                if(mp != null)
                {
                    mp.Stop();
                }

                options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample1.imagePath, Resources);
                bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample1.imagePath, options, 1260, 1080);
                background = new BitmapDrawable(bitmapToDisplay);
                imageView.SetImageDrawable(background);

                srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample1.videoPath;
                mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                mp.Start();
            };

			//if example 2 is not null
			if (videoPerkataanDetail.abjadExample2 != null)
			{
				// link example 2 with video
				FindViewById<TextView>(Resource.Id.AbjadVideoExample2).Visibility = ViewStates.Invisible;
				FindViewById<TextView>(Resource.Id.AbjadVideoExample2).Click += async delegate
				{
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample2.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample2.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample2.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
			}

			//if example 3 is not null
			if (videoPerkataanDetail.abjadExample3 != null)
			{
				// link example 3 with video
				FindViewById<TextView>(Resource.Id.AbjadVideoExample3).Visibility = ViewStates.Invisible;
				FindViewById<TextView>(Resource.Id.AbjadVideoExample3).Click += async delegate
                {
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample3.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample3.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample3.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
			}

            if (videoPerkataanDetail.abjadExample4 != null)
            {
                FindViewById<TextView>(Resource.Id.AbjadVideoExample4).Click += async delegate
                {
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample4.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample4.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample4.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
            }

            if (videoPerkataanDetail.abjadExample5 != null)
            {
                FindViewById<TextView>(Resource.Id.AbjadVideoExample5).Click += async delegate
                {
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample5.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample5.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample5.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
            }

            if (videoPerkataanDetail.abjadExample6 != null)
            {
                FindViewById<TextView>(Resource.Id.AbjadVideoExample6).Click += async delegate
                {
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample6.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample6.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample6.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
            }

            if (videoPerkataanDetail.abjadExample7 != null)
            {
                FindViewById<TextView>(Resource.Id.AbjadVideoExample7).Click += async delegate
                {
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample7.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample7.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample7.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
            }

            if (videoPerkataanDetail.abjadExample8 != null)
            {
                FindViewById<TextView>(Resource.Id.AbjadVideoExample8).Click += async delegate
                {
                    if (mp != null)
                    {
                        mp.Stop();
                    }

                    options = await decodeImage.GetBitmapOptionsOfImageAsync(videoPerkataanDetail.abjadExample8.imagePath, Resources);
                    bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, videoPerkataanDetail.abjadExample8.imagePath, options, 1260, 1080);
                    background = new BitmapDrawable(bitmapToDisplay);
                    imageView.SetImageDrawable(background);

                    srcPath = "android.resource://" + PackageName + "/" + videoPerkataanDetail.abjadExample8.videoPath;
                    mp = MediaPlayer.Create(this, Android.Net.Uri.Parse(srcPath));
                    mp.Start();
                };
            }
            // detect if the first & last of vokal & konsonan
            if (videoPerkataanDetail.category.Equals("v") && videoPerkataanDetail.sequence == 1)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoLeftBtn).Visibility = ViewStates.Invisible;
			} 
			else if (videoPerkataanDetail.category.Equals("k") && videoPerkataanDetail.sequence == 1)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoLeftBtn).Visibility = ViewStates.Invisible;
			}
			else if (videoPerkataanDetail.category.Equals("v") && videoPerkataanDetail.sequence == 6)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoRightBtn).Visibility = ViewStates.Invisible;
			}
			else if (videoPerkataanDetail.category.Equals("k") && videoPerkataanDetail.sequence == 15)
			{
				FindViewById<ImageButton>(Resource.Id.AbjadVideoRightBtn).Visibility = ViewStates.Invisible;
			}

			//function of left button
			FindViewById<ImageButton>(Resource.Id.AbjadVideoLeftBtn).Click += delegate
			{
				category = videoPerkataanDetail.category;
				sequence = videoPerkataanDetail.sequence - 1;
				symbol = (from p in videoPerkataans
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
				category = videoPerkataanDetail.category;
				sequence = videoPerkataanDetail.sequence + 1;
				symbol = (from p in videoPerkataans
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
			FindViewById<TextView>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Visible;
			FindViewById<TextView>(Resource.Id.AbjadVideoExample2).Visibility = ViewStates.Visible;
			FindViewById<TextView>(Resource.Id.AbjadVideoExample3).Visibility = ViewStates.Visible;
		}

		private async void loadBackgroundImage()
		{
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Abjad_main_OrangeBG, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Abjad_main_OrangeBG, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayoutBack = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVideoBack);
			linearLayoutBack.SetBackgroundDrawable(background);

            zoomIn = AnimationUtils.LoadAnimation(this, Resource.Animation.zoom_in);
            linearLayoutFront = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVideoFront);
            linearLayoutFront.StartAnimation(zoomIn);
            FindViewById<TextView>(Resource.Id.AbjadVideoExample1).Visibility = ViewStates.Visible;
            FindViewById<TextView>(Resource.Id.AbjadVideoExample2).Visibility = ViewStates.Visible;
            FindViewById<TextView>(Resource.Id.AbjadVideoExample3).Visibility = ViewStates.Visible;
        }

		private async void loadOtherImage()
		{
			//Save button image resource with each view id
			buttonResource = new List<imageLoadingDetails>();
            textResource = new List<textLoadingDetails>();

            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoBackBtn, drawableId = Resource.Drawable.Back_Button });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoLeftBtn, drawableId = Resource.Drawable.arrowL });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoRightBtn, drawableId = Resource.Drawable.arrowR });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVideoInfoBtn, drawableId = Resource.Drawable.Option_info });
            textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample1,  textId =  videoPerkataanDetail.abjadExample1.text});
			if (videoPerkataanDetail.abjadExample2 != null)
			{
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample2, textId = videoPerkataanDetail.abjadExample2.text });
			}
			if (videoPerkataanDetail.abjadExample3 != null)
			{
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample3, textId = videoPerkataanDetail.abjadExample3.text });
			}
            if (videoPerkataanDetail.abjadExample4 != null)
            {
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample4, textId = videoPerkataanDetail.abjadExample4.text });
            }
            if (videoPerkataanDetail.abjadExample5 != null)
            {
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample5, textId = videoPerkataanDetail.abjadExample5.text });
            }
            if (videoPerkataanDetail.abjadExample6 != null)
            {
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample6, textId = videoPerkataanDetail.abjadExample6.text });
            }
            if (videoPerkataanDetail.abjadExample7 != null)
            {
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample7, textId = videoPerkataanDetail.abjadExample7.text });
            }
            if (videoPerkataanDetail.abjadExample8 != null)
            {
                textResource.Add(new textLoadingDetails { resource = Resource.Id.AbjadVideoExample8, textId = videoPerkataanDetail.abjadExample8.text });
            }
            foreach (imageLoadingDetails imageDetails in buttonResource)
            {
                options = await decodeImage.GetBitmapOptionsOfImageAsync(imageDetails.drawableId, Resources);
                bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, imageDetails.drawableId, options, 250, 250);
                imgButton = FindViewById<ImageButton>(imageDetails.resource);
                imgButton.SetImageBitmap(bitmapToDisplay);
            }

            foreach (textLoadingDetails textDetails in textResource)
            {
                string path = "fonts/MyLexics_font.ttf";
                Typeface tf = Typeface.CreateFromAsset(Assets, path);

                if (textDetails.textId == "meradang" || textDetails.textId == "seladang" || textDetails.textId == "peladang")
                {
                    txtView = FindViewById<TextView>(textDetails.resource);
                    txtView.TextSize = 29;
                    txtView.SetTextColor(Color.Black);
                    txtView.SetHighlightColor(Color.Blue);
                    txtView.SetTypeface(tf, TypefaceStyle.Bold);
                    txtView.Text = textDetails.textId;
                }
                else
                {
                    txtView = FindViewById<TextView>(textDetails.resource);
                    txtView.TextSize = 33;
                    txtView.SetTextColor(Color.Black);
                    txtView.SetHighlightColor(Color.Blue);
                    txtView.SetTypeface(tf, TypefaceStyle.Bold);
                    txtView.Text = textDetails.textId;
                }
                
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
			videoPerkataans = null;
            videoPerkataanDetail = null;
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

