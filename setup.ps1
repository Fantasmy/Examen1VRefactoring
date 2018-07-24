#
# Program
# Installation of chocolatey for the automatic Installation of dependencies
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/installps1'))  
#
#Chocolatey update
choco upgrade chocolatey -Y
#
#Installing java (needed for flyway)
choco install jre8 -Y
choco install javaruntime -Y
choco install jdk8 -Y
choco install visualstudiocode -Y
#
# Installing flywaydb commandLine for the database versioning controll
choco install flyway.commandline
#
#Installing sqlcmd tool
Install-Module -Name SqlServer 
#
#Database creation (ExamenVueling)
sqlcmd -S localhost\master -i Vueling.Facade.Api\Sql\Create_Database_ExamenVueling.sql
#
#
echo "Info installation status at C:\ProgramData\chocolatey\logs\chocolatey.log"