echo "Publish .NET Project..."
dotnet publish -c Release -o publish

echo "Copying files..."
cp Dockerfile people.json publish/

echo "Creating ZipFile ..."
cd publish
zip -r ../deploy.zip .
cd ..

echo "Ready for the Deploy in EB: deploy.zip"
