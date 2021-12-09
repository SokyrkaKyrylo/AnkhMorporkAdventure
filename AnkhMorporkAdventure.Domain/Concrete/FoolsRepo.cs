﻿using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class FoolsRepo : IFoolsRepo
    {
        private ApplicationContext _context;

        public FoolsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Fool> Fools => _context.Fools;
    }
}
