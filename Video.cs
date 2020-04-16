using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cytPSV.Pluralsight.Domain;
using Ookii.Dialogs.WinForms;

namespace cytPSV
{
    static class Video
    {
        public static string[] selectedPsvList;
        public static string[] selectedPsvSafeNameList;

        public static string currentPsvName;
        public static string currentWorkingDirectory;

        public static string currentMp4SafeName;
        public static string currentMp4Name;

        static byte[] psvBuffer;

        private static string fileName;
        private static VistaFolderBrowserDialog openFolder;

        static IEnumerable<string> EnumerateFilesRecursive(string root, string pattern = "*")
        {
            var todo = new Queue<string>();
            todo.Enqueue(root);
            while (todo.Count > 0)
            {
                string dir = todo.Dequeue();
                string[] subdirs = new string[0];
                string[] files = new string[0];
                try
                {
                    subdirs = Directory.GetDirectories(dir);
                    files = Directory.GetFiles(dir, pattern);
                }
                catch (IOException)
                {
                }
                catch (System.UnauthorizedAccessException)
                {
                }

                foreach (string subdir in subdirs)
                {
                    todo.Enqueue(subdir);
                }
                foreach (string filename in files)
                {
                    yield return filename;
                }
            }
        }

        public static void OpenPsv()
        {
            openFolder = new VistaFolderBrowserDialog();

            string selectedRootDir;
            bool deleteProcessedFiles = false;

            /*
             * foreach (string file in allFiles)
            {
                Terminal.Term.Display($"Processed: {file}");
                if (deleteProcessedFiles)
                    File.Delete(file);
            }
            if (deleteProcessedFiles)
                    Directory.Delete(selectedRootDir, true);      
             */

            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                //selectedPsvList = openFile.FileNames;
                selectedRootDir = openFolder.SelectedPath;
                //selectedRootDir = openFile.FileNames[0].Replace(openFile.SafeFileNames[0], "");

                IEnumerable<string> allFiles = EnumerateFilesRecursive(selectedRootDir);

                //FrmHome.Terminal.Display($"Total files: {selectedPsvList.Length}\n");

                foreach(var file in allFiles)
                {
                    //Terminal.Term.Display(file.ToString() + "\n");
                    currentPsvName = file;
                    if (!(currentPsvName.EndsWith(".psv") || currentPsvName.EndsWith(".mp4")))
                    {
                        Terminal.Term.Display($"{currentPsvName}\n");
                        Terminal.Term.Display($"Not a PSV or MP4 file\n\n");
                        continue;
                    }

                    Terminal.Term.Display($"Processing: {currentPsvName}\n");

                    //Terminal.Term.Display(currentPsvName);
                    if (deleteProcessedFiles)
                        currentMp4Name = String.Concat($"{file}.mp4");
                    else
                        currentMp4Name = currentPsvName;

                    FileStream fs = new FileStream(currentPsvName, FileMode.OpenOrCreate, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(fs);

                    psvBuffer = reader.ReadBytes((int)fs.Length);

                    /*
                    Terminal.Term.Display("Initial magic bytes:");
                    for (int i=0; i<3; i++)
                    {
                        Terminal.Term.Display($"psvBuffer[{i}] = {psvBuffer[i]}");
                    }
                    */


                    string fileStatus = "Unknown";
                    if (psvBuffer[0] == 0 && psvBuffer[1] == 0 && psvBuffer[2] == 0)
                    {
                        fileStatus = "Already Decrypted";
                        Terminal.Term.Display($"{fileStatus} Skipping...\n\n");
                        continue;
                    }
                    else if (psvBuffer[0] == 't' && psvBuffer[1] == 'a' && psvBuffer[2] == 's' && psvBuffer[3] != '$')
                    {
                        fileStatus = "Corrupted";
                        Terminal.Term.Display("Damaged psv file found. Repairing...\n");
                        VideoEncryptionV2.XorBuffer(psvBuffer, psvBuffer.Length, 0);
                        Terminal.Term.Display("Successfully Repaired!\n");
                    }

                    Terminal.Term.Display("Trying to Decrypt the Video\n");
                    VideoEncryptionV2.XorBufferV2(psvBuffer, psvBuffer.Length, 0);

                    if (psvBuffer[0] == 0 && psvBuffer[1] == 1 && psvBuffer[2] == 2 && psvBuffer[3].ToString() == "$")
                        Terminal.Term.Display("Successfully Decrypted!");

                    /*
                     * Terminal.Term.Display("Final magic bytes:");
                    for (int i = 0; i < 3; i++)
                    {
                        Terminal.Term.Display($"psvBuffer[{i}] = {psvBuffer[i]}\n");
                    }
                    */


                    reader.Close();
                    fs.Close();

                    if (deleteProcessedFiles)
                    {
                        File.Delete(currentPsvName);
                    }


                    File.WriteAllBytes(currentMp4Name, psvBuffer);
                    Terminal.Term.Display($"Video Saved as: {currentMp4Name}\n" + '*' * 15 + "\n\n");


                }
                /*
                for (int i=0; i<selectedPsvList.Length; i++)
                {
                    currentPsvName = selectedPsvList[i];
                    currentMp4Name = String.Concat($"{currentPsvName}._repaired.mp4");

                    Terminal.Term.Display($"Processing: {currentPsvName}");

                    FileStream fs = new FileStream(currentPsvName,FileMode.OpenOrCreate, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(fs);

                    psvBuffer = reader.ReadBytes((int)fs.Length);

                    VideoEncryptionV2.XorBuffer(psvBuffer, psvBuffer.Length, 0);
                    Terminal.Term.Display("Successfully Repaired!\n");
                    Terminal.Term.Display("Decrypting the Video");
                    VideoEncryptionV2.XorBufferV2(psvBuffer, psvBuffer.Length, 0);

                    File.WriteAllBytes(currentMp4Name, psvBuffer);
                    Terminal.Term.Display($"Video Saved as: {currentMp4Name}");
                    Terminal.Term.Display("Do you want to delete the processed videos? (Y/N): ");

                    reader.Close();
                    fs.Close();

                    if (deleteProcessedFiles)
                        File.Delete(currentPsvName);
                }
                */

                Terminal.Term.Display("All operations completed successfully!\n");

                return;
            }
        }
    }
}
