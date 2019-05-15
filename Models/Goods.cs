using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Goods
    {
        public Goods(string articul, string name, string type, string material, string characteristics)
        {
            Articul = articul;
            Name = name;
            Type = type;
            Material = material;
            Characteristics = characteristics;
        }

        public string Articul { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public string Characteristics { get; set; }
    }
}
