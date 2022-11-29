﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Mantis_tests
{
    public class FtpHelper : HelperBase
    {
        public FtpClient client;

        public FtpHelper(ApplicationManager manager) : base(manager) {
        client = new FtpClient();
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        public void BackupFile (String path)
        {
            String backupPath = path + ".bak";
            if (client.FileExists(backupPath))
            {
                return;
            }
            client.Rename(path, backupPath);
        }

        public void RestoreBackupFile(String path)
        {
            String backupPath = path + ".bak";
            if (! client.FileExists(backupPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath, path);
        }
    }
        public void Upload(String path, Stream localFile)
        {
        if (client.FileExists(path))
        {
            client.DeleteFile(path);
        }

        using (Stream ftpStream = client.OpenWrite(path))
        {
            byte[] buffer = new byte[8 * 1024];
            localFile.Read(buffer, 0, buffer.Length);
            while (count > 0)
            {
                ftpStream.Write(buffer, 0, count);
                localFile.Read(buffer, 0, buffer.Length);
            }
        }
    }
    }
