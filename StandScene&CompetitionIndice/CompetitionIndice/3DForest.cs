using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mogre;

namespace CompetitionIndice
{
    public partial class RenderForm : Form
    {
        //bool boolMouseDown = false;
        const float mRotate = 0.4f;      //旋转常量
        cRender mRender;                 //声明一个mRender对象
        Form1.Tree_Info[] items = new Form1.Tree_Info[143];
        System.Drawing.Point MouPosition = new Point();

        public RenderForm(Form1.Tree_Info[] tree_info)
        {
            InitializeComponent();
            items = tree_info;
        }

        private void RenderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mRender.mShutDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mRender = new cRender(this.Handle, items);
            mRender.Init();
        }

        private void RenderForm_Resize(object sender, EventArgs e)
        {
            //mRender.Resize();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.Visible = false;
        }

        private void RenderForm_MouseMove(object sender, MouseEventArgs e)
        {
            float x, y;

            if (e.Button == MouseButtons.Right) 
            {
                //转动相机
                x = MouPosition.X - System.Windows.Forms.Cursor.Position.X;     //判断鼠标移动的方向
                y = MouPosition.Y - System.Windows.Forms.Cursor.Position.Y;
                //if(x)
                mRender.mCamera.Yaw(new Degree(mRotate * 0.5f * x));
                mRender.mCamera.Pitch(new Degree(mRotate * 0.5f * y));

                MouPosition = System.Windows.Forms.Cursor.Position;    //监测鼠标位置
            }
        }

        private void RenderForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    mRender.mMove.x = -100;
                    break;
                case Keys.D:
                    mRender.mMove.x = 100;
                    break;
                case Keys.E:
                    mRender.mMove.y = -100;
                    break;
                case Keys.Q:
                    mRender.mMove.y = 100;
                    break;
                case Keys.S:
                    mRender.mMove.z = 100;
                    break;
                case Keys.W:
                    mRender.mMove.z = -100;
                    break;
                default:
                    break;
            }
        }

        private void RenderForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    mRender.mMove.x = 0;
                    break;
                case Keys.D:
                    mRender.mMove.x = 0;
                    break;
                case Keys.E:
                    mRender.mMove.y = 0;
                    break;
                case Keys.Q:
                    mRender.mMove.y = 0;
                    break;
                case Keys.S:
                    mRender.mMove.z = 0;
                    break;
                case Keys.W:
                    mRender.mMove.z = 0;
                    break;
                default:
                    break;
            }
        }

        private void RenderForm_MouseDown(object sender, MouseEventArgs e)
        {
            //boolMouseDown = true;
            MouPosition = System.Windows.Forms.Cursor.Position;
        }

        private void RenderForm_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\titlerectangle.ssk";
        }


        
    }
}
