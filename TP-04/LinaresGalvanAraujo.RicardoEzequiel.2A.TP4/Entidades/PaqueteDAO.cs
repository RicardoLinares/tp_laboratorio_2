﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand sqlCommand;
        private static  SqlConnection SqlConnection;
        /// <summary>
        /// Contructor de PaqueteDAO, Crea un objeto tipo SqlConnection para el atributo del mismo nombre
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.SqlConnection = new SqlConnection(Entidades.Properties.Settings.Default.SqlKey);
        }
        /// <summary>
        /// Agrega un Paquete a la base datos de paquetes
        /// </summary>
        /// <param name="p"></param>
        /// <returns>True al agregarse, False si hubo un error</returns>
        public static bool Insertar(Paquete p)
        {
            bool respuesta = false;
            //INIT DEL COMANDO
            PaqueteDAO.sqlCommand = new SqlCommand();
            //ESTABLECER LA CONECCION
            PaqueteDAO.sqlCommand.Connection = PaqueteDAO.SqlConnection;
            // ESTABLECER TYPO DE COMANDO
            PaqueteDAO.sqlCommand.CommandType = CommandType.Text;
            // EL COMANDO(EN CASO DE COMANDO TEXTO)
            PaqueteDAO.sqlCommand.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega,trackingID,alumno) VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "'," + "'Ricardo Ezequiel')";
            try
            {
                PaqueteDAO.sqlCommand.Connection.Open();
                int cantidad = PaqueteDAO.sqlCommand.ExecuteNonQuery();
                if (cantidad > 0)
                {
                    respuesta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (PaqueteDAO.SqlConnection.State == ConnectionState.Open)
                {
                    PaqueteDAO.SqlConnection.Close();
                }
            }
            return respuesta;
        }
    }
}
