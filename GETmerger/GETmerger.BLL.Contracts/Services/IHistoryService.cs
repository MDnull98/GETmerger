using System.Collections.Generic;

namespace GETmerger.BLL.Contracts.Services
{
    public interface IHistoryService
    {
        IEnumerable<MarketDTO> GetMarkets();
        MarketDTO Getmarket(int? id);
        void DeleteMarket(int id);
        void Update(MarketDTO marketDTO);
        void CreateMarket(MarketDTO marketDTO);
    }
}
