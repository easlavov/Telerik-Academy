@IF EXIST "%~dp0\node.exe" (
  "%~dp0\node.exe"  "%~dp0\node_modules\karma-cli\bin\karma" %*
) ELSE (
  node  "%~dp0\node_modules\karma-cli\bin\karma" %*
)