
using BackLogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackLogApp.Interfaces
{
    public interface IBackLogService
    {

        BackLogViewModel NewBackLog(BackLogViewModel item);
        BackLogViewModel GetBackLogById(int id);
        ListOfBackLogViewModel GetBackLogList(string query = "");
        bool DeleteBackLog(int id);
    }
}