using System;
using Realms;

namespace crudrealdb.Models
{
    public class Personaje : RealmObject 
    {
        public int idPersonaje { get; set; }
        public String Nombre { get; set; }
        public String Serie { get; set; }

    }
}
