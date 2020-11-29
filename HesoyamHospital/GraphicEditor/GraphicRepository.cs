using System;
using System.Collections.Generic;
using System.IO;

namespace GraphicEditor
{
    class GraphicRepository
    {
        public GraphicRepository()
        {
        }

        public List<GraphicalObject> ReadFromFile(string fileName)
        {
            string path = Path.GetFullPath(fileName);
            List<GraphicalObject> list = new List<GraphicalObject>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    GraphicalObject graphical_object = ConvertLineToGraphicalObject(line);
                    list.Add(graphical_object);
                }
            }
            else
            {
                return list;
            }
            return list;
        }

        private GraphicalObject ConvertLineToGraphicalObject(string line)
        {
            string[] fields = line.Split(',');
            string type = fields[0].Trim();
            string name = fields[1].Trim();
            long width = Convert.ToInt64(fields[2]);
            long height = Convert.ToInt64(fields[3]);
            long top = Convert.ToInt64(fields[4]);
            long left = Convert.ToInt64(fields[5]);
            string shape = fields[6].Trim();

            return new GraphicalObject(type, name, width, height, top, left, shape);

        }
    }
}
