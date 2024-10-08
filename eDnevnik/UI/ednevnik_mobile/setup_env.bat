@echo off
setlocal enabledelayedexpansion

REM Prompt the user to input values for the keys
set /p stripePublishableKey="Enter value for stripePublishableKey: "
set /p stripeSecretKey="Enter value for stripeSecretKey: "

REM Write the values to the .env file in the ./lib directory
echo const stripePublishableKey="%stripePublishableKey%"; > ./lib/.env
echo const stripeSecretKey="%stripeSecretKey%"; >> ./lib/.env

echo .env file created successfully in ./lib directory!
pause