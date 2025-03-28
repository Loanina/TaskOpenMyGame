using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Modules.Systems
{
    public class ComponentContainer
    {
        
        private interface IContainerComponents
        {
            
        }
        
        private class ContainerComponents<T> : IContainerComponents where T : class 
        {
            private List<T> _components = new();

            public ContainerComponents()
            {
                
            }

            public void Add(T value)
            {
                _components.Add(value);
            }


            public void Remove(T value)
            {
                _components.Remove(value);
            }

            public T Get()
            {
                return _components.FirstOrDefault();
            }

            public List<T> GetComponents()
            {
                return _components;
            }

            public bool HasComponents()
            {
                return _components.Count > 0;
            }

            public void Clear()
            {
                _components.Clear();
            }

            public T RemoveFirst()
            {
                if (_components.Count == 0)
                {
                    return default;
                }

                var component = _components[0];
                _components.RemoveAt(0);
                return component;
            }

            public int GetComponentsCount()
            {
                return _components.Count;
            }
        }
        
        private readonly Dictionary<Type, IContainerComponents> _components = new();

        public T GetComponent<T>() where T : class
        {
            var container = GetContainerByType<T>();
            return container.Get();
        }
        
        public IReadOnlyList<T> GetComponents<T>() where T : class
        {
            var container = GetContainerByType<T>();
            return container.GetComponents();
        }
        
        public void AddComponent<T>(T component) where T : class
        {
            var container = GetContainerByType<T>();
            container.Add(component);
        }
        
        public void SetComponent<T>(T component) where T : class
        {
            var container = GetContainerByType<T>();
            container.Clear();
            container.Add(component);
        }

        private ContainerComponents<T> GetContainerByType<T>() where T : class
        {
            var type = typeof(T);

            if (_components.TryGetValue(type, out var container))
            {
                return container as ContainerComponents<T>;
            }

            var componentContainer = new ContainerComponents<T>();
            _components[type] = componentContainer;

            return componentContainer;
        }

        public bool HasComponent<T>() where T : class
        {
            var container = GetContainerByType<T>();


            return container.HasComponents();
        }
        
        public bool TryGetComponent<T>(out T component) where T : class
        {
            component = default;
            var container = GetContainerByType<T>();

            if (!container.HasComponents())
            {
                return false;
            }

            component = container.Get();

            return true;
        }
        
        public T ClearComponents<T>() where T : class
        {
            var container = GetContainerByType<T>();
            container.Clear();
            
            return default;
        }
        
        public T RemoveComponent<T>() where T : class
        {
            var container = GetContainerByType<T>();
            
            return container.RemoveFirst();;
        }

 
        
        public int GetComponentCount<T>() where T : class
        {
            var container = GetContainerByType<T>();

            return container.GetComponentsCount();
        }

        public void ClearAll()
        {
            _components.Clear();
        }
    }
}