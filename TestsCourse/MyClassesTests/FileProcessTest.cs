using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;
using System.Configuration;
using System.Drawing;

namespace MyClassesTests
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE = "C:\\BadFileName.txt";
        private string _GoodFile;

        public TestContext TestContext { get; set; }
        private const string FILE_NAME = @"FileToDeploy.txt";

        #region Test initialize e cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName == "FileNameDoesExists")
            {
                if (string.IsNullOrEmpty(_GoodFile))
                {
                    SetGoodFileName();
                    TestContext.WriteLine($"Creating file {_GoodFile}");
                    File.AppendAllText(_GoodFile, "some text");
                } 
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (string.IsNullOrEmpty(_GoodFile))
                {
                    TestContext.WriteLine($"Deleting file {_GoodFile}");
                    File.Delete(_GoodFile);
                }
            }
        }

        [TestMethod]
        [Priority(0)]
        [Description("Check to see if a file does exist")]
        [Owner("Rafaela")]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFile);

            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFile = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFile.Contains("[AppPAth"))
            {
                _GoodFile = _GoodFile.Replace("[AppPAth",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        [Priority(0)]
        [Owner("Rafaela")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExists_UsingDeploymentItem()
        {
            FileProcess fp = new();
            
            bool fromCall;
            string fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";


            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Timeout(2000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(1500);
        }

        [TestMethod]
        [Description("Check to see if a file does not exist")]
        [TestCategory("NoException")]
        [Owner("Rafaela")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Regedit.exe");

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(0)]
        [TestCategory("Exception")]
        [Owner("Rafaela")]
        public void FileNameNullOrEmpyt_ThrowsException()
        {
            FileProcess fp = new();
            fp.FileExists("");
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("NoException")]
        [Owner("Rafaela")]
        public void FileNameNullOrEmpyt_ThrowsException_UsingTryCatch()
        {
            FileProcess fp = new();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("Fail expected");
        }
        #endregion
        #region isInstanceOfType Test
        [TestMethod]
        [Owner("Rafaela")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            PersonClass per = mgr.CreatePersonClass("Rafaela", "Peres", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Rafaela")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            PersonClass per = mgr.CreatePersonClass("", "Peres", true);

            Assert.IsNull(per);
        }

        #endregion
    }
}