using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class Artist
    {
        public string Name { get; set; }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
