using System.Drawing;
using System.Windows.Forms;

namespace BackUpInSynch
{
    public partial class FolderComparer : Form
    {
        private FolderNode _folderNodeOne;
        private FolderNode _folderNodeTwo;

        private TreeView _treeViewFolderOne ;
        private TreeView _treeViewFolderTwo;
        
        public FolderComparer(FolderNode folderOne, FolderNode folderTwo)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(640, 480);
 
            _folderNodeOne = folderOne;
            _folderNodeTwo = folderTwo;
            _treeViewFolderOne = new TreeView {Nodes = {_folderNodeOne},Size = new Size(300, 350)};
            _treeViewFolderTwo = new TreeView {Nodes = {_folderNodeTwo},Size = new Size(300, 350)};
            
            _treeViewFolderOne.Location = new Point(1, 1);
            _treeViewFolderTwo.Location = new Point(_treeViewFolderOne.Right+15, 1);
            this.Controls.Add(_treeViewFolderOne);
            this.Controls.Add(_treeViewFolderTwo);
        }
    }
}