using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class AccesoBaseDeDatos
    {
        #region Atributos

        private SqlConnection conexion;
        private SqlCommand comando;
        #endregion

        #region Constructor

        /// <summary>
        /// constructor acceso base de datos
        /// </summary>
        public AccesoBaseDeDatos()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.miConexion);
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve true si la conexion de la base de datos se realiza con exito, caso contrario devuelve false
        /// </summary>
        /// <returns></returns>
        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        /// <summary>
        /// Devuelve la lista de libros de la base de datos, y segun el tipo de libro, los agrega a la lista
        /// </summary>
        /// <returns></returns>
        public List<Libro> ObtenerListaLibros()
        {
            List<Libro> listaLibros = new List<Libro>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                comando.CommandText = "SELECT * FROM TablaLibros ORDER BY id";
                this.conexion.Open();

                SqlDataReader oDr = comando.ExecuteReader();
                while (oDr.Read())
                {
                    if (!oDr.IsDBNull(6)) // si es tipo Cuento
                    {
                        listaLibros.Add(new Cuento(oDr.GetInt32(0), oDr.GetString(1), oDr.GetInt32(2),
                            oDr.GetString(3), (float)(oDr.GetDouble(4)), oDr.GetInt32(5), oDr.GetInt32(6)));
                    }
                    else // si es tipo diccionario
                    {
                        listaLibros.Add(new Diccionario(oDr.GetInt32(0), oDr.GetString(1), oDr.GetInt32(2),
                            oDr.GetString(3), (float)(oDr.GetDouble(4)), oDr.GetInt32(5), oDr.GetString(7)));
                    }

                }

                oDr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaLibros;
        }

        /// <summary>
        /// Devuelve la tabla de datos
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerTablaLibros()
        {
            DataTable tablaLibros = new DataTable("TablaLibros");

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.CommandText = "SELECT * FROM TablaLibros ORDER BY id";

                this.conexion.Open();

                SqlDataReader oDr = this.comando.ExecuteReader();

                tablaLibros.Load(oDr);

                oDr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return tablaLibros;
        }

        /// <summary>
        /// devuelve el libro segun el id ingresado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Libro ObtenerLibroPorId(int id)
        {
            Libro l = null;

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", id);

                this.comando.CommandText = "SELECT * FROM TablaLibros WHERE id = @id";

                this.conexion.Open();

                SqlDataReader oDr = this.comando.ExecuteReader();

                if (oDr.Read())
                {
                    if (oDr.IsDBNull(6)) // si es tipo diccionario
                    {
                        l = new Diccionario(oDr.GetInt32(0), oDr.GetString(1), oDr.GetInt32(2),
                            oDr.GetString(3), (float)(oDr.GetDouble(4)), oDr.GetInt32(5), oDr.GetString(7));
                    }
                    else
                    {
                        l = new Cuento(oDr.GetInt32(0), oDr.GetString(1), oDr.GetInt32(2),
                            oDr.GetString(3), (float)(oDr.GetDouble(4)), oDr.GetInt32(5), oDr.GetInt32(6));
                    }
                }

                oDr.Close();
            }

            catch (Exception e)
            {
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return l;
        }

        /// <summary>
        /// devuelve true si se pudo insertar el libro a la base de datos, caso contrario devuelve false
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool InsertarLibro(Libro l)
        {
            bool todoOk = false;

            string sql="";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                if(l is Diccionario)
                {
                    sql = "INSERT INTO TablaLibros (nombre,precio,idioma,cantidadPaginas,stock,tipoDiccionario)";
                    sql += "VALUES (@nombre,@precio,@idioma,@cantidadPaginas,@stock,@tipoDiccionario)";
                    this.comando.Parameters.AddWithValue("@tipoDiccionario", ((Diccionario)l).TipoDiccionario);

                }
                else if (l is Cuento)
                {
                    sql = "INSERT INTO TablaLibros (nombre,precio,idioma,cantidadPaginas,stock,cantidadCapitulos)";
                    sql += "VALUES (@nombre,@precio,@idioma,@cantidadPaginas,@stock,@cantidadCapitulos)";
                    this.comando.Parameters.AddWithValue("@cantidadCapitulos", ((Cuento)l).CantidadCapitulos);

                }
                this.comando.Parameters.AddWithValue("@nombre", l.Nombre);
                this.comando.Parameters.AddWithValue("@precio", l.Precio);
                this.comando.Parameters.AddWithValue("@idioma", l.Idioma);
                this.comando.Parameters.AddWithValue("@cantidadPaginas", l.CantidadPaginas);
                this.comando.Parameters.AddWithValue("@stock", l.Stock);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception ex)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        /// <summary>
        /// devuelve true si se modifico el libro, caso contrario devuelve false
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool ModificarLibro(Libro l)
        {
            bool todoOk = false;

            string sql = "UPDATE TablaLibros SET nombre = @nombre, precio = @precio, idioma = @idioma, ";
            sql += "cantidadPaginas = @cantidadPaginas, stock = @stock WHERE id = @id";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", l.ID);
                this.comando.Parameters.AddWithValue("@nombre", l.Nombre);
                this.comando.Parameters.AddWithValue("@idioma", l.Idioma);
                this.comando.Parameters.AddWithValue("@precio", l.Precio);
                this.comando.Parameters.AddWithValue("@cantidadPaginas", l.CantidadPaginas);
                this.comando.Parameters.AddWithValue("@stock", l.Stock);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }


        /// <summary>
        /// elimina el libro de la base de datos, caso contrario devuelve false
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool EliminarLibro(Libro l)
        {
            bool todoOk = false;

            string sql = "DELETE FROM TablaLibros WHERE id = @id";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@id", l.ID);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }
        #endregion

    }
}
