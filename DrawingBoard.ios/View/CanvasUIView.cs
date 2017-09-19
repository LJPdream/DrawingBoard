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
            UITouch touch = touches.AnyObject as UITouch;
            this.fingerDraw = true;
            this.touchLocation = (PointF)touch.LocationInView(this);
            this.previousTouchLocation = (PointF)touch.PreviousLocationInView(this);
            this.SetNeedsDisplay(); //更新视图
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            this.touchLocation = (PointF)touch.LocationInView(this);
            this.previousTouchLocation = (PointF)touch.PreviousLocationInView(this);
            this.SetNeedsDisplay();
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            if (this.fingerDraw)
            {
                using (CGContext context = UIGraphics.GetCurrentContext())
                {
                    context.SetStrokeColor(UIColor.Blue.CGColor);
                    context.SetLineWidth(5f);
                    context.SetLineJoin(CGLineJoin.Round);
                    context.SetLineCap(CGLineCap.Round);
                    this.drawPath.MoveToPoint(this.previousTouchLocation);
                    this.drawPath.AddLineToPoint(this.touchLocation);
                    context.AddPath(this.drawPath);
                    context.DrawPath(CGPathDrawingMode.Stroke);
                }
            }
        }

       
    }
}