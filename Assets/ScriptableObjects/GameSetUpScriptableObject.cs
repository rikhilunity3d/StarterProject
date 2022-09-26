using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSetUpScriptableObject", menuName = "GameSetUpScriptableObject", order = 0)]
public class GameSetUpScriptableObject : MonoBehaviour
{
    [SerializeField]
    LevelSetUpScriptableObject []levelSetUpSO;

    public LevelSetUpScriptableObject[] LevelSetUpSO { get => levelSetUpSO;}
}

