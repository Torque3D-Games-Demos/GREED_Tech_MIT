:: clean_msvc.cmd
::
:: This batch file cleans up some files that MSVC's Clean/Rebuild commands tend to miss.  In
:: particular the .ilk and .pdb files are known to get corrupted and cause all sorts of odd linker
:: linker errors, and the .ncb files can also get corrupted and cause intellisense breakges. 
::
:: Safety: This tool should be pretty safe.  It uses the command path to perform the deletion,
:: instead of relying on the CWD (which can sometimes fail to be set when working with UNCs across
:: network shares).  Furthermore, none of the files it deletes are important.  That is, they're
:: all files MSVC just rebuilds automatically next time you run/recompile.  The one minor
:: exception is *.pdb, since windows and a lot of developer tools include PDB sets to assist in
:: application debugging (however these files are by no means required by any software).

:: 11/18/2012 : added ncb & rar filters. PLEASE ADD MORE TO REDUCE REPOSITORIES SIZE (if possible
:: binary file that is NOT necessary to the compilation
:: also fixed ilk, why it does look everywhere but in bin folders only ? wtf ?

::del /s "%~dp0\*.ncb"
del /s "%~dp0\*.obj"
del /s "%~dp0\*.ncb"
del /s "%~dp0\*.rar"
del /s "%~dp0\*.ilk"
del /s "%~dp0\*.idb"
del /s "%~dp0\*.bsc"
del /s "%~dp0\*.sbr"
del /s "%~dp0\*.pch"
del /s "%~dp0\*.pdb"
:: added a .user mask 12/30/2013
del /s "%~dp0\*.user"
:: added a .suo mask 12/30/2013
del /s "%~dp0\*.suo"
:: added a .sdf mask 01/14/2014
del /s "%~dp0\*.sdf"
del /s /q "%~dp0\deps"

:: These two can't be used currently because they match unwanted 4+ letter extensions, such
:: as *.resx and *.tmpl ... wow, stupid. >_<

:: del /s "%~dp0\*.tmp"
:: del /s "%~dp0\*.res"
pause