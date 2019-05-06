cls
echo Installation et lancement des services…
%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\InstallUtil /i %~p0\Projet.ServiceWindows.GestionCloture\bin\Debug\Projet.ServiceWindows.GestionCloture.exe
sc start GestionCloture
echo Termine
cmd /Q