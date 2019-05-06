cls
echo Installation et lancement des services…
%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\InstallUtil /i C:\Users\alec6\source\repos\Projet.ServiceWindows.GestionCloture\Projet.ServiceWindows.GestionCloture\bin\Debug\Projet.ServiceWindows.GestionCloture.exe
sc start GestionCloture
echo Termine
cmd /k