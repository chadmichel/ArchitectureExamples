﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFR.Engines
{
    public class EngineFactory
    {
        List<object> _overrides = new List<object>();
        public void AddOverride<I>(I proxy)
            where I : class
        {
            var result = _overrides.FirstOrDefault(t => t.GetType().Name == typeof(I).Name) as I;
            if (result != null)
                _overrides.Remove(result);

            _overrides.Add(result);
        }

        public void ClearOverrides()
        {
            _overrides.Clear();
        }

        public I Create<I>()
            where I : class
        {
            var result = _overrides.FirstOrDefault(t => t.GetType().Name == typeof(I).Name) as I;
            if (result != null)
                return result;

            if (typeof(I).Name == typeof(IMakeLower).Name)
                return new MakeLower() as I;

            return null;
        }
    }
}
