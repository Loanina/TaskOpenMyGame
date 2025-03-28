namespace App.Scripts.Modules.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
    
    public interface IFactory<TParam, T>
    {
        T Create(TParam param);
    }
}