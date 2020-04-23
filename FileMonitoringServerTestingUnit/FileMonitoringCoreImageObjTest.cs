using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using FileMonitoringCore;
using System.IO;
using FileMonitoringCore.com.lib.objects;

namespace FileMonitoringServerTestingUnit
{
    [TestClass]
    public class FileMonitoringCoreImageObjTest
    {
        [TestMethod]
        public void TestImageObj_CompressImage()
        {
            FileInfo SourceImage = new FileInfo("D:\\Temp\\IMG_20200316_071933.jpg");
            ImageObj Image = new ImageObj(SourceImage);
            Image.PercentRationToCompress = (int)0.2f;
            Image.StartExpirationTime();
            System.Threading.Thread.Sleep(90000);
            Console.Write(Image.ImageCreated.FullName);
            Assert.IsNotNull(Image.ImageCreated);

        }
    }
}
