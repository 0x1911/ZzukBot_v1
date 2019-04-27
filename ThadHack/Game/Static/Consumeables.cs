using System.Collections.Generic;

namespace ZzukBot.Game.Static
{
    public static class Consumeables
    {
        public static Dictionary<int, int> DrinksDictionary = new Dictionary<int, int>()
        {
            { 159, 0 },     //Refreshing Spring Water
            { 5350, 0 },    //Conjured Water
            { 1179, 5 },    //Ice Cold Milk
            { 2288, 5 },    //Conjured Fresh Water
            { 1205 ,15 },   //Melon Juice
            { 2136, 15 },   //Conjured Purified Water
            { 1708, 25 },   //Sweet Nectar
            { 3772, 25 },   //Conjured Spring Water
            { 1645, 35 },   //Moonberry Juice
            { 8077, 35 },   //Conjured Mineral Water
            { 8766, 45 },   //Morning Glory Dew
            { 8078, 45 },   //Conjured Sparkling Water
            { 8079, 55 }    //Conjured Crystal Water
        };

        public static Dictionary<int, int> FoodsDictionary = new Dictionary<int, int>()
        {
            { 2681, 0 },    //Roasted Boar Meat
            { 2679, 0 },    //Charred Wolf Meat
            { 5349, 0 },    //Conjured Muffin
            { 4536, 0 },    //Shiny Red Apple
            { 2070, 0 },    //Darnassian Bleu
            { 787, 0 },      //Slitherskin Mackerel
            { 4540, 0 },    //Tough Hunk of Bread
            { 117, 0 },     //Tough Jerky
            { 4604, 0 },    //Forest Mushroom Cap
            { 4605, 5 },    //Red-speckled Mushroom
            { 4541, 5 },    //Freshly Baked Bread
            { 2287, 5 },    //Haunch of Meat
            { 4592, 5 },    //Longjaw Mud Snapper
            { 1113, 5 },    //Conjured Breed
            { 4537, 5 },    //Tel'Abim Banana
            { 414, 5 },     //Dalaran Sharp
            { 4538, 15 },   //Snapvine Watermelon
            { 4593, 15 },   //Bristle Whisker Catfish
            { 422, 15 },    //Dwarven Mild
            { 4542, 15 },   //Moist Cornbread
            { 3770, 15 },   //Mutton Chop
            { 1707, 25 },   //Stormwind Brie
            { 4539, 25 },   //Goldenbark Apple
            { 4544, 25 },   //Mulgore Spice Bread
            { 4594, 25 },   //Rockscale Cod
            { 3771, 25 },   //Wild Hog Shank
            { 4599, 35 },   //Cured Ham Steak
            { 3927, 35 },   //Fine Aged Cheddar
            { 4607, 35 },   //Delicious Cave Mold
            { 4602, 35 },   //Moon Harvest Pumpkin
            { 4601, 35 },   //Soft Banana Bread
            { 21552, 35 },  //Striped Yellowtail
            { 8953, 45 },   //Deep Fried Plantains          
            { 8932, 45 },   //Alterac Swiss
            { 8952, 45 },   //Roasted Quail
            { 8950, 45 },   //Homemade Cherry Pie
            { 22895, 55 },  //Conjured Cinnamon Roll
            { 8948 , 55 }   //Dried King Bolete  
        };
    }
}
