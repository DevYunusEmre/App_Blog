using App_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_Application.Concretes
{
    public class ServiceOperations : IServiceOperations
    {
        public List<SelectListItem> FillSelectListItem<T>(IEnumerable<T> list, Func<T, string> text, Func<T, string> Value)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (T item in list)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = text(item),
                    Value = Value(item)
                });
            }
            return selectListItems;
        }
    }
}
