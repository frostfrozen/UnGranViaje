using System;

namespace UnGranViaje
{
    public abstract class Estado
    {
        public virtual void Acelerar(int velodidad)
        {
        }

        public virtual void EstadoCombustible()
        {
        }
    }

    public class Encendido : Estado
    {
        private readonly static Encendido _instance = new Encendido();
        public event EventHandler<VelocidadEventArgs> AcelerarEvent;
        public event EventHandler EstadoCombustibleEvent;

        private Encendido()
        {

        }

        public static Encendido Instance()
        {
            return _instance;
        }

        public override void Acelerar(int velocidad)
        {
            OnAcelerar(velocidad);
        }

        protected virtual void OnAcelerar(int velocidad)
        {
            AcelerarEvent?.Invoke(this, new VelocidadEventArgs() { Velocidad = velocidad } );
        }

        public override void EstadoCombustible()
        {
            OnEstadoCombustible();
        }

        protected virtual void OnEstadoCombustible()
        {
            EstadoCombustibleEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Apagado : Estado
    {
        private readonly static Apagado _instance = new Apagado();

        private Apagado()
        {

        }

        public static Apagado Instance()
        {
            return _instance;
        }
    }
}
