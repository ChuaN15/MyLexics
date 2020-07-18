using System;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.Graphics;

namespace MyLexics
{
	public class decodeImage
	{
		/*public static int calculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Raw height and width of image
			int height = options.OutHeight;
			int width = options.OutWidth;
			int inSampleSize = 1;

			if (height > reqHeight || width > reqWidth)
			{

				// Calculate ratios of height and width to requested height and width
				int heightRatio = (int)Math.Round((float)height / (float)reqHeight);
				int widthRatio = (int)Math.Round((float)width / (float)reqWidth);

				// Choose the smallest ratio as inSampleSize value, this will guarantee
				// a final image with both dimensions larger than or equal to the
				// requested height and width.
				inSampleSize = heightRatio < widthRatio ? heightRatio : widthRatio;
			}

			return inSampleSize;
		}

		public static Bitmap decodeSampledBitmapFromResource(Resources res, int resId, int reqWidth, int reqHeight)
		{

			// First decode with inJustDecodeBounds=true to check dimensions
			BitmapFactory.Options options = new BitmapFactory.Options();
			options.InJustDecodeBounds = true;
			BitmapFactory.DecodeResource(res, resId, options);

			// Calculate inSampleSize
			options.InSampleSize = calculateInSampleSize(options, reqWidth, reqHeight);

			// Decode bitmap with inSampleSize set
			options.InJustDecodeBounds = false;
			return BitmapFactory.DecodeResource(res, resId, options);
		}*/

		public static async Task<Bitmap> LoadScaledDownBitmapForDisplayAsync(Resources res, int resId, BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Calculate inSampleSize
			options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);

			// Decode bitmap with inSampleSize set
			options.InJustDecodeBounds = false;

			return await BitmapFactory.DecodeResourceAsync(res, resId, options);
		}

		public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Raw height and width of image
			float height = options.OutHeight;
			float width = options.OutWidth;
			double inSampleSize = 1D;

			if (height > reqHeight || width > reqWidth)
			{
				int halfHeight = (int)(height / 2);
				int halfWidth = (int)(width / 2);

				// Calculate a inSampleSize that is a power of 2 - the decoder will use a value that is a power of two anyway.
				while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
				{
					inSampleSize *= 2;
				}
			}

			return (int)inSampleSize;
		}

		public static async Task<BitmapFactory.Options> GetBitmapOptionsOfImageAsync(int resId,Resources resources)
		{
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true
			};

			// The result will be null because InJustDecodeBounds == true.
			//Bitmap result = await BitmapFactory.DecodeResourceAsync(resources, resId, options);

			int imageHeight = options.OutHeight;
			int imageWidth = options.OutWidth;

			System.Console.WriteLine(String.Format("Original Size= {0}x{1}", imageWidth, imageHeight));

			return options;
		}
	}
}

