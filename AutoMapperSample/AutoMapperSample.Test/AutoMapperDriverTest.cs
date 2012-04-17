using System;
using AutoMapperSample.Logic;
using AutoMapperSample.Model;
using AutoMapperSample.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperSample.Test
{
    /// <summary>
    ///AutoMapperDriverTest のテスト クラスです。すべての
    ///AutoMapperDriverTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class AutoMapperDriverTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性

        //
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion 追加のテスト属性

        private Person CreateMe()
        {
            return new Person
            {
                FirstName = "masayuki",
                LastName = "ono",
                Birthday = new DateTime(1986, 9, 26),
                Company = new Company { Name = "mono corporation" },
            };
        }

        private Person CreatePersonA()
        {
            return new Person
            {
                FirstName = "Person",
                LastName = "A",
            };
        }

        /// <summary>
        ///MapSimple のテスト
        ///</summary>
        [TestMethod()]
        public void MapSimpleTest()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person me = CreateMe();
            PersonViewModel meViewModel = driver.MapSimple(me);
            Assert.AreEqual(meViewModel.FirstName, me.FirstName);
            Assert.AreEqual(meViewModel.LastName, me.LastName);
            //FullNameにはマッピングされません
            Assert.AreEqual(meViewModel.FullName, null);
            Assert.AreEqual(meViewModel.Birthday, me.Birthday.Value.ToString());
            //ModelのCompanyプロパティのNameプロパティがマッピングされます
            Assert.AreEqual(meViewModel.CompanyName, me.Company.Name);
        }

        /// <summary>
        ///MapSimple のテスト
        ///</summary>
        [TestMethod()]
        public void MapWithIgnoreTest()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person me = CreateMe();
            PersonViewModel meViewModel = driver.MapWithIgnore(me);
            Assert.AreEqual(meViewModel.FirstName, me.FirstName);
            Assert.AreEqual(meViewModel.LastName, me.LastName);
            //FullNameにはマッピングされません
            Assert.AreEqual(meViewModel.FullName, null);
            Assert.AreEqual(meViewModel.Birthday, me.Birthday.Value.ToString());
            //ModelのCompanyプロパティのNameプロパティがマッピングされます
            Assert.AreEqual(meViewModel.CompanyName, me.Company.Name);
        }

        /// <summary>
        ///MapSimple のテスト
        ///</summary>
        [TestMethod()]
        public void MapWithFullNameTest()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person me = CreateMe();
            PersonViewModel meViewModel = driver.MapWithFullName(me);
            Assert.AreEqual(meViewModel.FirstName, me.FirstName);
            Assert.AreEqual(meViewModel.LastName, me.LastName);
            Assert.AreEqual(meViewModel.FullName, "masayuki ono");
            Assert.AreEqual(meViewModel.Birthday, me.Birthday.Value.ToString());
            Assert.AreEqual(meViewModel.CompanyName, me.Company.Name);
        }

        /// <summary>
        ///MapSimple のテスト
        ///</summary>
        [TestMethod()]
        public void MapWithProfileTest()
        {
            AutoMapperDriver driver = new AutoMapperDriver();
            Person me = CreateMe();
            PersonViewModel meViewModel = driver.MapWithProfile(me);
            Assert.AreEqual(meViewModel.FirstName, me.FirstName);
            Assert.AreEqual(meViewModel.LastName, me.LastName);
            Assert.AreEqual(meViewModel.FullName, "masayuki ono");
            Assert.AreEqual(meViewModel.Birthday, "1986年09月26日生まれ");
            Assert.AreEqual(meViewModel.CompanyName, me.Company.Name);
        }
    }
}