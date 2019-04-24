using System;
using System.Collections.Generic;
using ZzukBot.FSM;
using ZzukBot.Helpers;
using ZzukBot.Mem;
using ZzukBot.Constants;

namespace ZzukBot.Game.Static
{
    /// <summary>
    ///     Class related to Skills (Engineering etc.)
    /// </summary>
    public class Skills
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

        private static readonly Lazy<Skills> _instance = new Lazy<Skills>(() => new Skills());
        public Skills()
        {
        }

        /// <summary>
        /// Returns all skills the player has learned
        /// </summary>
        /// <returns></returns>
        public List<Skill> GetAllPlayerSkills()
        {
            if (!ObjectManager.IsIngame) return new List<Skill>();
            var start = ObjectManager.Player.SkillField;
            var list = new List<Skill>();
            var maxSkills = 0x00B700B4.ReadAs<int>();
            for (var i = 0; i < maxSkills + 5; i++)
            {
                var curPointer = start.Add(i * 12);
                var id = curPointer.ReadAs<Enums.Skills>();
                if (!Enum.IsDefined(typeof(Enums.Skills), id))
                {
                    continue;
                }
                var minMax = curPointer.Add(4).ReadAs<int>();

                list.Add(new Skill
                {
                    Id = id,
                    CurrentLevel = minMax & 0xFFFF,
                    MaxLevel = minMax >> 16
                });
            }
            return list;
        }

        /// <summary>
        ///     Access to the current instance
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static Skills Instance => _instance.Value;
    }
}