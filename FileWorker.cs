using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class FileWorker
    {

        string source_of_file;
        public FileWorker(string _source)
        {
            this.source_of_file = _source;
        }
        


        Dictionary<string, string> codes = new Dictionary<string, string>(); //словарь для дерева


        public Dictionary<string, string> Get_Dictionary()
        { 
            string line; //хранит текущую строку
            using (StreamReader _sw = new StreamReader(@source_of_file, Encoding.Default))
            {
                while (!_sw.EndOfStream)
                {
                    line = _sw.ReadLine(); //Чтение построчно

                    String[] words = line.Split(new char[] { '	' }, StringSplitOptions.RemoveEmptyEntries); //деление по " " Получаем код, имя и уровень 
                    try
                    {
                        codes.Add(words[0], words[1]); //заполнение словаря  

                    }
                    catch
                    {
                        MessageBox.Show("Код классификатора не были ранее добавлены.File.txt пуст");
                    }

                }
                _sw.Close();
            }


            return codes;

        }
    }
}
