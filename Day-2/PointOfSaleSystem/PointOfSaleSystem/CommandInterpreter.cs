using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleSystem
{
    public class CommandInterpreter
    {
        ISaleEventListener _saleEventListener;

        public CommandInterpreter(ISaleEventListener saleEventListener)
        {
            _saleEventListener = saleEventListener;
        }

        public void Parse(string command)
        {
            var id = _saleEventListener.GetId();
            _saleEventListener.BeginSale(id + 1);
        }
    }
}
