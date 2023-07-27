using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Servicios.Tiempo
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
