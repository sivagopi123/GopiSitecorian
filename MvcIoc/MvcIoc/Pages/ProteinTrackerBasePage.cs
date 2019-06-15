using System;
using System.Web.Mvc;
using Unity.Attributes;

namespace MvcIoc.Pages
{
    public class ProteinTrackerBasePage : WebViewPage
    {
        [Dependency]
        public IAnalyticService analyticService { get; set; }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}