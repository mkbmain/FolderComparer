using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BackUpInSynch.CalculateMissMatches;
using BackUpInSynch.Models.ResultStructure;
using BackUpInSynch.Models.ScanStructure;

namespace BackUpInSynch.FormsAndControls.ResultsForm
{
    public  class ResultsForm : Form
    {
        private List<DirectoryResultDetails> Directories { get; set; }
        private List<FileResultDetails> Files { get; set; }
        private Panel _panel;

        public ResultsForm(DirectoryNode source, DirectoryNode destination)
        {
            AutoSize = false;
            Size = new Size(750, 600);
            Text = "Results";
            var issue = CalculateDiffrences.Issues(source.BasePath, destination.BasePath, source, destination);
            Directories = issue.DirectoryResultDetailsList;
            Files = issue.FileResultDetailsList;
            DrawWindow();
        }


        private void DrawWindow()
        {
            var location = 0;
            if (_panel != null && Controls.Contains(_panel))
            {
                Controls.Remove(_panel);
            }

            _panel = new Panel {Name = "M", Size = new Size(Width - 30, Height - 50), AutoScroll = true};

            foreach (var item in _panel.Controls.Cast<Control>())
            {
                _panel.Controls.Remove(item);
            }

            foreach (var directoryView in Directories.Select(item => new DirectoryView(item) {Top = location}))
            {
                directoryView.PathChosen += DirectoryOnPathChosen;
                location += directoryView.Height + 5;
                _panel.Controls.Add(directoryView);
            }

            foreach (var fileView in Files.Select(item => new FileView(item) {Top = location}))
            {
                fileView.PathChosen += FileOnPathChosen;
                location += fileView.Height + 5;
                _panel.Controls.Add(fileView);
            }

            Controls.Add(_panel);
        }

        private void DirectoryOnPathChosen(object sender, EventArgs e)
        {
            var item = e as DirectoryResultDetails;
            Directories = Directories.Where(f => f.Data.Id != item.Data.Id)
                .Where(f => f.Linked == null || f.Linked.Id != item.Data.Id).ToList();
            DrawWindow();
        }

        private void FileOnPathChosen(object sender, EventArgs e)
        {
            var item = e as FileResultDetails;
            Files = Files.Where(f => f.Data.Id != item.Data.Id)
                .Where(f => f.Linked == null || f.Linked.Id != item.Data.Id).ToList();
            DrawWindow();
        }
    }
}