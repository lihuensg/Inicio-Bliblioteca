using Aplication.LOG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplication.TAREAS {
    /// <summary>
    /// Clase que ejecuta una tarea de forma reptitiva cada cierto intervalo.
    /// </summary>
    public abstract class TareaBase : ITarea {
        protected string nombreTarea;
        protected TimeSpan intervalo;
        private CancellationTokenSource tokenSource;
        private Task tarea;

        public void Detener() {
            LogManager.GetLogger().Info("Deteniendo tarea {tarea}", nombreTarea);
            tokenSource.Cancel();
        }
        public async Task DetenerAsync()
        {
            LogManager.GetLogger().Info("Deteniendo tarea {tarea}", nombreTarea);
            tokenSource.Cancel();
            try
            {
                await tarea;
            }
            catch (TaskCanceledException) { }
        }
        public void Iniciar() {
            if (string.IsNullOrEmpty(nombreTarea)) {
                throw new ArgumentNullException(nameof(nombreTarea), "Se debe especificar un nombre a la tarea");
            }

            if (intervalo == TimeSpan.Zero) {
                throw new ArgumentNullException(nameof(intervalo), "Se debe especificar un intervalo");
            }

            LogManager.GetLogger().Info("Iniciando tarea {tarea}", nombreTarea);
            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            this.tarea = Task.Run(async () => {
                while (!token.IsCancellationRequested) {
                    LogManager.GetLogger().Info("Ejecutando tarea {tarea}", nombreTarea);
                    this.Tarea();
                    try
                    {
                        await Task.Delay(this.intervalo, token);
                    }
                    catch (TaskCanceledException) { }
                    
                }
            }, token);
        }

        /// <summary>
        /// Metodo que se ejecutara periodicamente
        /// </summary>
        protected abstract void Tarea();
    }
}
