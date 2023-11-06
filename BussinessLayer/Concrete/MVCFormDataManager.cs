using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class MVCFormDataManager : IMVCFormDataService
    {
        IMVCFormDataDal _mVCFormDataDal;

        public MVCFormDataManager(IMVCFormDataDal mVCFormDataDal)
        {
            _mVCFormDataDal = mVCFormDataDal;

        }

        public List<MVCFormData> GetByFilter(Expression<Func<MVCFormData, bool>> filter)
        {
            return _mVCFormDataDal.GetListByFilter(filter);
        }

        public void TAdd(MVCFormData t)
        {
            _mVCFormDataDal.Insert(t);
        }

        public void TAddList(List<MVCFormData> formList)
        {
            foreach (var formData in formList)
            {
                _mVCFormDataDal.Insert(formData);
            }
        }

        public void TDelete(MVCFormData t)
        {
            _mVCFormDataDal.Delete(t);
        }

        public MVCFormData TGetByID(int id)
        {
            return _mVCFormDataDal.GetByID(id);
        }

        public List<MVCFormData> TGetList()
        {

            return _mVCFormDataDal.GetList();
        }

        public void TUpdate(MVCFormData t)
        {
            _mVCFormDataDal.Update(t);
        }
        public async Task<List<MVCFormData>> TGetListUserId(AppUser appUser)
        {

            List<MVCFormData> values =  _mVCFormDataDal.GetListByFilter(x => x.AppUserID == appUser.Id);


            if (values.Count > 0)
            {

                var getInculede = _mVCFormDataDal.GetFormDataInculede();
                return _mVCFormDataDal.GetFormData(getInculede, appUser.Id);
            }
            return new List<MVCFormData>();
        }
    }
}
