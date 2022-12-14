﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCad.Models
{
    public class Shape
    {
    }

    public class Circle : Shape
    {
        public required Point Center { get; init; }
        public required int Radius { get; init; }

        public Rectangle BoundingBox =>
            new Rectangle(Center - new Size(Radius, Radius), new Size(Radius * 2, Radius * 2));
    }
}
