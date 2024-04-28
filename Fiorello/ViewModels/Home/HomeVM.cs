using Fiorello.Models;

namespace Fiorello.ViewModels.Home
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderInfo SliderInfos { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Surprize> Surprizes { get; set; }
        public List<SurprizeList> SurprizeLists { get; set; }
        public List<Expert> Experts { get; set; }


    }
}
