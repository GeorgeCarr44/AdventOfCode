using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    enum FileType
    {
        File,
        Dir
    }

    class StarFile
    {
        public StarFile? Parent { get; set; }
        public List<StarFile> Children { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public FileType Type { get; set; }

        public StarFile(string name, FileType type, StarFile? parent = null, List<StarFile> children = null, int size = 0)
        {
            Name = name;
            Size = size;
            Parent = parent;
            if(children == null)
            {
                Children = new List<StarFile>();
            } 
            else
            {
                Children = children;
            }

            Type = type;
        }

        public int CalculateSize()
        {
            if (Type == FileType.File)
            {
                return Size;
            }
            else if (Type == FileType.Dir && Children != null)
            {
                int fileSize = 0;

                foreach (var child in Children)
                {
                    fileSize += child.CalculateSize();
                }
                Size = fileSize;
                return Size;
            }
            else
            {
                Size = 0;
                return Size;
            }
        }

        public List<StarFile> ListAllDirectories()
        {
            if(this.Type == FileType.Dir)
            {
                var directories = new List<StarFile> { this };

                foreach (var i in this.Children)
                {
                    if (i.Type == FileType.Dir)
                    {
                        //look for sub dir
                        directories.AddRange(i.ListAllDirectories());
                    }
                }
                return directories;
            }
            else
            {
                return new List<StarFile>();
            }
        }

    }


    static class FileSystem
    {

        public static string[] Input { get; set; }
        public static void Run()
        {
            Input = File.ReadAllLines(@"Inputs\FileSystem.txt");
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var system = CreateSystemFromInput();
            system.CalculateSize();

            PrintSystem(system, 0);
            Console.WriteLine();
            Console.WriteLine("Sum");
            Console.WriteLine(SumAllDirectories(system, 100000));
        }

        private static void Part2()
        {
            int totalSpace = 70000000;
            int spaceNeeded = 30000000;
            var system = CreateSystemFromInput();
            system.CalculateSize();
            var list = system.ListAllDirectories();
            list = list.OrderBy(x => x.Size).ToList();
            foreach (var dir in list)
            {
                //Remaining space - what we want to remove >= spaceNeeded
                if(totalSpace - (system.Size - dir.Size) >= spaceNeeded)
                { 
                    Console.WriteLine($"Size:{dir.Size} - {dir.Name} {dir.Type} ");
                    break;
                
                }
            }
        }
        private static int SumAllDirectories(StarFile dir, int limit)
        {
            int sum = 0;
            if (limit == 0 || dir.Size <= limit)
                sum += dir.Size;

            foreach (var i in dir.Children)
            {
                if (i.Type == FileType.Dir)
                {
                    //look for sub dir
                    sum += SumAllDirectories(i, limit);
                }
            }
            return sum;
        }

        private static void PrintSystem(StarFile dir, int tab)
        {
            for (int i = 0; i < tab; i++)
            {
                Console.Write("   ");
            }
            Console.WriteLine($"- {dir.Name} {dir.Type} Size:{dir.Size}");

            foreach (var child in dir.Children)
            {
                PrintSystem(child, tab + 1);
            }
        }

        private static StarFile CreateSystemFromInput()
        {
            StarFile root = new StarFile("/", FileType.Dir);

            StarFile currentDir = root;

            foreach (var line in Input)
            {
                //Commands
                if (line.StartsWith("$ cd"))
                {
                    string filename = line.Split("$ cd ")[1];

                    if (filename == "/")
                    {
                        currentDir = root;
                    }
                    else if(filename == "..")
                    {
                        currentDir = currentDir.Parent;
                    }
                    else
                    {
                        //look at children
                        if(currentDir != null && currentDir.Children != null)
                            currentDir = currentDir.Children.Find(x => x.Name == filename);
                    }
                }
                else if (line.StartsWith("$ ls"))
                {

                }
                else
                {
                    var data = line.Split(" ");
                    if(currentDir != null)
                    {
                        if (data[0] == "dir")
                        {
                            currentDir.Children.Add(new StarFile(data[1], FileType.Dir, currentDir));
                        }
                        else
                        {
                            currentDir.Children.Add(new StarFile(data[1], FileType.File, currentDir, size: Convert.ToInt32(data[0])));
                        }
                    }
                }
            }
            return root;
        }
    }
}
