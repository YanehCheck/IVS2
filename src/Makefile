APP_DEBUG_PATH=IvsProject\CalculatorDesktopApp\bin\Debug\net7.0-windows10.0.19041.0\win10-x64\CalculatorDesktopApp.exe
APP_RELEASE_PATH=IvsProject\CalculatorDesktopApp\bin\Release\net7.0-windows10.0.19041.0\win10-x64\CalculatorDesktopApp.exe
PROFILER_DEBUG_PATH=IvsProject\Profiler\bin\Debug\net7.0\Profiler.exe
PROFILER_RELEASE_PATH=IvsProject\Profiler\bin\Release\net7.0\Profiler.exe

all: run

run:
	@IF EXIST $(APP_DEBUG_PATH) ("$(APP_DEBUG_PATH)") ELSE ( IF EXIST $(APP_RELEASE_PATH) ("$(APP_RELEASE_PATH)") ELSE (echo First build the application -make help))

profile:
	@echo 10 20 30 40 50 60 70 80 90 100 > test_input.txt
	@IF EXIST $(PROFILER_DEBUG_PATH) ($(PROFILER_DEBUG_PATH) < test_input.txt) ELSE ( IF EXIST $(PROFILER_RELEASE_PATH) ($(PROFILER_RELEASE_PATH) < test_input.txt) ELSE (echo First build the profiler -make help))
	@del /q test_input.txt

pack:
	if exist xsalon02_xjanec36_xcechm13_xpomik01 (rmdir /q /s xsalon02_xjanec36_xcechm13_xpomik01)
	mkdir xsalon02_xjanec36_xcechm13_xpomik01
	mkdir xsalon02_xjanec36_xcechm13_xpomik01\doc
	mkdir xsalon02_xjanec36_xcechm13_xpomik01\install
	mkdir xsalon02_xjanec36_xcechm13_xpomik01\repo
	for /d %%i in (..\*) do (if not "%%~nxi"=="src" xcopy /s /h /i /y "..\%%~nxi" "xsalon02_xjanec36_xcechm13_xpomik01\repo\%%~nxi")
	for %%i in (..\*.*) do copy "%%i" "xsalon02_xjanec36_xcechm13_xpomik01\repo\"
	for /d %%i in (.\*) do (if not "%%~nxi"=="xsalon02_xjanec36_xcechm13_xpomik01" xcopy /s /h /i /y ".\%%~nxi" "xsalon02_xjanec36_xcechm13_xpomik01\repo\src\%%~nxi")
	for %%i in (.\*.*) do copy "%%i" "xsalon02_xjanec36_xcechm13_xpomik01\repo\src\"
	xcopy /e /h /y /i ..\.git xsalon02_xjanec36_xcechm13_xpomik01\repo\.git

clean:
	for /d %%i in (IvsProject\*) do (if exist "%%i\bin" rd /s /q "%%i\bin")
	for /d %%i in (IvsProject\*) do (if exist "%%i\obj" rd /s /q "%%i\obj")

help:
	@echo CALCULATOR:
	@echo Follow steps in documentation.pdf section 3.1 and 3.2.
	@echo PROFILER:
	@echo Open src\IvsProject\IvsProject.sln in Visual Studio 2022.
	@echo Open Solution Explorer, right click on Profiler and build it.