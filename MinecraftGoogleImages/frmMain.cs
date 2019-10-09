using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MinecraftGoogleImages
{
    public partial class frmMain : Form
    {
        string dataPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data");
        string dataPathWork = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data", "work");
        string dataPathOutput = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "data", "output");

        const int maxImagePerPage = 20;

        int pixelsWidth, pixelsHeight;
        ResizeMode mode;
        bool tagEnabled = false;
        string tag = string.Empty;
        int defaultIndex;
        BackgroundMode backgroundMode;
        Color backgroundColor;
        bool transOnly;
        string queryTags;


        BackgroundWorker bw = new BackgroundWorker();

        int fileCount = -1;
        int workCounter = 0;
        int timeoutCounter = 0;

        Random rnd = new Random();
        bool indexRnd = false;

        string jarPath = string.Empty;

        enum BackgroundMode
        {
            Transparent,
            FixedColor,
        }

        public frmMain()
        {
            InitializeComponent();

            cbResizeMode.SelectedIndex = 3;
            txtTag.Enabled = chbTag.Checked;
            txtImgIndex.Enabled = !chbRnd.Checked;
            cbBackground.SelectedIndex = 0;
            backgroundColor = Color.White;
            visuBackground.BackColor = backgroundColor;

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbStatus.Value = 100;
            if ((int)e.Result == 2)
                btnUpdate.PerformClick();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Get files count to report progress
                int arg = (int)e.Argument;
                if (arg == 1)
                {
                    workCounter = 0;
                    WriteStatus("Getting images...");
                    // Create directory
                    if (!Directory.Exists(dataPathOutput))
                        Directory.CreateDirectory(dataPathOutput);

                    GetImages(dataPathWork);
                    Console.WriteLine("Images downloaded successfully");
                    WriteStatus("Images downloaded successfully");
                }
                else if (arg == 2)
                {
                    if (jarPath == string.Empty)
                        jarPath = dataPath;
                    WriteStatus("Extracting...");
                    // Extraire toutes les images du jar dans le dossier output
                    ExtractJarToOutput(".png");
                }
                e.Result = e.Argument;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ShowError(ex.ToString());
                throw;
            }
        }

        public enum ResizeMode
        {
            Resize,
            KeepX,
            KeepY,
            Shrink,
        }

        private int GetFilesCount(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            return GetFilesCount(di);
        }

        private int GetFilesCount(DirectoryInfo di)
        {
            int res = di.GetFiles().Length;

            foreach (DirectoryInfo di2 in di.EnumerateDirectories())
            {
                res += GetFilesCount(di2);
            }

            return res;
        }

        private void btnOpenDataFolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);

            Process.Start(dataPath);
        }

        private void btnExtractJar_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
            {
                MessageBox.Show("Task already running !", "Warning");
                return;
            }
            pbStatus.Value = 0;

            bw.RunWorkerAsync(2);
        }

        private void btnGetImages_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
            {
                MessageBox.Show("Task already running !", "Warning");
                return;
            }

            if (!Directory.Exists(dataPathWork))
            {
                ShowError("No data found. Run the Extract jar before");
                return;
            }

            if (!int.TryParse(txtPixelsW.Text, out pixelsWidth))
            {
                ShowError("Invalid value for Pixel X");
                return;
            }
            if (!int.TryParse(txtPixelsH.Text, out pixelsHeight))
            {
                ShowError("Invalid value for Pixel Y");
                return;
            }
            indexRnd = chbRnd.Checked;
            if (!indexRnd)
            {
                if (!int.TryParse(txtImgIndex.Text, out defaultIndex))
                {
                    ShowError("Invalid value for default index. Must be an integer between 1 and 20");
                    return;
                }
                if (defaultIndex < 1 || defaultIndex > maxImagePerPage)
                {
                    ShowError("Invalid value for default index. Must be an integer between 1 and 20");
                    return;
                }
                defaultIndex--;
            }
            mode = (ResizeMode)cbResizeMode.SelectedIndex;
            tagEnabled = chbTag.Checked;
            tag = txtTag.Text;
            pbStatus.Value = 0;
            transOnly = chbTrans.Checked;
            backgroundMode = (BackgroundMode)cbBackground.SelectedIndex;
            queryTags = txtTags.Text;

            if (folders.Count == 0)
                btnUpdate.PerformClick();

            // Run worker
            bw.RunWorkerAsync(1);
        }

        private void ExtractJarToOutput(string filterExtension)
        {
            // Get files in data path
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            FileInfo jarFileInfo;
            if (Path.GetExtension(jarPath) == ".jar")
            {
                jarFileInfo = new FileInfo(jarPath);
            }
            else
            {
                // Search for a jar file
                DirectoryInfo di = new DirectoryInfo(jarPath);
                FileInfo[] jarFiles = di.GetFiles("*.jar");

                if (jarFiles.Length == 0)
                {
                    ShowError("No minecraft.jar detected in data folder !");
                    return;
                }

                // Get first file
                jarFileInfo = jarFiles.FirstOrDefault();
            }

            // Create directory
            if (!Directory.Exists(dataPathWork))
                Directory.CreateDirectory(dataPathWork);

            fileCount = 0;

            // Decompress this file
            //ZipFile.ExtractToDirectory(Path.Combine(jarFileInfo.FullName, "assets"), dataPathExtracted);
            ZipArchive zipArchive = ZipFile.Open(jarFileInfo.FullName, ZipArchiveMode.Read);
            // Extract only png files (defined by param filterExtension)
            foreach (ZipArchiveEntry entry in zipArchive.Entries)
            {
                string ext = Path.GetExtension(entry.FullName);
                Console.WriteLine("Found : " + entry.FullName + " || Extension : " + ext);
                if (ext == filterExtension)
                {
                    Console.WriteLine("Extracting it...");
                    string extractPath = Path.Combine(dataPathWork, entry.FullName);
                    if (!Directory.Exists(Path.GetDirectoryName(extractPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(extractPath));

                    entry.ExtractToFile(extractPath, true);
                    fileCount++;
                    if (bw.CancellationPending)
                    {
                        // Cancel
                        Console.WriteLine("Cancel requested");
                        WriteStatus("Cancel requested");
                        return;
                    }
                }
            }

            Console.WriteLine("Successfully extracted");
            WriteStatus("Extraction complete");
        }

        private void GetImages(string parentDir)
        {
            GetImages(new DirectoryInfo(parentDir), string.Empty);
        }

        private void GetImages(DirectoryInfo di, string parent)
        {
            // Check if this folder is enabled
            if (di.FullName != dataPathWork)
            {
                parent = Path.Combine(parent, di.Name);
                if (!folders[parent].Checked)
                    return;
            }

            Console.WriteLine("Retrieving images for : " + di.FullName);
            // Get all files
            foreach (FileInfo file in di.EnumerateFiles())
            {
                if (bw.CancellationPending)
                {
                    // Cancel
                    Console.WriteLine("Cancel requested");
                    WriteStatus("Cancel requested");
                    return;
                }
                timeoutCounter = 0;
                if (indexRnd)
                    defaultIndex = rnd.Next(0, maxImagePerPage + 1);
                GetImageForFile(file, defaultIndex, mode);
            }

            // Recursive call of child directories
            foreach (DirectoryInfo diChild in di.EnumerateDirectories())
            {
                if (bw.CancellationPending)
                {
                    // Cancel
                    Console.WriteLine("Cancel requested");
                    WriteStatus("Cancel requested");
                    return;
                }
                GetImages(diChild, parent);
            }
            if (di.GetFiles().Length == 0 && di.GetDirectories().Length == 0 && di.FullName != dataPathWork)
                di.Delete();
        }

        private void GetImageForFile(FileInfo file, int index, ResizeMode mode)
        {
            if (timeoutCounter++ >= maxImagePerPage)
            {
                ShowError("No image found for file : " + file.FullName);
                return;
            }
            // Search name
            string name = Path.GetFileNameWithoutExtension(file.Name);
            string search = name + (tagEnabled ? "+" + tag : "");
            search = search.Replace('_', '+');
            Console.WriteLine("Searching : " + search);
            string tag1 = (transOnly ? "&tbs=ic:trans" : string.Empty);
            string url = $@"https://www.google.co.uk/search?q={search}+-minecraft&tbm=isch{tag1}{queryTags}";
            Console.WriteLine("Searching : " + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            file.Delete();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string htmlContent = reader.ReadToEnd();
                // Search for image
                string[] htmlImages = htmlContent.Split(new string[] { "<img " }, StringSplitOptions.None);
                if (index + 1 >= htmlImages.Length)
                {
                    index = 0;
                    //ShowError("Index out of range");
                    return;
                }
                string htmlimage = htmlImages[index + 1];
                string[] htmlTags = htmlimage.Split('"');
                string htmlUrl = string.Empty;
                for (int i = 0; i < htmlTags.Length; i++)
                {
                    if (htmlTags[i].Contains("src"))
                    {
                        // Check for valid url
                        if (htmlTags[i + 1].Contains("http"))
                        {
                            htmlUrl = htmlTags[i + 1];
                            break;
                        }
                    }
                }

                if (htmlUrl == string.Empty)
                {
                    //ShowError("No valid picture found for this file : " + file.FullName);
                    // Retry for index + 1
                    if (index + 1 >= maxImagePerPage)
                        index = 0;
                    GetImageForFile(file, index + 1, mode);
                    return;
                }
                Console.WriteLine("Found image : " + htmlUrl);

                // Download image
                try
                {
                    string outputPath = file.FullName.Replace(dataPathWork, dataPathOutput);
                    if (!Directory.Exists(Path.GetDirectoryName(outputPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(htmlUrl, outputPath);
                    }

                    // Retrieve image
                    Image img = Image.FromFile(outputPath);
                    // Resize image
                    Bitmap bitmap = ResizeImage(img, pixelsWidth, pixelsHeight, mode);
                    img.Dispose();
                    bitmap.Save(outputPath);
                    bitmap.Dispose();
                    file.Delete();

                    workCounter++;
                    bw.ReportProgress((100 * workCounter) / fileCount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to retrieve image : " + file.FullName + " | Path was : " + htmlUrl);
                    Console.WriteLine(ex.ToString());
                    ShowError("Error retrieving image for : " + file.FullName + "\nPath was : " + htmlUrl);
                    // Retry for index + 1
                    GetImageForFile(file, index + 1, mode);
                    return;
                }
            }
            Console.WriteLine("Image complete for : " + file.FullName);
        }

        public Bitmap ResizeImage(Image image, int width, int height, ResizeMode mode)
        {
            double mod;
            int rlWidth = width;
            int rlHeight = height;
            int rlX = 0;
            int rlY = 0;

            if (mode == ResizeMode.Shrink)
            {
                // Get the smallest mod
                mod = image.Width / (float)width;
                double mod2 = image.Height / (float)height;
                if (mod >= mod2)
                    mode = ResizeMode.KeepX;
                else
                    mode = ResizeMode.KeepY;
            }

            if (mode == ResizeMode.KeepX)
            {
                mod = image.Width / (float)width;
                rlHeight = (int)Math.Round(image.Height / mod);
                // Center on Y
                rlY = (pixelsHeight - rlHeight) / 2;
            }
            else if (mode == ResizeMode.KeepY)
            {
                mod = image.Height / (float)height;
                rlWidth = (int)Math.Round(image.Width / mod);
                // Center on Y
                rlX = (pixelsWidth - rlWidth) / 2;
            }


            var destRect = new Rectangle(rlX, rlY, rlWidth, rlHeight);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    // White background, comment to have transparent background
                    if (backgroundMode == BackgroundMode.FixedColor)
                    {
                        Brush brush = new Pen(backgroundColor).Brush;
                        graphics.FillRectangle(brush, 0, 0, width, height);
                    }
                    // Draw image
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
                bw.CancelAsync();
        }

        private void chbTag_CheckedChanged(object sender, EventArgs e)
        {
            txtTag.Enabled = chbTag.Checked;
        }

        private void WriteStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
        }

        private void chbRnd_CheckedChanged(object sender, EventArgs e)
        {
            txtImgIndex.Enabled = !chbRnd.Checked;
        }

        private void btnSelJar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft", "versions");

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                jarPath = openFileDialog1.FileName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dataPathWork))
            {
                ShowError("No data found ! Extract jar first !");
                return;
            }

            // Get file count
            fileCount = GetFilesCount(dataPathWork);
            lblCount.Text = fileCount.ToString();

            // Get directories

            treeView1.Nodes.Clear();
            depthCounter = -1;
            folders.Clear();
            treeView1.Nodes.AddRange(GetTreeList(dataPathWork, string.Empty, null).ToArray());
        }

        Dictionary<string, TreeNode> folders = new Dictionary<string, TreeNode>();
        int depthCounter;
        private List<TreeNode> GetTreeList(string rootDir, string parent, TreeNode parentNode)
        {
            depthCounter++;
            List<TreeNode> res = new List<TreeNode>();
            DirectoryInfo di = new DirectoryInfo(rootDir);

            foreach (DirectoryInfo di2 in di.EnumerateDirectories())
            {
                TreeNode node = new TreeNode(di2.Name);
                folders.Add(Path.Combine(parent, di2.Name), node);
                node.Nodes.AddRange(GetTreeList(di2.FullName, Path.Combine(parent, di2.Name), node).ToArray());
                if (depthCounter < 3)
                    node.Expand();
                FilterTreeNode(node);
                res.Add(node);
            }
            depthCounter--;
            return res;
        }

        private void FilterTreeNode(TreeNode treenode)
        {
            switch (treenode.Text)
            {
                case "gui":
                case "font":
                case "colormap":
                case "dither":
                case "map":
                case "realms":
                case "effect":
                    treenode.Checked = false;
                    checkNodes(treenode, false);
                    break;
                default:
                    treenode.Checked = true;
                    break;
            }
        }

        bool busy = false;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
            }
            finally
            {
                busy = false;
            }
        }

        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
            if (check)
            {
                checkParent(node);
            }
        }

        private void checkParent(TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Parent.Checked = true;
                checkParent(node.Parent);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            pbStatus.Value = 0;
            string zipPath = Path.Combine(dataPath, "pack.zip");
            string destPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft", "resourcepacks", "GoogleImages.zip");
            if (!Directory.Exists(Path.GetDirectoryName(destPath)))
            {
                ShowError("Unable to locate %appdata%/.minecraft/resourcepacks folder");
                return;
            }
            if (!File.Exists(zipPath))
            {
                ShowError("Unable to find pack.zip. Click on Create Zip before this");
                return;
            }
            File.Copy(zipPath, destPath, true);
            pbStatus.Value = 100;
            WriteStatus("Copy complete");
        }

        private void visuBackground_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backgroundColor = colorDialog1.Color;
                cbBackground.SelectedIndex = 1;
                visuBackground.BackColor = backgroundColor;
            }
        }

        private void btnCreateZip_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dataPathOutput))
            {
                ShowError("Output folder not found !");
                return;
            }
            // Create pack.mcmeta file
            string packData = @"{""pack"":{""pack_format"": 4,""description"": ""Textures replaces by Google Images result""}}";
            File.WriteAllText(Path.Combine(dataPathOutput, "pack.mcmeta"), packData);
            // Create zip
            string zipPath = Path.Combine(dataPath, "pack.zip");
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(dataPathOutput, zipPath, CompressionLevel.Optimal, false);
            WriteStatus("Zip file created");
            pbStatus.Value = 0;
            Application.DoEvents();
            pbStatus.Value = 100;
            // Open folder
            btnOpenDataFolder.PerformClick();
        }
    }
}
