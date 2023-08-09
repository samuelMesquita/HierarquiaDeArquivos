using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace HierarquiaDeArquivos.Classes
{
    public class DirectoryReader
    {
        public string RootDirectoryPath { get; private set; }

        public DirectoryReader(string rootPath)
        {
            UpdateRootDirectoryPath(rootPath);
        }

        public DirectoryData GetRootDirectoryData()
        {
            ThrowIfRootDirectoryPathDoesNotExists();

            var rootDirectory = new DirectoryData(RootDirectoryPath);

            AddFiles(rootDirectory);

            return rootDirectory;
        }

        private void AddFiles(DirectoryData rootDirectory, DirectoryData parent = null)
        {
            var directoryFiles = Directory.GetFiles(rootDirectory.Path);
            var childrenDirectories = Directory.GetDirectories(rootDirectory.Path);

            rootDirectory.AddFiles(directoryFiles);
            rootDirectory.UpdateParent(parent);

            foreach (var childDirectoryPath in childrenDirectories)
            {
                var childDirectory = new DirectoryData(childDirectoryPath);

                if (!(parent is  null))
                {
                    parent.AddChild(childDirectory);
                }

                AddFiles(childDirectory, rootDirectory);
            }
        }

        private void ThrowIfRootDirectoryPathDoesNotExists()
        {
            if (!Directory.Exists(RootDirectoryPath))
            {
                throw new InvalidOperationException("Diretório não existe.");
            }
        }

        public void UpdateRootDirectoryPath(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
            {
                throw new ArgumentNullException(nameof(rootPath));
            }

            RootDirectoryPath = rootPath;
        }
    }
}
