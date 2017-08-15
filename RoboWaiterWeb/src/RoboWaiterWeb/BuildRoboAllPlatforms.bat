dotnet publish --runtime win7-x64 --configuration Release
dotnet publish --runtime win10-x64 --configuration Release
dotnet publish --runtime win7-x86 --configuration Release
dotnet publish --runtime win10-x86 --configuration Release
mkdir "%UserProfile%\Desktop\Release TraficC"
"%ProgramFiles%\WinRAR\Rar.exe" a -ep1 -r "%UserProfile%\Desktop\Release TraficC\TraficC_win7-x64.rar" "bin\Release\netcoreapp1.0\win7-x64\publish" 
"%ProgramFiles%\WinRAR\Rar.exe" a -ep1 -r "%UserProfile%\Desktop\Release TraficC\TraficC_win7-x86.rar" "bin\Release\netcoreapp1.0\win7-x86\publish" 
"%ProgramFiles%\WinRAR\Rar.exe" a -ep1 -r "%UserProfile%\Desktop\Release TraficC\TraficC_win10-x64.rar" "bin\Release\netcoreapp1.0\win10-x64\publish" 
"%ProgramFiles%\WinRAR\Rar.exe" a -ep1 -r "%UserProfile%\Desktop\Release TraficC\TraficC_win10-x86.rar" "bin\Release\netcoreapp1.0\win10-x86\publish" 
pause