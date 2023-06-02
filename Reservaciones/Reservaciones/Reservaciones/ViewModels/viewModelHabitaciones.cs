using Reservaciones.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Reservaciones.ViewModels
{
    public class viewModelHabitaciones : INotifyPropertyChanged
    {

        public viewModelHabitaciones() {

            // Rutina para abrir el archivo de listas 

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



            crearHabitacion = new Command(() => {


                Habitaciones h = new Habitaciones() {

                    cantidadHuespedes = this.cantidadHuspedes,
                    nombre = this.nombre

                };

                listaH.Add(h);
                 // Rutina para Serializar las Listas de Habitaciones
                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaH);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                CantidadHuespedes = 0;

                Nombre = String.Empty;
            });


        }

        public ObservableCollection<Habitaciones> listaH {get;set;} = new ObservableCollection<Habitaciones>();

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitaciones.bin");

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


        int cantidadHuspedes;

        public int CantidadHuespedes
        {

            get => cantidadHuspedes;
            set
            {
                cantidadHuspedes = value;
                var args = new PropertyChangedEventArgs(nameof(CantidadHuespedes));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command crearHabitacion { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
