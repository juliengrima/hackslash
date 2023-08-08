#!/bin/bash

file="$1"
# use file to sed one time (solve pb that only the first sed were executed)

if [[ "$file" == "Packages/manifest.json" ]]; then
	sed '/^\s*"com\.unity\.ide\.vscode": "https:\/\/github\.com\/SwaonD\/VSCodePackage\.git",\s*$/d'
	# vscode in Packages/manifest.json
elif [[ "$file" == "Packages/packages-lock.json" ]]; then
	sed '/^\s*"com\.unity\.ide\.vscode": {/,/^\s*},\s*$/d'
	# vscode in Packages/packages-lock.json
fi
