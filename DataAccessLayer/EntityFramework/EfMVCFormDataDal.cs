using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMVCFormDataDal : GenericRepository<MVCFormData>, IMVCFormDataDal
    {
        public List<MVCFormData> GetFormDataInculede()
        {
            using var dbContext = new Context();

            // Veritabanından MVCFormData nesnelerini alırken FormElements ilişkisini de dahil eder.
            var combinedData = dbContext.MVCFormDatas
                            .Include(m => m.FormElements)
                            .ToList();

            return combinedData;

        }

        public List<MVCFormData> GetFormData(List<MVCFormData> values, int userId)
        {

            using var dbContext = new Context();
            // Verilen 'values' listesini 'userId' değerine göre filtreler.
            List<MVCFormData> formDataGroupedByAppUser = values.Where(formData => formData.AppUserID == userId)
                                                    .ToList();


            return formDataGroupedByAppUser;
        }
    }
}
