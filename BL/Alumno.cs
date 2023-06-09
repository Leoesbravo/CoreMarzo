﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        //public static ML.Result Add(ML.Alumno alumno)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
        //        {
        //            string query = "UsuarioAdd";
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = context;
        //                cmd.CommandText = query;
        //                cmd.CommandType = CommandType.StoredProcedure;


        //                SqlParameter[] collection = new SqlParameter[4];

        //                collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
        //                collection[0].Value = alumno.Nombre;

        //                collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
        //                collection[1].Value = alumno.ApellidoPaterno;

        //                collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
        //                collection[2].Value = alumno.ApellidoMaterno;

        //                collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
        //                collection[3].Value = alumno.FechaNacimiento;

        //                cmd.Parameters.AddRange(collection);

        //                cmd.Connection.Open();

        //                int rowsAffected = cmd.ExecuteNonQuery();///

        //                if (rowsAffected > 0)
        //                {
        //                    result.Correct = true;


        //                }

        //            }
        //        }




        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno" + result.Ex;
        //        //throw;
        //    }

        //    return result;
        //}
        public static ML.Result GetAll(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {
                    var semestreList = context.Alumnos.FromSqlRaw($"AlumnoGetAll").ToList();

                    result.Objects = new List<object>();

                    foreach (var row in semestreList)
                    {
                        alumno = new ML.Alumno();

                        alumno.IdAlumno = row.IdAlumno;
                        alumno.Nombre = row.Nombre;
                        alumno.ApellidoPaterno = row.ApellidoPaterno;
                        alumno.ApellidoMaterno = row.ApellidoMaterno;

                        //alumno.Imagen = row.Imagen;
                     
                        alumno.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                        //alumno.Estatus = row.Estatus.Value;

                        alumno.Semestre = new ML.Semestre();
                        alumno.Semestre.IdSemestre = row.IdSemestre.Value;
                       // alumno.Semestre.Nombre = row.SemestreNombre;

                        alumno.Horario = new ML.Horario();
                       // alumno.Horario.Turno = row.Turno;

                        alumno.Horario.Grupo = new ML.Grupo();
                        //alumno.Horario.Grupo.IdGrupo = row.IdGrupo;
                        //alumno.Horario.Grupo.Nombre = row.Grupo;

                        alumno.Horario.Grupo.Plantel = new ML.Plantel();
                        //alumno.Horario.Grupo.Plantel.IdPlantel = row.IdPlantel;
                        //alumno.Horario.Grupo.Plantel.Nombre = row.Plantel;

                        result.Objects.Add(alumno);

                    }

                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"AlumnoAdd '{alumno.Nombre}','{alumno.ApellidoPaterno}','{alumno.ApellidoMaterno}', '{alumno.FechaNacimiento}', {alumno.Semestre.IdSemestre} ");

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
        public static ML.Result GetByUserName(string userName)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {

                    var objAlumno = context.Alumnos.FromSqlRaw($"AlumnoGetByUserName {userName}").AsEnumerable().FirstOrDefault();

                    if (objAlumno != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        alumno.Nombre = objAlumno.Nombre;
                        //alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        //alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;

                        //alumno.Semestre = new ML.Semestre();
                        //alumno.Semestre.IdSemestre = objAlumno.IdSemestre.Value;
                        //alumno.Semestre.Nombre = objAlumno.SemestreNombre;

                        //alumno.Horario = new ML.Horario();
                        //alumno.Horario.Turno = objAlumno.Turno;

                        //alumno.Horario.Grupo = new ML.Grupo();
                        //alumno.Horario.Grupo.IdGrupo = objAlumno.IdGrupo;

                        //alumno.Horario.Grupo.Plantel = new ML.Plantel();
                        //alumno.Horario.Grupo.Plantel.IdPlantel = objAlumno.IdPlantel;

                        result.Object = alumno; //boxing


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Alumno";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result GetByIdEF(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {

                    var objAlumno = context.Alumnos.FromSqlRaw($"AlumnoGetById {IdAlumno}").AsEnumerable().FirstOrDefault();

                    if (objAlumno != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = objAlumno.IdAlumno;
                        alumno.Nombre = objAlumno.Nombre;
                        alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;

                        alumno.Semestre = new ML.Semestre();
                        alumno.Semestre.IdSemestre = objAlumno.IdSemestre.Value;
                        //alumno.Semestre.Nombre = objAlumno.SemestreNombre;

                        alumno.Horario = new ML.Horario();
                        //alumno.Horario.Turno = objAlumno.Turno;

                        alumno.Horario.Grupo = new ML.Grupo();
                        //alumno.Horario.Grupo.IdGrupo = objAlumno.IdGrupo;

                        alumno.Horario.Grupo.Plantel = new ML.Plantel();
                        //alumno.Horario.Grupo.Plantel.IdPlantel = objAlumno.IdPlantel;

                        result.Object = alumno; //boxing


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Alumno";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"AlumnoUpdate {alumno.IdAlumno},'{alumno.Nombre}','{alumno.ApellidoPaterno}','{alumno.ApellidoMaterno}', '{alumno.FechaNacimiento}', {alumno.Semestre.IdSemestre} ,'{alumno.Imagen}',{alumno.Estatus}");

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }

        public static ML.Result CambiarEstatus(int idAlumno, bool estatus)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaProgramacionNcapasGm2023Context context = new DL.IespinozaProgramacionNcapasGm2023Context())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"AlumnoEstatus {idAlumno},{estatus}");

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el alumno" + ex;
            }
            return result;
        }
    }
}
