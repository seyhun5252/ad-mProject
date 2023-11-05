using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMVCFormDataDal : IGenericDal<MVCFormData>
    {
        List<MVCFormData> GetFormDataInculede();
        List<MVCFormData> GetFormData(List<MVCFormData> values, int userId);

    }
}
