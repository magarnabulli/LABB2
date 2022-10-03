using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABB2_Neliz
{
    //implementerar Interface
    public abstract class KitchenAppliance : IKitchenAppliance
    {
        public string Type { get; set; } //typen av grejser
        public string Brand { get; set; } //märke
        public bool IsFunctioning { get; set; } //funkar den tho
        public KitchenAppliance()
        {
            this.Type = Type;
            this.Brand = Brand;
            this.IsFunctioning = IsFunctioning;
        }
        public abstract void Use();
    }
}
