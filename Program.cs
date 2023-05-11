using SFML.Graphics;

class Args{
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;
}

class Program{

    private static string ProgramName = System.AppDomain.CurrentDomain.FriendlyName;
    public static void Main(string[] argv){
        var args = PraseArgs(argv);
        Image? image = null;
        try{
            image = new Image(args.Input);
        }
        catch(Exception){
            ErrorAndExit($"Could not load {args.Input}");
        }
        var bytes = ImageToBytes(image!);
        var xbmBuilder = new XbmBuilder();
        File.WriteAllText($"./{args.Output}.xbm", (new XbmBuilder()).CreateXbm(args.Output, (int)image!.Size.X, (int)image!.Size.Y, bytes));
        return;
    }
    private static Args PraseArgs(string[] args){
        if (args.Length != 2){
            ErrorAndExit("Did not understand arguments.");
        }
        return new Args{Input = args[0], Output = args[1]};
    }

    private static List<byte> ImageToBytes(Image image){
        var builder = new BitMapByteListBuilder();
        for (uint r = 0; r < image.Size.Y; r++){
            for (uint c = 0; c < image.Size.X; c++){
                builder.Append(image.GetPixel(c, r) == Color.Black); // black is the foreground color
            }
            if (r < image.Size.Y - 1){
                builder.PadCurrentByte(); // a new row can't start in the middle of a byte
            }
        }
        return builder.ToByteList();
    }
    private static void ErrorAndExit(string message){
        Console.Error.WriteLine(message);
        Environment.Exit(1);
    }
}