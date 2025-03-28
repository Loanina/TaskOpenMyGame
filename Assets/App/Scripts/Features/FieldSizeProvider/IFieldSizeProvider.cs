using UnityEngine;

namespace App.Scripts.Features.FieldSizeProvider
{
    public interface IFieldSizeProvider
    {
        Rect GetFieldRect();
    }
}