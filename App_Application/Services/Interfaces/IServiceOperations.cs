using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.AspNetCore;

namespace App_Application.Services.Interfaces
{
    public interface IServiceOperations
    {
        List<SelectListItem> FillSelectListItem<T>(IEnumerable<T> list, Func<T, string> text, Func<T, string> Value);
    }
}
