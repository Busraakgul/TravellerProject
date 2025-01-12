using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

//namespace TravellerProject.ViewComponents.Default
//{
//    public class _Feature : ViewComponent
//    {
//        FeatureManager featureManager = new FeatureManager(new EFFeatureDal());

//        public IViewComponentResult Invoke()
//        {
//            return View();
//            //var values = featureManager.TGetList().Where(x => x.Status == true).ToList(); // Durumu aktif olan kayıtlar
//            //return View(values);
//        }
//    }
//}


namespace TravellerProject.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        private readonly FeatureManager featureManager;

        public _Feature()
        {
            featureManager = new FeatureManager(new EFFeatureDal());
        }

        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList().Where(x => x.Status == true).ToList(); // Fetch active features
            return View(values); // Pass the feature list to the view
        }

    }
}

