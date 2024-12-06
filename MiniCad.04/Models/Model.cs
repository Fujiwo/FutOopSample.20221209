using System.Collections;
using System.ComponentModel;

namespace MiniCad.Models
{
    partial class Model : Component, IEnumerable<Figure>
    {
        public event Action? Update;

        LinkedList<Figure> figures = new();
        
        public Model() => InitializeComponent();

        public Model(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void Add(Figure figure)
        {
            figures.AddLast(figure);
            Update?.Invoke();
        }

        public IEnumerator<Figure> GetEnumerator() => figures.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
