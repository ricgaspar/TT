rem Tento skript slouzi pro spusteni s parametrem, ktery obsahuje jmeno suoboru napr. "runpwshell_parameter /muj_Skript.ps1"
@echo off
set curdir=%~dp0%
pushd %curdir%
title TechnolToolkit
color 0e
cls
PowerShell -NoProfile -ExecutionPolicy Bypass -File ".\%1" %2 -debug true -simulate false