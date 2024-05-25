using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Создание KML документа с координатами точек");
        Console.WriteLine("Введите путь, где будет создан KML документ c названием файла и расширением kml \nПример: C:\\Users\\cer56\\OneDrive\\Desktop\\check.kml");
        string path_new_file = Console.ReadLine();
        path_new_file.Trim();
        Console.WriteLine("Введите путь, где лежит файл с координатами c названием файла и расширением txt \nПример: C:\\Users\\cer56\\OneDrive\\Desktop\\example.txt");
        string path_to_read = Console.ReadLine();
        path_to_read.Trim();                
        
        File_edit file_edit = new File_edit(path_new_file,path_to_read);   //Экземпляр класса для редактирования 
        file_edit.Read_Lines();                                            //Считать файл с координатами
        file_edit.Write_Lines();                                           //Записываются сами точки в KML



    }



}

