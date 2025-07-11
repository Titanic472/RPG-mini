using System;
using System.Collections.Generic;

[Serializable]
public class Data
{
    public int[] intPlayer = new int[230], intPlayerItems = new int[21], intGame = new int[1], intPlayerXP = new int[50], intActiveSkills = new int[4], intSkillTree = new int[4];
    public bool boolPlayer, IsHardcore;
    public float[] floatPlayer = new float[16], floatMapPositions = new float[4];
    public bool[] ActiveSkills = new bool[9], boolGame = new bool[10];
    public string[,] Checklist = new string[2, 50];
    public string[] stringMap = new string[2];
    public List<SkillTreeEntry> skillTree = new List<SkillTreeEntry>();

    //[UnityEngine.SerializeField]
}