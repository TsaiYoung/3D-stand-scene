using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mogre;
using System.IO;

namespace CompetitionIndice
{

    public partial class Form1 : Form
    {
        bool bool2DPaint = false;     //是否点击绘图
        //bool bool3DPaint = false;
        bool boolData = false;      //是否加载数据

        public Form1()
        {
            InitializeComponent();
        }

        public struct Tree_Info        //树木信息
        {
            public int TreeNo;
            public string Species;
            public double DBH;
            public double Height;
            public double CrownWidth;
            public double X;
            public double Y;
        }
        public Tree_Info[] items = new Tree_Info[143];

        private void OpenExcel_Click(object sender, EventArgs e)
        {
            OpenFile();
            boolData = true;
        }

        private void OpenFile()
        {
            try
            {
                OpenFileDialog myOpenFileDialog = new OpenFileDialog();
                myOpenFileDialog.Title = "     打开文件对话框";
                myOpenFileDialog.Filter = "excel文件|*.xls;*.xlsx|所有文件|*.*";
                myOpenFileDialog.FilterIndex = 1;
                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = myOpenFileDialog.FileName;
                    string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
                    OleDbConnection myConnection = new OleDbConnection(strConnection);              //建立连接
                    myConnection.Open();
                    string strExcel = strExcel = "select * from [sheet1$]";
                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strExcel, strConnection); //建立数据适配器
                    //OleDbCommand myCommand = new OleDbCommand(strExcel, strConnection);
                    //OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myCommand);
                    DataSet myDataset = new DataSet();                  //新建数据集
                    myDataAdapter.Fill(myDataset, "table1");

                    dataGridView1.DataSource = null;                    // 清空原有表格
                    dataGridView1.DataSource = myDataset.Tables[0];     //把数据适配器中的数据读到数据集中的一个表中
                    //指定datagridview1的数据源为数据集ds的第一张表（也就是table1表），也可以写ds.Table["table1"]
                    ReadExcel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 保存FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Execl files (*.xls)|*.xls";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            sfd.CreatePrompt = true;
            sfd.Title = "保存为Excel文件";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "\t";
                        }
                        columnTitle += dataGridView1.Columns[i].HeaderText;
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        string columnValue = "";

                        for (int k = 0; k < dataGridView1.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += "\t";
                            }

                            if (dataGridView1.Rows[j].Cells[k].Value == null)
                                columnValue += "";
                            else
                                columnValue += dataGridView1.Rows[j].Cells[k].Value.ToString().Trim();
                        }

                        sw.WriteLine(columnValue);
                    }

                    sw.Close();
                    myStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }

        private void ReadExcel()
        {
            for (int i = 0; i < 143; i++)
            {
                items[i].TreeNo = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                //items[i].TreeNo = Convert.ToInt32(dataGridView1.Rows[i].Cells["Tree No"].Value);使用列名的方法
                items[i].Species = dataGridView1.Rows[i].Cells[1].Value.ToString();
                items[i].DBH = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                items[i].Height = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                items[i].CrownWidth = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                items[i].X = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                items[i].Y = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
            }
        }

        private void 二维图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool2DPaint = true;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (bool2DPaint)
            {
                if (boolData)
                {
                    Graphics myGraphics = e.Graphics;

                    Pen myPen = new Pen(Color.Black, 1);
                    myPen.EndCap = LineCap.NoAnchor;  //设置线段终点的样式

                    myGraphics.TranslateTransform(0, pictureBox1.Height);
                    myGraphics.ScaleTransform(1f, -1f, MatrixOrder.Prepend);

                    myGraphics.DrawLine(myPen, 1, 1, 1, pictureBox1.Height - 1);
                    myGraphics.DrawLine(myPen, 1, 1, pictureBox1.Width - 1, 1);
                    myGraphics.DrawLine(myPen, 1, pictureBox1.Height - 1, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    myGraphics.DrawLine(myPen, pictureBox1.Width - 1, 1, pictureBox1.Width - 1, pictureBox1.Height - 1);

                    //PointF myPoint = new Point();
                    //List<PointF> treeLocation = new List<PointF>();

                    for (int i = 0; i < 143; i++)
                    {
                        items[i].CrownWidth = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        items[i].X = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        items[i].Y = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);

                        myPen.Color = Color.Green;
                        myGraphics.DrawEllipse(myPen, (float)(items[i].X * 10 - items[i].CrownWidth * 2.5), (float)(items[i].Y * 10 - items[i].CrownWidth * 2.5), (float)items[i].CrownWidth * 5, (float)items[i].CrownWidth * 5);

                        //myPoint.X = (float)items[i].X;
                        //myPoint.Y = (float)items[i].Y;
                        //treeLocation.Add(myPoint);
                    }

                }
                else
                {
                    MessageBox.Show("请打开数据！");
                    bool2DPaint = false;
                }
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bool2DPaint)
            {
                toolStripStatusLabel2.Text = "坐标：( " + e.X / 10.0 + ", " +  (500 - e.Y) / 10.0 + " )";
            }
        }

        private void bALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boolData)
            {
                int i = 0;
                int itemp = 0;
                int[] num = new int[143];
                double sum = 0;
                double dtemp = 0;
                double[] area = new double[143];
                double[] BAL = new double[143];

                for (i = 0; i < 143; i++)
                {
                    area[i] = System.Math.PI * (items[i].DBH / 2) * (items[i].DBH / 2) / 10000;
                    sum = sum + area[i];
                    num[i] = i;
                }

                for (i = 0; i < 143 - 1; i++)
                {
                    if (area[i] > area[i + 1])
                    {
                        dtemp = area[i];
                        area[i] = area[i + 1];
                        area[i + 1] = dtemp;

                        itemp = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = itemp;
                    }
                }

                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = "BAL";
                dataGridView1.Columns.Add(column);

                for (i = 0; i < 143; i++)
                {
                    sum = sum - area[num[i]];
                    BAL[num[i]] = sum;
                    dataGridView1.Rows[num[i]].Cells["BAL"].Value = System.Math.Round(BAL[num[i]], 4);
                }

            }
            else
            {
                MessageBox.Show("请打开数据！");
            }
        }

        private void 三维图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boolData)
            {
                render3DForm();
            }
            else
            {
                MessageBox.Show("请打开数据！");
            }
            //bool3DPaint = true;
        }

        public void render3DForm()
        {
            RenderForm mRederForm = new RenderForm(items); 
            mRederForm.Show();
            mRederForm.KeyPreview = true;       //激活窗体的键盘事件

            //mRender = new cRender(mRederForm.Handle,items);       //参数是实例化的对象mRederForm，不是类RenderForm
            //mRender.Init();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //mRender.mShutDown = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\titlerectangle.ssk";
        }

        private void 文件FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
