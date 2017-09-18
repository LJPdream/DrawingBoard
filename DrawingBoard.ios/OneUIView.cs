using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace DrawingBoard.ios
{
    [Register("OneUIView")]
    public class OneUIView : UIView
    {
        public OneUIView()
        {
            Initialize();
        }

        public OneUIView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }


    }
}