using System;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathLineDrawer
{
    public class PathLineDrawerMono : MonoBehaviour, IPathLineDrawer
    {
        [SerializeField] private LineRenderer lineRenderer;

        private Vector3[] _points = new Vector3[10];
        private int _currentPoint;

        public void AddPoint(Vector2 point)
        {
            AppendNextPoint(point);
        }

        private void AppendNextPoint(Vector2 point)
        {
            _points[_currentPoint] = new Vector3(point.x, point.y, transform.position.z);
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                var nextPoints = new Vector3[_points.Length * 2];
                Array.Copy(_points, nextPoints, _points.Length);
                _points = nextPoints;
            }

            lineRenderer.positionCount = _currentPoint;
            lineRenderer.SetPositions(_points);
        }

        public void Reset()
        {
            _currentPoint = 0;
            lineRenderer.positionCount = 0;
        }
    }
}