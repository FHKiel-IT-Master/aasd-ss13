﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem
{
    public class Context
    {

        public String description;
        public String name;
        public List<String> tags = new List<String>();

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
