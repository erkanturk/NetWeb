using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _15_Filter_Operation.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action Executed");//işlem sonrası
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("İşlem Sırası");//işlem sırası
        }
    }
}
