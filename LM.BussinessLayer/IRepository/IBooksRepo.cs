using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.BussinessLayer.Model
{
    public interface IBooksRepo
    {
        public int Create(Books book);
        public int Update(Books book);
        public void Delete(int id);
        public List<Books> List();
    }
}
