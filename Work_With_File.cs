using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace KNPClassificator_main.Views
{
    class Work_With_File
    {
        public string source_of_file {
            get;
            set; }

        public Dictionary<string, string> Get_Dictionary()
        {

            Dictionary<string, string> codes = new Dictionary<string, string>(); //словарь для дерева
            string line; //хранит текущую строку
            if (!File.Exists(@source_of_file))
            {
                FileStream file = new FileStream(@source_of_file, FileMode.Create); //режим добавления строки
                file.Close();

            }
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
