using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace DrawingBoard.ios.View
{
    [Register("CanvasUIView")]
    public class CanvasUIView : UIView
    {
        private PointF touchLocation;
        private PointF previousTouchLocation;
        private CGPath drawPath;
        private bool fingerDraw;
        public CanvasUIView()
        {
            Initialize();
        }

        public CanvasUIView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            //BackgroundColor = UIColor.Red;
            this.drawPath = new CGPath();
        }

        /// <summary>
        /// 触屏开始
        /// </summary>
        /// <param name="touches"></param>
        /// <param name="evt"></param>
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
        }
    }
}