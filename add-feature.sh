#!/bin/bash

# === Validate input ===
if [ -z "$1" ]; then
  BLUE='\033[1;34m'
  GREEN='\033[1;32m'
  NC='\033[0m' 
  printf "${BLUE}Usage${NC}: bash add-feature.sh ${GREEN}<FeatureName>${NC}\n"
  exit 1
fi

# === Variables ===
FEATURE_NAME=$1
BASE_DIR="./App/Features/$FEATURE_NAME"
NAMESPACE="$(basename $PWD).App.Features.$FEATURE_NAME"
PAGE=$(echo "$FEATURE_NAME" | tr '[:upper:]' '[:lower:]' | sed 's/ /-/g')

# === Create directories ===
mkdir -p "$BASE_DIR/Components"
mkdir -p "$BASE_DIR/Models"
mkdir -p "$BASE_DIR/Pages"
mkdir -p "$BASE_DIR/Services"

# === Feedback ===
echo "✅ Feature '$FEATURE_NAME' created at $BASE_DIR:"
echo "   ├── Components/"
echo "   ├── Models/"
echo "   ├── Pages/"
echo "   └── Services/"

printf "<h1>Sample $FEATURE_NAME Component</h1>" > "$BASE_DIR/Components/SampleComponent.razor"
printf "namespace $NAMESPACE.Models;\n\npublic class ${FEATURE_NAME}Model\n{\n\n}" > "$BASE_DIR/Models/${FEATURE_NAME}Model.cs"
printf "@page \"/${PAGE}\"\n@using $NAMESPACE.Components\n\n<PageTitle>$FEATURE_NAME</PageTitle>\n\n<h1>Sample $FEATURE_NAME Page</h1>\n\n<SampleComponent />" > "$BASE_DIR/Pages/${FEATURE_NAME}.razor"
printf "namespace $NAMESPACE.Services;\n\npublic interface I${FEATURE_NAME}Service\n{\n\n}" > "$BASE_DIR/Services/I${FEATURE_NAME}Service.cs"
printf "namespace $NAMESPACE.Services;\n\npublic class ${FEATURE_NAME}Service : I${FEATURE_NAME}Service\n{\n\n}" > "$BASE_DIR/Services/${FEATURE_NAME}Service.cs"

# === Feedback for files created ===
echo ""
echo "✅ Files created:"
echo "   ├── Components/Sample.razor"
echo "   ├── Models/${FEATURE_NAME}Model.cs"
echo "   ├── Pages/${FEATURE_NAME}.razor"
echo "   ├── Services/I${FEATURE_NAME}Service.cs"
echo "   └── Services/${FEATURE_NAME}Service.cs"  
echo ""
echo "Don't forget to update your routing in App.razor and register the service in your DI container."

