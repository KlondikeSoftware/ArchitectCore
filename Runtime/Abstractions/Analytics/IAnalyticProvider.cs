using System.Collections.Generic;
using com.ksgames.core.abstractions.coreservices;

namespace com.ksgames.core.abstractions.analytics
{
    public interface IAnalyticProvider:ICoreServiceProvider
    {
        public void SendCustomEvent(string eventName, Dictionary<string, string> parameters);
        public void LevelUp(int level);
        public void VirtualCurrencyPayment(int coins, string source);
        public void Tutorial(int i);
        public void RealCurrencyPayment(string transactionID, decimal price, string definitionID, string currencyCode);
        public void Balance(int coins);
        public void Purchase(string code, string orderId, decimal price, string currency);
        public void DeleteUserData(string userID);
    }
}