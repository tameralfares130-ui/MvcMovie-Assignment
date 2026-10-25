@echo off
cd /d "%~dp0MvcMovie"
where dotnet >nul 2>nul
if errorlevel 1 (
  echo ERROR: .NET SDK is not installed. Install .NET 10 SDK first.
  pause
  exit /b 1
)
echo Running ASP.NET Core MVC Movie Library at http://localhost:5098
echo SQL Server Express LocalDB must be installed and running.
dotnet run --launch-profile http
pause
