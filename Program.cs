using SFML.Graphics;
using System.Text;

var image = new Image("./brick.png");
var string_builder = new StringBuilder();

for (uint i = 0; i < image.Size.Y; i++){
    for (uint j = 0; j < image.Size.X; j++){
        if (image.GetPixel(j, i) == Color.Black){
            string_builder.Append('#');
        }
        else{
            string_builder.Append(' ');
        }
    }
    string_builder.Append('\n');
}

Console.Write(string_builder);