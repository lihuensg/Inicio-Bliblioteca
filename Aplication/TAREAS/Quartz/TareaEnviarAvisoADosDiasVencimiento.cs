using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DAL;
using Aplication.DAL.EntityFramework;
using Aplication.LOG;
using Aplication.Servicios.Notificacion;
using Aplication.Servicios.Tiempo;
using Quartz;

namespace Aplication.TAREAS
{
    [DisallowConcurrentExecution]
    public class TareaEnviarAvisoADosDiasVencimiento : EnviarAvisosADiasDelVencimiento, IJob
    {
        public static readonly JobKey Key = new JobKey(nameof(TareaEnviarAvisoADosDiasVencimiento), "notificaciones");

        readonly List<INotificador> notificadores;
        readonly IUnitOfWorkFactory unitOfWorkFactory;
        readonly IDateTimeProvider dateTimeProvider;

        public TareaEnviarAvisoADosDiasVencimiento(IEnumerable<INotificador> pNotificadores,
                                                   IUnitOfWorkFactory pUnitOfWorkFactory,
                                                   IDateTimeProvider pDateTimeProvider)
                : base(2, pNotificadores, pUnitOfWorkFactory, pDateTimeProvider)
        {
            this.notificadores = pNotificadores.ToList();
            unitOfWorkFactory = pUnitOfWorkFactory;
            dateTimeProvider = pDateTimeProvider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Ejecutar();
        }
    }
}
