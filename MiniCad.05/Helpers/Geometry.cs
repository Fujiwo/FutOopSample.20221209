namespace MiniCad.Helpers
{
    static class Geometry
    {
        public static int Distance(this Point @this, Point other) => @this.Difference(other).Absolute();
        public static Size Difference(this Point @this, Point other) => new Size(other.X - @this.X, other.Y - @this.Y);
        public static int Absolute(this Size @this) => (int)Math.Sqrt(Square(@this.Width) + Square(@this.Height));

        public static Rectangle BoundingBox(this (Point center, int radius) @this)
            => new Rectangle(@this.center - new Size(@this.radius, @this.radius), new Size(@this.radius * 2, @this.radius * 2));
        
        public static Rectangle? BoundingBox(this IEnumerable<Point> @this)
        {
            Rectangle? boundingBox = null;
            @this.ForEach(point =>
                boundingBox = boundingBox is null ? new Rectangle(point, new Size())
                                                  : Rectangle.Union(boundingBox.Value, new Rectangle(point, new Size())));
            return boundingBox;
        }

        static int Square(int value) => value * value;
    }
}