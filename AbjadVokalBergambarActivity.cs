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
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Content.PM;
using System.Threading.Tasks;
using Android.Util;

namespace MyLexics
{
	[Activity (Label = "AbjadVokalBergambarActivity",Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]			
	public class AbjadVokalBergambarActivity : Activity
	{
		private BitmapFactory.Options options;
		private Bitmap bitmapToDisplay;
		private LinearLayout linearLayout;
		private ImageButton imgButton;
		private List<imageLoadingDetails> buttonResource;
		private LinearLayout linearLayoutScrollViewVokal;
		private ImageView imgView;
		private DisplayMetrics displayMetrics;
		private double dpHeight;
		private double dpWidth;
		private LinearLayout.LayoutParams layoutParams;
		private List<vokalKonsonan> vokalList;
		private HorizontalScrollView horizontalSV;
		private int firstSymbol = 1;
		private ViewTreeObserver vto;
		private int horizontalSVMaxWidth;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.AbjadVokalBergambar);

			loadBackgroundImage();
			loadButtonImage();

			horizontalSV = FindViewById<HorizontalScrollView>(Resource.Id.AbjadVokalBergambarhorizontalSV);


			displayMetrics = this.Resources.DisplayMetrics;
			dpHeight = displayMetrics.HeightPixels / displayMetrics.Density * 20 / 100;

			linearLayoutScrollViewVokal = FindViewById<LinearLayout>(Resource.Id.linearLayoutScrollViewVokal);
			layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			layoutParams.SetMargins(Convert.ToInt32(dpHeight), 0, 0, 0);

			vokalList = new List<vokalKonsonan>();
			vokalList.Add(new vokalKonsonan("a", Resource.Drawable.Abjad_Button_a));
			vokalList.Add(new vokalKonsonan("i", Resource.Drawable.Abjad_Button_i));
			vokalList.Add(new vokalKonsonan("u", Resource.Drawable.Abjad_Button_u));
			vokalList.Add(new vokalKonsonan("e", Resource.Drawable.Abjad_Button_e));
			vokalList.Add(new vokalKonsonan("o", Resource.Drawable.Abjad_Button_o));

			foreach (vokalKonsonan vk in vokalList)
			{
				if (firstSymbol == 1)// first button without left margin
				{
					imgButton = new ImageButton(this);
					imgButton.SetBackgroundResource(vk.drawableId);
					linearLayoutScrollViewVokal.AddView(imgButton);
					firstSymbol++;
				}
				else {
					imgButton = new ImageButton(this);
					imgButton.SetBackgroundResource(vk.drawableId);
					linearLayoutScrollViewVokal.AddView(imgButton, layoutParams);
				}

				//function of btn
				imgButton.Click += delegate
				{
					Intent intent = new Intent(this, typeof(AbjadBergambarVideoActivity));
					intent.PutExtra("key",vk.symbol);
					intent.PutExtra("category", "v");
					StartActivity(intent);
					this.Finish();
				};

			}

			FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUIBackButton).Click += delegate
			{
				Intent intent = new Intent(this, typeof(AbjadSelectionActivity));
				StartActivity(intent);
				this.Finish();
			};

			FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUILeftButton).Touch +=  delegate {
				horizontalSV.ScrollTo(Convert.ToInt32(horizontalSV.ScrollX) - 50, Convert.ToInt32(horizontalSV.ScrollY));
			};

			FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUIRightButton).Touch += delegate
			{
				horizontalSV.ScrollTo(Convert.ToInt32(horizontalSV.ScrollX) + 50, Convert.ToInt32(horizontalSV.ScrollY));
			};

			vto = horizontalSV.ViewTreeObserver;
			vto.GlobalLayout += Vto_GlobalLayout;

			horizontalSV.ViewTreeObserver.ScrollChanged += delegate {
				if (horizontalSV.ScrollX == horizontalSVMaxWidth)
				{
					FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUIRightButton).Visibility = ViewStates.Invisible;
				}
				else if (horizontalSV.ScrollX == 0)
				{
					FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUILeftButton).Visibility = ViewStates.Invisible;

				}
				else
				{
					FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUILeftButton).Visibility = ViewStates.Visible;
					FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUIRightButton).Visibility = ViewStates.Visible;
				}
			};

			//Make left button disappear at first
			FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUILeftButton).Visibility = ViewStates.Invisible;

            FindViewById<ImageButton>(Resource.Id.AbjadVokalBergambarUIInfoButton).Click += delegate
            {
                //Toast.MakeText(this, "Button Setting 2", ToastLength.Long).Show();
                new AlertDialog.Builder(this)
               .SetView(Resource.Layout.ContactInformation)
               .SetPositiveButton("OK", delegate { })
               .Show();

            };
        }

		private void Vto_GlobalLayout(object sender, EventArgs e)
		{
			horizontalSVMaxWidth = (Convert.ToInt32(horizontalSV.GetChildAt(0).MeasuredWidth) - horizontalSV.MeasuredWidth);
		}

		private async void loadBackgroundImage(){
			BitmapDrawable background;
			options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.SubSubMenu_Background, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.SubSubMenu_Background, options, 1920, 1080);
			background = new BitmapDrawable(bitmapToDisplay);
			linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadVokalBergambar);
			linearLayout.SetBackgroundDrawable(background);
		}

		private async void loadButtonImage()
		{
			buttonResource = new List<imageLoadingDetails>();
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVokalBergambarUIBackButton, drawableId = Resource.Drawable.Back_Button });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVokalBergambarUIInfoButton, drawableId = Resource.Drawable.Option_info });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVokalBergambarUIRightButton, drawableId = Resource.Drawable.arrowR });
			buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadVokalBergambarUILeftButton, drawableId = Resource.Drawable.arrowL });
			foreach (imageLoadingDetails imageDetails in buttonResource)
			{
				options = await decodeImage.GetBitmapOptionsOfImageAsync(imageDetails.drawableId, Resources);
				bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, imageDetails.drawableId, options, 250, 250);
				imgButton = FindViewById<ImageButton>(imageDetails.resource);
				imgButton.SetImageBitmap(bitmapToDisplay);
			}
			options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Vokal_Bergambar_title, Resources);
			bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Vokal_Bergambar_title, options, 250, 250);
			imgView = FindViewById<ImageView>(Resource.Id.AbjadVokalBergambarUITitle);
			imgView.SetImageBitmap(bitmapToDisplay);
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			Drawable drawable = linearLayout.Background;
			linearLayout.SetBackgroundDrawable(null);
			drawable.Dispose();
			if (linearLayout != null)
			{
				linearLayout.Dispose();
				linearLayout = null;
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
			buttonResource = null;
			if (linearLayoutScrollViewVokal != null)
			{
				linearLayoutScrollViewVokal.Dispose();
				linearLayoutScrollViewVokal = null;
			}
			if (imgView != null)
			{
				imgView.Dispose();
				imgView = null;
			}
			if (displayMetrics != null)
			{
				displayMetrics.Dispose();
				displayMetrics = null;
			}
			if (layoutParams != null)
			{
				layoutParams.Dispose();
				layoutParams = null;
			}
			if (horizontalSV != null)
			{
				horizontalSV.Dispose();
				horizontalSV = null;
			}
			if (vto != null)
			{
				vto.Dispose();
				vto = null;
			}
			vokalList = null;
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

