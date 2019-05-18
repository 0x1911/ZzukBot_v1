using System;
using System.Collections.Generic;
using System.Linq;
using ZzukBot.Engines.Grind;
using ZzukBot.Helpers;
using ZzukBot.Mem;

namespace ZzukBot.API
{
    public static class BParty
    {
        public static List<Objects.WoWUnit> GetMembers()
        {
            List<Objects.WoWUnit> tmpMemberList = new List<Objects.WoWUnit>();

            //member 1
            var tmpMember1 = Party1;
            if (tmpMember1 != null) { tmpMemberList.Add(tmpMember1); }
            //member 2
            var tmpMember2 = Party2;
            if (tmpMember2 != null) { tmpMemberList.Add(tmpMember2); }
            //member 3
            var tmpMember3 = Party3;
            if (tmpMember3 != null) { tmpMemberList.Add(tmpMember3); }
            //member 4
            var tmpMember4 = Party4;
            if (tmpMember4 != null) { tmpMemberList.Add(tmpMember4); }
            

            return tmpMemberList;
        }

        public static bool IsMobTargetingPartyMember(ulong targetGuid)
        {
            if (!IsInParty || IsPartyLeader()) { return false; }

            foreach (Objects.WoWUnit tmpMember in API.BParty.GetMembers())
            {
                if (tmpMember.Guid == targetGuid)
                {
                    return true;
                }
            }


            return false;
        }
                
        public static bool IsPartyLeader()
        {
            if (PartyLeader != null) { return PartyLeader.Guid == ObjectManager.Player.Guid; }


            return false;
        }

        public static bool NeedToWaitForGroup()
        {
            if(!BParty.IsPartyLeader()) { return false; }

            foreach(var tmpMember in GetMembers())
            {
                if(tmpMember.Channeling != 0|| tmpMember.Casting != 0|| tmpMember.GotAura("Drink") || tmpMember.GotAura("Food"))
                {
                    return true;
                }
            }

            return false;
        }

       
        public static void MoveNearLeader()
        {
            if(!IsInParty || IsPartyLeader()) { return; }


            Random rand = new Random();
            float distanceToLeader = Calc.Distance3D(PartyLeader.Position, ObjectManager.Player.Position);
            if (distanceToLeader > rand.Next(5, 25))
            {
                var tuu = Grinder.Access.Info.PathToPosition.ToPos(new XYZ(PartyLeader.Position.X + rand.Next(1,5), PartyLeader.Position.Y + rand.Next(1,5), PartyLeader.Position.Z));
                ObjectManager.Player.CtmTo(tuu);
            }
        }

        public static bool IsLeaderNextToVendor()
        {
            if (!IsInParty || IsPartyLeader()) { return false; }


            Random rand = new Random();
            float LeaderDistanceToVendor = Calc.Distance3D(PartyLeader.Position, Grinder.Access.Profile.RepairNPC.Coordinates);
            if (LeaderDistanceToVendor <= 10)
            {
                return true;
            }


            return false;
        }

        public static bool IsInParty => isInParty();
        private static bool isInParty()
        {
            if (GetMembers().Count > 0) { return true; }


            return false;
        }
        /// <summary>
        ///     Access to the party leaders object
        /// </summary>
        private static Objects.WoWUnit PartyLeader
        {
            get
            {
                var guid = ((int)Constants.Offsets.Party.leaderGuid).ReadAs<ulong>();

                if (guid == 0) return null;
                object Locker = new object();
                lock (Locker)
                {
                    return (Objects.WoWUnit)ObjectManager.Players.FirstOrDefault(i => i.Guid == guid);
                }
            }
        }
        /// <summary>
        ///     Access to the object of party member 1
        /// </summary>
        private static Objects.WoWUnit Party1
        {
            get
            {
                var guid = ((int)Constants.Offsets.Party.party1Guid).ReadAs<ulong>();
                return GetPartyMember(guid);
            }
        }
        /// <summary>
        ///     Access to the object of party member 2
        /// </summary>
        private static Objects.WoWUnit Party2
        {
            get
            {
                var guid = ((int)Constants.Offsets.Party.party2Guid).ReadAs<ulong>();
                return GetPartyMember(guid);
            }
        }
        /// <summary>
        ///     Access to the object of party member 3
        /// </summary>
        private static Objects.WoWUnit Party3
        {
            get
            {
                var guid = ((int)Constants.Offsets.Party.party3Guid).ReadAs<ulong>();
                return GetPartyMember(guid);
            }
        }
        /// <summary>
        ///     Access to the object of party member 4
        /// </summary>
        private static Objects.WoWUnit Party4
        {
            get
            {
                var guid = ((int)Constants.Offsets.Party.party4Guid).ReadAs<ulong>();
                return GetPartyMember(guid);
            }
        }
        /// <summary>
        /// Get a Objects.WoWUnit for a given GUiD
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        private static Objects.WoWUnit GetPartyMember(ulong guid)
        {
            if (guid == 0) return null;

            object Locker = new object();
            lock (Locker)
            {
                return (Objects.WoWUnit)ObjectManager.Players.FirstOrDefault(i => i.Guid == guid);
            }
        }
    }
}
