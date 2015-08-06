using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLST.Data;
using SQLST;
using FastDB.Service;
using FastDB.Cache.Repoistory;
using FastDB.AOF;
using FastDB.Cache;
using FastDB.Pattern;
using FastDB.Pattern.Implementation;
using System.Diagnostics;
using QuickData.Controllers;
using System.Collections.Generic;

namespace QuickData.Tests.Controllers
{
    [TestClass]
    public class Listtest
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
        public void get()
        {

        }
        [TestMethod]
        public void post()
        {
            ListController sct = new ListController(fastdb);
            var d = new List<object> { new testmodel { i = 1, s = "s" }, new testmodel { i = 2, s = "ss" } };
            sct.Post("key",d );
        }
    }
}
