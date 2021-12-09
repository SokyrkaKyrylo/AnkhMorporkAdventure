﻿using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Abstract
{
    public interface IFoolsRepo
    {
        IEnumerable<Fool> Fools { get; }
    }
}
