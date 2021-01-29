using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Praktikmoede.Models;

namespace Praktikmoede.ViewModels
{
    public class MoedeDetails
    {
        public Moede moede { get; set; }
        public List<MoedeDeltager> moedeDeltagere { get; set; }
    }
}
