using ZzukBot.Constants;

namespace ZzukBot.Game.Static.Classes
{
    /// <summary>
    /// Represents a skill
    /// </summary>
    public class Skill
    {
        internal Skill() { }
        internal Enums.Skills Id { get; set; }
        public int CurrentLevel { get; set; }
        public int MaxLevel { get; set; }
    }
}
