
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MyLexics
{
    [Activity(Label = "PerkataanSelectionActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
    public class PerkataanSelectionActivity : Activity
    {
        private BitmapFactory.Options options;
        private Bitmap bitmapToDisplay;
        private LinearLayout linearLayout;
        private ImageButton imgButton;
        private List<imageLoadingDetails> buttonResource;
        private LinearLayout linearLayoutScrollViewKonsonan;
        private ImageView imgView;
        private DisplayMetrics displayMetrics;
        private double dpHeight;
        private LinearLayout.LayoutParams layoutParams;
        private List<vokalKonsonan> vokalList;
        private HorizontalScrollView horizontalSV;
        private int firstSymbol = 1;
        private ViewTreeObserver vto;
        private int horizontalSVMaxWidth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Create your application here
            SetContentView(Resource.Layout.PerkataanSelection);

            loadBackgroundImage();
            loadButtonImage();

            horizontalSV = FindViewById<HorizontalScrollView>(Resource.Id.AbjadKonsonanhorizontalSV);


            displayMetrics = this.Resources.DisplayMetrics;
            dpHeight = displayMetrics.HeightPixels / displayMetrics.Density * 20 / 100;

            linearLayoutScrollViewKonsonan = FindViewById<LinearLayout>(Resource.Id.linearLayoutScrollViewKonsonan);
            layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            layoutParams.SetMargins(Convert.ToInt32(dpHeight), 0, 0, 0);

            vokalList = new List<vokalKonsonan>();
            vokalList.Add(new vokalKonsonan("b", Resource.Drawable.p1));
            vokalList.Add(new vokalKonsonan("c", Resource.Drawable.p2));
            vokalList.Add(new vokalKonsonan("d", Resource.Drawable.p3));
            vokalList.Add(new vokalKonsonan("f", Resource.Drawable.p4));
            vokalList.Add(new vokalKonsonan("g", Resource.Drawable.p5));
            vokalList.Add(new vokalKonsonan("h", Resource.Drawable.p6));
            vokalList.Add(new vokalKonsonan("j", Resource.Drawable.p7));
            vokalList.Add(new vokalKonsonan("k", Resource.Drawable.p8));
            vokalList.Add(new vokalKonsonan("l", Resource.Drawable.p9));
            vokalList.Add(new vokalKonsonan("m", Resource.Drawable.p10));
            vokalList.Add(new vokalKonsonan("n", Resource.Drawable.p11));
            vokalList.Add(new vokalKonsonan("p", Resource.Drawable.p12));
            vokalList.Add(new vokalKonsonan("q", Resource.Drawable.p13));
            vokalList.Add(new vokalKonsonan("r", Resource.Drawable.p14));
            vokalList.Add(new vokalKonsonan("s", Resource.Drawable.p15));

            foreach (vokalKonsonan vk in vokalList)
            {
                if (firstSymbol == 1)// first button without left margin
                {
                    imgButton = new ImageButton(this);
                    imgButton.SetBackgroundResource(vk.drawableId);
                    imgButton.SetMinimumWidth(380);
                    imgButton.SetMinimumHeight(380);
                    linearLayoutScrollViewKonsonan.AddView(imgButton);
                    firstSymbol++;
                }
                else
                {
                    imgButton = new ImageButton(this);
                    imgButton.SetBackgroundResource(vk.drawableId);
                    imgButton.SetMinimumWidth(380);
                    imgButton.SetMinimumHeight(380);
                    linearLayoutScrollViewKonsonan.AddView(imgButton, layoutParams);
                }

                //function of btn
                imgButton.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(PerkataanVideoActivity));
                    intent.PutExtra("key", vk.symbol);
                    intent.PutExtra("category", "k");
                    StartActivity(intent);
                    this.Finish();
                };

            }

            FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUIBackButton).Click += delegate
            {
                Intent intent = new Intent(this, typeof(SelectionActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUILeftButton).Touch += delegate
            {
                horizontalSV.ScrollTo(Convert.ToInt32(horizontalSV.ScrollX) - 50, Convert.ToInt32(horizontalSV.ScrollY));
            };

            FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUIRightButton).Touch += delegate
            {
                horizontalSV.ScrollTo(Convert.ToInt32(horizontalSV.ScrollX) + 50, Convert.ToInt32(horizontalSV.ScrollY));
            };

            vto = horizontalSV.ViewTreeObserver;
            vto.GlobalLayout += Vto_GlobalLayout;

            horizontalSV.ViewTreeObserver.ScrollChanged += delegate
            {
                if (horizontalSV.ScrollX == horizontalSVMaxWidth)
                {
                    FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUIRightButton).Visibility = ViewStates.Invisible;
                }
                else if (horizontalSV.ScrollX == 0)
                {
                    FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUILeftButton).Visibility = ViewStates.Invisible;

                }
                else
                {
                    FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUILeftButton).Visibility = ViewStates.Visible;
                    FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUIRightButton).Visibility = ViewStates.Visible;
                }
            };

            //Make left button disappear at first
            FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUILeftButton).Visibility = ViewStates.Invisible;

            FindViewById<ImageButton>(Resource.Id.AbjadKonsonanUIInfoButton).Click += delegate
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

        private async void loadBackgroundImage()
        {
            BitmapDrawable background;
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.SubSubMenu_Background, Resources);
            bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.SubSubMenu_Background, options, 1920, 1080);
            background = new BitmapDrawable(bitmapToDisplay);
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadKonsonan);
            linearLayout.SetBackgroundDrawable(background);
        }

        private async void loadButtonImage()
        {
            buttonResource = new List<imageLoadingDetails>();
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadKonsonanUIBackButton, drawableId = Resource.Drawable.Back_Button });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadKonsonanUIInfoButton, drawableId = Resource.Drawable.Option_info });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadKonsonanUIRightButton, drawableId = Resource.Drawable.arrowR });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadKonsonanUILeftButton, drawableId = Resource.Drawable.arrowL });
            foreach (imageLoadingDetails imageDetails in buttonResource)
            {
                options = await decodeImage.GetBitmapOptionsOfImageAsync(imageDetails.drawableId, Resources);
                bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, imageDetails.drawableId, options, 250, 250);
                imgButton = FindViewById<ImageButton>(imageDetails.resource);
                imgButton.SetImageBitmap(bitmapToDisplay);
            }
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Kenanli_Konsonan_title, Resources);
            bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Keluarga_Perkataan_title, options, 250, 250);
            imgView = FindViewById<ImageView>(Resource.Id.AbjadKonsonanBergambarUITitle);
            imgView.SetImageBitmap(bitmapToDisplay);
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
            if (linearLayoutScrollViewKonsonan != null)
            {
                linearLayoutScrollViewKonsonan.Dispose();
                linearLayoutScrollViewKonsonan = null;
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

