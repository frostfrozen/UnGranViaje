﻿using System;

namespace UnGranViaje
{
    public abstract class Estado
    {

        public Estado()
        {
        }

        public virtual void Acelerar(Auto auto, int velodidad)
        {
        }

        public virtual void EstadoCombustible(Auto auto)
        {
        }
    }

    public class Encendido : Estado
    {
        public override void Acelerar(Auto auto, int velocidad)
        {
            auto.AcelerarA(velocidad);
        }


        public override void EstadoCombustible(Auto auto)
        {
            auto.ConsultarEstadoCombustible();
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
