using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dal
{
    public interface Intermediacao<NomeClasse>
    {
        void create(NomeClasse obj);
        void delete(NomeClasse obj);
        void update(NomeClasse obj);
        bool find(NomeClasse obj);
        List<NomeClasse> findAll();
        List<NomeClasse> findAllId(int id);
    }
}
