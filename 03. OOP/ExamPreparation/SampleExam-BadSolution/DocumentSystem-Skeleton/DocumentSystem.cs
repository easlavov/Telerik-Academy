using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        static List<Document> documents = new List<Document>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);


            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            // AddTextDocument[name=…;charset=…;content=…] 
            attributes = Extraction(attributes);
            //
            string name = null;
            string charset = null;
            string content = null;
            int currentAttrib = 0;
            while (currentAttrib < attributes.Length)
            {
                if (attributes[currentAttrib] == "name")
                {
                    name = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "charset")
                {
                    charset = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "content")
                {
                    content = attributes[currentAttrib + 1];
                }
                currentAttrib += 2;
            }
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return;
            }
            documents.Add(new TextDocument(name, charset, content));
            Console.WriteLine("Document added: {0}", name);
        }



        private static void AddPdfDocument(string[] attributes)
        {
            // AddPDFDocument[name=…;pages=…;size=…;content=…] 
            attributes = Extraction(attributes);
            //
            string name = null;
            string content = null;
            int? size = null;
            int? pages = null;
            int currentAttrib = 0;
            while (currentAttrib < attributes.Length)
            {
                if (attributes[currentAttrib] == "name")
                {
                    name = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "content")
                {
                    content = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "size")
                {
                    size = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "pages")
                {
                    pages = int.Parse(attributes[currentAttrib + 1]);
                }
                currentAttrib += 2;
            }
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return;
            }
            documents.Add(new PDFDocument(name, content, size, pages));
            Console.WriteLine("Document added: {0}", name);
        }

        private static void AddWordDocument(string[] attributes)
        {
            // AddWordDocument chars=…;name=…;version=…;size=…;content=…]
            attributes = Extraction(attributes);
            //
            string name = null;
            string content = null;
            int? size = null;
            string version = null;
            int? chars = null;
            int currentAttrib = 0;
            while (currentAttrib < attributes.Length)
            {
                if (attributes[currentAttrib] == "name")
                {
                    name = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "content")
                {
                    content = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "size")
                {
                    size = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "chars")
                {
                    chars = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "version")
                {
                    version = attributes[currentAttrib + 1];
                }
                currentAttrib += 2;
            }
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return;
            }
            documents.Add(new WordDocument(name, content, size, version, chars));
            Console.WriteLine("Document added: {0}", name);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            // AddExcelDocument[rows=…;cols=…;version=…;size=…;name=…;content=…]
            attributes = Extraction(attributes);
            //
            string name = null;
            string content = null;
            int? size = null;
            string version = null;
            int? rows = null;
            int? cols = null;
            int currentAttrib = 0;
            while (currentAttrib < attributes.Length)
            {
                if (attributes[currentAttrib] == "name")
                {
                    name = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "content")
                {
                    content = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "size")
                {
                    size = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "rows")
                {
                    rows = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "cols")
                {
                    cols = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "version")
                {
                    version = attributes[currentAttrib + 1];
                }
                currentAttrib += 2;
            }
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return;
            }
            documents.Add(new ExcelDocument(name, content, size, version, rows, cols));
            Console.WriteLine("Document added: {0}", name);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            // AddAudioDocument[name=…;content=…;samplerate=…;length=…;size=…]
            attributes = Extraction(attributes);
            //
            string name = null;
            string content = null;
            int? sampleRate = null;
            int? length = null;
            int? size = null;
            int currentAttrib = 0;
            while (currentAttrib < attributes.Length)
            {
                if (attributes[currentAttrib] == "name")
                {
                    name = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "content")
                {
                    content = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "size")
                {
                    size = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "length")
                {
                    length = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "samplerate")
                {
                    sampleRate = int.Parse(attributes[currentAttrib + 1]);
                }
                currentAttrib += 2;
            }
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return;
            }
            documents.Add(new AudioDocument(name, content, size, length, sampleRate));
            Console.WriteLine("Document added: {0}", name);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            // AddVideoDocument[name=…;content=…;framerate=…;length=…;size=…]
            attributes = Extraction(attributes);
            //
            string name = null;
            string content = null;
            int? framerate = null;
            int? length = null;
            int? size = null;
            int currentAttrib = 0;
            while (currentAttrib < attributes.Length)
            {
                if (attributes[currentAttrib] == "name")
                {
                    name = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "content")
                {
                    content = attributes[currentAttrib + 1];
                }
                else if (attributes[currentAttrib] == "size")
                {
                    size = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "length")
                {
                    length = int.Parse(attributes[currentAttrib + 1]);
                }
                else if (attributes[currentAttrib] == "framerate")
                {
                    framerate = int.Parse(attributes[currentAttrib + 1]);
                }
                currentAttrib += 2;
            }
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return;
            }
            documents.Add(new VideoDocument(name, content, size, length, framerate));
            Console.WriteLine("Document added: {0}", name);
        }

        private static void ListDocuments()
        {
            // 
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found");
            }
            foreach (var item in documents)
            {
                if (item is IEncryptable)
                {
                    IEncryptable obj = item as IEncryptable;
                    if (obj.IsEncrypted == true)
                    {
                        Console.WriteLine("{0}[encrypted]", obj.GetType().Name);
                        continue;
                    }
                }

                Type type = item.GetType();
                StringBuilder sb = new StringBuilder();
                sb.Append(type.Name + "[");
                if (type.Name == "TextDocument")
                {
                    TextDocument doc = item as TextDocument;
                    if (doc.Charset != null)
                    {
                        sb.AppendFormat("charset={0};", doc.Charset);
                    }
                    if (doc.Content != null)
                    {
                        sb.AppendFormat("content={0};", doc.Content);
                    }
                    sb.AppendFormat("name={0}", doc.Name);
                }
                else if (type.Name == "PDFDocument")
                {
                    PDFDocument doc = item as PDFDocument;
                    if (doc.Content != null)
                    {
                        sb.AppendFormat("content={0};", doc.Content);
                    }
                    sb.AppendFormat("name={0}", doc.Name);
                    if (doc.Pages != null)
                    {
                        sb.AppendFormat(";pages={0}", doc.Pages);
                    }
                    if (doc.Size != null)
                    {
                        sb.AppendFormat(";size={0}", doc.Size);
                    }
                }
                else if (type.Name == "WordDocument")
                {
                    WordDocument doc = item as WordDocument;
                    if (doc.Chars != null)
                    {
                        sb.AppendFormat("chars={0};", doc.Chars);
                    }
                    if (doc.Content != null)
                    {
                        sb.AppendFormat("content={0};", doc.Content);
                    }
                    sb.AppendFormat("name={0}", doc.Name);
                    if (doc.Size != null)
                    {
                        sb.AppendFormat(";size={0}", doc.Size);
                    }
                    if (doc.Version != null)
                    {
                        sb.AppendFormat(";version={0}", doc.Version);
                    }
                }
                else if (type.Name == "ExcelDocument")
                {
                    ExcelDocument doc = item as ExcelDocument;
                    if (doc.Cols != null)
                    {
                        sb.AppendFormat("cols={0};", doc.Cols);
                    }
                    if (doc.Content != null)
                    {
                        sb.AppendFormat("content={0};", doc.Content);
                    }
                    sb.AppendFormat("name={0}", doc.Name);
                    if (doc.Rows != null)
                    {
                        sb.AppendFormat(";rows={0}", doc.Rows);
                    }
                    if (doc.Size != null)
                    {
                        sb.AppendFormat(";size={0}", doc.Size);
                    }
                    if (doc.Version != null)
                    {
                        sb.AppendFormat(";version={0}", doc.Version);
                    }
                }
                else if (type.Name == "AudioDocument")
                {
                    AudioDocument doc = item as AudioDocument;
                    if (doc.Content != null)
                    {
                        sb.AppendFormat("content={0};", doc.Content);
                    }
                    if (doc.Length != null)
                    {
                        sb.AppendFormat("length={0};", doc.Length);
                    }
                    sb.AppendFormat("name={0}", doc.Name);
                    if (doc.Samplerate != null)
                    {
                        sb.AppendFormat(";samplerate={0}", doc.Samplerate);
                    }
                    if (doc.Size != null)
                    {
                        sb.AppendFormat(";size={0}", doc.Size);
                    }
                }
                else if (type.Name == "VideoDocument")
                {
                    VideoDocument doc = item as VideoDocument;
                    if (doc.Content != null)
                    {
                        sb.AppendFormat("content={0};", doc.Content);
                    }
                    if (doc.Framerate != null)
                    {
                        sb.AppendFormat("framerate={0};", doc.Framerate);
                    }
                    sb.AppendFormat("name={0}", doc.Name);
                    if (doc.Length != null)
                    {
                        sb.AppendFormat(";length={0}", doc.Length);
                    }
                    if (doc.Size != null)
                    {
                        sb.AppendFormat(";size={0}", doc.Size);
                    }
                }
                sb.Append("]");
                Console.WriteLine(sb.ToString());

            }
        }

        private static void EncryptDocument(string name)
        {
            // 
            bool found = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    found = true;
                    IEncryptable obj = item as IEncryptable;
                    if (obj != null)
                    {
                        obj.Encrypt();
                        Console.WriteLine("Document encrypted: {0}", name);

                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", name);
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            // 
            bool found = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    found = true;
                    IEncryptable obj = item as IEncryptable;
                    if (obj != null)
                    {
                        obj.Decrypt();
                        Console.WriteLine("Document decrypted: {0}", name);

                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", name);
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            // 
            bool found = false;
            foreach (var item in documents)
            {
                IEncryptable obj = item as IEncryptable;
                if (obj != null)
                {
                    found = true;
                    obj.Encrypt();
                }
            }
            if (found == true)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            // 
            bool found = false;
            foreach (var item in documents)
            {
                if (item.Name == name)
                {
                    found = true;
                    IEditable obj = item as IEditable;
                    if (obj != null)
                    {
                        obj.ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}", name);
                    }
                }
            }
            if (found == false)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static string[] Extraction(string[] attributes)
        {
            // AddTextDocument[name=…;charset=…;content=…] 
            string[] temp = new string[attributes.Length * 2];
            int pos = 0;
            for (int i = 0; i < attributes.Length; i++)
            {
                temp[pos] = attributes[i].Split('=')[0];
                temp[pos + 1] = attributes[i].Split('=')[1];
                pos += 2;
            }
            attributes = temp;
            return attributes;
        }
    }
}
