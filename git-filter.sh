#!/bin/bash

# GIT LINES FILTER BASH PROGRAM
# to ignore a certain line :
# put this into .gitattributes : path/to/your/file filter=remove-line
# then add a new line to this programm with your condition and your sed command
# IMPORTANT : To try if it work clear cache and readd the file,
# then check if the line is added or not


file="$1"
# file sent from git (implemented to solve the issue that only the first sed were executed)

if [[ "$file" == "Packages/manifest.json" ]]; then
	sed '/^\s*"com\.unity\.ide\.vscode": "https:\/\/github\.com\/SwaonD\/VSCodePackage\.git",\s*$/d'
	# vscode in Packages/manifest.json
elif [[ "$file" == "Packages/packages-lock.json" ]]; then
	sed '/^\s*"com\.unity\.ide\.vscode": {/,/^\s*},\s*$/d'
	# vscode in Packages/packages-lock.json
fi
