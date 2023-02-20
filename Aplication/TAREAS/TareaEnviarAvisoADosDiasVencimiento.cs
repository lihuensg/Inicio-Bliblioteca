using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.TAREAS {
    public class TareaEnviarAvisoADosDiasVencimiento :  TareaBase {
        public TareaEnviarAvisoADosDiasVencimiento() {
            this.nombreTarea = "TareaEnviarAvisoADosDiasVencimiento";
            this.intervalo = TimeSpan.FromSeconds(5);
        }

        protected override void Tarea() {
            // TODO:
            //  1. Obtener los prestamos que esten a X dias a vencer (definido en una cte)
            //     y que no se les haya enviado el mail de aviso de vencimiento
            //  2. Enviar el mail para cada uno
            //  3. Si fue exitoso: Actualizar el prestamo, indicando que ya se envió el mail.
            //  4. Sino, intentar nuevamente sino seguir con el siguiente.
        }
    }
}
