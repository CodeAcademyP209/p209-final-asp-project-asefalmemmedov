using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models.HomeVM
{
    public class HomeVM
    {
        public IEnumerable<HomeDTO> GetHomes { get; set; }
        public IEnumerable<ServicesDTO> GetServices { get; set; }
        public IEnumerable<CategoryDTO> GetCategories { get; set; }
        public IEnumerable<BannerDTO> GetBanners { get; set; }
    }
}