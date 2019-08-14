using System;
using System.Collections.Generic;
using System.Text;

namespace XamAppWithYtE
{
    public static class Testdata
    {
        public static IEnumerable<string> GetVideoIds()
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

    }
}
