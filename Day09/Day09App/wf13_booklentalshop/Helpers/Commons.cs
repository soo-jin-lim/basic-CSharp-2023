using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf13_booklentalshop.Helpers
{
    internal class Commons
    {
        //모든 프로그램 상에서 다 사용 가능
        //DB 연결문자열은 여기서만 수정하면 됨.
        public static readonly string ConnString = "Server = localhost;" +
                                                    "Port=3306;" +
                                                    "Database=bookrentalshop;" +
                                                    "Uid=root;Pwd=12345";
            
    }
}
