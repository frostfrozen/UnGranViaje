using System;

namespace UnGranViaje
{
    public class Motor : IParteAuto
    {
        public double Temperatura { get; private set; }
        private const double ACELERADO = 0.2;
        private const double FRENADO = 0.04;
        private readonly int _temperaturaElectro;

        public Motor(int TemperaturaElectro)
        {
            _temperaturaElectro = TemperaturaElectro;
        }

        public void EstaCaliente()
        {
            if (Temperatura > _temperaturaElectro)
                Enfriar();
        }

        private void Enfriar()
        {
            Temperatura -= 15;
        }

        public void Acelerar(int velocidad)
        {
            Temperatura += velocidad * ACELERADO;
            this.EstaCaliente();
        }

        public void Detenerse(int velocidad)
        {
            Temperatura += velocidad * FRENADO;
            this.EstaCaliente();
        }

        public void Encender()
        {
            Temperatura += 70;
            this.EstaCaliente();
        }

        public void Apagar()
        {
            Temperatura = 0;
        }
    }
}
