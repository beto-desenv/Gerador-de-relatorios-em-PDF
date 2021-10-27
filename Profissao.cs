using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeRelatoriosEmPDF
{
    [Serializable] // Indica que a classe é serealizavel, ou seja, os objeto instanciados a partir desta classe, poderam ser serealizados para um arquivo Json ou XML, 
                   //ou Deseralizados a partir de um arquivo que contenha dados em Json ou XML e que sejam compativeis com essa classe.
    class Profissao
    {
        public int IdProfissao { get; set; }
        public string Nome { get; set; }
    }
}
