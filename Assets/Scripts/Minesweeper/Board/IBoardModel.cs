using UnityEngine;

public interface IBoardModel
{
    void Setup(int size, int mines);

    void Reset();

    GameObject GetPosition(int x, int y);

    void SetPosition(int x, int y, GameObject tile);

    int Mines { get; set; }
    
    int Size { get; }

    int BlankTiles { get; set; }
}
