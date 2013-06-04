using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem
{
    public class Result
    {
    
        public Guid id;
        public int relevance;
        public String title;
        public String description;
        public String displayURL;
        public String url;

        public Result()
        {

        }


        public void AddRelevance()
        {

            relevance++;
        }

        public int GetRelevance()
        {
            return relevance;
        }

    }
}
