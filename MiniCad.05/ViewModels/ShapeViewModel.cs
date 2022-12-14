using MiniCad.Models;

namespace MiniCad.ViewModels
{
    static class ShapeViewModel
    {
        const  int            penWidth = 10;
        static readonly Color color    = Color.Black;
        static readonly Pen   pen      = new Pen(color, penWidth);
        static readonly Brush brush    = new SolidBrush(color);

        public static void Draw(this Shape @this, Graphics graphics)
        {
            switch (@this) {
                case Dot    shape: graphics.FillEllipse(brush, shape.BoundingBox); break;
                case Line   shape: graphics.DrawLine(pen, shape.Start, shape.End); break;
                case Circle shape: graphics.DrawEllipse(pen, shape.BoundingBox)  ; break;
            }
        }
    }
}
