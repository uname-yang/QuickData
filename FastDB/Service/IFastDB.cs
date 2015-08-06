using FastDB.Cache;
using FastDB.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDB.Service
{
    public interface IFastDB
    {
        ISingleEntity SingleEntity { get; set; }
        IHashEntity HashEntity { get; set; }
        IListEntity ListEntity { get; set; }
        ITreeEntity TreeEntity { get; set; }
    }
}
