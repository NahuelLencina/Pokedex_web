using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;


namespace negocio
{
    public class PokemonNegocio
    {

        public List<Pokemon> listar(string id = "")
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, p.Id, p.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.id = P.IdTipo and D.id = P.IdDebilidad ";
                if (id != "")
                    comando.CommandText += " and P.id = " + id;
                comando.Connection = conexion;

                 conexion.Open();
                 lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    //if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagen")))) 
                    //aux.UrlImagen = (string)lector["UrlImagen"];
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];


                    aux.Tipo = new Elemento();
                    aux.Tipo.id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (String)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];
                    aux.Activo = (bool)lector["Activo"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Pokemon> listaConSP()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Stores Procedures -- Nueva forma de ejecutar la lectura
                // con una funcion en la base de datos

                // string consulta = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, p.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.id = P.IdTipo and D.id = P.IdDebilidad And P.Activo = 1";
                // datos.setearConsulta(consulta);

                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (String)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarConSP(Pokemon Poke)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storeModificarPokemon");
                datos.setearParametro("@numero", Poke.Numero);
                datos.setearParametro("@nombre", Poke.Nombre);
                datos.setearParametro("@desc", Poke.Descripcion);
                datos.setearParametro("@img", Poke.UrlImagen);
                datos.setearParametro("@idTipo", Poke.Tipo.id);
                datos.setearParametro("@idDebilidad", Poke.Debilidad.id);
                datos.setearParametro("@id", Poke.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //public void agregar(Pokemon nuevo)
        //{
        //    //Creamos la coneccion con nuestra base de datos
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen) Values (" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @UrlImagen)");
        //        datos.setearParametro("@idTipo", nuevo.Tipo.id);
        //        datos.setearParametro("@idDebilidad", nuevo.Debilidad.id);
        //        datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
        //        datos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}


        public void agregarConSP(Pokemon nuevo)
        {
            //Creamos la coneccion con nuestra base de datos
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storeAltaPokemon");

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@numero", nuevo.Numero);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@Img", nuevo.UrlImagen);
                datos.setearParametro("@idTipo", nuevo.Tipo.id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.id);
              //  datos.setearParametro("@idEvolucion", null);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        //public void modificar(Pokemon Poke)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion =@desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad where Id = @id");
        //        datos.setearParametro("@numero", Poke.Numero);
        //        datos.setearParametro("@nombre", Poke.Nombre);
        //        datos.setearParametro("@desc", Poke.Descripcion);
        //        datos.setearParametro("@img", Poke.UrlImagen);
        //        datos.setearParametro("@idTipo", Poke.Tipo.id);
        //        datos.setearParametro("@idDebilidad", Poke.Debilidad.id);
        //        datos.setearParametro("@id", Poke.Id);


        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, p.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.id = P.IdTipo and D.id = P.IdDebilidad And P.Activo = 1 And ";

                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero >  " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero <  " + filtro;
                            break;

                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }

                }

                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;

                        default:
                            consulta += "Nombre like '%" + filtro + "%' ";
                            break;
                    }


                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like'" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;

                        default:
                            consulta += "P.Descripcion like '%" + filtro + "%' ";
                            break;
                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (String)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from POKEMONS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo = @activo where id = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
