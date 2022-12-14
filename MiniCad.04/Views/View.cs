namespace MiniCad.Views
{
    using Models;
    using Helpers;

    partial class View : UserControl
    {
        public View() => InitializeComponent();
        
        void OnPaint(object sender, PaintEventArgs e)
        {
            var model = DataContext as IEnumerable<Figure>;
            if (model is null)
                return;

            model.SelectMany(figure => figure.Shapes)
                 .ForEach(shape => Draw(e.Graphics, shape));
        }

        const int penWidth = 10;
        static readonly Pen pen = new Pen(Color.Black, penWidth);

        void Draw(Graphics graphics, Shape shape)
        {

            switch (shape) {
                case Circle x:
                    graphics.DrawEllipse(pen, x.BoundingBox);
                    break;
            }
        }
    }
}
