﻿namespace System
{
    public static class Numbers
    {
        public static decimal AsPercentageOf(this decimal part, decimal total)
        {
            total.MustComplyWith(d => d != 0m, "Can't divide by 0");
            return Math.Round(part * 100 / total, 2);
        }
    }
}