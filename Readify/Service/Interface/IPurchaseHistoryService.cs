﻿using Readify.DTOs.PurchaseHistory;

namespace Readify.Service.Interface
{
    public interface IPurchaseHistoryService
    {
        void AddPurchaseHistory(InsertPurchaseHistoryDto purchaseHistoryDto);

        List<GetAllPurchaseHistory> GetAllPurchaseHistories();

        GetAllPurchaseHistory GetById(Guid id);

        void DeletePurchaseHistory(Guid id);

        void UpdatePurchaseHistory(Guid id, UpdatePurchaseHistoryDto purchaseHistoryDto);

        List<Readify.DTOs.PurchaseHistory.GetAllPurchaseHistory> Filter(PurchaseHistoryFilterDto filter);
    }
}
