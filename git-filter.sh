#!/bin/bash

file_path="$1"

sed -i '/^\s*"com\.unity\.ide\.vscode": "https:\/\/github\.com\/SwaonD\/VSCodePackage\.git",\s*$/d' "$file_path"

exec cat "$file_path"
