using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnGranViaje
{
    public class Auto
    {
        private Estado _estado;
        private readonly int _temperaturaElectro;
        public double CapacidadMaximaTanque { get; private set; }

        public void AcelerarA(object velocidad)
        {
            throw new NotImplementedException();
        }

        public int VelocidadActual { get; private set; }
        private DateTime? _horaAceleracion;
        private IList<IParteAuto> _partesAuto;

        public void ConsultarEstadoCombustible()
        {
            throw new NotImplementedException();
        }

        private const double CONSUMOPORKM = 0.133;

        public Auto(string marca, double capacidadMaximaTanque)
        {
            _estado = new Apagado();
            _partesAuto = new List<IParteAuto>();
            TemperaturasAutos.Temperatura.TryGetValue(marca, out _temperaturaElectro);
            CapacidadMaximaTanque = capacidadMaximaTanque;


            //añado las partes vitales
            _partesAuto.Add(new TanqueCombustible(this));
            _partesAuto.Add(new Motor(_temperaturaElectro));
        }

        public void Encender()
        {
            _estado = new Encendido();
        }

        public void Apagar()
        {
            _estado = new Apagado();
            VelocidadActual = 0;
            _horaAceleracion = null;
        }

        public void InsertarParte(IParteAuto parte)
        {
            if (NoCumpleRestricciones(parte))
                throw new Exception("Esa parte esta restringida a una unica");

            _partesAuto.Add(parte);
        }

        private bool NoCumpleRestricciones(IParteAuto parte)
        {
            var esTanqueCombustible = parte.GetType() == typeof(TanqueCombustible);
            var esMotor = parte.GetType() == typeof(Motor);

            var existeTanqueCombustible = _partesAuto.Any(x => x.GetType() == typeof(Motor) && esMotor);
            var existeMotor = _partesAuto.Any(x => x.GetType() == typeof(Motor) && esMotor);

            return (existeMotor || existeTanqueCombustible);
        }

        public void Acelerar(int velocidad)
        {
            _estado.Acelerar(this,  velocidad);

            Console.WriteLine("Dispare Evento Acelerar");
        }

        private void OnAcelerar(object source, VelocidadEventArgs e)
        {
            int velocidadMedia = (e.Velocidad + VelocidadActual) / 2;

            if (_horaAceleracion != null)
            {
                var tiempoRecorrido = DateTime.Now - _horaAceleracion;

                double distancia = (velocidadMedia * tiempoRecorrido.Value.Seconds) / 60 / 24f;

                this.ConsumirCombustible(distancia);
            }

            foreach (var parte in _partesAuto)
            {
                parte.Acelerar(e.Velocidad);
            }


            _horaAceleracion = DateTime.Now;
            VelocidadActual += e.Velocidad;

            Console.WriteLine("Acelere: " + e.Velocidad);

        }

        public void EstadoCombustible()
        {
            _estado.EstadoCombustible(this);
        }

        private void OnEstadoCombustible(object sender, EventArgs e)
        {
            var tanqueCombustible = _partesAuto.SingleOrDefault(x => x.GetType() == typeof(TanqueCombustible));

            if (tanqueCombustible == null)
                throw new TanqueCombustibleException("No hay tanque de combustible");

            Console.WriteLine((tanqueCombustible as TanqueCombustible).EstadoCombustible());
        }

        private void ConsumirCombustible(double distancia)
        {
            var tanqueCombustible = _partesAuto.SingleOrDefault(x => x.GetType() == typeof(TanqueCombustible));

            if (tanqueCombustible == null)
                throw new TanqueCombustibleException("No hay tanque de combustible");

            (tanqueCombustible as TanqueCombustible).Consumir(CONSUMOPORKM * distancia);
        }

        public void CantidadCombustible()
        {
            var tanqueCombustible = _partesAuto.SingleOrDefault(x => x.GetType() == typeof(TanqueCombustible));

            if (tanqueCombustible == null)
                throw new TanqueCombustibleException("No hay tanque de combustible");

            Console.WriteLine((tanqueCombustible as TanqueCombustible).CantidadCombustibleActual());
        }

        public void Temperatura()
        {
            var motor = _partesAuto.SingleOrDefault(x => x.GetType() == typeof(Motor));

            if (motor == null)
                throw new MotorException("No hay motor");

            Console.WriteLine((motor as Motor).Temperatura);
        }
    }
}
