using ProniaMvc.Models;

namespace ProniaMvc.ViewModels.HomeVMs;

public class HomeVm
{
    public ICollection<Slider> Sliders { get; set; }
    public ICollection<Product> Products { get; set; }
}
