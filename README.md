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
  IvsProject                ; Obsahuje zdrojové kódy rozřazené do projektů (včetně profileru)  
  Makefile  
  Doxyfile  
  DOXYREADME.md                 ; Upravené README pro doxygen dokumentaci  
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
Kalkulačka je zaručeně podporována na operačních systémech:
* Windows 11 64-bit
* Windows 10 64-bit verze 1941 nebo vyšší

Po správném sestavení zdrojového kódu je kalkulačka podporována na platformách Mac, iOS a Android.  

Instalace
---------

Kalkulačka vyžaduje mít nainstalovaný [.NET 7 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

Pro provedení instalace kalkulačky je nutné nejprve extrahovat instalační soubory z případného archivu, ve kterém se nachází. 
Před zahájením certifikace je nutno přidat certifikát jako důvěryhodný. Vizuální návod včetně přeložení můžete najít [zde](https://learn.microsoft.com/en-us/dotnet/maui/windows/deployment/publish-cli?view=net-maui-7.0).

- Klikněte pravým tlačítkem myši na soubor .msix a vyberte možnost Vlastnosti.

<pre>
DigitObliterator_[verze]_[isa].msix
</pre>

- Vyberte kartu Digitální podpisy.
- Zvolte certifikát a poté Klepněte na Detaily.

- Vlastnosti panelu souboru MSIX s vybranou záložkou digitálních podpisů.

- Klepněte na Zobrazit certifikát.

- Poté vyberte Nainstalovat certifikát....

- Vyberte Moje počítače a klepněte na Další.

- Pokud se zobrazí dotaz UAC (Uživatelská kontrola účtu), zvolte Ano.

- V okně Průvodce importem certifikátů zvolte Možnost umístit všechny certifikáty do následujícího úložiště.

- Vyberte Procházet a poté zvolte úložiště Důvěryhodné osoby. Poté klepněte na OK a zavřete dialog.

- Okno průvodce importem certifikátů se zobrazeným výběrem úložiště Důvěryhodné osoby.

- Zvolte Další a poté Dokončit. Měli byste vidět dialogové okno s textem: Import byl úspěšný.

- Okno průvodce importem certifikátů s úspěšnou zprávou o importu.

- Klepněte na OK na všech oknech, která se v rámci tohoto procesu otevřela, abyste je uzavřeli.

Pro zahájení instalačního procesu spusťte výše uvedený soubor. Instalační průvodce vás provede celým procesem a nainstaluje kalkulačku na váš počítač.

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

[![License: GPL v2](https://img.shields.io/badge/License-GPL_v2-blue.svg)](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html)
