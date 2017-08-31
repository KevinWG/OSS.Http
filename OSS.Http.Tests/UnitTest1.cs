using System;
using System.Net.Http;
using System.Threading.Tasks;
using OSS.Http.Extention;
using OSS.Http.Mos;
using Xunit;

namespace OSS.Http.Tests
{
    public class UnitTest1
    {

        public class StaticTest
        {
            public static int Count { get; set; }
        }



        public class SubStaticTest :StaticTest
        {
            
        }


        [Fact]
        public void Test1()
        {

            StaticTest.Count = 2;

            var testCount = SubStaticTest.Count;
        }

        private static async Task<HttpResponseMessage> GetTest()
        {
            var req = new OsHttpRequest();
            req.AddressUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxaa9e6cb3f03afa97&secret=0fc0c6f735a90fda1df5fc840e010144&code=ssss&grant_type=authorization_code";
            req.HttpMothed = HttpMothed.GET;

            return await req.RestSend();
        }
        private static async Task<HttpResponseMessage> Test()
        {
            //OsHttpRequest req = new OsHttpRequest();

            //req.AddressUrl = "http://www.baidu.com";
            //req.HttpMothed = HttpMothed.GET;
            //return await req.RestSend();

            var req = new OsHttpRequest();
            req.AddressUrl = "http://localhost:59489/";
            req.HttpMothed = HttpMothed.POST;

            //  �ļ��ϴ�����
            //var imageFile = new FileStream("E:\\111.png", FileMode.Open, FileAccess.Read);
            //req.FileParameters.Add(new FileParameter("media", imageFile, "111.png", "image/jpeg")); 
            // ������������
            //req.FormParameters.Add(new FormParameter("description", "����"));
            return await req.RestSend();
        }
    }
}