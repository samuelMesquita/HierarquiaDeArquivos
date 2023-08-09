using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace HierarquiaDeArquivos.Classes
{
    public class DirectoryData
    {
        public DirectoryData? Parent { get; private set; }
        public bool IsRoot => Parent is null;

        private readonly List<string> _files;
        public IReadOnlyCollection<string> Files => _files.AsReadOnly();

        private readonly List<DirectoryData> _children;
        public IReadOnlyCollection<DirectoryData> Children => _children.AsReadOnly();

        public string Path { get; private set; }

        public DirectoryData(string path)
        {
            Path = path;
            _files = new List<string>();
            _children = new List<DirectoryData>();
        }

        public void AddFiles(IEnumerable<string> files)
        {
            _files.AddRange(files);
        }

        public void UpdateParent(DirectoryData parent)
        {
            Parent = parent;
        }

        public void AddChild(DirectoryData child)
        {
            _children.Add(child);
        }

    }
}
