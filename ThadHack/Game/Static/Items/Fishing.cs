
using System.Collections.Generic;

namespace ZzukBot.Game.Static.Items
{
    public class FishingPole
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int LevelRequirement { get; set; }
        public int SkillRequirement { get; set; }
        public int SkillEnhancement { get; set; }

        public FishingPole(string name, int id, int skillEnh = 0, int levelReq = 0, int skillReq = 0)
        {
            Name = name;
            Id = id;
            SkillEnhancement = skillEnh;
            LevelRequirement = levelReq;
            SkillRequirement = skillReq;
        }        
    }

    public class Bait
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int SkillRequirement { get; set; }
        public int SkillEnhancement { get; set; }

        public Bait(string name, int id, int skillEnh = 0, int skillReq = 0)
        {
            Name = name;
            Id = id;
            SkillEnhancement = skillEnh;
            SkillRequirement = skillReq;
        }
    }

    public static class Fishing
    {
        public static List<FishingPole> FishingPoleList
        {
            // Name                                 id      +Skill  LvlReq  SkillReq
            //Arcanite Fishing Pole -               19970   [+35]           F300
            //Nat Pagle's Extreme Angler FC-5000 -  19022   [+25]           F100
            //Big Iron Fishing Pole -               6367    [+20]   Lvl25   F100
            //Darkwood Fishing Pole -               6366    [+15]   Lvl15   F50
            //Strong Fishing Pole -                 6365    [+5]    Lvl5    F10
            //Blump Family Fishing Pole -           12225   [+3]
            //Fishing Pole -                        6256    [+0]

            get
            {
                List<FishingPole> FPoles = new List<FishingPole>();
                FPoles.Add(new FishingPole("Arcanite Fishing Pole", 19970, 35, 0, 300));
                FPoles.Add(new FishingPole("Nat Pagle's Extreme Angler FC-5000", 19022, 25, 0, 100));
                FPoles.Add(new FishingPole("Big Iron Fishing Pole", 6367, 20, 25, 100));
                FPoles.Add(new FishingPole("Darkwood Fishing Pole", 6366, 15, 15, 50));
                FPoles.Add(new FishingPole("Strong Fishing Pole", 6365, 5, 5, 10));
                FPoles.Add(new FishingPole("Blump Family Fishing Pole", 12225, 3));
                FPoles.Add(new FishingPole("Fishing Pole", 6256));


                return FPoles;
            }
        }

        public static List<Bait> BaitList
        {
            get
            {
                List<Bait> FBait = new List<Bait>();
                FBait.Add(new Bait("Shiny Bauble", 6529, 25));
                FBait.Add(new Bait("Aquadynamic Fish Lens", 6811, 50));
                FBait.Add(new Bait("Nightcrawlers", 6530, 50, 50));
                FBait.Add(new Bait("Flesh Eating Worm", 7307, 75, 100));
                FBait.Add(new Bait("Bright Baubles", 6532, 75, 100));
                FBait.Add(new Bait("Aquadynamic Fish Attractor", 6533, 100, 100));


                return FBait;
            }
        }
    }
}
