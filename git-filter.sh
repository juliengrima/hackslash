#!/bin/bash

#vscode in Packages/manifest.json
sed '/^\s*"com\.unity\.ide\.vscode": "https:\/\/github\.com\/SwaonD\/VSCodePackage\.git",\s*$/d'

#vscode in Packages/packages-lock.json
sed '/"com\.unity\.ide\.vscode": {/,/},/d'
