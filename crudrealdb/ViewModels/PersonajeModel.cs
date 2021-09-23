using System;
using crudrealdb.Models;
using crudrealdb.Repositories;
using crudrealdb.ViewModels.Base;
using Xamarin.Forms;

namespace crudrealdb.ViewModels
{
    public class PersonajeModel : ViewModelBase
    {
        RepositoryesRealm repo;

        public PersonajeModel()
        {
            this.repo = new RepositoryesRealm();
            this.Personaje = new Personaje();
        }
        //PROPIEDAD PARA REALIZAR LOS BINDINGS SOBRE LAS VISTAS 
        private Personaje _Personaje;
        public Personaje Personaje
        {
            get { return this._Personaje; }
            set
            {
                this._Personaje = value;
                OnPropertyChanged("Personaje");
            }
        }


        //PROPIEDAD PARA MOSTRAR LOS RESULTADOS DE LAS ACCIONES 
        private String _Mensaje;
        public String Mensaje
        {
            get { return this._Mensaje; }
            set
            {
                this._Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        public Command InsertarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.InsertarPersonaje(this.Personaje);
                    this.Mensaje = "Dato insertado";
                });
            }
        }

        public Command ModificarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.ModificarPersonaje(this.Personaje);
                    this.Mensaje = "Dato Modificado";
                });
            }
        }

        public Command EliminarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.EliminarPersonaje(this.Personaje.idPersonaje);
                    this.Mensaje = "Dato Eliminado";
                });
            }
        }
    }
}
