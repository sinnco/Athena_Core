using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace ViData.Dict
{
    public class DMPropertyPart
    {
        internal string TypeName { get; set; }
        internal string ColumnName { get; set; }
        PCDictionary _pcDict;
        PCDictionary PcDict
        {
            get
            {
                if (_pcDict == null)
                {
                    _pcDict = DMClassMap.PFCDictionary[TypeName];
                }
                return _pcDict;
            }
        }

        public DMPropertyPart Identity()
        {
            PcDict.IdIdentity = true;
            return this;
        }

        public DMPropertyPart Identity(string seqName)
        {
            PcDict.IdIdentity = true;
            PcDict.SeqName = seqName;
            return this;
        }


    }
}
