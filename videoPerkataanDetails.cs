using System;
namespace MyLexics
{
	public class videoPerkataanDetails
	{
		public string symbol;
		public int videoID;
		public string category;
		public int sequence;
		public videoPerkataanExampleDetails abjadExample1;
		public videoPerkataanExampleDetails abjadExample2;
		public videoPerkataanExampleDetails abjadExample3;
        public videoPerkataanExampleDetails abjadExample4;
        public videoPerkataanExampleDetails abjadExample5;
        public videoPerkataanExampleDetails abjadExample6;
        public videoPerkataanExampleDetails abjadExample7;
        public videoPerkataanExampleDetails abjadExample8;

        public videoPerkataanDetails(string symbol,int videoID,string category, int sequence, videoPerkataanExampleDetails abjadExample1, videoPerkataanExampleDetails abjadExample2, videoPerkataanExampleDetails abjadExample3, videoPerkataanExampleDetails abjadExample4, videoPerkataanExampleDetails abjadExample5, videoPerkataanExampleDetails abjadExample6, videoPerkataanExampleDetails abjadExample7, videoPerkataanExampleDetails abjadExample8)
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
            this.abjadExample6 = abjadExample6;
            this.abjadExample7 = abjadExample7;
            this.abjadExample8 = abjadExample8;
        }

	}
}

