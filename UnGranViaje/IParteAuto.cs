namespace UnGranViaje
{
    public interface IParteAuto
    {
        void Acelerar(int velocidad);
        void Detenerse(int velocidad);
        void Encender();
        void Apagar();
    }
}