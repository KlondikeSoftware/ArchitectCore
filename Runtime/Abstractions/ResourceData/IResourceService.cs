namespace com.ksgames.core.abstractions.gameresources
{
    public interface IResourceService
    {
        void Init();
        void Add(IGameResourceData gameResourceData);
    }
}