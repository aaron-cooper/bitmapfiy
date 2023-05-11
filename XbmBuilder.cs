using System.Text;
using System.Linq;

class XbmBuilder {
    public string CreateXbm(string name, int width, int height, List<byte> bytes){
        var string_builder = new StringBuilder();
        string_builder.AppendLine($"#define {name}_width {width}");
        string_builder.AppendLine($"#define {name}_height {height}");
        string_builder.AppendLine($"static unsigned char {name}_bits[] = {{");

        int i = 0;
        while (i < bytes.Count){
            string_builder.Append("    ");
            string_builder.Append($"0x{bytes[i]:x2}");
            i++;
            for (int j = i + 11; i < j && i < bytes.Count; i++){
                string_builder.Append($", 0x{bytes[i]:x2}");
            }
            if (i < bytes.Count){
                string_builder.AppendLine(",");
            } else {
                string_builder.AppendLine();
                string_builder.Append("};");
            }
        }
        return string_builder.ToString();
    }
}