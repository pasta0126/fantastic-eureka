using ApiTest.Models;
using System.Collections.Generic;

namespace ApiTest.Services
{
    public interface IActividadSesionService
    {
        double EvaluacionPorActividades(List<ActividadSesionModel> actividades);
        double EvaluacionPorActividad(ActividadSesionModel actividad);
        double EvaluacionPorCompetencias(List<ActividadSesionModel> actividades);
        double Evaluacion(ActividadSesionModel actividad, double porcentaje);
    }
}
