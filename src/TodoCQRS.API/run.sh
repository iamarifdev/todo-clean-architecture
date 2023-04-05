#!/bin/sh

# Run the application in the background
dotnet TodoCQRS.API.dll &

# Get the process ID of the application
APP_PID=$!

# Sleep for 2 seconds
sleep 2

# Print custom messages
echo "Application is running. Access it on the host machine using:"
echo "HTTP: http://localhost:${HTTP_PORT}/swagger/index.html"
echo "HTTPS: https://localhost:${HTTPS_PORT}/swagger/index.html"

# Wait for the application process to complete
wait $APP_PID
