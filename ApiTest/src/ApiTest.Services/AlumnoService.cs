using ApiTest.Models;
using ApiTest.Models.Types;
using System.Collections.Generic;

namespace ApiTest.Services
{
    public class AlumnoService
    {
        public AlumnoService()
        {

        }

        public int EvaluacionPorActividades(List<ActividadModel> actividades)
        {
            int evaluacion = 0;
            
            foreach (var actividad in actividades)
            {
                switch (actividad.Tipo)
                {
                    case ActividadType.Prueba:

                        break;
                    case ActividadType.Ejercicio:
                        break;
                    case ActividadType.Actividad:
                        break;

                    case ActividadType.Autoevaluacion:
                        break;

                    default:
                        break;
                }

            }

            return evaluacion;
        }
    }
}
