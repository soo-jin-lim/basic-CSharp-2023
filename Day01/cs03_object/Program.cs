using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace cs03_object
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Object 형식
            // int == SysTEM.Int32
            // long == System.Int64
            Int64 val = 1111;
            long idata = 1024;
            Console.WriteLine(idata);
            Console.WriteLine(idata.GetType());

            object iobj = (object)idata; // 박싱: 데이터타입값을 object로 담아라 
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            long udata = (long)iobj;    // 언박싱: object타입을 원래 데이터 타입으로 바꾸는 것 
            Console.WriteLine(udata);
            Console.WriteLine(udata.GetType());

            double ddata = 3.141592;
            object pobj = (object)ddata;
            double pdata = (double)pobj;

            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            short sdata = (short)32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata);
            indata = (int)lndata;   // overflow
            Console.WriteLine(lndata);

            // float double간 형변환
            float fval = 3.141592f; // float형은 마지막에 f 써줘야 함
            Console.WriteLine("fval = " + fval);
            double dval = (double)fval;
            Console.WriteLine("dval = " + dval);
            Console.WriteLine(dval == 3.141592);

            //정말 중요 
            int numival = 1024;
            string strival = numival.ToString();
            //Console.WriteLine(numival == strival);
            Console.WriteLine(strival.GetType());

            double numdval = 3.141592265358979;
            string strdval = numdval.ToString();
            Console.WriteLine(strdval);

            //문자열을 숫자로
            //문자열내에 숫자가 아닌 특수문자나 정수인데 .이 있거나
            string originstr = "3000000";//"3million"은 예외발생
            int convval =Convert.ToInt32(originstr);//int.Parse() 동일
            Console.WriteLine(convval);
            originstr = "1.2345";
            float convfloat = float.Parse(originstr);
            Console.WriteLine(convfloat);
            // 예외 발생하지 않도록 형변환 방법
            originstr = "123.4f";
            float ffval;
            //TryParse는 예외가 발생하면 0 대체, 예외없으면 원래값으로
            float.TryParse(originstr, out ffval); //예외 발생하지않게 숫자변환
            Console.WriteLine(ffval);

            const double pi = 3.1415926768678;
            Console.WriteLine(pi);

            //pi = 4.56; 상수는 못바꿈
        }
    }
}