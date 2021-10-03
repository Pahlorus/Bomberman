
using UnityEngine;
[CreateAssetMenu(fileName = nameof(BoardConfig), menuName = "ScriptableObjects/" + nameof(BoardConfig))]
public class BoardConfig : ScriptableObject
{
    public int GridXCount;
    public int  GridYCount;
    public float BlockGap;
    public Vector2 WorldSize;
}
