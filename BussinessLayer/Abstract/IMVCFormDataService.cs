using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IMVCFormDataService : IGenericService<MVCFormData>
    {
        void TAddList(List<MVCFormData> formList);
        Task<List<MVCFormData>> TGetListUserId(AppUser appUser);

    }
}
