namespace App.Scripts.Modules.Systems
{
    public class SystemContext
    {
        public ComponentContainer Data { get; } = new ComponentContainer();
        public ComponentContainer Signals { get; } = new ComponentContainer();

        public SystemContext()
        {
            
        }

        public void Clean()
        {
            Signals.ClearAll();
        }
    }
}