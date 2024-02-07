using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bfres.Structs;
using FirstPlugin;
using Toolbox.Library;
using Toolbox.Library.Forms;
using UKing.Actors;

namespace UKing.Actors.Forms
{
    public partial class BotwActorEditorControl : STUserControl
    {
        public BotwActorEditorControl()
        {
            InitializeComponent();

            stTabControl1.myBackColor = FormThemes.BaseTheme.FormBackColor;
        }

        public void LoadActor(BotwActorLoader.ActorEntry entry)
        {
            stPropertyGrid1.LoadProperty(entry.Info);

            if (entry.Models.FilePathModel != null)
            {
                BFRES bfres = (BFRES)Toolbox.Library.IO.STFileLoader.OpenFileFormat(entry.Models.FilePathModel);
                if (entry.Textures.FilePathTex1 != null)
                    Toolbox.Library.IO.STFileLoader.OpenFileFormat(entry.Textures.FilePathTex1);
                
                if (entry.Textures.FilePathTex2 != null)
                    Toolbox.Library.IO.STFileLoader.OpenFileFormat(entry.Textures.FilePathTex2);
                
                bfres.LoadEditors(null);
            }

            if (entry.Parameters.FilePathActorLink != null && entry.Nodes.Count == 0)
            {
                string imageKey = "Byaml";
                SARC link = (SARC)Toolbox.Library.IO.STFileLoader.OpenFileFormat(entry.Parameters
                    .FilePathActorLink);
                foreach (var File in link.Files)
                {
                    entry.Nodes.Add(new QuickAccessFile(File.FileName)
                    {
                        Tag = File,
                        ImageKey = imageKey,
                        SelectedImageKey = imageKey
                    });
                }
            }
        }
    }
}