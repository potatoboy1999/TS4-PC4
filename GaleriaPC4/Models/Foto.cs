using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaleriaPC4.Models
{
    public class Foto
    {
        public int id { get; set; }
        public string foto { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int categoriaId { get; set; }
    }
}