using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wf13_booklentalshop
{
    public partial class FrmGenre : Form
    {
        bool isNew = false; //false(UPDATE)/true(INSERT)
        #region<생성자>
        public FrmGenre()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region<이벤트 핸들러>
        private void FrmGenre_Load(object sender, EventArgs e)
        {
            RefreshData();
            isNew = true;

        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true)// 신규
            {
                MessageBox.Show("삭제할 데이터를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //삭제여부를 물을 때  아니오를 누르면 삭제 진행
            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            //Yes를 누르면 계속 진행 //SaveData에 있는 로직 복사->수정
            DeleteData();//데이터 삭제처리
            RefreshData();// 지우고나서 재조회
            ClearInputs();//입력창 데이터 지우기
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() != true) return;

            saveData();//데이터 저장/수정
            RefreshData();//데이터 재조회
            ClearInputs();// 입력창 클리어
        }
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) //아무것도 선택안하면 -1
            {
                var selData = DgvResult.Rows[e.RowIndex];
                // MessageBox.Show(selData.ToString());
                //Debug.WriteLine(selData.ToString());
                Debug.WriteLine(selData.Cells[0].Value);
                Debug.WriteLine(selData.Cells[1].Value);
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true; //Pk는 수정하면 안됨
                isNew = false; //수정
            }
        }

        #endregion

        #region<커스텀 매서드>
        private void RefreshData()
        {

            // DB divtbl 데이터 조회 DgvResult 뿌림
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // 쿼리 작성
                    var selQuery = @"SELECT  Division
                                 , Names
                                    From divtbl";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl"); // divtbl로 dataSet 접근가능

                    DgvResult.DataSource = ds.Tables[0];
                    //DgvResult.DataSource = ds;
                    //DgvResult.DataMember = "divtbl";

                    DgvResult.Columns[0].HeaderText = "장르코드";
                    DgvResult.Columns[1].HeaderText = "장르명";

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;//신규일 땐 입력가능
            TxtDivision.Focus();
            isNew = true; //신규
        }
        private bool CheckValidation()
        {
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                result = false;
                errorMsg += "●장르명을 입력하세요.\r\n";
            }
            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                result = false;
                errorMsg += "●장르명을 입력하세요.\r\n";
            }
            if (result == false)
            {
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;

            }
        }
        private void DeleteData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {

                    if (conn.State == ConnectionState.Closed) conn.Open();
                    {
                        var query = @"DELETE FROM divtbl
			                           WHERE Division = @Division";


                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                        cmd.Parameters.Add(prmDivision);


                        var result = cmd.ExecuteNonQuery(); //INSERT, UPDATE, DELETE

                        if (result != 0)
                        {
                            //저장성공
                            MessageBox.Show("삭제성공!!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //저장실패
                            MessageBox.Show("삭제실패", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //is New = true INSERT /false UPDATE
        private void saveData()
        {
            //INSERT부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = "";
                    if (isNew)
                    {
                        query = @"INSERT INTO divtbl
			                           Value(@Division,@Names)";
                    }
                    else
                    {
                        query = @"update divtbl
                                    set Names = @Names
                                    Where Division = @Division";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

                    var result = cmd.ExecuteNonQuery(); //INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        //저장성공
                        MessageBox.Show("저장성공!!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //저장실패
                        MessageBox.Show("저장실패", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #region<>

        #endregion

        #region
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNames_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// 그리드 뷰 클릭하면 발생 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
    }
}
