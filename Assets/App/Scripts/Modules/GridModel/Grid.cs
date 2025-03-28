using System;
using System.Text;
using UnityEngine;

namespace App.Scripts.Modules.GridModel
{
    public class Grid<T> : IEquatable<Grid<T>>
    {
        public int Width => _size.x;
        public int Height => _size.y;

        public Vector2Int Size => _size;
        
        private  Vector2Int _size;
        private T[][] _matrix;

        public Grid(Vector2Int size)
        {
            UpdateMatrix(size);
        }

        public void UpdateMatrix(Vector2Int size)
        {
            if (_size == size)
            {
                return;
            }
            
            _size = size;
           _matrix = new T[size.y][];

           for (int i = 0; i < _size.y; i++)
           {
               _matrix[i] = new T[_size.x];
           }
        }

        public void Clear()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _matrix[i][j] = default;
                }
            }
        }
        
        public T this[int x, int y]
        {
            get
            {
                return _matrix[y][x];
            }

            set
            {
                _matrix[y][x] = value;
            }
        }

        public T this[Vector2Int index]
        {
            get => this[index.x, index.y];

            set => this[index.x, index.y] = value;
        }

        public bool IsValid(Vector2Int index)
        {
            return index.x >= 0 && index.y >= 0 && index.x < Width && index.y < Height;
        }

        public bool Equals(Grid<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _size.Equals(other._size) && EqualsMatrix(_matrix, other._matrix);
        }

        private bool EqualsMatrix(T[][] matrix, T[][] otherMatrix)
        {
            if (ReferenceEquals(matrix, otherMatrix))
            {
                return true;
            }

            if (matrix.Length != otherMatrix.Length || matrix[0].Length != otherMatrix[0].Length)
            {
                return false;
            }
            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j].Equals(otherMatrix[i][j]) is false)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Grid<T>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_size, _matrix);
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                buffer.AppendLine(string.Join(' ', _matrix[i]));
            }
            
            return buffer.ToString();
        }
    }
}