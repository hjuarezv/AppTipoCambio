using System;
using System.Collections.Generic;
using System.Text;

namespace AppTipoCambio.Model
{
    public class TipoCambio
    {
        public double compra { get; set; }
        public double venta { get; set; }
        public string origen { get; set; }
        public string moneda { get; set; }
        public DateTime fecha { get; set; }
    }
}
