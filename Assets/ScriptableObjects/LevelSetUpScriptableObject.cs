using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetUpScriptableObject", menuName = "MakeLevelSetUpScriptableObject", order = 0)]
public class LevelSetUpScriptableObject : ScriptableObject
{
    [SerializeField]
    string levelName;
    [SerializeField]
    Sprite levelBg;

    [SerializeField]
    LevelStatus isLevelLock= LevelStatus.LOCK;

    [Header("To set button size dyamically according to screensize you have to " +
        "specify the number to divide screen size in buttonclick.cs script")]
    [SerializeField]
    float widthDivide;
    [SerializeField]
    float heightDivide;

    [SerializeField]
    ChangeableScriptableObjects[] changeableSO;

    //Getters are here of above variables
    #region
    public string LevelName
    { get => levelName; }
    public Sprite LevelBg
    { get => levelBg; }
    public float WidthDivide
    { get => widthDivide; }
    public float HeighDivide
    { get => heightDivide; }
    public ChangeableScriptableObjects[] ChangeableSO { get => changeableSO; }

    #endregion
}





