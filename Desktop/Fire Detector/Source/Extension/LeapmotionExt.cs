using Leap;

namespace Fire_Detector.Source.Extension
{
    public static class LeapmotionExt
    {
        public static Hand LeftHand(this Frame frame)
        {
            foreach(var hand in frame.Hands)
            {
                if(hand.IsLeft)
                    return hand;
            }

            return null;
        }

        public static Hand RightHand(this Frame frame)
        {
            foreach(var hand in frame.Hands)
            {
                if(hand.IsRight)
                    return hand;
            }

            return null;
        }
    }
}
