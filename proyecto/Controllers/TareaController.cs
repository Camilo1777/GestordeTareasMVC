using System;
using System.Collections.Generic;
using proyecto.Models;
using proyecto.Views;

namespace proyecto.Controllers
{
    public class TareaController
    {
        private List<Tarea> tareas = new List<Tarea>();
        private TareaViews vista = new TareaViews();
        private int contadorId = 1;

        public void Iniciar()
        {
            string opcion;

            do
            {
                MostrarMenu();
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearTarea();
                        break;
                    case "2":
                        vista.MostrarTareas(tareas);
                        break;
                    case "3":
                        CompletarTarea();
                        break;
                    case "4":
                        EliminarTarea();
                        break;
                    case "5":
                        MostrarTareasPendientes();
                        break;
                    case "6":
                        MostrarTareasCompletadas();
                        break;
                    case "0":
                        MostrarResumenTareas();
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != "0");
        }
        private void MostrarMenu()
        {
            Console.WriteLine("\n--- Menú de Tareas ---");
            Console.WriteLine("1. Crear tarea");
            Console.WriteLine("2. Mostrar tareas");
            Console.WriteLine("3. Completar tarea");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("5. Mostrar tareas pendientes");
            Console.WriteLine("6. Mostrar tareas completadas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private void CrearTarea()
        {
            string descripcion = vista.PedirDescripcion();
            Tarea nueva = new Tarea(contadorId++, descripcion);
            tareas.Add(nueva);
            
        }
        private void CompletarTarea()
        {
            int id = vista.PedirIdParaCompletar();

            Tarea tareaEncontrada = null;
            foreach (Tarea t in tareas)
            {
                if (t.Id == id)
                {
                    tareaEncontrada = t;
                    break;
                }
            }
            if (tareaEncontrada != null)
            {
                tareaEncontrada.Completada = true;
                Console.WriteLine($"Tarea {id} completada.");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con ID {id}.");
            }

        }
        private void EliminarTarea()
        {
            int id = vista.PedirIdParaCompletar();
            Tarea tareaEncontrada = null;
            foreach (Tarea t in tareas)
            {
                if (t.Id == id)
                {
                    tareaEncontrada = t;
                    break;
                }
            }
            if (tareaEncontrada != null)
            {
                tareas.Remove(tareaEncontrada);
                Console.WriteLine($"Tarea {id} eliminada.");
            }
            else
            {
                Console.WriteLine($"No se encontró la tarea con ID {id}.");
            }
        }
        private void MostrarTareasPendientes()
        {
            List<Tarea> tareasPendientes = new List<Tarea>();

            foreach (Tarea tarea in tareas)
            {
                if (!tarea.Completada)
                {
                    tareasPendientes.Add(tarea);
                }
            }

            vista.MostrarTareasPendientes(tareasPendientes);
        }

        private void MostrarTareasCompletadas()
        {
            List<Tarea> tareasCompletadas = new List<Tarea>();
            foreach (Tarea tarea in tareas)
            {
                if (tarea.Completada)
                {
                    tareasCompletadas.Add(tarea);
                }
            }

            vista.MostrarTareasCompletadas(tareasCompletadas);
        }
        private void MostrarResumenTareas()
        {
            
            int total = tareas.Count;
            int completadas = 0;
            int pendientes = 0;

            foreach (Tarea tarea in tareas)
            {
                if (tarea.Completada)
                {
                    completadas++;
                }
                else
                {
                    pendientes++;
                }
            }

            vista.MostrarResumen(total, completadas, pendientes);
        }



    }

}

