using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow + 1, i));

                engine.AddObject(currBlock);
            }
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow + 2, i));

                engine.AddObject(currBlock);
            }
            for (int i = startCol; i < endCol / 3; i++)
            {
                UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(startRow + 4, i));

                engine.AddObject(currBlock);
            }

            // Exploding blocks. Chain reaction :)
            for (int i = endCol/2; i < endCol; i++)
            {
                ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow + 3, i));

                engine.AddObject(currBlock);
            }
            
            //Gift testGift = new Gift(new MatrixCoords(10, 20));
            //engine.AddObject(testGift);

            GiftBlock giftBlock = new GiftBlock(new MatrixCoords(7, 25));
            engine.AddObject(giftBlock);

            // TASK 1
            startCol = 0;
            endCol = WorldRows - 1;

            for (int i = startRow; i < endCol; i++) // LEFT SIDE
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(i, startCol));

                engine.AddObject(currBlock);
            }

            startCol = WorldCols - 1;

            for (int i = startRow; i < endCol; i++) // RIGHT SIDE
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(i, startCol));

                engine.AddObject(currBlock);
            }

            startRow = 2;
            startCol = 0;
            endCol = WorldCols;

            for (int i = startCol; i < endCol; i++) // CEILING
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // END TASK 1

            // Bellow the three balls are added to the engine
            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            MeteoriteBall theMeteoriteBall = new MeteoriteBall(new MatrixCoords(20, 9),
                new MatrixCoords(-1, 1));

            UnstoppableBall theUnstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 25),
               new MatrixCoords(-1, 1));

            engine.AddObject(theBall);
            engine.AddObject(theMeteoriteBall);
            engine.AddObject(theUnstoppableBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
            

            // Part of TASK 5
            //TrailObject trailObject = new TrailObject(new MatrixCoords(10, 20), 5);

            //engine.AddObject(trailObject);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingEngine gameEngine = new ShootingEngine(renderer, keyboard);
            
            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            // TASK 13
            // Allows shooting
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };
            // END TASK 13
            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
