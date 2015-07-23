using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_2.Infostructure
{
    public class PagingInfo
    {   
        public PagingInfo()
        {
            IsDefault = true;
        }
        
        public PagingInfo(int pageSize, int pageCount, int currentPageIndex)
        {
            PageSize = pageSize;
            PageCount = pageCount;
            CurrentPageIndex = currentPageIndex;
        }
        
        public PagingInfo(PagingInfo info, int currentPageIndex)
        {
            PageSize = info.PageSize;
            PageCount = info.PageCount;
            CurrentPageIndex = currentPageIndex;
        }

        public PagingInfo(PagingInfo info)
        {
            PageSize = info.PageSize;
            PageCount = info.PageCount;
            CurrentPageIndex = info.CurrentPageIndex;
        }
        
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public bool IsDefault { get; set; }
    }
}