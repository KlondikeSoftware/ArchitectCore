

using com.ksgames.core.abstractions.enums;

namespace com.ksgames.core.abstractions.gameresources
{
    public interface IGameResourceData
    {
        public GameResourceEnum ResourceType { get; set;}
        public int Amount { get; set; }
    }
}