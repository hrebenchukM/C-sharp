using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interface
{

    interface IPart
    {
         string Name
         {
            get;
            set;
         }

        bool Ready 
        { 
            get; 
            set; 
        }
    }

    interface IWorker
    {
        void Build(IPart part);
        string Name
        {
            get;
            set;
        }

    }


}
