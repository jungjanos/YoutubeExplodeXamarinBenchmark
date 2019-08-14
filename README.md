# YoutubeExplodeXamarinBenchmark
Benchmarking YoutubeExplode's async methods

YoutubeExplode:
https://github.com/Tyrrrz/YoutubeExplode

YoutubeExplode currently gives poor performance on Xamarin.Forms(Android) platform 
and possibly all compute-weak mobile devices.

Benchmarks .GetVideoAsync(id) and .GetVideoMediaStreamInfosAsync(id) methods with a 10 piece set of 
Youtube id-s.

PERFORMANCE:

Low end phone (Redmi 3S Prime with Qualcomm Snapdragon 430)

10x invocations:

* .GetVideoAsync() ~ 40sec 
* .GetVideoMediaStreamInfosAsync() ~ 24sec

Midrange phone (Redmi Note 5Pro with Qualcomm Snapdragon 636)

soon...

INSTALLATION:

The provided APK does not require any permission or access. 
It is hovever needed to enable the installation of "unsafe" apps from outside Google Play.

Remark: 

I have collapsed the YoutubeExplode https://github.com/Tyrrrz/YoutubeExplode code into this projects  assembly
to be able to debug it in Xamarin.Forms. 
