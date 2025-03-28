using System;
using System.Collections.Generic;
using App.Scripts.Modules.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services
{
    public class HandlerInputCellClickContainer : IHandlerFieldClick, IHandlerInputSelector
    {
        private readonly Dictionary<string, IHandlerFieldClick> _handlerMap = new ();
        private IHandlerFieldClick _currentHandler;

        public IList<string> AvailableHandlers => _handlersKeys;

        private readonly List<string> _handlersKeys = new();
        public void AddHandler(string id, IHandlerFieldClick handlerFieldClick)
        {
            _handlersKeys.Add(id);
            _handlerMap.Add(id, handlerFieldClick);
        }

        public void ChangeHandler(string id)
        {
            if (_handlerMap.TryGetValue(id, out var handler) is false)
            {
                throw new Exception($"handler with {id} not found");
            }

            ResetCurrentHandler();

            _currentHandler = handler;
        }

        public void ProcessGridClick(SystemContext context, Vector2Int cellIndex)
        {
            _currentHandler.ProcessGridClick(context, cellIndex);
        }

        public void Reset()
        {
            ResetCurrentHandler();
        }
        
        private void ResetCurrentHandler()
        {
            if (_currentHandler != null)
            {
                _currentHandler.Reset();
            }
        }
    }
}