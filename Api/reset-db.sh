#!/bin/bash

# Paths — adjust if your structure changes
DB_FILE="../SQLiteDatabase/db/LCB_Clone.db"  # Or update if your actual .db file is elsewhere
MIGRATIONS_DIR="../LCB_Clone_Backend/Migrations/"
PROJECT_PATH="../LCB_Clone_Backend/LCB_Clone_Backend.csproj"
STARTUP_PATH="./Api.csproj"

echo "⚠️  Resetting database and migrations..."

# Step 1: Delete the SQLite database
if [ -f "$DB_FILE" ]; then
    echo "🗑️  Deleting database at $DB_FILE"
    rm "$DB_FILE"
else
    echo "✅ No existing database found."
fi

# Step 2: Delete existing migrations
if [ -d "$MIGRATIONS_DIR" ]; then echo "🗑️  Removing existing migrations at $MIGRATIONS_DIR"
    rm -rf "$MIGRATIONS_DIR"
else
    echo "✅ No existing migrations directory found."
fi

# Step 3: Recreate migrations
echo "🛠️  Creating new InitialCreate migration..."
dotnet ef migrations add InitialCreate --project "$PROJECT_PATH" --startup-project "$STARTUP_PATH"

# Step 4: Update database (apply migration)
echo "🔄 Applying migration to database..."
dotnet ef database update --project "$PROJECT_PATH" --startup-project "$STARTUP_PATH"

echo "✅ Done. Fresh database and migrations ready!"
