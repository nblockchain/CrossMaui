#!/bin/env bash

# Use PROJECTS_TO_PACK env. var for newline-separated list of projects.

set -euxo pipefail


echo "$PROJECTS_TO_PACK" | while read -r project; do
    [ -z "$project" ] && continue  # Skip if empty
    dotnet pack "$project" --no-build --no-restore
done
