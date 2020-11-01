using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Address : BaseEntity
    {
        public int AddressId { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public Address()
        {

        }

        public Address(string[] addressInfo)
        {
            if (addressInfo != null && addressInfo.Length >= 3)
            {
                Provincia = addressInfo[0];
                Canton = addressInfo[1];
                Distrito = addressInfo[2];
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }
        }

        public override string ToString()
        {
            return "Provinvia:" + Provincia + " Canton: " + Canton + " Distrito: " + Distrito;
        }
    }
}
