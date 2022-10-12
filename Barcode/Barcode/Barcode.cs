using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode
{
    public class Barcode
    {
        private static int id = 0;
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public static int nextId() 
        { 
            return id++;
        }
    }
}
