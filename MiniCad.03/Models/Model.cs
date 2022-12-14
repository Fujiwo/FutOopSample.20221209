using System.Collections;
using System.ComponentModel;

namespace MiniCad.Models
{
    public partial class Model : Component, IEnumerable<Figure>
    {
        public Model()
        {
            InitializeComponent();
        }

        public Model(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public IEnumerator<Figure> GetEnumerator()
        {
            yield return new Figure { Position = new Point(30, 40) };
            yield return new Figure { Position = new Point(130, 180) };
            yield return new Figure { Position = new Point(280, 300) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
