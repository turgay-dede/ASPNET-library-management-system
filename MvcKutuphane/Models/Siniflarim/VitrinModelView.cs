using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Models.Siniflarim
{
    public class VitrinModelView
    {
        public IEnumerable<TBLKİTAP> Kitap { get; set; }
        public IEnumerable<TBLHAKKIMIZDA> Hakkimizda { get; set; }

    }
}