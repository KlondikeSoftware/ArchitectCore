using com.ksgames.core.abstractions.waves;
using com.ksgames.core.abstractions.waves.ViewModels;

namespace com.ksgames.core.architect.monsters
{
    public interface IMonsterFactory
    {
        public IWaveItemData CreateWaveItemData(IWaveInfo waveInfo);
        public IWaveItem CreateWaveItemEntityProxy(IWaveItemData setting);
        public IWaveItemService CreateWaveItemService(IWaveItem origin, ICommandProcessor cmd);
        public IWaveItemViewModel CreateWaveItemViewModel(IWaveItemService service);
    }
}