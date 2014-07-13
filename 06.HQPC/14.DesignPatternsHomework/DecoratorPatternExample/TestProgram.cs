namespace DecoratorPatternExample
{
    class TestProgram
    {
        static void Main()
        {
            // Footballer is a type of person
            var berbatov = new Footballer("Dimitar Berbatov", "Monaco");

            // The international extends the regular footballer
            var internationalBerbo = new International(berbatov);
            internationalBerbo.Greet();
            internationalBerbo.Retire();

            // The painter extends the international footballer
            var painter = new Artist(internationalBerbo);
            painter.Greet();
        }
    }
}
