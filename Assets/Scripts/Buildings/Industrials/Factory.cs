namespace Buildings.Industrials
{
    /** Тип постройки "Завод". Существует для дальнейшего наследования **/
    public abstract class Factory<P> : Industrial<P> where P : FactoryProperties
    {

    }
}