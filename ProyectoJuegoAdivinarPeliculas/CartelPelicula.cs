using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace ProyectoJuegoAdivinarPeliculas
{
    public enum Dificultad {Baja, Normal, Alta }
    class CartelPelicula : INotifyPropertyChanged
    {
        public CartelPelicula()
        {
            
        }
        public CartelPelicula(string nombre, string imagen, string pista, string genero, Dificultad dificultad)
        {
            Nombre = nombre;
            Imagen = imagen;
            Pista = pista;
            Genero = genero;
            Dificultad = dificultad;
        }
        private string _nombre;
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (this._nombre != value)
                {
                    this._nombre = value;
                    this.NotifyPropertyChanged("Nombre");
                }
            }
        }

        private string _imagen;
        public string Imagen
        {
            get { return this._imagen; }
            set
            {
                if (this._imagen != value)
                {
                    this._imagen = value;
                    this.NotifyPropertyChanged("Imagen");
                }
            }
        }
        private string _pista;
        public string Pista
        {
            get { return this._pista; }
            set
            {
                if (this._pista != value)
                {
                    this._pista = value;
                    this.NotifyPropertyChanged("Pista");
                }
            }
        }
        private string _genero;
        public string Genero
        {
            get { return this._genero; }
            set
            {
                if (this._genero != value)
                {
                    this._genero = value;
                    this.NotifyPropertyChanged("Género");
                }
            }
        }
        private Dificultad _dificultad;
        public Dificultad Dificultad
        {
            get { return this._dificultad; }
            set
            {
                if(this._dificultad != value)
                {
                    this._dificultad = value;
                    this.NotifyPropertyChanged("Dificultad");
                }
            }
        }
        public static ObservableCollection<CartelPelicula> GetSamples(string ruta)
        {
            ObservableCollection<CartelPelicula> lista = new ObservableCollection<CartelPelicula>();

            lista.Add(new CartelPelicula("Pulp Fiction", Path.Combine(ruta, @"pulp_fiction.png"), "Pulp Fiction", "Thriller", Dificultad.Baja));
            lista.Add(new CartelPelicula("Miedo y asco en Las Vegas", Path.Combine(ruta, @"miedo_y_asco.jpg"), "Miedo y...", "Novela", Dificultad.Baja));
            lista.Add(new CartelPelicula("Spiderman", Path.Combine(ruta, @"spiderman.jpg"), "Spiderman", "Ciencia-ficción", Dificultad.Baja));

            return lista;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
