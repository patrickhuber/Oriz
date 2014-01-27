﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xacml.Schemas;

namespace Xacml
{
    public interface IContextHandler
    {
        IEnumerable<AttributesType> GetContext();
    }
}
