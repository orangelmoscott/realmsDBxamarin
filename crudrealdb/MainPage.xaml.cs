using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudrealdb.Models;
using crudrealdb.Repositories;
using crudrealdb.ViewModels;
using crudrealdb.Views;
using Xamarin.Forms;

namespace crudrealdb
{
    public partial class MainPage : ContentPage
    {
        RepositoryesRealm repo;
        public MainPage()
        {
            InitializeComponent();
            this.repo = new RepositoryesRealm();
            this.botondetalles.Clicked += Botondetalles_Clicked;
            this.botoneliminar.Clicked += Botoneliminar_Clicked;
            this.botoninsertar.Clicked += Botoninsertar_Clicked;
            this.botonmodificar.Clicked += Botonmodificar_Clicked;
            this.botonmostrarregistros.Clicked += Botonmostrarregistros_Clicked;
        }
        private async void Botoninsertar_Clicked(object sender, EventArgs e)
        {
            InsertarPersonaje insertview = new InsertarPersonaje();
            await Navigation.PushAsync(insertview);
        }

        private async void Botonmostrarregistros_Clicked(object sender, EventArgs e)
        {
            PersonajesView listaview = new PersonajesView();
            await Navigation.PushAsync(listaview);
        }

        private async void Botondetalles_Clicked(object sender, EventArgs e)
        {
            DetallePersonaje detailsview = new DetallePersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.Personaje = person;
            detailsview.BindingContext = viewmodel;
            await Navigation.PushAsync(detailsview);
        }

        private async void Botonmodificar_Clicked(object sender, EventArgs e)
        {
            ModificarPersonaje updateview = new ModificarPersonaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.Personaje = person;
            updateview.BindingContext = viewmodel;
            await Navigation.PushAsync(updateview);
        }



        private async void Botoneliminar_Clicked(object sender, EventArgs e)
        {
            EliminarPeronaje deleteview = new EliminarPeronaje();
            PersonajeModel viewmodel = new PersonajeModel();
            int id = int.Parse(this.txtid.Text);
            Personaje person = this.repo.BuscarPersonaje(id);
            viewmodel.Personaje = person;
            deleteview.BindingContext = viewmodel;
            await Navigation.PushAsync(deleteview);
        }
    }
}
