using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;

namespace DemoEnglish
{
    public partial class MainForm : Form
    {
        public class NGUOIDUNG
        {
           
            public string MA_NGUOIDUNG { get; set; }
            public string MATKHAU { get; set; }
            public string TEN_NGUOIDUNG { get; set; }
            public string NGAYSINH { get; set; }
            public Nullable<double> TONGDIEM { get; set; }
            public string SDT { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            this.PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            string apiUrl = "http://localhost:1063/api/english";
            object input = new
            {
                Name = txt_name.Text.Trim(),
            };
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string address = apiUrl + "/GetNGUOIDUNG";
            string json = client.UploadString(address, inputJson);

            dtgv_Data.DataSource = (new JavaScriptSerializer()).Deserialize<List<NGUOIDUNG>>(json);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.PopulateDataGridView();
        }

    }
}
