using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public bool EditMode = false;


    #region CalculateSettings
    [Header("CalculateData")]
    public float BlockStep;
    public Vector2 StartPos;

    public float BlockSizeX;
    public float BlockSizeY;

    public float ShiftX;
    public float ShiftY;

    [Header("SettingsData")]
    public BoardConfig Config;

    #endregion

    private void Start()
    {
        CalculateSettings();
        CreateBoard();
    }

    private void CalculateSettings()
    {
        var vBackPos = Vector2.zero;
        var vBackSize = Config.WorldSize;

        var blockCollider = EntityManager.Instance.WallPref.Collider;
        var scale = EntityManager.Instance.WallPref.Collider.transform.localScale;

        var blockGap = Config.BlockGap;
        BlockSizeX = blockCollider.size.x * scale.x;
        BlockSizeY = blockCollider.size.y * scale.y;


        ShiftX = BlockSizeX + blockGap / 2;
        ShiftY = BlockSizeY + blockGap / 2;

        float blocksPackHeight = ShiftY * (Config.GridYCount - 1);
        float blocksPackWidth = ShiftX * (Config.GridXCount - 1);

        StartPos.x = vBackPos.x - vBackSize.x / 2 + (vBackSize.x - blocksPackWidth) / 2;
        StartPos.y = vBackPos.y - vBackSize.y / 2 + (vBackSize.y - blocksPackHeight) / 2;

    }

    public void CreateBoard() //Temporary
    {
        var xCount = Config.GridXCount;
        var yCount = Config.GridYCount;

        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                
                Vector2 pos = new Vector3(StartPos.x + ShiftX * x, StartPos.y + ShiftY * y);

                if (x == 0 && y == 11)
                {
                    var hero = EntityManager.Instance.GetHero(this.transform);
                    hero.Transform.position = pos;
                }
                else
                {
                    IBlock wall;
                    if (y % 10 == 0 && x % 10 == 0)
                    {
                        wall = EntityManager.Instance.GetDebris(this.transform);
                    }
                    else
                    {
                        var destroyable = y % 2 == 0 && x % 2 == 0;
                        if (!destroyable) continue;
                        wall = EntityManager.Instance.GetWall(destroyable, this.transform);
                    }

                    wall.Transform.position = pos;
                }


            }
        }
    }

}
