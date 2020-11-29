
namespace GraphicEditor
{
    class GraphicalObject
    {
            public string Type { get; set; }
            public string Name { get; set; }
            public long Width { get; set; }
            public long Height { get; set; }
            public long Top { get; set; }
            public long Left { get; set; }
            public string Shape { get; set; }



            public GraphicalObject()
            {

            }

            public GraphicalObject(string type, string name, long width, long height, long top, long left, string shape)
            {
                Type = type;
                Name = name;
                Width = width;
                Height = height;
                Top = top;
                Left = left;
                Shape = shape;

            }
    }
}
