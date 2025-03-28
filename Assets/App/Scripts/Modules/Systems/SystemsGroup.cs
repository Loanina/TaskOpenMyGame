using System.Collections.Generic;

namespace App.Scripts.Modules.Systems
{
    public class SystemsGroup
    {
        private readonly List<ISystem> _systems = new();

        private readonly SystemContext _context = new ();

        public SystemContext Context => _context;
        
        public SystemsGroup()
        {
        }

        public SystemsGroup(IEnumerable<ISystem> systems)
        {
            AddSystems(systems);
        }

        public SystemsGroup AddSystem(ISystem system)
        {
            system.Context = _context;
            _systems.Add(system);
            return this;
        }

        public SystemsGroup AddSystems(IEnumerable<ISystem> systems)
        {
            foreach (var system in systems) AddSystem(system);

            return this;
        }

        public void Init()
        {
            foreach (var system in _systems) system.Init();
        }

        public void Update(float dt)
        {
            foreach (var system in _systems)
            {
                system.Update(dt);
            }
            
            _context.Clean();
        }

        public void Cleanup()
        {
            foreach (var system in _systems)
            {
                system.Cleanup();
            }
        }
    }
}