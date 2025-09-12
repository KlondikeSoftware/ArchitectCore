
using com.ksgames.core.abstractions.enums;
using UnityEngine;

namespace com.ksgames.core.abstractions.waves
{
    public interface IWaveItemPositionData
    {
        public PositionInWaveEnum PositionInWave { get; }
        public Vector3 Coordinates { get; }
        void Set(Vector3 positionDataCoordinates);
    }
}