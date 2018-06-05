using RegistroParcial1.DAL;
using RegistroParcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroParcial1.BLL
{
    public class GruposBLL
    {

        public static bool Guardar(Grupos grupos)
        {
            bool paso = false;
  
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Grupos.Add(grupos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Grupos grupos)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(grupos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;

                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                Grupos grupos = contexto.Grupos.Find(id);
                contexto.Grupos.Remove(grupos);
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;

                }

                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return paso;
        }

        public static Grupos Buscar(int id)
        {

            Grupos grupos = new Grupos();
            Contexto contexto = new Contexto();

            try
            {
                grupos = contexto.Grupos.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return grupos;

        }

        public static List<Grupos> GetList(Expression<Func<Grupos, bool>> expression)
        {
            
            List<Grupos> Grupos = new List<Grupos>();
            Contexto contexto = new Contexto();            

            try
            {

                Grupos = contexto.Grupos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Grupos;
        }


    }
}
