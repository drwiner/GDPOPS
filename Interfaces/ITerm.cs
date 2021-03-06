﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoltFreezer.Interfaces
{
    public interface ITerm
    {
        // Terms may have a variable symbol.
        string Variable { get; set; }

        // Terms may have a constant symbol.
        string Constant { get; set; }

        // Terms may have an associated type.
        string Type { get; set; }

        // Terms may be bound or unbound.
        bool Bound { get; }

        bool IsConsistent(ITerm other);

        // Terms may be cloned.
        Object Clone();
    }
}
