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
    public class FormElementManager : IFormElementService
    {
        IFormElementDal _formElementDal;

        public FormElementManager(IFormElementDal formElementDal)
        {
            _formElementDal = formElementDal;
        }

        public List<FormElement> GetByFilter(Expression<Func<FormElement, bool>> filter)
        {
            return _formElementDal.GetListByFilter(filter);
        }

        public void TAdd(FormElement t)
        {
            _formElementDal.Insert(t);
        }

        public void TDelete(FormElement t)
        {
            throw new NotImplementedException();
        }

        public FormElement TGetByID(int id)
        {
            return _formElementDal.GetByID(id);
        }

        public List<FormElement> TGetList()
        {
            return _formElementDal.GetList();
        }

        public void TUpdate(FormElement t)
        {
            _formElementDal.Update(t);
        }
    }
}
