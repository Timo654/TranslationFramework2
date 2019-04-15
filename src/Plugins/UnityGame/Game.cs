﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using TF.Core.Entities;
using UnityGame.Files;

namespace UnityGame
{
    public abstract class Game : IGame
    {
        public virtual string Id { get; }
        public virtual string Name { get; }
        public virtual string Description { get; }
        public virtual Image Icon { get; }
        public virtual int Version { get; }
        public virtual Encoding FileEncoding { get; }

        public virtual GameFileContainer[] GetContainers(string path)
        {
            var result = new List<GameFileContainer>();
            return result.ToArray();
        }

        public virtual void ExtractFile(string inputFile, string outputPath)
        {
            var fileName = Path.GetFileName(inputFile);
            var extension = Path.GetExtension(inputFile);

            if (extension.StartsWith(".unity3d"))
            {
                Unity3DFile.Extract(inputFile, outputPath);
            }
        }

        public virtual void RepackFile(string inputPath, string outputFile, bool compress)
        {
            var fileName = Path.GetFileName(outputFile);
            var extension = Path.GetExtension(outputFile);

            if (extension.StartsWith(".unity3d"))
            {
                Unity3DFile.Repack(inputPath, outputFile, compress);
            }
        }
    }
}
