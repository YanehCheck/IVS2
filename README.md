# 2. Projekt do IVS
Kalkulačka a profiler

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
  IvsProject                ; Obsahuje zdrojové kódy rozzařené v projektech (včetně profileru)  
  Makefile  
  Doxyfile  
debugging.png  
dokumentace.pdf  
screenshot.png  
skutecnost.txt  
hodnoceni.txt  
README.md  
LICENSE                     ; GPL v2
.gitignore  
</pre>

Rozhodli jsme se nepoužívat soubor .editorconfig, neboť jsme všichni při vývoji využívali výchozí nastavení Visual Studio (oficiální C# coding conventions).

Prostředí
---------
Kalkulačka a profiler je podporována na operačních systémech:
* Windows 11 64-bit
* Windows 10 64-bit verze 1809 nebo vyšší

[UPLOADNI INSTALACKU DO REALEASES A DOPLN KRATKY NAVOD JAK TO ZPROVOZNIT]

Autoři
------

No Risk, No Reward
- xpomik01 - Jakub Pomikálek
- xcechm13 - Roman Čechmánek
- xsalon02 - [DOPLN JMENO]
- xjanec36 - Michael Janeček

Licence
-------

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
