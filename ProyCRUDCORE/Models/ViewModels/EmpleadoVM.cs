using Microsoft.AspNetCore.Mvc.Rendering;
namespace ProyCRUDCORE.Models.ViewModels
{
    public class EmpleadoVM
    {
        public Empleado oEmpleado { get; set; }
        public List<SelectListItem> olistaCargo { get; set; }
    }
}
