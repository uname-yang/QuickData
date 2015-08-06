using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLST.Data;
using SQLST;
using FastDB.Cache.Repoistory;
using FastDB.Service;
using FastDB.AOF;
using FastDB.Pattern;
using FastDB.Pattern.Implementation;
using FastDB.Cache;
using System.Diagnostics;
using QuickData.Controllers;
using System.Collections.Generic;

namespace QuickData.Tests.Controllers
{
    [TestClass]
    public class Hashtest
    {
        public static IDatabaseFactory db = new DatabaseFactory();
        public static IUnitOfWork unit = new UnitOfWork(db);

        public static IKeyValueSR kv = new KeyValueSR(db);
        public static IAOF aof = new AOFAdapter(unit, kv);

        public static ISingleCache sc = new SingleCache();
        public static IListCache lc = new ListCache();
        public static IHashCache hc = new HashCache();
        public static ITreeCache tc = new TreeCache();
        public static IMemory mem = new Memory(sc, lc, hc, tc);

        public static IHashEntity he = new HashEntity(aof, mem);
        public static IListEntity le = new ListEntity(aof, mem);
        public static ISingleEntity se = new SingleEntity(aof, mem);
        public static ITreeEntity te = new TreeEntity(aof, mem);
        public static IFastDB fastdb = new FastDBService(he, le, se, te);
        [TestMethod]
        public void post()
        {
            HashController sct = new HashController(fastdb);
            var dt = new Dictionary<string, object>();
            dt.Add("key1",new testmodel { i = 1, s = "yuyang" });
            dt.Add("key2", new testmodel { i = 1, s = "yuyang" });
            sct.Post("key", dt);
        }
        [TestMethod]
        public void get()
        {

        }
    }
}
