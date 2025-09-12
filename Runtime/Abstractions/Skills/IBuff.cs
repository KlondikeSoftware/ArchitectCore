using com.ksgames.core.abstractions.enums;

namespace com.ksgames.core.abstractions.skills
{
    public interface IBuff
    {
        public DamageType DamageType { get; }
        public SkillActionEnum Action { get; }
        public float Damage { get; }
    }
}