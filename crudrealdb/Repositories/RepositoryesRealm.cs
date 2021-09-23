using System;
using System.Collections.Generic;
using System.Linq;
using crudrealdb.Models;
using Realms;

namespace crudrealdb.Repositories
{
    public class RepositoryesRealm
    {
        private Realm conexionrealm;
        Transaction transaction;

        public RepositoryesRealm()
        {
            //CREAMOS EL OBJETO QUE NOS PERMITIRA CONECTARNOS 
            //CON REALM EN CADA DISPOSITIVO 
            this.conexionrealm = Realm.GetInstance();
        }


        //METODO PARA DEVOLVER TODOS LOS OBJETOS PERSONAJES 
        public List<Personaje> GetPersonajes()
        {
            List<Personaje> lista = this.conexionrealm.All<Personaje>().ToList();
            return lista;
        }

        public Personaje BuscarPersonaje(int idpersonaje)
        {
            //RECUPERAMOS TODOS LOS PERSONAJES 
            List<Personaje> lista = this.GetPersonajes();
            //BUSCAMOS UN PERSONAJE EN CONCRETO 
            Personaje personaje = lista.FirstOrDefault(z => z.idPersonaje == idpersonaje);
            return personaje;
        }

        public int GetMaximoIdPersonaje()
        {
            //RECUPERAMOS TODOS LOS PERSONAJES 
            List<Personaje> lista = this.GetPersonajes();
            return lista.Count + 1;
        }

        //METODO PARA INSERTAR EN REALM.   
        public void InsertarPersonaje(Personaje personaje)
        {
            transaction = conexionrealm.BeginWrite();
            var entry = conexionrealm.Add(personaje);
            transaction.Commit();
            //this.conexionrealm.Write(() => 
            //{ 
            //    //CREAMOS UN NUEVO PERSONAJE PARA INSERTAR 
            //    //EN EL METODO WRITE 
            //    Personaje newpersonaje = new Personaje(); 
            //    newpersonaje.IdPersonaje = this.GetMaximoIdPersonaje(); 
            //    newpersonaje.Nombre = personaje.Nombre; 
            //    newpersonaje.Serie = personaje.Serie; 
            //}); 
        }
        //METODO PARA MODIFICAR EN REALM.   
        public void ModificarPersonaje(Personaje personaje)
        {
            //BUSCAMOS UN PERSONAJE EN CONCRETO 
            Personaje existepersonaje = this.BuscarPersonaje(personaje.idPersonaje);
            //UTILIZAMOS TRANSACCIONES PARA MODIFICAR EL PERSONAJE 
            using (var trans = this.conexionrealm.BeginWrite())
            {
                existepersonaje.Nombre = personaje.Nombre;
                existepersonaje.Serie = personaje.Serie;
                trans.Commit();
            }
        }
        public void EliminarPersonaje(int idpersonaje)
        {
            //BUSCAMOS EL PERSONAJE 
            Personaje personaje = this.BuscarPersonaje(idpersonaje);

            if (personaje != null)
            {
                using (var trans = this.conexionrealm.BeginWrite())
                {
                    this.conexionrealm.Remove(personaje);
                    trans.Commit();
                }
            }
        }

    }
}