using System.Collections.Generic;

namespace Services
{
    public interface ICustomerStore
    {
        List<string> GetAll();
    }

}
