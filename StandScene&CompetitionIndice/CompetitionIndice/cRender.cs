using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mogre;
using MOIS;

namespace CompetitionIndice
{
    class cRender
    {
        public bool mShutDown = false;
        public Root mRoot;
        public Mogre.Vector3 mMove = Mogre.Vector3.ZERO;
        RenderWindow mWindow;
        SceneManager mSceneMgr;     //场景管理器
        public Camera mCamera;
        Viewport mViewPort;
        IntPtr mIntPtr;             //用来表示一个指针或者一个句柄
        Form1.Tree_Info[] items = new Form1.Tree_Info[143];
        

        public cRender(IntPtr renderHandle,Form1.Tree_Info[] tree_info) 
        {
            mIntPtr = renderHandle;
            items = tree_info;      //树木信息
        }

        public void Init()      //初始化渲染
        {
            mRoot = new Root();
            LoadResouces();

            //设置 RenderSystem
            RenderSystem mRenderSystem = mRoot.GetRenderSystemByName("Direct3D9 Rendering Subsystem");
            mRoot.RenderSystem = mRenderSystem;
            mRenderSystem.SetConfigOption("Full Screen", "No");
            mRenderSystem.SetConfigOption("Video Mode", "1280 x 1024 @ 32-bit colour");     //????????????????

            // Create Render Window
            mRoot.Initialise(false, "Main Render Window");

            NameValuePairList misc = new NameValuePairList();       //supply the Form's Handle to Ogre in the NameValuePairList parameter so that Ogre knows what window to render inside of.
            misc["externalWindowHandle"] = mIntPtr.ToString();      //这是什么用法？？？？？？？？？？
            mWindow = mRoot.CreateRenderWindow("Main RenderWindow", 800, 700, false, misc); //创建渲染窗体
            mSceneMgr = mRoot.CreateSceneManager(SceneType.ST_EXTERIOR_CLOSE);              //场景优化管理 ST_EXTERIOR_CLOSE适合室外场景中远距离渲染

            TextureManager.Singleton.DefaultNumMipmaps = 5;                         //Singleton???????????????????????????????
            ResourceGroupManager.Singleton.InitialiseAllResourceGroups();           //初始化所有资源组，将资源加载至内存


            CreateCamera();     //设置相机
            CreateViewport();   //
            SetLight();         //设置光线
            CreateSky();        //天空
            CreateTerrain();    //创建地形
            AddTrees();         //加载树
            CreateFrameListeners(); //创建帧监听
            //结束释放资源
        }

        private void LoadResouces()
        {
            // Load resource paths from config file
            var cf = new ConfigFile();
            cf.Load("resources.cfg", "\t:=", true);

            // Go through all sections & settings in the file
            var seci = cf.GetSectionIterator();
            while (seci.MoveNext())
            {
                foreach (var pair in seci.Current)
                {
                    ResourceGroupManager.Singleton.AddResourceLocation(pair.Value, pair.Key, seci.CurrentKey);
                    //pair.Key类型名；pair.Value档案名
                }
            }

            //ConfigFile cf = new ConfigFile();
            //cf.Load("resources.cfg", "\t:=", true);
            //ConfigFile.SectionIterator seci = cf.GetSectionIterator();
            //String secName, typeName, archName;

            //while (seci.MoveNext())
            //{
            //    secName = seci.CurrentKey;
            //    ConfigFile.SettingsMultiMap settings = seci.Current;
            //    foreach (KeyValuePair<string, string> pair in settings)
            //    {
            //        typeName = pair.Key;
            //        archName = pair.Value;
            //        ResourceGroupManager.Singleton.AddResourceLocation(archName, typeName, secName);
            //    }
            //}
        }

        private void CreateCamera()
        {
            mCamera = mSceneMgr.CreateCamera("myCamera");
            mCamera.Position = new Mogre.Vector3(300f, 200f, 300f);
            mCamera.NearClipDistance = 1f;
            mCamera.FarClipDistance = 0;
            mCamera.LookAt(0, 0, 0);
        }

        private void CreateViewport()
        {
            mViewPort = mWindow.AddViewport(mCamera);
            //mViewPort.BackgroundColour = ColourValue.Black;

            // Alter the camera aspect ratio to match the viewport
            mCamera.AutoAspectRatio = true;
            //mCamera.AspectRatio = (mViewPort.ActualWidth / mViewPort.ActualHeight);
        }

        private void SetLight()
        {
            mSceneMgr.AmbientLight = new ColourValue(1.0f, 1.0f, 1.0f);
            Light light = mSceneMgr.CreateLight("Light");
            light.Type = Light.LightTypes.LT_DIRECTIONAL;
            light.Position = new Mogre.Vector3(0, 150, 250);
            light.DiffuseColour = ColourValue.White;
        }

        private void CreateSky()
        {
            mSceneMgr.SetSkyDome(true, "Examples/CloudySky", 2, 3, 20000, true);    //天空穹
        }

        private void AddTrees()  //加载树木
        {
            Entity[] trees = new Entity[143];
            SceneNode[] treesNode = new SceneNode[143];
            for (int i = 0; i < 143; i++)
            {
                trees[i] = mSceneMgr.CreateEntity(items[i].TreeNo.ToString(), "sm3.13.mesh");
                trees[i].CastShadows = true;
                treesNode[i] = mSceneMgr.RootSceneNode.CreateChildSceneNode(items[i].TreeNo.ToString());
                treesNode[i].SetPosition((float)(items[i].X * 10 - 250), 0, (float)(items[i].Y * 10 - 250));
                treesNode[i].Scale(5, (float)(items[i].Height / 2), 5);    //高度乘上树高
                treesNode[i].AttachObject(trees[i]);        //节点与模型绑定
            }
        }

        private void CreateTerrain()
        {
            //设置地形——平面
            Plane ground = new Plane(Mogre.Vector3.UNIT_Y, 0);
            MeshManager.Singleton.CreatePlane("ground", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME, ground, 500, 500, 20, 20, true, 1, 5, 5, Mogre.Vector3.UNIT_Z);
            Entity groundEnt = mSceneMgr.CreateEntity("GroundEntity", "ground");
            mSceneMgr.RootSceneNode.CreateChildSceneNode().AttachObject(groundEnt);
            groundEnt.SetMaterialName("Examples/GrassLand");
            groundEnt.CastShadows = false;
        }

        private void CreateFrameListeners()
        {
            mRoot.FrameRenderingQueued += new FrameListener.FrameRenderingQueuedHandler(OnFrameRenderingQueued);
            while (mRoot != null && mRoot.RenderOneFrame())
                Application.DoEvents();
        }

        private bool OnFrameRenderingQueued(FrameEvent evt)
        {
            if (mWindow.IsClosed)
                return false;

            if (mShutDown)
                return false;
            
            mCamera.Position += mCamera.Orientation * mMove * evt.timeSinceLastFrame;

            if (mCamera.Position.y <= 5)
            {
                mCamera.SetPosition(mCamera.Position.x, 5, mCamera.Position.z);
            }
            

            return true;
        }

        //public void Disposed()
        //{
        //    mRoot.Dispose();
        //    mRoot = null;
        //}

        public void Resize()
        {
            mWindow.WindowMovedOrResized();
        }
    }
}
