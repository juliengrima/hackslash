#!/bin/bash

#file_path="$1"
# -i
sed '/^\s*"com\.unity\.ide\.vscode": "https:\/\/github\.com\/SwaonD\/VSCodePackage\.git",\s*$/d'
sed -e '/^\s*"com\.unity\.ide\.vscode": {/,/^\s*},\s*$/d'

#"$file_path"

#exec cat "$file_path"
