using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VentasDAL
    {
        public int AgregarVenta(Ventas pEN)
        {
            IDbConnection _conn = DBComon.Conexion();
            _conn.Open();
            SqlCommand _Comand = new SqlCommand("AGREGAR_VENTAS", _conn as SqlConnection);
            _Comand.CommandType = CommandType.StoredProcedure;
            _Comand.Parameters.Add(new SqlParameter("@NOMBRE", pEN.Nombre));
            _Comand.Parameters.Add(new SqlParameter("@TOTAL_VENTAS", pEN.TotalVentas));
            _Comand.Parameters.Add(new SqlParameter("@ESTADO", pEN.Estado));
            int Resultado = _Comand.ExecuteNonQuery();
            _conn.Close();
            return Resultado;
        }

        public List<Ventas> MostrarVentas()
        {
            IDbConnection _conn = DBComon.Conexion();
            _conn.Open();
            SqlCommand _Command = new SqlCommand("CONSULTAR_VENTAS", _conn as SqlConnection);
            _Command.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _Command.ExecuteReader();
            List<Ventas> Lista = new List<Ventas>();
            while (_reader.Read())
            {
                Ventas _ventas = new Ventas();
                _ventas.Id = _reader.GetInt64(0);
                _ventas.Nombre = _reader.GetString(1);
                _ventas.TotalVentas = _reader.GetInt64(2);
                _ventas.Estado = _reader.GetString(3);
                Lista.Add(_ventas);
            }
            _conn.Close();
            return Lista;
        }

        public List<Ventas> MostrarVentasPorNombre(Ventas pEN)
        {
            IDbConnection _conn = DBComon.Conexion();
            _conn.Open();
            SqlCommand _Command = new SqlCommand("CONSULTAR_VENTAS_POR_NOMBRE", _conn as SqlConnection);
            _Command.CommandType = CommandType.StoredProcedure;
            _Command.Parameters.Add(new SqlParameter("@NOMBRE", pEN.Nombre));
            IDataReader _reader = _Command.ExecuteReader();
            List<Ventas> Lista = new List<Ventas>();
            while (_reader.Read())
            {
                Ventas _ventas = new Ventas();
                _ventas.Id = _reader.GetInt64(0);
                _ventas.Nombre = _reader.GetString(1);
                _ventas.TotalVentas = _reader.GetInt64(2);
                _ventas.Estado = _reader.GetString(3);
                Lista.Add(_ventas);
            }
            _conn.Close();
            return Lista;
        }

        public int ModificarVentas(Ventas pEN)
        {
            IDbConnection _Conn = DBComon.Conexion();
            _Conn.Open();
            SqlCommand _Command = new SqlCommand("MODIFICAR_VENTAS", _Conn as SqlConnection);
            _Command.CommandType = CommandType.StoredProcedure;
            _Command.Parameters.Add(new SqlParameter("@ID", pEN.Id));
            _Command.Parameters.Add(new SqlParameter("@NOMBRE", pEN.Nombre));
            _Command.Parameters.Add(new SqlParameter("@TOTAL_VENTAS", pEN.TotalVentas));
            _Command.Parameters.Add(new SqlParameter("@ESTADO", pEN.Estado));
            int Resultado = _Command.ExecuteNonQuery();
            _Conn.Close();
            return Resultado;
        }

        public int ElimnarVentas(Ventas pEN)
        {
            IDbConnection _Conn = DBComon.Conexion();
            _Conn.Open();
            SqlCommand _Command = new SqlCommand("ELIMINAR_VENTAS", _Conn as SqlConnection);
            _Command.CommandType = CommandType.StoredProcedure;
            _Command.Parameters.Add(new SqlParameter("@ID", pEN.Id));
            int resultado = _Command.ExecuteNonQuery();
            _Conn.Close();
            return resultado;
        }
    }
}
