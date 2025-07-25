using System;
using System.Collections.Generic;
using proyecto.Models;

namespace proyecto.Views
{
    public class TareaViews
    {
        public void MostrarTareas(List<Tarea> tareas)
        {
            Console.WriteLine("\n Lista de Tareas:");
            foreach (var tarea in tareas)
            {
                string estado = tarea.Completada ? "[X]" : "[ ]";
                Console.WriteLine($"{estado} {tarea.Id} - {tarea.Descripcion}");

            }
        }
        public string PedirDescripcion()
        {
            Console.Write("Ingrese la descripción de la tarea: ");
            return Console.ReadLine();
        }
        public int PedirIdParaCompletar()

            
        {
            while (true)
            {
                Console.Write("Ingrese el ID de la tarea a completar: ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int id))
                {
                    return id; 
                }

                Console.WriteLine("Entrada inválida. Recuerda que el ID debe ser un número entero.");
            }

        }

        public void MostrarTareasPendientes(List<Tarea> tareasPendientes)
        {
            Console.WriteLine("\n Tareas pendientes:");
            if (tareasPendientes.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes.");
                return;
            }
            else
            {
                foreach (Tarea tarea in tareasPendientes)
                {
                    Console.WriteLine($"[] {tarea.Id} - {tarea.Descripcion}");
                }
            }
        }
        public void MostrarTareasCompletadas(List<Tarea> tareasCompletadas)
        {
            Console.WriteLine("\nTareas completadas:");
            if (tareasCompletadas.Count == 0)
            {
                Console.WriteLine("No hay tareas completadas.");
                return;
            }
            else
            {
                foreach (Tarea tarea in tareasCompletadas)
                {
                    Console.WriteLine($"[X] {tarea.Id} - {tarea.Descripcion}");
                }
            }
        }
        public void MostrarResumen(int total, int completadas, int pendientes)
        {
            Console.WriteLine("\n--- Resumen de Tareas ---");

            if (total == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }
            Console.WriteLine($"Total de tareas: {total}");
            Console.WriteLine($"Tareas completadas: {completadas}");
            Console.WriteLine($"Tareas pendientes: {pendientes}");
        }
    }
}
