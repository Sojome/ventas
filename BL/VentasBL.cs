using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using DAL;

namespace BL
{
    public class VentasBL
    {
        VentasDAL _dal = new VentasDAL();

        public int AgregarVentas(Ventas pEN)
        {
            return _dal.AgregarVenta(pEN);
        }

        public List<Ventas> MostrarVentas()
        {
            return _dal.MostrarVentas();
        }

        public List<Ventas> MostrarVentasPorNombre(Ventas pEN)
        {
            return _dal.MostrarVentasPorNombre(pEN);
        }

        public int ModificarVentas(Ventas pEN)
        {
            return _dal.ModificarVentas(pEN);
        }

        public int Eliminar(Ventas pEN)
        {
            return _dal.ElimnarVentas(pEN);
        }
    }
}
