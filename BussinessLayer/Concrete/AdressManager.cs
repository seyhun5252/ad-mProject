using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AdressManager : IAdressService
    {
        IAdressDal _adressDal;

        public AdressManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public List<Adress> GetByFilter(Expression<Func<Adress, bool>> filter)
        {
            return _adressDal.GetListByFilter(filter);
        }

        public void TAdd(Adress t)
        {
            _adressDal.Insert(t);
        }

        public void TDelete(Adress t)
        {
            _adressDal.Delete(t);
        }

        public Adress TGetByID(int id)
        {
            return _adressDal.GetByID(id);
        }

        public List<Adress> TGetList()
        {
            return _adressDal.GetList();

        }

        public void TUpdate(Adress t)
        {
            _adressDal.Update(t);
        }
    }
}
