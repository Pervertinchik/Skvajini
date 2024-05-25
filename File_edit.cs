using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class File_edit
{
    string path_new_file;                                                         //Путь к файлу, который будет создаваться
    string path_to_read;                                                          //Путь к файлу, который читается, с координатами

    List<string> coordinates_skv = new List<string>();                            //Лист с координатами скважин по строчкам
    List<string> names_skv = new List<string>();                                  //Лист с именами скважин по строчкам
    public List<string> main_kml = new List<string>();                            //Лист, в котором содержатся все строчки текста KML


    public File_edit(string ext_path_new_file, string ext_path_to_read)
    {
        path_new_file = ext_path_new_file;
        path_to_read = ext_path_to_read;
        Write_firtst_strings_in_kml();


    }

    private void Write_firtst_strings_in_kml()                           //Добавить первые строки в KML
    {

        main_kml.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        main_kml.Add("<kml xmlns=\"http://earth.google.com/kml/2.2\">");
        main_kml.Add("  <Document>");
        main_kml.Add("    <Folder>");
        main_kml.Add("      <name>Skvajini</name>");
        main_kml.Add("      <open>1</open>");
        main_kml.Add("      <Style>");
        main_kml.Add("       <ListStyle>");
        main_kml.Add("        <listItemType>Skvajini</listItemType>");
        main_kml.Add("        <bgColor>00ffffff</bgColor>");
        main_kml.Add("       </ListStyle>");
        main_kml.Add("      </Style>");




    }

    private void Write_last_strings_in_kml()                           //Добавить последние строки в KML
    {

        main_kml.Add("    </Folder>");
        main_kml.Add("  </Document>");
        main_kml.Add("</kml>");


    }



    public void Read_Lines()
    {

        foreach (string line in File.ReadLines(path_to_read))
        {
            int dot = line.IndexOf(',');                                          //Индекс запятой, которая разделяет имя и координаты строки
            string name_line = line.Remove(dot);
            string coordinates_line = line.Remove(0,dot+1);

            names_skv.Add(name_line);
            coordinates_skv.Add(coordinates_line);

        }

    }

    public void Write_Lines()                                               //Записываются сами точки в KML
    {

        for (int i = 0; i < names_skv.Count(); i++)
        {

            main_kml.Add("      <Placemark>");
            main_kml.Add($"        <name>{names_skv[i]}</name>");
            main_kml.Add("        <description> nothing </description>");
            main_kml.Add("        <Style>");
            main_kml.Add("          <LabelIStyle>");
            main_kml.Add("            <color>A6FF0000</color>");
            main_kml.Add("            <scale>1</scale>");
            main_kml.Add("          </LabelIStyle>");
            main_kml.Add("          <IconStyle>");
            main_kml.Add("            <scale>0.5</scale>");
            main_kml.Add("            <Icon>");
            main_kml.Add("              <href>files/blue-pushpin.png</href>");
            main_kml.Add("            </Icon>");
            main_kml.Add("            <hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\"/>");
            main_kml.Add("          </IconStyle>");
            main_kml.Add("        </Style>");
            main_kml.Add("        <Point>");
            main_kml.Add("          <extrude>1</extrude>");
            main_kml.Add($"          <coordinates>{coordinates_skv[i]}</coordinates>");
            main_kml.Add("        </Point>");
            main_kml.Add("      </Placemark>");
            


        }

        Write_last_strings_in_kml();

        File.WriteAllLines(path_new_file, main_kml);

    }

    //C:\Users\cer56\OneDrive\Desktop\check.kml
    //C:\Users\cer56\OneDrive\Desktop\example.txt



}

