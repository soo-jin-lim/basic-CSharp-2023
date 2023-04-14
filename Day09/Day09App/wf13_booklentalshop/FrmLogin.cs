using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace wf13_booklentalshop
{
    public partial class FrmLogin : Form
    {
        private bool IsLogined = false;//로그인 성공했는지 물어보는 변수
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            IsLogined = LoginProcess();//로그인을 성공해야만 true가 됨.

            if (IsLogined)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            Environment.Exit(0);//가장 완벽하게 프로그램을 종료
        }

        //이게 없으면 종료 버튼이나 Alt+F4로 했을 때 메인 폼이 나타난다.
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsLogined != true)
            { //로그인이 안되었을 때 창을 닫으면 프로그램 모두 종료
                Environment.Exit(0);
            }

        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//엔터키 누르면
            {
                BtnLogin_Click(sender, e);//버튼 클릭 이벤트 핸들러 호출
            }
        }
        /// <summary>
        /// DB userTbl에서 정보확인 로그인처리
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool LoginProcess()
        {
            //validation check
            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                MessageBox.Show("유저아이디를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("패스워드를 입력하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string strUserId = "";
            string strPassword = "";

            try
            {
                //string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";
                // DB 처리
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    conn.Open();

                    #region << DB쿼리를 위한 구성 >>
                    string selQuery = @"SELECT userId
                                             , password
                                          FROM usertbl
                                         WHERE userID = @userID
                                           AND password = @password";
                    MySqlCommand selCmd = new MySqlCommand(selQuery, conn);
                    // @userID, @password 파라미터 할당
                    MySqlParameter prmUserID = new MySqlParameter("@userID", TxtUserId.Text);
                    MySqlParameter prmPassword = new MySqlParameter("@password", TxtPassword.Text);
                    selCmd.Parameters.Add(prmUserID);
                    selCmd.Parameters.Add(prmPassword);
                    #endregion

                    MySqlDataReader reader = selCmd.ExecuteReader(); // 실행한 다음에 userID, password
                    if (reader.Read())
                    {

                        strUserId = reader["userId"] != null ? reader["userId"].ToString() : "-";
                        strPassword = reader["password"] != null ? reader["password"].ToString() : "-";

                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"로그인정보가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

                // conn.Close();
                //MessageBox.Show($"{strUserId} / {strPassword}");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //유저 아이디 택스트 박스에서 앤터를 치면 패스워드 택스트 박스로 포커스 이동
        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
