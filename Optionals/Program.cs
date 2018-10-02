using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Optionals
{
    class Program
    {
        static void Main(string[] args)
        {
            Optional<int> emptyOpt = Optionals.Empty<int>();
            int result = emptyOpt.IfPresent(
                    x => {
                        return x + 1;  
                    }
                );
            assert(result == default(int));

            Optional<int> fullOpt = Optional<int>.Of(32);
            result = fullOpt.IfPresent(x => { return x + 1; });
            assert(result == 33);
            
        }

        static void assert(bool boolean, String msg = "")
        {
            if (msg == "")
                Debug.Assert(boolean);
            else
                Debug.Assert(boolean, msg);
        }
    }
}
