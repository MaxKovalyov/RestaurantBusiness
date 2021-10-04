using System;

namespace RestaurantBusiness.App.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }

        public int TotalPages { get; private set; }

        public PageViewModel(int countItems, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(countItems / (double)pageSize);
        }
    }
}
