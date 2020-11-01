using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenfoBank_client
{
    public class AddressManager  
    {
        private AddressCrudFactory crudAddress;

        public AddressManager()
        {
            crudAddress = new AddressCrudFactory();
        }

        public void Create(Address address)
        {
            crudAddress.Create(address);

        }

        public List<Address> RetrieveAll()
        {
            return crudAddress.RetrieveAll<Address>();
        }

        public int RetrieveId(Address address)
        {
            return crudAddress.RetrieveObjId(address);
        }

        public void Update(Address address)
        {
            crudAddress.Update(address);
        }

        public void Delete(Address address)
        {
            crudAddress.Delete(address);
        }
    }
}
