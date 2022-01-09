/* 
 *  **StaticAI v1.0 by Pradosh**  
 *
 *  here is how it works:
 *  AI has 2 Phases.
 *  It will generate a random score between 0 to 100
 *  In Phase 1 it will check if the score was > 50;
 *  In Phase 2 it will check if the score was bigger than the last one if yes add it as it's didWork
 *  At last it will show how many better scores it got and the most best one
 */

using System;

// The Main AI namespace
namespace StaticAI
{
    //The Main AI class
    internal class AI
    {
        // The Main Score variable
        int[] Score = new int[32];
        int didWork;
        string Version = "v1.0.1";
        static void Main(string[] args)
        {
            AI AIreference = new AI();  // Refrence of AI so we can call it in a static function
            Console.Clear();
            Console.Title = "StaticAI" + " " + AIreference.Version;
            Console.WriteLine("Starting StaticAI...");
            Console.WriteLine();
            // you know rest
            AIreference.GenerateScores();
            AIreference.Phase1();
            AIreference.Phase2();
            AIreference.Result();

            //Add this so it doesn't close quickly
            Console.ReadKey();
            Console.Write("\b \b"); // if we press a key in keyboard that will get print I don't what just read the key so this is need
        }

        //Generate the scores
        void GenerateScores(){
            Random random = new Random();
            for(int i=0;i<Score.Length;i++){
                Score[i] = random.Next(0, 100);
            }
        }
        //The First Phase of the AI
        void Phase1(){
            for(int a=1;a<Score.Length;a++){
                if(Score[a] < 50){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed! (Phase1) {0}", Score[a]);
                    Console.ResetColor();
                }else{
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Passed! (Phase1) {0}", Score[a]);
                    Console.ResetColor();
                    didWork++;
                }
            }
        }

        //The Second Phase of AI
        void Phase2(){
            for(int a=1;a<Score.Length;a++){
                if(Score[a] > Score[a - 1]){
                    if(Score[a] > 50){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Passed! 2nd checking (Phase2) {0}", Score[a]);
                        Console.ResetColor();
                        didWork++;
                    }
                }else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed! (Phase2) {0}", Score[a]);
                    Console.ResetColor();
                }
            }
        }

        void Result(){
            int biggest = Score[0];
            for(int i = 1;i < Score.Length;++i)
            {
            	if(Score[i] > biggest)
                {
                 	biggest = Score[i]; 
                }
            }
            Console.WriteLine("Learned: {0} best is: {1}", didWork, biggest);
        }
    }
}
