using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyTimeSeries
{
    class fts
    {
        MembershipSegi3 dingin, sedang, panas;


        public fts(MembershipSegi3 a, MembershipSegi3 b, MembershipSegi3 c)
        {
            dingin = a;
            sedang = b;
            panas = c;
        }
    }
}
