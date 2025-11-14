@echo off
echo ================================
echo     TM OS - Создание релиза
echo ================================
echo.

REM Очистка старых файлов
echo 🧹 Очистка старых файлов...
if exist "bin\Release\net8.0-windows\win-x64\publish" rmdir /s /q "bin\Release\net8.0-windows\win-x64\publish"

echo.
echo 🔨 Сборка проекта...
dotnet clean
dotnet build -c Release

echo.
echo 📦 Создание релиза...
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=false

echo.
echo 📂 Создание папки для распространения...
set RELEASE_DIR=TM_OS_v1.0_Release
if exist "%RELEASE_DIR%" rmdir /s /q "%RELEASE_DIR%"
mkdir "%RELEASE_DIR%"

echo.
echo 📋 Копирование файлов...
copy "bin\Release\net8.0-windows\win-x64\publish\MyApp.exe" "%RELEASE_DIR%\TM_OS.exe"
copy "README.md" "%RELEASE_DIR%\"
copy "LICENSE" "%RELEASE_DIR%\"
copy "CHANGELOG.md" "%RELEASE_DIR%\"

echo.
echo 📝 Создание инструкции для пользователя...
echo # TM OS - Инструкция по установке > "%RELEASE_DIR%\INSTALL.txt"
echo. >> "%RELEASE_DIR%\INSTALL.txt"
echo 🚀 Как запустить TM OS: >> "%RELEASE_DIR%\INSTALL.txt"
echo. >> "%RELEASE_DIR%\INSTALL.txt"
echo 1. Распакуйте все файлы в любую папку >> "%RELEASE_DIR%\INSTALL.txt"
echo 2. Запустите TM_OS.exe >> "%RELEASE_DIR%\INSTALL.txt"
echo 3. Наслаждайтесь! 🎉 >> "%RELEASE_DIR%\INSTALL.txt"
echo. >> "%RELEASE_DIR%\INSTALL.txt"
echo ⚙️ Системные требования: >> "%RELEASE_DIR%\INSTALL.txt"
echo - Windows 10/11 >> "%RELEASE_DIR%\INSTALL.txt"
echo - 100+ MB RAM >> "%RELEASE_DIR%\INSTALL.txt"
echo - 50+ MB свободного места >> "%RELEASE_DIR%\INSTALL.txt"
echo. >> "%RELEASE_DIR%\INSTALL.txt"
echo 💡 Все настройки сохраняются автоматически! >> "%RELEASE_DIR%\INSTALL.txt"
echo 🎮 Попробуйте ввести "2+2" в калькулятор! >> "%RELEASE_DIR%\INSTALL.txt"

echo.
echo ✅ Релиз готов в папке: %RELEASE_DIR%
echo.
echo 📁 Содержимое релиза:
dir "%RELEASE_DIR%" /b

echo.
echo 🎯 Что делать дальше:
echo 1. Заархивируйте папку %RELEASE_DIR%
echo 2. Загрузите на GitHub в раздел Releases
echo 3. Отправьте ссылку другу!
echo.
pause