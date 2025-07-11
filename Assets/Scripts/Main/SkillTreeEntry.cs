[System.Serializable]
    public struct SkillTreeEntry
    {
        public string name;
        public int level;
        public bool buttonState;

    public SkillTreeEntry(string name, int level, bool buttonState)
    {
        this.name = name;
        this.level = level;
        this.buttonState = buttonState;
    }
    }