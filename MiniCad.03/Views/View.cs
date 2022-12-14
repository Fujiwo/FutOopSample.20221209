namespace MiniCad.Views
{
    using Models;
    using Helpers;

    public partial class View : UserControl
    {
        //public IEnumerable<Figure>? DataContext { get; set; } = null;

        public View() => InitializeComponent();

        void OnPaint(object sender, PaintEventArgs e)
        {
            var model = DataContext as IEnumerable<Figure>;
            if (model is null)
                return;

            model.SelectMany(figure => figure.Shapes)
                 .ForEach(shape => Draw(e.Graphics, shape));
        }

        void Draw(Graphics graphics, Shape shape)
        {
            switch (shape) {
                case Circle x:
                    graphics.DrawEllipse(Pens.Black, x.BoundingBox);
                    break;
            }
        }
    }
}
