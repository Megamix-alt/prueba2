using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyCRUDCORE.Models;
using ProyCRUDCORE.Models.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyCRUDCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbcrudcoreContext _DBContext;

        public HomeController(DbcrudcoreContext context)
        {
            _DBContext = context;
            //_logger = logger;
        }



        public IActionResult Index()
        {
            List<Empleado> lista = _DBContext.Empleados.Include(c => c.oCargo).ToList();
            return View(lista);
        }

        [HttpGet]

        public IActionResult Empleado_Detalle(int idEmpleado)
        {
            EmpleadoVM oEmpleadoVM = new EmpleadoVM()
            {
                oEmpleado = new Empleado(),
                olistaCargo = _DBContext.Cargos.Select(c => new SelectListItem()
                {
                    Text = c.Descripcion,
                    Value = c.IdCargo.ToString()
                }).ToList()
            };
            if (idEmpleado != 0)
            {
                oEmpleadoVM.oEmpleado = _DBContext.Empleados.Find(idEmpleado);
            }

            return View(oEmpleadoVM);
        }
        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM)
        {
            if (oEmpleadoVM.oEmpleado.IdEmpleado == 0)
            {
                //Nuevo
                _DBContext.Empleados.Add(oEmpleadoVM.oEmpleado);
            }
            else
            {
                //Editar
                _DBContext.Empleados.Update(oEmpleadoVM.oEmpleado);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Eliminar(int idEmpleado)
        {
            Empleado oEmpleado = _DBContext.Empleados.Include(c => c.oCargo).Where
                (e => e.IdEmpleado == idEmpleado).FirstOrDefault();
            return View(oEmpleado);
        }

        [HttpPost]

        public IActionResult Eliminar(Empleado oEmpleado)
        {
            _DBContext.Empleados.Remove(oEmpleado);
            _DBContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult FrancheskaNavarro()
        {
            return View();
        }
    }

    }
