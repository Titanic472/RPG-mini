using System;

[Serializable]
public class Data
{
    public int[] intPlayer = new int[230], intPlayerItems = new int[21], intSkillTree = new int[30], intGame = new int[1], intPlayerXP = new int[50];
    public bool boolPlayer, IsHardcore;
    public float[] floatPlayer = new float[16], floatMapPositions = new float[4];
    public bool[] ActiveSkills = new bool[9], boolSkillTree = new bool[122], boolSkillsChecked = new bool[153], boolGameObjects = new bool[708], boolGame = new bool[10];//529 - Empty
    public string[,] Checklist = new string[2,50];
    public string[] stringSkills = new string[176], stringMap = new string[2];
}