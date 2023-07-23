using System.Text.RegularExpressions;

namespace SketchupConvertVersion
{
    internal class SketchupAPI
    {
        private int version;
        private string newDirectory;
        private string oldDirectory;
        private static Semaphore _semaphore = new Semaphore(1,1);
        public SketchupAPI(int version, string newDirectory, string oldDirectory)
        {
            this.version = version;
            this.newDirectory = newDirectory;
            this.oldDirectory = oldDirectory;
        }

        public bool convertSingel(ProgressBar progressBar)
        {
            String newName = this.newDirectory.Replace(".skp", "_" + this.version.ToString() + ".skp");
           if (BUAPI.BUSaveAs(this.oldDirectory, newName, this.version))
            {
                progressBar.Value = 100;
                return true;
            }
            return false;
        }

        public bool Convert(ProgressBar progressBar)
        {
            List<String> files = this.getFileList();
            if (files == null) return false;
            List<String> fileError = new List<String>();
            int  progressCount = (int) Math.Ceiling(100.00 / files.Count);
            foreach(var file in files)
            {
               if (!BUAPI.BUSaveAs(oldDirectory + "/" + file, newDirectory + "/" + file, this.version))
               {
                   fileError.Add(file + "\n");
               }
               if (progressBar.Value > progressBar.Value + progressCount)
                {
                    progressBar.Value += progressCount;
                } else
                {
                    progressBar.Value = 100;
                }
            }
            if (fileError.Count > 0)
            {
                MessageBox.Show(fileError.ToString(), "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private List<String> getFileList()
        {
            List<String> list = new List<String>();
            DirectoryInfo d = new DirectoryInfo(this.oldDirectory);
            FileInfo[] Files = d.GetFiles("*.skp");
            foreach (FileInfo file in Files)
            {
                list.Add(file.Name);
            }
            return list;
        }


    }


}
