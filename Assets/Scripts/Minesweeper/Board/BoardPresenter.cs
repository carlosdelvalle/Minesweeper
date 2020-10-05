using System;
using System.Collections.Generic;
using System.Drawing;
using Minesweeper.Tile;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Minesweeper.Board
{
    public class BoardPresenter : MonoBehaviour
    {
        private const int TILE_WIDTH = 50;
        private const int BOARD_SIZE = 8;
        private const int MINES = 10;
        private IBoardModel _model;
        private IBoardView _view;
        public GameObject mineTilePrefab;
        public GameObject blankTilePrefab;
        public GameObject boardContainer;
        private void Start()
        {
            _model = new BoardModel();
            _model.Setup(BOARD_SIZE,MINES);
            _view = GetComponent<BoardView>();
            Initialize();
        }

        public void OnReset()
        {
            _view.Reset();
        
            IterateBoard((x, y) =>
            {
                DestroyImmediate(_model.GetPosition(x,y));
            });
        
            _model.Reset();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _model.Mines; i++)
            {
                GenerateMines();
            }

            GenerateBlankTiles();
        
            SetNeighbours();
        }

        private void GenerateBlankTiles()
        {
            IterateBoard((x,y) =>
            {
                if (_model.GetPosition(x,y) == null)
                {
                    SetTile(blankTilePrefab, new BlankTileModel(new Point(x,y)), OnBlankTileUncover);
                }
            });
        }

        private void SetNeighbours()
        {
            IterateBoard((x,y) =>
            {
                var adjacents = GetAdjacentSquares(x, y);
                List<ITilePresenter> ne = new List<ITilePresenter>();
                
                foreach (var point in adjacents)
                {
                    var tile = _model.GetPosition(point.X,point.Y).GetComponent<ITilePresenter>();
                    ne.Add(tile);
                }
                
                _model.GetPosition(x,y)?.GetComponent<ITilePresenter>().SetNeighbours(ne);
            });
        }

        public void GenerateMines()
        {
            var size = _model.Size;
            int x = Random.Range(0, size);
            int y = Random.Range(0, size);

            if (_model.GetPosition(x,y) == null)
            {
                SetTile(mineTilePrefab,new MineTileModel(new Point(x,y)),OnMineTileUncover);
            }
            else
            {
                GenerateMines();
            }
        }

        private void SetTile(GameObject prefab, ITileModel model, Action<int, int> callback)
        {
            GameObject tile = Instantiate(prefab, boardContainer.transform);
            int offset = ((_model.Size * TILE_WIDTH) / 2) - TILE_WIDTH / 2;

            tile.transform.localPosition = new Vector3(model.Position.X * TILE_WIDTH - offset , 
                                                    model.Position.Y * TILE_WIDTH - offset, 0);
            var tilePresenter = tile.GetComponent<ITilePresenter>();

            tilePresenter.Initialize(model, callback);
            _model.SetPosition(model.Position.X , model.Position.Y, tile);
        }
    
        private void OnMineTileUncover(int x, int y)
        {
            _model.Mines--;
            GameOver(_view.ShowLose);
        }
    
        private void OnBlankTileUncover(int x, int y)
        {
            _model.BlankTiles--;
            if (_model.BlankTiles == 0)
            {
                GameOver(_view.ShowWin);
            }
        }

        private void GameOver(Action resultAction)
        {
            resultAction.Invoke();
            BlockGrid();
        }

        private void BlockGrid()
        {
            IterateBoard((x,y) =>
            {
                _model.GetPosition(x,y).GetComponent<ITilePresenter>().Block();
            });
        }

        #region Utils
    
        private void IterateBoard(Action<int,int> action)
        {
            var size = _model.Size;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    action(x, y);
                }
            }
        }
    
        private IEnumerable<Point> GetAdjacentSquares(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0) && CheckBounds(x + i, y + j , _model.Size))
                        yield return new Point(x + i, y + j);
                }
            }
        }

        private bool CheckBounds(int x, int y , int bound)
        {
            return x >= 0 && x < bound && y >= 0 && y < bound;
        }

        #endregion
    
    }
}
