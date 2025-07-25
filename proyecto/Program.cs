using proyecto.Controllers;

namespace proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            TareaController controlador = new TareaController();
            controlador.Iniciar();
        }
    }
}