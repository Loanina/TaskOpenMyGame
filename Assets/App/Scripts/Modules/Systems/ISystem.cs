namespace App.Scripts.Modules.Systems
{
    public interface ISystem
    {
        
        public SystemContext Context { get; set; }
        void Init();
        void Update(float dt);
        void Cleanup();
    }
}