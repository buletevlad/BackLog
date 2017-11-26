using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackLogApp.ViewModels
{
    public class ListOfBackLogViewModel
    {
        public ListOfBackLogViewModel() { }
        public ListOfBackLogViewModel(List<BackLogViewModel> items)
        {
            BackLogList = items.Select(x=> new BackLogViewModel()
            {
                Id = x.Id,
                Label = x.Label,
                Status = x.Status,
                CreatedDate = x.CreatedDate
            }).ToList();
        }
        public List<BackLogViewModel> BackLogList { get; set; }
    }
}