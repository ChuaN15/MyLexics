using System;
namespace MyLexics
{
	public class videoAbjadDetails
	{
		public string symbol;
		public int videoID;
		public string category;
		public int sequence;
		public videoAbjadExampleDetails abjadExample1;
		public videoAbjadExampleDetails abjadExample2;
		public videoAbjadExampleDetails abjadExample3;
        public videoAbjadExampleDetails abjadExample4;
        public videoAbjadExampleDetails abjadExample5;


        public videoAbjadDetails(string symbol,int videoID,string category, int sequence,videoAbjadExampleDetails abjadExample1,videoAbjadExampleDetails abjadExample2,videoAbjadExampleDetails abjadExample3, videoAbjadExampleDetails abjadExample4, videoAbjadExampleDetails abjadExample5)
		{
			this.symbol = symbol;
			this.videoID = videoID;
			this.category = category;
			this.sequence = sequence;
			this.abjadExample1 = abjadExample1;
			this.abjadExample2 = abjadExample2;
			this.abjadExample3 = abjadExample3;
            this.abjadExample4 = abjadExample4;
            this.abjadExample5 = abjadExample5;
        }

	}
}

