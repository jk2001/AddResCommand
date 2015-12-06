md ucspackages\%1
md ucspackages\%1\gamefiles
md ucspackages\%1\lib
md ucspackages\%1\tools
md ucspackages\%1\logs
xcopy "Ultrapowa Clash Server\bin\Debug\gamefiles" ucspackages\%1\gamefiles /s /e /I
rem copy "Ultrapowa Clash Server\bin\Release\gamefiles\fingerprint.json" ucspackages\%1\gamefiles\fingerprint.json.backup
xcopy "Ultrapowa Clash Server\bin\Debug\x64" ucspackages\%1\lib\x64 /s /e /I
xcopy "Ultrapowa Clash Server\bin\Debug\x86" ucspackages\%1\lib\x86 /s /e /I
xcopy "Ultrapowa Clash Server\bin\Debug\*.dll" ucspackages\%1\lib
xcopy "Ultrapowa Clash Server\bin\Debug\ucs.exe" ucspackages\%1
xcopy "Ultrapowa Clash Server\bin\Debug\ucs.exe.config" ucspackages\%1
xcopy "Ultrapowa Clash Server\bin\Debug\ucsconf.config" ucspackages\%1
xcopy "Ultrapowa Clash Server\bin\Debug\tools\*.*" ucspackages\%1\tools
xcopy ucsbuildsha.exe ucspackages\%1\tools
xcopy gen_patch.bat ucspackages\%1\tools
xcopy ucsgflzma.exe ucspackages\%1\tools
xcopy ucsdb.sql ucspackages\%1\tools
xcopy ucsdb ucspackages\%1
xcopy readme.txt ucspackages\%1
md ucspackages\%1\filter
break>"ucspackages\%1\filter\filter.txt"
