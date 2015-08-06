using FastDB.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastDB.Pattern;

namespace FastDB.Service
{
    public class FastDBService : IFastDB
    {
        public IHashEntity HashEntity
        { get; set; }

        public IListEntity ListEntity
        { get; set; }

        public ISingleEntity SingleEntity
        { get; set; }

        public ITreeEntity TreeEntity
        { get; set; }

        public FastDBService(IHashEntity _HashEntity, IListEntity _ListEntity, ISingleEntity _SingleEntity,  ITreeEntity _TreeEntity)
        {
            HashEntity = _HashEntity;
            ListEntity = _ListEntity;
            SingleEntity = _SingleEntity;
            TreeEntity = _TreeEntity;
        }
    }
}
