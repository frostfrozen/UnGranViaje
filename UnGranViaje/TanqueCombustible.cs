using System;

namespace UnGranViaje
{
    public class TanqueCombustible:IParteAuto
    {
        private double _litrosDisponibles;
        private readonly double _capacidadMaxima;

        public TanqueCombustible(Auto auto)
        {
            _capacidadMaxima = auto.CapacidadMaximaTanque;
            CargarTanque(_capacidadMaxima);
        }

        public string CantidadCombustibleActual()
        {
            return _litrosDisponibles.ToString();
        }

        public void CargarTanque(double litros  )
        {
            _litrosDisponibles += litros;
        }

        public void Acelerar(int velocidad)
        {
            
        }

        public void Detenerse(int velocidad)
        {

        }

        public void Apagar()
        {

        }

        public void Encender()
        {
            double cantidadAConsumir = _capacidadMaxima * 0.001;
            Consumir(cantidadAConsumir);
        }

        public EstadoCombustible EstadoCombustible()
        {
            double cantidadActual = _litrosDisponibles / _capacidadMaxima;

            if (cantidadActual >= 0.15)
                return UnGranViaje.EstadoCombustible.OK;

            if (cantidadActual >= 0.10)
                return UnGranViaje.EstadoCombustible.PROXIMO_RESERVA;

            return UnGranViaje.EstadoCombustible.RESERVA;
        }

        public void Consumir(double cantidad)
        {
            _litrosDisponibles -= cantidad;
        }


    }
}
