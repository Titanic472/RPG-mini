using System;

[Serializable]
public class Data
{
    public int[] intPlayer = new int[230], intPlayerItems = new int[21], intSkillTree = new int[170], intGame = new int[1], intPlayerXP = new int[50], intActiveSkills = new int[4];
    public bool boolPlayer, IsHardcore;
    public float[] floatPlayer = new float[16], floatMapPositions = new float[4], floatGameObjects = new float[188], floatSkillTree = new float[9];
    public bool[] ActiveSkills = new bool[9], boolSkillTree = new bool[27], boolGame = new bool[10], boolGameObjects = new bool[188];
    public string[,] Checklist = new string[2,50];
    public string[] stringMap = new string[2];
}