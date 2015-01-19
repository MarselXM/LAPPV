$MSBUILD = "C:\windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
& $MSBUILD /t:Clean /p:Configuration=Debug
& $MSBUILD /t:Clean /p:Configuration=Release
& $MSBUILD /t:Build /p:Configuration=Debug
& $MSBUILD /t:Build /p:Configuration=Release
