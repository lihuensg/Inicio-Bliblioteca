﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DAL
{
   public interface IUnitOfWorkFactory
    {
        IUnitOfWork Crear();
    }
}
