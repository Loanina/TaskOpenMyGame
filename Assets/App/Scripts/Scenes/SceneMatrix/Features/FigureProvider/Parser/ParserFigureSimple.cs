using System;
using System.Collections.Generic;
using App.Scripts.Modules.GridModel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureProvider.Parser
{
    public class ParserFigureSimple : IFigureParser
    {
        public List< Grid<bool>> ParseFile(string text)
        {
            var lines = text.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            var result = new List<Grid<bool>>();

            foreach (string line in lines)
            {
                try
                {
                    var figure = ParseFigure(line);
                    result.Add(figure);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Exception parse figure {text} in line {line} with {e}");
                }
            }

            return result;
        }

        private Grid<bool> ParseFigure(string line)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) throw new ArgumentOutOfRangeException(nameof(line));

            if (!int.TryParse(parts[0], out var width) || !int.TryParse(parts[1], out var height))
            {
                throw new Exception($"Cant parse size figure {line}");
            }
            
            var result = new Grid<bool>(new Vector2Int(width, height) );

            for (int index = 2; index < parts.Length; index++)
            {
                var idText = parts[index];
                
                if (int.TryParse(idText, out var id))
                {
                    int i = id / width;
                    int j = id % width;

                    result[j, i] = true;
                }
            }
            
            return result;
        }
    }
}