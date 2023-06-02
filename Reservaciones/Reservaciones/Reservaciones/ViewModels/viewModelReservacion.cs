using Reservaciones.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Reservaciones.ViewModels
{
    public class viewModelReservacion : INotifyPropertyChanged
    {
        public viewModelReservacion() {


            // Abrir las habitaciones 

            try
            {
                /*Abir y leer el archivo */
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formater = new BinaryFormatter();
                listaH = (ObservableCollection<Habitaciones>)formater.Deserialize(memory);
                memory.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sin archivo por cargar de Personas");

            }

            crearReserva = new Command(() => {

                Reservacion r = new Reservacion() { 
                    
                    nombreResponsable = this.Nombre, 
                    fechaReservacion = this.FechaReserva, 
                    telefono = this.Telefono, 
                    correo = this.correo, 
                    cantidadPersonas = this.CantidadPersonas
                
                };


                bool seHizoReserva = ObjetoSeleccionado.agregarReservacion(r);

                if (seHizoReserva == true) {

                    Resultado = "Reservacion Exitosa";
                    
                }

                else
                {

                    Resultado = "Reservacion Erronea";
                }

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaH);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);


            });



        }

        string resultado;

        public string Resultado
        {

            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);
            }

        }

        Habitaciones objetoSeleccionado;

        public Habitaciones ObjetoSeleccionado {

            get => objetoSeleccionado;
            set
            {
                objetoSeleccionado = value;
                var args = new PropertyChangedEventArgs(nameof(ObjetoSeleccionado));
                PropertyChanged?.Invoke(this, args);
            }

        }


        DateTime fechaMin = DateTime.Today;

        public DateTime FechaMin
        {

            get => fechaMin;
            set
            {
                fechaMin = value;
                var args = new PropertyChangedEventArgs(nameof(FechaMin));
                PropertyChanged?.Invoke(this, args);
            }

        }

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitaciones.bin");

        public ObservableCollection<Habitaciones> listaH { get; set; } = new ObservableCollection<Habitaciones>();
        
        string nombre;

        public string Nombre
        {

            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        DateTime fechaReserva = DateTime.Today;

        public DateTime FechaReserva
        {

            get => fechaReserva;
            set
            {
                fechaReserva = value;
                var args = new PropertyChangedEventArgs(nameof(FechaReserva));
                PropertyChanged?.Invoke(this, args);
            }
        }

        int cantidadPersonas;

        public int CantidadPersonas
        {

            get => cantidadPersonas;
            set
            {
                cantidadPersonas = value;
                var args = new PropertyChangedEventArgs(nameof(CantidadPersonas));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string telefono;

        public string Telefono
        {

            get => telefono;
            set
            {
                telefono = value;
                var args = new PropertyChangedEventArgs(nameof(Telefono));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string correo;

        public string Correo
        {

            get => correo;
            set
            {
                correo = value;
                var args = new PropertyChangedEventArgs(nameof(Correo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command crearReserva { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
