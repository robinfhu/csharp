using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Patterns
{
    abstract class FileVisitor
    {
        protected int _depth = 0;
        public abstract void visit(TextFile f);
        public abstract void visit(FolderFile f);

        public void levelUp()
        {
            _depth--;
        }

        public void levelDown()
        {
            _depth++;
        }
    }

    abstract class FileElement
    {
        protected string _filename;
        public abstract void accept(FileVisitor visitor);
        public abstract string name { get; }
    }

    class TextFile : FileElement
    {
        public TextFile(string name)
        {
            _filename = name;
        }

        public override string name
        {
            get {
                return _filename;
            }
        }

        public override void accept(FileVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class FolderFile : FileElement
    {
        private List<FileElement> _children;
        public FolderFile(string name)
        {
            _filename = name;
            _children = new List<FileElement>();
        }

        public FolderFile(string name, List<FileElement> children)
        {
            _filename = name;
            _children = children;
        }

        public override string name
        {
            get {
                return _filename;
            }
        }

        public FolderFile addFile(FileElement f)
        {
            _children.Add(f);
            return this;
        }

        public override void accept(FileVisitor visitor)
        {
            visitor.visit(this);
            visitor.levelDown();
            foreach(FileElement child in _children) {
                child.accept(visitor);
            }
            visitor.levelUp();
        }
    }


    class DirectoryPrinter : FileVisitor
    {
        public override void visit(TextFile f)
        {
            Console.WriteLine(this.getDashes() + f.name + ".txt");
        }

        public override void visit(FolderFile f)
        {
            Console.WriteLine(this.getDashes() + "[DIRECTORY]" + f.name);
        }

        private string getDashes()
        {
            string result = "";
            for (int i = 0; i < _depth; i++)
            {
                result += "-";
            }
            return result;
        }
    }

    class VisitorPattern
    {

        public static void Main(string []args) {
            FolderFile folder1 = new FolderFile("Documents");
            FolderFile folder2 = new FolderFile("TaxDocs");

            folder2.addFile(new TextFile("W2JPMorgan")).addFile(new TextFile("1099Form"));
            folder1.addFile(new TextFile("resume")).addFile(new TextFile("favorites")).addFile(folder2);

            FileVisitor visitor = new DirectoryPrinter();
            folder1.accept(visitor);
            Console.ReadLine();
        }
    }
}
