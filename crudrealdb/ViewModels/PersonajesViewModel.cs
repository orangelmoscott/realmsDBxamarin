using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using crudrealdb.Models;
using crudrealdb.Repositories;
using crudrealdb.ViewModels.Base;

namespace crudrealdb.ViewModels
{
    public class PersonajesViewModel : ViewModelBase
    {
        private RepositoryesRealm repo;

        public PersonajesViewModel()
        {

            this.repo = new RepositoryesRealm();
            List<Personaje> lista = this.repo.GetPersonajes();
            this.Personajes = new ObservableCollection<Personaje>(lista);
        }
        private ObservableCollection<Personaje> _Personajes;
        public ObservableCollection<Personaje> Personajes
        {
            get { return this._Personajes; }
            set
            {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }
    }
}
