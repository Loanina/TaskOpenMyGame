using System.Collections.Generic;
using System.Linq;
using App.Scripts.Modules.GridModel;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Model;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Services
{
    public class ServicePackFieldDummy : IServiceFieldPacker
    {
        public void GeneratePlacements(List<FigurePlacement> outputPlaces, Vector2Int fieldSize, List<ViewModelFigure> figures)
        {
            if (figures.Count == 0) return;
            
            // Сортируем фигуры по занимаемой площади (убывание)
            figures = SortFiguresByOccupiedCells(figures);
            
            var sizeX = fieldSize.x;
            var sizeY = fieldSize.y;
            
            // Разделяем фигуры по максимальному горизонтальному и вертикальному отрезку
            Dictionary<int, List<ViewModelFigure>> horizontalGroups = new();
            Dictionary<int, List<ViewModelFigure>> verticalGroups = new();

            // Создаем пустые списки для всех возможных размеров
            for (int i = 1; i <= sizeX; i++) horizontalGroups[i] = new List<ViewModelFigure>();
            for (int i = 1; i <= sizeY; i++) verticalGroups[i] = new List<ViewModelFigure>();

            // Заполняем словари
            foreach (var figure in figures)
            {
                horizontalGroups[figure.Grid.Width].Add(figure);
                verticalGroups[figure.Grid.Height].Add(figure);
            }

            //Сначала поставим самый длинный и самый тяжелый который встанет в нижний левый угол
          // ???
            

            // Начинаем заполнение поля 
            
             bool[,] field = new bool[sizeX, sizeY]; //грид с занятыми/не занятыми клетками
             
            // Начинаем с самой нижней и левой свободной клетки
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (field[x, y]) continue; // Пропускаем занятые клетки

                    // Если клетка свободна, ищем для неё подходящую фигуру
                    Vector2Int currentCell = new Vector2Int(x, y);

                    // Считаем свободное место справа и сверху
                    int freeRight = CountFreeCells(field, currentCell, Vector2Int.right, sizeX, sizeY);
                    int freeUp = CountFreeCells(field, currentCell, Vector2Int.up, sizeX, sizeY);

                    // Ищем, в какую сторону (по горизонтали или вертикали) меньше свободных мест
                    // Ищем подходящую фигуру
                    ViewModelFigure figureToPlace = null;
            
                    if (freeRight > freeUp)
                    {
                        figureToPlace = FindBestFit(horizontalGroups, freeRight, field, currentCell, sizeX, sizeY); // Ищем фигуру по горизонтали
                        //если после этого фигура пустая то запустим по вертикали
                        if (figureToPlace == null) figureToPlace = FindBestFit(verticalGroups, freeUp, field, currentCell, sizeX, sizeY);

                    }
                    else if (freeRight < freeUp)
                    {
                        figureToPlace = FindBestFit(verticalGroups, freeUp, field, currentCell, sizeX, sizeY); // Ищем фигуру по вертикали
                        if (figureToPlace == null) figureToPlace = FindBestFit(horizontalGroups, freeRight, field, currentCell, sizeX, sizeY);
                    }
                    else
                    {
                        //если равны то нужно что? определить наврное какая по весу больше которая способна встать
                        //пока пусть будет так:
                        figureToPlace = FindBestFit(horizontalGroups, freeRight, field, currentCell, sizeX, sizeY); // Ищем фигуру по горизонтали
                        if (figureToPlace == null) figureToPlace = FindBestFit(verticalGroups, freeUp, field, currentCell, sizeX, sizeY);
                    }
            
                    // Если мы нашли подходящую фигуру, выставляем в наш field значения true на новых клетках занятых
                    if (figureToPlace != null)
                    {
                        var anchorCell = FindAnchorCell(figureToPlace);
                        Vector2Int finalPosition = new Vector2Int(currentCell.x - anchorCell.x, currentCell.y - anchorCell.y);
                        PlaceFigure(field, figureToPlace, finalPosition);
                        outputPlaces.Add(new FigurePlacement
                        {
                            Id = figureToPlace.Id,
                            Place = finalPosition
                        });

                        //нужно удалить фигуру из списка фигур, горизонталь и вертикалей.
                        figures.Remove(figureToPlace);
                        horizontalGroups[figureToPlace.Grid.Width].Remove(figureToPlace);
                        verticalGroups[figureToPlace.Grid.Height].Remove(figureToPlace);
                    }
                }
            }
        }
        
        private ViewModelFigure FindBestFit(Dictionary<int, List<ViewModelFigure>> groups, int availableSpace, bool[,] grid, Vector2Int currentCell, int sizeX, int sizeY)
        {
            // Проходимся от availableSpace до самого маленького ключа
            for (int key = availableSpace; key > 0; key--)
            {
                foreach (var figure in groups[key])
                {
                    if (CanFit(grid, figure, currentCell, sizeX, sizeY)) // Проверяем, встанет ли фигура
                    {
                        return figure; // Как только нашли подходящую, сразу возвращаем её
                    }
                }
            }

            return null; // Если ничего не нашли
        }

        private bool CanFit(bool[,] grid, ViewModelFigure figureToPlace, Vector2Int currentCell, int sizeX, int sizeY)
        {
            int figureWidth = figureToPlace.Grid.Width;
            int figureHeight = figureToPlace.Grid.Height;
            var anchorCell = FindAnchorCell(figureToPlace); // Новая опорная точка

            // Корректируем стартовую позицию, чтобы учесть опорную клетку
            int offsetX = currentCell.x - anchorCell.x;
            int offsetY = currentCell.y - anchorCell.y;

            // Проверяем, чтобы фигура не выходила за границы грида
            if (offsetX < 0 || offsetY < 0 || offsetX + figureWidth > sizeX || offsetY + figureHeight > sizeY)
                return false;

            // Проверяем, что все клетки под фигурой свободны
            for (int x = 0; x < figureWidth; x++)
            {
                for (int y = 0; y < figureHeight; y++)
                {
                    if (figureToPlace.Grid[x, y]) // Если клетка фигуры занята
                    {
                        int posX = offsetX + x;
                        int posY = offsetY + y;

                        // Проверяем границы перед доступом к массиву!
                        if (posX < 0 || posX >= sizeX || posY < 0 || posY >= sizeY)
                        {
                            return false; // Выход за границы — фигуру нельзя поставить
                        }

                        if (grid[posX, posY]) // Проверяем занятость клетки
                        {
                            return false;
                        }
                    }
                }
            }

            return true; // Всё ок, фигура встает
        }

        
        private Vector2Int FindAnchorCell(ViewModelFigure figureToPlace)
        {
            int figureWidth = figureToPlace.Grid.Width;
            int figureHeight = figureToPlace.Grid.Height;

            // Идем по фигуре с нижнего правого угла (снизу вверх, слева направо)
            for (int y = 0; y < figureHeight; y++)
            {
                for (int x = 0; x < figureWidth; x++)
                {
                    if (figureToPlace.Grid[x, y]) return new Vector2Int(x, y);
                }
            }
            return Vector2Int.zero;
        }

        
        private void PlaceFigure(bool[,] grid, ViewModelFigure figureToPlace, Vector2Int cellToPlace)
        {
            int figureWidth = figureToPlace.Grid.Width;
            int figureHeight = figureToPlace.Grid.Height;

            for (int x = 0; x < figureWidth; x++)
            {
                for (int y = 0; y < figureHeight; y++)
                {
                    if (figureToPlace.Grid[x, y]) // Если в фигуре есть блок
                    {
                        grid[cellToPlace.x + x, cellToPlace.y + y] = true; // Помечаем клетку как занятую
                    }
                }
            }
        }

        
        private List<ViewModelFigure> SortFiguresByOccupiedCells(List<ViewModelFigure> figures)
        {
            return figures.OrderByDescending(fig => GetOccupiedCellsCount(fig.Grid)).ToList();
        }

        private int GetOccupiedCellsCount(Grid<bool> grid)
        {
            int count = 0;
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    if (grid[x, y]) count++;
                }
            }
            return count;
        }

        private int CountFreeCells(bool[,] field, Vector2Int start, Vector2Int direction, int sizeX, int sizeY)
        {
            int count = 0;
            Vector2Int pos = start;
    
            while (pos.x >= 0 && pos.y >= 0 && pos.x < sizeX && pos.y < sizeY && !field[pos.x, pos.y])
            {
                count++;
                pos += direction;
            }
    
            return count;
        }
    }
}
