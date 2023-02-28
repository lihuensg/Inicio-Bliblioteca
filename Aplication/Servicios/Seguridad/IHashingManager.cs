using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Servicios.Seguridad {
    interface IHashingManager {
        string Hash(string password, int iterations = 10000);
        bool Verify(string password, string hashedPassword);
        bool IsHashSupported(string hashString);
    }
}
