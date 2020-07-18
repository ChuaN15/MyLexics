using System;
namespace MyLexics
{
	public class videoPerkataanExampleDetails
	{
		public string text;
		public int videoPath;
        public int imagePath;


        public videoPerkataanExampleDetails(string text, int videoPath, int imagePath)
		{
			this.text = text;
			this.videoPath = videoPath;
            this.imagePath = imagePath;
        }
	}


}
