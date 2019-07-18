using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using DTKBarReaderLib;
using System.Runtime.InteropServices;
using Edward;
using System.IO;
using System.Management;




namespace SBBarcode
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        [DllImport("DTKBarReader.dll", CharSet = CharSet.Unicode), PreserveSig]
        private static extern int CreateBarcodeReader(ref BarcodeReader barReader);
        [DllImport("DTKBarReader.dll", CharSet = CharSet.Unicode), PreserveSig]
        private static extern int DestroyBarcodeReader(BarcodeReader barReader);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        BarcodeReader barReader = null;


       

        private string CurBar = "";
        


        /// <summary>
        /// 类别的一个列表看到AForge.Video.DirectShow.FilterCategory。
        ///样本用法:
        ///列举videoDevices =新FilterInfoCollection(FilterCategory.VideoInputDevice视频设备);
        ///列出设备(视频设备中的FilterInfo设备)
        /// </summary>
        //定义收集过滤器信息的对象
        FilterInfoCollection videoDevices;

        /// <summary>
        /// 这个视频源类从本地视频捕获设备获取视频数据，
        /// 像USB网络摄像头(或内部)、帧抓取器、捕捉板——任何东西
        /// 支持DirectShow的接口。对于有快门按钮的设备
        /// 或者支持外部软件触发，类也允许做快照。
        /// 视频大小和快照大小都可以配置。
        /// </summary>
        //定义视频源抓取类
        VideoCaptureDevice videoSource;
        //定义下标
        public int selectedDeviceIndex = 0;

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Scan Mac(Code-128) & SN(DataMatrix),ver:" + Application.ProductVersion;
            btnCloseCam.Enabled = false;
            btnCapturePic.Enabled = false;
            txtImg.SetWatermark("Double Click here to select image file.");


            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    comboCam.Items.Add(videoDevices[i].Name);
                }

                comboCam.SelectedIndex = 0;
                selectedDeviceIndex = 0;
            }

            if (!Directory.Exists("Pictures"))
                Directory.CreateDirectory("Pictures");


  
            if (!File.Exists(p.IniFile ))
            {
                //創建配置檔
                createIniFile(p.IniFile);
            }
            //加載配置檔
            loadConfigData(p.IniFile);

            DeleteLog();
            if (!Directory.Exists(p.SNFolder))
            {
                Directory.CreateDirectory(p.SNFolder);
            }
            txtLeftAHWID.Text = p.LeftAHWID;
            txtLeftBHWID.Text = p.LeftBHWID;
            txtRightAHWID.Text = p.RightAHWID;
            txtRightBHWID.Text = p.RightBHWID;
            txtLeftASN.Text = p.LeftASN;
            txtLeftBSN.Text = p.LeftBSN;
            txtRightASN.Text = p.RightASN;
            txtRightBSN.Text = p.RightBSN;

           // MessageBox.Show(p.SNFolder);

    

            txtSNFolder.Text = p.SNFolder;
          
            if (p.RunType == p.RunTypeFlag.Auto)
            {
                if (p.CamIndex > videoDevices.Count-1)
                {
                    p.WriteLog("Select Cam index(" + p.CamIndex.ToString() +") out of local cam index range (" + (videoDevices.Count -1).ToString () +").");
                }
                else
                {


                    if (p.ArgStr == "L")
                    {

                        //L1

                        p.CamIndex = GetCamIndexByHwid(p.LeftAHWID);
                        if (p.CamIndex > -1)
                        {
                            CurBar = "LA";
                            comboCam.SelectedIndex = p.CamIndex;
                            selectedDeviceIndex = p.CamIndex;
                            OpenCam();
                            p.WriteLog("Auto Open Cam Left A.");
                            CapAndRead(CurBar);
                        }
                        else
                            p.WriteLog("Left A Cam's HWID maybe wrong," + p.LeftAHWID);
                        //L2
                        p.CamIndex = GetCamIndexByHwid(p.LeftBHWID);
                        if (p.CamIndex > -1)
                        {
                            CurBar = "LB";
                            comboCam.SelectedIndex = p.CamIndex;
                            selectedDeviceIndex = p.CamIndex;
                            OpenCam();
                            p.WriteLog("Auto Open Cam Left B.");
                            CapAndRead(CurBar);
                        }
                        else
                            p.WriteLog("Left B Cam's HWID maybe wrong," + p.LeftBHWID);
                    }


                    if (p.ArgStr == "R")
                    {

                        //R1

                        p.CamIndex = GetCamIndexByHwid(p.RightAHWID);
                        if (p.CamIndex > -1)
                        {
                            CurBar = "RA";
                            comboCam.SelectedIndex = p.CamIndex;
                            selectedDeviceIndex = p.CamIndex;
                            OpenCam();
                            p.WriteLog("Auto Open Cam Right A.");
                            CapAndRead(CurBar);
            
                        }
                        else
                            p.WriteLog("Right A Cam's HWID maybe wrong," + p.RightAHWID);
                        //R2
                        p.CamIndex = GetCamIndexByHwid(p.RightBHWID);
                        if (p.CamIndex > -1)
                        {
                            CurBar = "RB";
                            comboCam.SelectedIndex = p.CamIndex;
                            selectedDeviceIndex = p.CamIndex;
                            OpenCam();
                            p.WriteLog("Auto Open Cam Right B.");
                            CapAndRead(CurBar);

                        }
                        else
                            p.WriteLog("Right B Cam's HWID maybe wrong," + p.RightBHWID);

                    }

                }


                Environment.Exit(0);
            }

        }


        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            OpenCam();
            p.WriteLog("Manual Open Cam.");

        }

        private void OpenCam()
        {
            //实例化过滤类
            //FilterCategory.VideoInputDevice视频输入设备类别。
          
            //实例化下标
            
            //实例化视频源抓取类
            //videoDevices[selectedDeviceIndex].MonikerString   过滤器的名字的字符串。
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
            //视频分辨设置
            //该属性允许设置一个支持的视频分辨率
            //相机。使用AForge.Video.DirectShow.VideoCaptureDevice.VideoCapabilities
            //属性以获得支持的视频分辨率列表。
            //在照相机开始生效之前必须设置好该属性。
            //属性的默认值设置为null，这意味着默认的视频分辨率
            //使用。
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            //把实例化好的videosource类赋值到VideoSourcePlayer控件的VideoSource属性
            // vspxianshi.VideoSource = videoSource;
            videoSourcePlayer1.VideoSource = videoSource;
            //启动VideoSourcePlayer控件
            //vspxianshi.Start();
            videoSourcePlayer1.Start();
            //这样就把摄像头的图像获取到了本地
            System.Threading.Thread.Sleep(500);
            UpdateMsg(lstMsg, "Open cam.");
            btnCloseCam.Enabled = true;
            btnOpenCam.Enabled = false;
            btnCapturePic.Enabled = true;
            comboCam.Enabled = false;

        }






        private void OpenCam(p.RunTypeFlag runtype)
        {
            //实例化过滤类
            //FilterCategory.VideoInputDevice视频输入设备类别。

            //实例化下标

            //实例化视频源抓取类
            //videoDevices[selectedDeviceIndex].MonikerString   过滤器的名字的字符串。
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
            //视频分辨设置
            //该属性允许设置一个支持的视频分辨率
            //相机。使用AForge.Video.DirectShow.VideoCaptureDevice.VideoCapabilities
            //属性以获得支持的视频分辨率列表。
            //在照相机开始生效之前必须设置好该属性。
            //属性的默认值设置为null，这意味着默认的视频分辨率
            //使用。
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            //把实例化好的videosource类赋值到VideoSourcePlayer控件的VideoSource属性
            // vspxianshi.VideoSource = videoSource;
            videoSourcePlayer1.VideoSource = videoSource;
            //启动VideoSourcePlayer控件
            //vspxianshi.Start();
            videoSourcePlayer1.Start();
            //这样就把摄像头的图像获取到了本地
            System.Threading.Thread.Sleep(500);
            UpdateMsg(lstMsg, "Open cam.");
            btnCloseCam.Enabled = true;
            btnOpenCam.Enabled = false;
            btnCapturePic.Enabled = true;
            comboCam.Enabled = false;
            if (runtype == p.RunTypeFlag.Auto)
            {
                timerDelay.Enabled = true;
                timerDelay.Start();
            }
        }

        private void btnCloseCam_Click(object sender, EventArgs e)
        {

            CloseCam();
            p.WriteLog("Manual Close Cam.");
        }

        private void CloseCam()
        {
            videoSourcePlayer1.Stop();
            timerDelay.Stop();
            btnOpenCam.Enabled = true;
            btnCloseCam.Enabled = false;
            btnCapturePic.Enabled = false;
            comboCam.Enabled = true;
            UpdateMsg(lstMsg, "Close cam.");
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            if (videoSource == null)
            {
                return;
            }
            else
            {
                try
                {
                    //创建图像对象
                    Bitmap bm1 = videoSourcePlayer1.GetCurrentVideoFrame();
                    Bitmap bm2 = new Bitmap(bm1.Width, bm1.Height);
                    Graphics g = Graphics.FromImage(bm2);
                    g.DrawImageUnscaled(bm1, 0, 0);
                    //get rid of the graphics
                    g.Dispose();
                    //and save a new gif
                   // bm2.Save("001.jpg", ImageFormat.Jpeg);
                    //pbboxpot.ImageLocation = "001.jpg";


                    //定义图片路径
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                    //创建图片
                    bm2.Save(Environment.CurrentDirectory + @"\Pictures\" + filename, ImageFormat.Bmp);
                    txtImg.Text = Environment.CurrentDirectory + @"\Pictures\" + filename;
                    picCapture.ImageLocation = Environment.CurrentDirectory + @"\Pictures\" + filename;
                    UpdateMsg(lstMsg, "capture " + filename);
                    p.WriteLog("capture " + filename);
                    CloseCam();
                    switch (CurBar)
                    {
                        case "LA":
                            ReadBarcode(p.LeftASN);
                            break;
                        case "LB":
                            ReadBarcode(p.LeftBSN);
                            break;
                        case "RA":
                            ReadBarcode(p.RightASN);
                            break;
                        case "RB":
                            ReadBarcode(p.RightBSN);
                            break;
                        default:
                            break;
                    }
                    //ReadBarcode(p.RightASN);


                }
                catch (Exception)
                {
                    MessageBox.Show("您的摄像头有问题,请您重新试一次!");
                }

            }
        }

        private void btnCapturePic_Click(object sender, EventArgs e)
        {
            CapturePic();
        }


        private void CapturePic()
        {
            if (videoSource == null)
            {
                return;
            }
            else
            {
                //创建图像对象
                Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
                //定义图片路径
                string filename =   DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                //创建图片
                bitmap.Save(Environment.CurrentDirectory + @"\Pictures\" + filename, ImageFormat.Bmp);
                txtImg.Text = Environment.CurrentDirectory + @"\Pictures\" + filename;
                picCapture.ImageLocation = Environment.CurrentDirectory + @"\Pictures\" + filename;
                UpdateMsg(lstMsg, "capture " + filename);
                p.WriteLog("capture " + filename);
            }
        }

        private void UpdateMsg(ListBox listbox,string msg)
        {

            string item = DateTime.Now.ToString("HH:mm:ss") + "->" + msg;
            listbox.Items.Add(item);
            listbox.SelectedIndex = listbox.Items.Count - 1;
            if (listbox.Items.Count >=100)
                listbox.Items.RemoveAt(0);

        }



        /// <summary>
        /// 条码识别
        /// </summary>
        private void ScanBarCode(string fileName)
        {
            DateTime now = DateTime.Now;
            System.Drawing.Image primaryImage = System.Drawing.Image.FromFile(fileName);

            Bitmap pImg = MakeGrayscale3((Bitmap)primaryImage);
            using (ZBar.ImageScanner scanner = new ZBar.ImageScanner())
            {
                scanner.SetConfiguration(ZBar.SymbolType.None, ZBar.Config.Enable, 0);
                scanner.SetConfiguration(ZBar.SymbolType.CODE39, ZBar.Config.Enable, 1);
                scanner.SetConfiguration(ZBar.SymbolType.CODE128, ZBar.Config.Enable, 1);

                List<ZBar.Symbol> symbols = new List<ZBar.Symbol>();
                symbols = scanner.Scan((System.Drawing.Image)pImg);

                if (symbols != null && symbols.Count > 0)
                {
                    string result = string.Empty;
                    symbols.ForEach(s => result += "条码内容:" + s.Data + " 条码质量:" + s.Quality + Environment.NewLine);
                    //  MessageBox.Show(result);

                    foreach (ZBar.Symbol sym in symbols)
                    {
                        UpdateMsg(lstMsg, "条码内容:" + sym.Data + " 条码质量:" + sym.Quality);
                        p.WriteLog("MAC.txt", sym.Data);
                        p.WriteLog("MAC:" + sym.Data + ",Quality:" + sym.Quality);
                    }
                }
                else
                {
                    UpdateMsg(lstMsg, "一维码读取失败.");
                }
            }
        }


        /// <summary>
        /// 处理图片灰度
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        private  Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
               new float[][] 
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        private void btnReadBarcode_Click(object sender, EventArgs e)
        {

            ReadBarcode();
        }


        private void ReadBarcode()
        {
            if (!string.IsNullOrEmpty(txtImg.Text.Trim()))
            {
               // ScanBarCode(txtImg.Text.Trim());

                barReader = new BarcodeReader();
                // set barcode types to read 
                barReader.BarcodeTypes = BarcodeTypeEnum.BT_DataMatrix;
                // define expected barcode orientations
                barReader.BarcodeOrientation = BarcodeOrientationEnum.BO_All;
                // the following values are default values (for TM_Multiple only)
                // for example, if barReader.Threshold = 128, 
                //      then the follwong thresholds will be used 64,80,96,112,128,144,160,176,192
                barReader.ThresholdStep = 16;
                barReader.ThresholdCount = 8;
                barReader.ReadFromFile(txtImg.Text.Trim());

                if (barReader.Barcodes.Count == 0)
                    UpdateMsg(lstMsg, "No barcodes found");
                else
                {
                    for (int i = 0; i < barReader.Barcodes.Count; i++)
                    {
                        Barcode barcode = barReader.Barcodes.get_Item(i);
                        UpdateMsg(lstMsg, barcode.BarcodeString);
                       // p.WriteLog(p.SNFolder + p.SNFile , barcode.BarcodeString);
                        p.WriteLog("SN:" + barcode.BarcodeString);
                    }
                }

            }
        }

        private void ReadBarcode(string  snfile)
        {
            if (!string.IsNullOrEmpty(txtImg.Text.Trim()))
            {
                // ScanBarCode(txtImg.Text.Trim());

                barReader = new BarcodeReader();
                // set barcode types to read 
                barReader.BarcodeTypes = BarcodeTypeEnum.BT_DataMatrix;
                // define expected barcode orientations
                barReader.BarcodeOrientation = BarcodeOrientationEnum.BO_All;
                // the following values are default values (for TM_Multiple only)
                // for example, if barReader.Threshold = 128, 
                //      then the follwong thresholds will be used 64,80,96,112,128,144,160,176,192
                barReader.ThresholdStep = 16;
                barReader.ThresholdCount = 8;
                barReader.ReadFromFile(txtImg.Text.Trim());

                if (barReader.Barcodes.Count == 0)
                    UpdateMsg(lstMsg, "No barcodes found");
                else
                {
                    for (int i = 0; i < barReader.Barcodes.Count; i++)
                    {
                        Barcode barcode = barReader.Barcodes.get_Item(i);
                        UpdateMsg(lstMsg, barcode.BarcodeString);
                         p.WriteLog(p.SNFolder + snfile  , barcode.BarcodeString);
                        p.WriteLog("SN:" + barcode.BarcodeString);
                    }
                }

            }
        }


        private void txtImg_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtImg.Text = open.FileName;
                picCapture.Load(txtImg.Text.Trim());
            }

        }

        private void btnCapturePic_EnabledChanged(object sender, EventArgs e)
        {
            if (btnCapturePic.Enabled)
                btnCapturePic.BackColor = Color.FromArgb(51, 153, 255);
            else
                btnCapturePic.BackColor = Color.Gray;
        }

        private void btnCloseCam_EnabledChanged(object sender, EventArgs e)
        {
            if (btnCloseCam.Enabled)
                btnCloseCam.BackColor = Color.FromArgb(51, 153, 255);
            else
                btnCloseCam.BackColor = Color.Gray;
        }

        private void btnOpenCam_EnabledChanged(object sender, EventArgs e)
        {
            if (btnOpenCam.Enabled)
                btnOpenCam.BackColor = Color.FromArgb(51, 153, 255);
            else
                btnOpenCam.BackColor = Color.Gray;
        }







        /// <summary>
        /// 
        /// </summary>
        private void DeleteLog()
        {

            if (File.Exists("MAC.txt"))
                File.Delete("MAC.txt");
            if (File.Exists("SN.txt"))
                File.Delete("SN.txt");
            if (File.Exists(p.SNFolder + p.LeftASN))
                File.Delete(p.SNFolder + p.LeftASN);
            if (File.Exists(p.SNFolder + p.LeftBSN))
                File.Delete(p.SNFolder + p.LeftBSN);
            if (File.Exists(p.SNFolder + p.RightASN))
                File.Delete(p.SNFolder + p.RightASN);
            if (File.Exists(p.SNFolder + p.RightBSN))
                File.Delete(p.SNFolder + p.RightBSN);

        }

        private void comboCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDeviceIndex = comboCam.SelectedIndex;
            string str = videoDevices[selectedDeviceIndex].MonikerString.ToUpper();
            int i1st = str.LastIndexOf('?');
            int ilast = str.LastIndexOf('{');
            txtHWID.Text = str.Substring(i1st + 2, ilast- i1st - 2);
        }


        /// <summary>
        /// 創建ini配置檔并加載初始化值
        /// </summary>
        /// <param name="inifilepath">配置檔地址</param>
        /// <returns></returns>
        private void createIniFile(string inifilepath)
        {
            FileStream fs = File.Create(inifilepath);
            fs.Close();
            IniFile.IniWriteValue("SysConfig", "SysVersion", ProductVersion, inifilepath);
            IniFile.IniWriteValue("SysConfig", "SNFolder", p.SNFolder, inifilepath);
            IniFile.IniWriteValue("SysConfig", "LeftAHWID", p.LeftAHWID, inifilepath);
            IniFile.IniWriteValue("SysConfig", "LeftBHWID", p.LeftBHWID, inifilepath);
            IniFile.IniWriteValue("SysConfig", "RightAHWID", p.RightAHWID , inifilepath);
            IniFile.IniWriteValue("SysConfig", "RightBHWID", p.RightBHWID , inifilepath);
            IniFile.IniWriteValue("SysConfig", "LeftASN", p.LeftASN, inifilepath);
            IniFile.IniWriteValue("SysConfig", "LeftBSN", p.LeftBSN, inifilepath);
            IniFile.IniWriteValue("SysConfig", "RightASN", p.RightASN, inifilepath);
            IniFile.IniWriteValue("SysConfig", "RightBSN", p.RightBSN, inifilepath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inifilepath"></param>
        private void loadConfigData(string inifilepath)
        {
           p.SNFolder  = IniFile.IniReadValue("SysConfig", "SNFolder", inifilepath);
           p.LeftAHWID   = IniFile.IniReadValue("SysConfig", "LeftAHWID", inifilepath);
           p.LeftBHWID = IniFile.IniReadValue("SysConfig", "LeftBHWID", inifilepath);
           p.RightAHWID = IniFile.IniReadValue("SysConfig", "RightAHWID", inifilepath);
           p.RightBHWID = IniFile.IniReadValue("SysConfig", "RightBHWID", inifilepath);
           p.LeftASN = IniFile.IniReadValue("SysConfig", "LeftASN", inifilepath);
           p.LeftBSN = IniFile.IniReadValue("SysConfig", "LeftBSN", inifilepath);
           p.RightASN = IniFile.IniReadValue("SysConfig", "RightASN", inifilepath);
           p.RightBSN = IniFile.IniReadValue("SysConfig", "RightBSN", inifilepath);
 
        }



        private void txtSNFolder_DoubleClick(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSNFolder.Text = fbd.SelectedPath;
                p.SNFolder = fbd.SelectedPath;
                IniFile.IniWriteValue("SysConfig", "SNFolder", p.SNFolder);
                
            }

        }

        private void txtSNFolder_TextChanged(object sender, EventArgs e)
        {
            p.SNFolder = txtSNFolder.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "SNFolder", p.SNFolder, p.IniFile);
        }

        private void btnRefreshCam_Click(object sender, EventArgs e)
        {

            comboCam.Items.Clear();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {

                for (int i = 0; i < videoDevices.Count; i++)
                {
                    comboCam.Items.Add(videoDevices[i].Name);
                }

                comboCam.SelectedIndex = 0;
                selectedDeviceIndex = 0;
            }
      
        }

        private void txtLeftASN_TextChanged(object sender, EventArgs e)
        {
            p.LeftASN = txtLeftASN.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "LeftASN", p.LeftASN, p.IniFile);
        }

        private void txtLeftBSN_TextChanged(object sender, EventArgs e)
        {
            p.LeftBSN = txtLeftBSN.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "LeftBSN", p.LeftBSN, p.IniFile);
        }

        private void txtRightASN_TextChanged(object sender, EventArgs e)
        {
            p.RightASN = txtRightASN.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "RightASN", p.RightASN , p.IniFile);
        }

        private void txtRightBSN_TextChanged(object sender, EventArgs e)
        {
            p.RightBSN = txtRightBSN.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "RightBSN", p.RightBSN, p.IniFile);
        }

        private void txtLeftAHWID_TextChanged(object sender, EventArgs e)
        {
            p.LeftAHWID = txtLeftAHWID.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "LeftAHWID", p.LeftAHWID, p.IniFile);
        }

        private void txtLeftBHWID_TextChanged(object sender, EventArgs e)
        {
            p.LeftBHWID = txtLeftBHWID.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "LeftBHWID", p.LeftBHWID, p.IniFile);
        }

        private void txtRightAHWID_TextChanged(object sender, EventArgs e)
        {
            p.RightAHWID = txtRightAHWID.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "RightAHWID", p.RightAHWID, p.IniFile);
        }

        private void txtRightBHWID_TextChanged(object sender, EventArgs e)
        {
            p.RightBHWID = txtRightBHWID.Text.Trim();
            IniFile.IniWriteValue("SysConfig", "RightBHWID", p.RightBHWID, p.IniFile);
        }


        private int  GetCamIndexByHwid(string hwid)
        {
            int camindex = -1;
            for (int i = 0; i < videoDevices.Count; i++)
            {
                if (videoDevices[i].MonikerString.ToUpper().Contains(hwid))
                {
                    camindex = i;
                    break;
                }
            }

            return camindex;
        }



        private void CapAndRead()
        {

            while (videoSource.IsRunning )
            {
                System.Threading.Thread.Sleep(100);
                try
                {
                    CapturePic();
                    CloseCam();
                    ReadBarcode();
                    break;
                }
                catch (Exception ex)
                {

                    UpdateMsg(lstMsg, ex.Message);
                }
            }
        }


        private void CapAndRead(string bank)
        {

            while (videoSource.IsRunning)
            {
                System.Threading.Thread.Sleep(100);
                try
                {
                    CapturePic();
                    CloseCam();

                    switch (bank )
                    {
                        case "LA":
                            ReadBarcode(p.LeftASN);
                            break;
                        case "LB":
                            ReadBarcode(p.LeftBSN);
                            break;
                        case "RA":
                            ReadBarcode(p.RightASN);
                            break;
                        case "RB":
                            ReadBarcode(p.RightBSN);
                            break;
                        default:
                            break;

                    }


                    ReadBarcode();
                    break;
                }
                catch (Exception ex)
                {

                    UpdateMsg(lstMsg, ex.Message);
                }
            }
        }

    }
}
