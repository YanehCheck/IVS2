# Kalkulačka

Použité technologie a závislosti
--------
- Jazyk - C#
- Framework - .NET 7
- UI Framework - MAUI
- Unit Test Frameworks - xUnit
- Pro překlad použito Visual Studio 2022

Struktura repozitáře
---------
<pre>
.github/workflows           ; Github Actions  
mockup/  
plan/  
resources/                  ; Obsahuje ikony  
profiling/  
src/  
  IvsProject                ; Obsahuje zdrojové kódy rozřazené do projektů (včetně profileru)  
  Makefile  
  Doxyfile  
  DOXYREADME.md		    ; Dokument, který právě čtete
debugging.png  
dokumentace.pdf  
screenshot.png  
skutecnost.txt  
hodnoceni.txt  
README.md  
LICENSE                     ; GPL v2
.gitignore  
</pre>

Prostředí
---------
Kalkulačka je zaručeně podporována na operačních systémech:
* Windows 11 64-bit
* Windows 10 64-bit verze 1941 nebo vyšší

Po správném sestavení zdrojového kódu je kalkulačka podporována na platformách Mac, iOS a Android.  

Instalace
---------

Kalkulačka vyžaduje mít nainstalovaný [.NET 7 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

Pro provedení instalace kalkulačky je nutné nejprve extrahovat instalační soubory z případného archivu, ve kterém se nachází. 
Následně stačí spustit MSIX soubor pojmenovaný ve formátu:
<pre>
DigitObliterator_[verze]_[isa].msix
</pre>

Po zahájení instalačního procesu vás instalační průvodce provede celým procesem a nainstaluje kalkulačku na váš počítač.

Pro kompletní odinstalaci je k dispozici [standardní odinstalační funkce operačního systému Windows](https://support.microsoft.com/cs-cz/windows/odinstalace-nebo-odebrání-aplikací-a-programů-ve-windows-4b55f974-2cc6-2d2b-d092-5905080eaf98#ID0EBD=Windows_11).

Autoři
------

No Risk, No Reward
- xpomik01 - Jakub Pomikálek
- xcechm13 - Roman Čechmánek
- xsalon02 - Christian Saloň
- xjanec36 - Michael Janeček

Licence
-------

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
