
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
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace MyLexics
{
    [Activity(Label = "AbjadSelectionActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape, ParentActivity = typeof(SelectionActivity))]
    public class AbjadSelectionActivity : Activity
    {
        private BitmapFactory.Options options;
        private Bitmap bitmapToDisplay;
        private ImageButton imgButton;
        private List<imageLoadingDetails> buttonResource;
        private LinearLayout linearLayout;
        private ImageView imgView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AbjadSelection);

            loadBackgroundImage();
            loadButtonImage();

            //Function of btnVokal
            FindViewById<ImageButton>(Resource.Id.AbjadSelectionVokalButton).Click += delegate
            {
                Intent intent = new Intent(this, typeof(AbjadVokalActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.AbjadSelectionUIBackButton).Click += delegate
            {
                Intent intent = new Intent(this, typeof(SelectionActivity));
                StartActivity(intent);
                this.Finish();
            };


            //Function of btnKonsonan
            FindViewById<ImageButton>(Resource.Id.AbjadSelectionKonsonanButton).Click += delegate
            {
                Intent intent = new Intent(this, typeof(AbjadKonsonanActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.AbjadSelectionVokalBergambarButton).Click += delegate
            {
                Intent intent = new Intent(this, typeof(AbjadVokalBergambarActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.AbjadSelectionKonsonanBergambarButton).Click += delegate
            {
                Intent intent = new Intent(this, typeof(AbjadKonsonanBergambarActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.AbjadSelectionUIInfoButton).Click += delegate
            {
                //Toast.MakeText(this, "Button Setting 2", ToastLength.Long).Show();
                new AlertDialog.Builder(this)
               .SetView(Resource.Layout.ContactInformation)
               .SetPositiveButton("OK", delegate { })
               .Show();

            };
        }

        private async void loadBackgroundImage()
        {
            BitmapDrawable background;
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.AbjadBackground, Resources);
            bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.AbjadBackground, options, 1920, 1080);
            background = new BitmapDrawable(bitmapToDisplay);
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutAbjadSelection);
            linearLayout.SetBackgroundDrawable(background);

        }


        private async void loadButtonImage()
        {
            buttonResource = new List<imageLoadingDetails>();
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadSelectionUIBackButton, drawableId = Resource.Drawable.Back_Button });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadSelectionUIInfoButton, drawableId = Resource.Drawable.Option_info });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadSelectionVokalButton, drawableId = Resource.Drawable.Vokal_Button });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadSelectionVokalBergambarButton, drawableId = Resource.Drawable.VokalBergambar_Button });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadSelectionKonsonanButton, drawableId = Resource.Drawable.Konsonan_Button });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.AbjadSelectionKonsonanBergambarButton, drawableId = Resource.Drawable.KonsonanBergamber_Button_temp });
            foreach (imageLoadingDetails imageDetails in buttonResource)
            {
                options = await decodeImage.GetBitmapOptionsOfImageAsync(imageDetails.drawableId, Resources);
                bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, imageDetails.drawableId, options, 250, 250);
                imgButton = FindViewById<ImageButton>(imageDetails.resource);
                imgButton.SetImageBitmap(bitmapToDisplay);
            }
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.Abjad_title, Resources);
            bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.Abjad_title, options, 250, 250);
            imgView = FindViewById<ImageView>(Resource.Id.AbjadSelectionUITitle);
            imgView.SetImageBitmap(bitmapToDisplay);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Drawable drawable = linearLayout.Background;
            linearLayout.SetBackgroundDrawable(null);
            drawable.Dispose();
            foreach (imageLoadingDetails imageLoadingDetail in buttonResource)
            {
                imgButton = FindViewById<ImageButton>(imageLoadingDetail.resource);
                drawable = imgButton.Drawable;
                imgButton.SetImageBitmap(null);
                drawable.Dispose();
            }
            imgView = FindViewById<ImageView>(Resource.Id.AbjadSelectionUITitle);
            imgView.SetImageBitmap(null);
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
            if (imgView != null)
            {
                imgView.Dispose();
                imgView = null;
            }
            buttonResource = null;
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

