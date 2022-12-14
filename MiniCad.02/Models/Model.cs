using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCad.Models
{
    public partial class Model : Component
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
    }
}
