using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config")]
public class Config : ScriptableObject
{
    public int col;
    public int lin;
    public int[,] mapa;
}