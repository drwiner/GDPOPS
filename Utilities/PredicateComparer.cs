﻿using BoltFreezer.Interfaces;
using System;

namespace BoltFreezer.Utilities
{
    public class PredicateComparer
    {
        public static int CompareByName (IPredicate x, IPredicate y)
        {
            return String.Compare(x.Name, y.Name);
        }

        public static int InverseCompareByName (IPredicate x, IPredicate y)
        {
            return String.Compare(x.Name, y.Name) * -1;
        }
    }
}
