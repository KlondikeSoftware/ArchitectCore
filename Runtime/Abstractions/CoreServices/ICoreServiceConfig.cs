using UnityEngine;

namespace com.ksgames.core.abstractions.coreservices
{
    public interface ICoreServiceConfig
    {
        [Header("Common settings")] 
        public int TimeOutSeconds { get; }
    }
}