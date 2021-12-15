using ApiTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiTest.Services
{
    public class ActividadSesionService : IActividadSesionService
    {
        public ActividadSesionService()
        {

        }

        public double EvaluacionPorActividades(List<ActividadSesionModel> actividades)
        {
            double evaluacion = 0;

            foreach (var actividad in actividades)
            {
                evaluacion += EvaluacionPorActividad(actividad);
            }

            return evaluacion;
        }

        public double EvaluacionPorActividad(ActividadSesionModel actividad)
        {
            double porcentaje;

            switch (actividad.Tipo)
            {
                case Models.Types.ActividadType.Prueba:
                    porcentaje = 0.5;
                    break;

                case Models.Types.ActividadType.Ejercicio:
                    porcentaje = 0.3;
                    break;

                case Models.Types.ActividadType.Actividad:
                    porcentaje = 0.2;
                    break;

                case Models.Types.ActividadType.Autoevaluacion:
                    return 0;

                default:
                    return 0;
            }

            return Evaluacion(actividad, porcentaje);
        }

        public double EvaluacionPorCompetencias(List<ActividadSesionModel> actividades)
        {
            double evaluacion = 0;

            var competenciaMatematica = actividades.Where(w => w.Competencia == Models.Types.CompetenciaType.Matematicas).ToList();
            if (competenciaMatematica.Count() > 0)
            {
                foreach (var competencia in competenciaMatematica)
                {
                    evaluacion += Evaluacion(competencia, 0.6);
                }
            }

            var competenciaDigital = actividades.Where(w => w.Competencia == Models.Types.CompetenciaType.Digital).ToList();
            if (competenciaDigital.Count() > 0)
            {
                foreach (var competencia in competenciaDigital)
                {
                    evaluacion += Evaluacion(competencia, 0.2);
                }
            }

            var competenciaSocial = actividades.Where(w => w.Competencia == Models.Types.CompetenciaType.Social).ToList();
            if (competenciaSocial.Count() > 0)
            {
                foreach (var competencia in competenciaSocial)
                {
                    evaluacion += Evaluacion(competencia, 0.2);
                }
            }

            return evaluacion;
        }

        public double Evaluacion(ActividadSesionModel actividad, double porcentaje)
        {
            double respuestasTotal = actividad.Respuestas.Count();
            double respuestasOk = actividad.Respuestas.Where(w => w.IsOk).Count();
            double nota = (respuestasOk / respuestasTotal) * 10;

            return nota * porcentaje;
        }
    }
}
