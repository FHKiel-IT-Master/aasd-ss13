using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem
{
    class Context
    {

        String description;
        String name;
        List<String> tags = new List<String>();
        List<Operands> operands = new List<Operands>();

        public Context()
        {



        }

        public void AddTag(String tag)
        {
            tags.Add(tag);

        }

        public void removeTag(String tag)
        {
            tags.Remove(tag);

        }
    }
}
