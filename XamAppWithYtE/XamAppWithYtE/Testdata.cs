using System;
using System.Collections.Generic;
using System.Text;

namespace XamAppWithYtE
{
    public static class Testdata
    {
        public static IEnumerable<string> StandardTestVideoIds()
        {
            yield return "9bZkp7q19f0"; // very popular
            yield return "SkRSXFQerZs"; // age restricted (embed allowed)
            yield return "hySoCSoH-g8"; // age restricted (embed not allowed)
            yield return "_kmeFXjjGfk"; // embed not allowed (type 1)
            yield return "MeJVWBSsPAY"; // embed not allowed (type 2)
            yield return "5VGm0dczmHc"; // rating not allowed
            yield return "ZGdLIwrGHG8"; // unlisted
            yield return "H1O_-JVbl_k"; // very large video
            yield return "rsAAeyAr-9Y";
            yield return "_QdPW8JrYzQ"; //with closed captions
        }

        public static IEnumerable<string> MovieTrailerTestVideoIds()
        {
            yield return "w7pYhpJaJW8"; //Alita battle angel
            yield return "U3D2vmWD88w"; //Alita battle angel
            yield return "hA6hldpSTF8"; // Avengers Endgame
            yield return "TcMBFSGVi1c"; // Avengers Endgame
            yield return "ue80QwXMRHg"; // Thor Ragnarok
            yield return "8CjYw1hARhY"; // Terminator 6
            yield return "Z1BCujX3pw8"; // Captain marvel
            yield return "g6eB0JT1DI4"; // Brightburn
            yield return "8_rTIAOohas"; // Ant man
            yield return "40ghX7dNuKI"; // Man in black
        }
    }
}
