using System.Collections.Generic;
using com.ksgames.core.abstractions.skills;

namespace com.ksgames.core.abstractions.battle
{
    public class UnitDamageObject: IDamageObject
    {
        public float Damage;
        public bool IsCritical;
        public List<IBuff> Buffs = new List<IBuff>();

        public UnitDamageObject(float damage, bool isCritical, List<IBuff> buffList)
        {
            Damage = damage;
            IsCritical = isCritical;
            Buffs = buffList;
        }
    }
}