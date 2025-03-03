using OptMobile.Retailer.Models;

namespace OptMobile.Retailer.Services;

public class BrandService
{
    public static List<BrandMaster> AllItems => new List<BrandMaster>
    {
        new BrandMaster
        {
            BrandName = "Cipla",
            Price = 34078,
            DefaultImage = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
            Images = new List<string>
            {
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg"
            }
        },
        new BrandMaster
        {
            BrandName = "Mankind",
            Price = 34078,
            DefaultImage = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
            Images = new List<string>
            {
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg"
            }
        },
        new BrandMaster
        {
            BrandName = "Leeford",
            Price = 34078,
            DefaultImage = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
            Images = new List<string>
            {
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg"
            }
        },
        new BrandMaster
        {
            BrandName = "Macleods",
            Price = 34078,
            DefaultImage = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
            Images = new List<string>
            {
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/05/24/11/00/interior-4226020_640.jpg",
                "https://cdn.pixabay.com/photo/2019/10/17/02/39/villa-4555815_640.jpg",
            }
        },
    };
}
