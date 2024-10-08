@echo off
setlocal enabledelayedexpansion

REM Write empty values to the .env file
echo const stripePublishableKey=""; > "C:\MyProjects\eDnevnik\eDnevnik\UI\ednevnik_mobile\lib\.env"
echo const stripeSecretKey=""; >> "C:\MyProjects\eDnevnik\eDnevnik\UI\ednevnik_mobile\lib\.env"

REM Commit changes using GitHub Desktop command line
REM Adjust the path to GitHub Desktop CLI as necessary
"C:\Users\alica\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\GitHub, Inc\GitHub Desktop.lnk" /command:create-branch-and-checkout /path:"C:\path\to\your\repository"

echo Commit completed with empty .env values!
pause
