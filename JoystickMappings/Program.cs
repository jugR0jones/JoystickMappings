namespace JoystickMappings;

internal static class Program
{
    public static (float outputX, float outputY) AiAssistantSquareToCircleMapping(in float x, in float y)
    {
        float outputX = x * (float)Math.Sqrt(1.0f - (y * y) / 2.0f);
        float outputY = y * (float)Math.Sqrt(1.0f - (x * x) / 2.0f);
        
        return (outputX, outputY);
    } 
    
    private static (float outputX, float outputY) SquelchedGridOpenMapping(in float inputX,in float inputY)
    {
        float inputXSquared = inputX * inputX;
        float inputYSquared = inputY * inputY;
        float denominator = 1.0f - (inputXSquared * inputYSquared);

        float outputX = inputX * (float)Math.Sqrt((1.0f - inputYSquared) / denominator);
        float outputY = inputY * (float)Math.Sqrt((1.0f - inputXSquared) / denominator);

        return (outputX, outputY);
    }
    
    private static (float outputX, float outputY) TwoSquircularMapping(in float inputX,in float inputY)
    {
        float inputXSquared = inputX * inputX;
        float inputYSquared = inputY * inputY;
        float denominator = (float)Math.Sqrt(1.0f + inputXSquared * inputYSquared);

        float outputX = inputX / denominator;
        float outputY = inputY / denominator;

        return (outputX, outputY);
    }
    
    private static void Main(string[] args)
    {
        for (float x = -1.0f; x <= 1.0f; x += 0.01f)
        {
            (float outputX1, float outputY1) = AiAssistantSquareToCircleMapping(in x, 1.0f);
            (float outputX2, float outputY2) = SquelchedGridOpenMapping(in x, 1.0f);
            (float outputX3, float outputY3) = TwoSquircularMapping(in x, 1.0f);
            Console.WriteLine("[outputX, outputY]: [" + outputX1 + ", " + outputY1 + "] [" + outputX2 + ", " + outputY2 + "] [" + outputX3 + ", " + outputY3 + "]");
        }
    }
}