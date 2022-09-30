using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T> //metot imzalarını attık
    {
        List<T> List();//imzayı attık
        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter); //dışardan bir şart alıcaksın 
        void Delete(T p);
        void Update(T p);
        List<T> List(Expression <Func<T, bool>> filter); //şartlı liste yazar adı ali olanları getir vs..
   
    }
}
