
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
using Android.Views.Animations;
using Android.Media;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MyLexics
{
    [Activity(Label = "SelectionActivity", Theme = "@style/Theme.Menu", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
    public class SelectionActivity : Activity
    {
        private BitmapFactory.Options options;
        private Bitmap bitmapToDisplay;
        private ImageButton imgButton;
        private Animation animMoveLeftSurvey;
        private Animation animMoveRightSurvey;
        private Animation animMoveLeftHelp;
        private Animation animMoveRightHelp;
        private Animation animMoveLeftSetting;
        private Animation animMoveRightSetting;
        private bool isBtnSettingClicked = false;
        private List<imageLoadingDetails> buttonResource;
        private LinearLayout linearLayout;
        private ImageButton buttonHelp;
        private ImageButton buttonSetting;
        private ImageButton buttonInfo;
        private ImageButton buttonSurvey;
        private Drawable drawable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCenter.Start("03d10b45-8848-4c0f-869e-6dc3855f88ab", typeof(Analytics), typeof(Crashes));

            // Set our view from the "Selection" layout resource
            SetContentView(Resource.Layout.Selection);

            animMoveLeftSurvey = AnimationUtils.LoadAnimation(this, Resource.Animation.move_left2);
            animMoveRightSurvey = AnimationUtils.LoadAnimation(this, Resource.Animation.move_right2);
            animMoveLeftHelp = AnimationUtils.LoadAnimation(this, Resource.Animation.move_left3);
            animMoveRightHelp = AnimationUtils.LoadAnimation(this, Resource.Animation.move_right3);
            animMoveLeftSetting = AnimationUtils.LoadAnimation(this, Resource.Animation.move_left4);
            animMoveRightSetting = AnimationUtils.LoadAnimation(this, Resource.Animation.move_right4);

            loadBackgroundImage();
            loadOtherImage();

            FindViewById<ImageButton>(Resource.Id.selectionUIModuleAbjadBtn).Click += delegate
            {
                Analytics.TrackEvent("Abjad Event");

                Intent intent = new Intent(this, typeof(AbjadSelectionActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.selectionUIModuleSukukataBtn).Click += delegate
            {
                Analytics.TrackEvent("Sukukata Event");

                Intent intent = new Intent(this, typeof(SukukataSelectionActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.selectionUIModulePerkataanBtn).Click += delegate
            {
                Analytics.TrackEvent("Perkataan Event");

                Intent intent = new Intent(this, typeof(PerkataanSelectionActivity));
                StartActivity(intent);
                this.Finish();
            };

            FindViewById<ImageButton>(Resource.Id.selectionUIModuleAktivitiBtn).Click += delegate
            {
                new AlertDialog.Builder(this)
                .SetCancelable(true)
               .SetView(Resource.Layout.LockInformation)
               .Show();
            };

            buttonSurvey = FindViewById<ImageButton>(Resource.Id.selectionUISurveyBtn);
            buttonHelp = FindViewById<ImageButton>(Resource.Id.selectionUIHelpBtn);
            buttonSetting = FindViewById<ImageButton>(Resource.Id.selectionUISettingBtn);

            buttonSurvey.Visibility = ViewStates.Invisible;
            buttonHelp.Visibility = ViewStates.Invisible;
            buttonSetting.Visibility = ViewStates.Invisible;

            buttonInfo = FindViewById<ImageButton>(Resource.Id.selectionUIInfoBtn);
            buttonInfo.Click += delegate
            {
                if (isBtnSettingClicked)
                {
                    buttonSurvey.StartAnimation(animMoveRightSurvey);
                    buttonSurvey.Visibility = ViewStates.Visible;
                    buttonHelp.StartAnimation(animMoveRightHelp);
                    buttonHelp.Visibility = ViewStates.Visible;
                    buttonSetting.StartAnimation(animMoveRightSetting);
                    buttonSetting.Visibility = ViewStates.Visible;
                    isBtnSettingClicked = !isBtnSettingClicked;
                }
                else
                {
                    buttonSurvey.StartAnimation(animMoveLeftSurvey);
                    buttonSurvey.Visibility = ViewStates.Invisible;
                    buttonHelp.StartAnimation(animMoveLeftHelp);
                    buttonHelp.Visibility = ViewStates.Invisible;
                    buttonSetting.StartAnimation(animMoveLeftSetting);
                    buttonSetting.Visibility = ViewStates.Invisible;
                    isBtnSettingClicked = !isBtnSettingClicked;
                }
            };

            buttonSurvey.Click += delegate
            {
                var uri = Android.Net.Uri.Parse("https://docs.google.com/forms/d/e/1FAIpQLSfFo1ryadXr-vB4_5YdJ0-pJVcSDdtGrkVcqlK-3KSiJjR-tg/viewform?usp=sf_link");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };

            buttonHelp.Click += delegate
            {
                //Toast.MakeText(this, "Button Setting 2", ToastLength.Long).Show();
                new AlertDialog.Builder(this)
               .SetView(Resource.Layout.ContactInformation)
               .SetPositiveButton("OK", delegate { })
               .Show();
            };

            buttonSetting.Click += delegate
            {
                AudioManager audioManager = (AudioManager)this.GetSystemService(Context.AudioService);
                if (audioManager.RingerMode == RingerMode.Normal)
                {
                    audioManager.RingerMode = RingerMode.Silent;
                    Toast.MakeText(this, "Mod senyap.", ToastLength.Long).Show();
                }
                else
                {
                    audioManager.RingerMode = RingerMode.Normal;
                    Toast.MakeText(this, "Mod suara.", ToastLength.Long).Show();
                }

            };

            FindViewById<ImageButton>(Resource.Id.selectionUIBackButton).Click += delegate
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
            };
            

            if (EntraceTimes.numOfEntraceTimes == 1)
            {
                EntraceTimes.numOfEntraceTimes++;
                StartService(new Intent(this, typeof(IntroductionAudioService))); // run introduction audio (selamat datang)
            }

            
        }

        private async void loadBackgroundImage()
        {
            BitmapDrawable background;
            options = await decodeImage.GetBitmapOptionsOfImageAsync(Resource.Drawable.selection, Resources);
            bitmapToDisplay = await decodeImage.LoadScaledDownBitmapForDisplayAsync(Resources, Resource.Drawable.selection, options, 1920, 1080);
            background = new BitmapDrawable(bitmapToDisplay);
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutSelection);
            linearLayout.SetBackgroundDrawable(background);

        }

        private async void loadOtherImage()
        {
            //Save button image resource with each view id
            buttonResource = new List<imageLoadingDetails>();
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUISurveyBtn, drawableId = Resource.Drawable.Option_survey });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIHelpBtn, drawableId = Resource.Drawable.Option_Help });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUISettingBtn, drawableId = Resource.Drawable.Option_Setting });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIInfoBtn, drawableId = Resource.Drawable.Option_info });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIModuleAbjadBtn, drawableId = Resource.Drawable.Abjad });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIModuleSukukataBtn, drawableId = Resource.Drawable.Sukukata });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIModulePerkataanBtn, drawableId = Resource.Drawable.Perkataan });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIModuleAktivitiBtn, drawableId = Resource.Drawable.activitigrey });
            buttonResource.Add(new imageLoadingDetails { resource = Resource.Id.selectionUIBackButton, drawableId = Resource.Drawable.Back_Button });
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
            drawable = linearLayout.Background;
            linearLayout.SetBackgroundDrawable(null);
            drawable.Dispose();
            foreach (imageLoadingDetails imageLoadingDetail in buttonResource)
            {
                imgButton = FindViewById<ImageButton>(imageLoadingDetail.resource);
                drawable = imgButton.Drawable;
                imgButton.SetImageBitmap(null);
                drawable.Dispose();
            }
            if (animMoveLeftHelp != null)
            {
                animMoveLeftHelp.Dispose();
                animMoveLeftHelp = null;
            }
            if (animMoveRightHelp != null)
            {
                animMoveRightHelp.Dispose();
                animMoveRightHelp = null;
            }
            if (animMoveLeftSetting != null)
            {
                animMoveLeftSetting.Dispose();
                animMoveLeftSetting = null;
            }
            if (animMoveRightSetting != null)
            {
                animMoveRightSetting.Dispose();
                animMoveRightSetting = null;
            }
            buttonResource = null;
            if (linearLayout != null)
            {
                linearLayout.Dispose();
                linearLayout = null;
            }
            if (buttonSurvey != null)
            {
                buttonSurvey.Dispose();
                buttonSurvey = null;
            }
            if (buttonSetting != null)
            {
                buttonSetting.Dispose();
                buttonSetting = null;
            }
            if (buttonInfo != null)
            {
                buttonInfo.Dispose();
                buttonInfo = null;
            }
            if (buttonHelp != null)
            {
                buttonHelp.Dispose();
                buttonHelp = null;
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
            if (drawable != null)
            {
                drawable.Dispose();
                drawable = null;
            }
            this.Dispose();
        }


        public override void OnBackPressed()
        {
            new AlertDialog.Builder(this)
                 .SetMessage("Anda ingin keluar?")
                 .SetPositiveButton("Ya", delegate { this.Finish(); })
                 .SetNegativeButton("Tidak", delegate { })
                 .Show();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GC.Collect(GC.MaxGeneration);
        }

    }
}

